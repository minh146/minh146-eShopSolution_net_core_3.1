

using eShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.Catalog.Products.Dtos.Public
{
   public class GetPublicProductPagingReq : PagingReqBase
    {
        public int? CategoryId { set; get; }
    }
}
