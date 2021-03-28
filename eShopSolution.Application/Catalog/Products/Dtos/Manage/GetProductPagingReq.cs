using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingReq : PagingReqBase
    {
        public string Keyword { set; get; }
        public List<int> CategoryIds { set; get; }
    }
}
