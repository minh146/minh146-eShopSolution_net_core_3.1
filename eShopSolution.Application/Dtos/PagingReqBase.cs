using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PagingReqBase
    {
        public int PageIndex { set; get; }
        public int pageSize { set; get; }
    }
}
