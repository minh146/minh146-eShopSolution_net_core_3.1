using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
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

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        public ManageProductService(EShopDbContext context)
        {
            _context = context;
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

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingReq req)
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
    }
}
