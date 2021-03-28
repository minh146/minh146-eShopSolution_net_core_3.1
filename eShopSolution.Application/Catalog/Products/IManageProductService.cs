using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products

{
    public interface IManageProductService
    {
        Task<int> Create(ProductsCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<int> AddViewCount(int prodctId);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task<List<ProductViewModel>> GetAll();
        Task AddViewcount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingReq req);
    }
}
