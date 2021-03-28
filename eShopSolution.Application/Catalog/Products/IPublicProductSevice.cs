using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductSevice
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingReq req );
    }
}
