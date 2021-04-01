using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Catalog.Products.Dtos.Public;
using eShopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Application.Catalog.Products
{
    public interface IPublicProductSevice
    {
       
         Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingReq req);
        Task<List<ProductViewModel>> GetAll();
    }

}