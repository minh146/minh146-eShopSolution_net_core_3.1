using eShopSolution.ViewModel.Catalog.Products.Dtos;
using eShopSolution.ViewModel.Catalog.Products.Dtos.Manage;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using EShopSolutionUtilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.ViewModel.Catalog.Products.Manage;
using eShopSolution.ViewModel.Common;
using System.Net.Http.Headers;
using System.IO;
using eShopSolution.ViewModel.Catalog.Products.Public;
using eShopSolution.ViewModel.Catalog.Products;
using EShop.Application.Common;

namespace EShop.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;

        }
        public async Task<int> Create(ProductsCreateRequest req)
        {
            var product = new Product()
            {
                Price = req.Price,
                OriginalPrice = req.OriginalPrice,
                Stock = req.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = req.Name,
                        Description = req.Description,
                        Details = req.Details,
                        SeoDescription = req.SeoDescription,
                        SeoAlias = req.SeoAlias,
                        SeoTitle = req.SeoTitle,
                        LanguageId =req.LanguageId
                    }
                }

            };
            //Save Image
            if (req.ThumbnailImage != null)
            {
                product.productImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated =DateTime.Now,
                        FileSize = req.ThumbnailImage.Length,
                        ImagePath = await SaveFile(req.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }
        public async Task AddViewcount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EshopException($"Cannot find a product:{productId}");
            var images = _context.productImages.Where(i => i.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }


            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }



        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = _context.Products.Find(request.Id);
            var productranlastions = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguegeId);
            if (product == null || productranlastions == null) throw new EshopException($"Cannot find a product with id:{request.Id}");
            productranlastions.Name = request.Name;
            productranlastions.SeoAlias = request.SeoAlias;
            productranlastions.SeoDescription = request.SeoDescription;
            productranlastions.Description = request.Description;
            productranlastions.Details = request.Details;
            //UPdate image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.productImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await SaveFile(request.ThumbnailImage);
                    _context.productImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EshopException($"Cannot find a product with id:{productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EshopException($"Cannot find a product with id:{productId}");
            product.Stock = addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<int> AddViewCount(int prodctId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingReq req)
        {
            //Select join

            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.ID
                        select new { p, pt, pic };
            //filter
            if (!string.IsNullOrEmpty(req.Keyword))
                query = query.Where(x => x.pt.Name.Contains(req.Keyword));
            if (req.CategoryIds.Count > 0)
            {
                query = query.Where(p => req.CategoryIds.Contains(p.pic.CategoryId));

            }
            //Paging

            int totalRow = await query.CountAsync();

            var data = await query.Skip((req.PageIndex - 1) * req.pageSize).Take(req.pageSize)
                .Take(req.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.ID,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();


            // Select And project
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedResult;
        }
        // ham XU LY IMage
        public async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> AddImages(int productId, List<IFormFile> files)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {

                //Save Image
                if (files != null)
                {
                    foreach (var Image in files)
                    {
                        product.productImages = new List<ProductImage>()
                        {
                            new ProductImage()
                            {
                            Caption = "Thumbnail image",
                            DateCreated =DateTime.Now,
                            FileSize = Image.Length,
                            ImagePath = await SaveFile(Image),
                            IsDefault = true,
                            SortOrder = 1
                            }
                         };
                    }

                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveImages(int imageId)
        {
            var image = _context.productImages.SingleOrDefault(x => x.Id == imageId);
            await _storageService.DeleteFileAsync(image.ImagePath);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {


            var thumbnailImage = await _context.productImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == imageId);
            if (thumbnailImage != null)
            {
                thumbnailImage.Caption = caption;
                thumbnailImage.IsDefault = isDefault;
                _context.productImages.Update(thumbnailImage);

            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            try
            {
                List<ProductImageViewModel> lst = new List<ProductImageViewModel>();
                var products =  _context.productImages.Where(i => i.ProductId == productId);
                foreach (var prod in products)
                {
                    lst.Add(new ProductImageViewModel
                    {
                        FileSize = prod.FileSize,
                        ImagePath = prod.ImagePath
                    });
                }
                return lst;
            }
            catch (Exception)
            {

                throw new EshopException($"Cannot find a product with id:{productId}");
            }


        }


    }
}
