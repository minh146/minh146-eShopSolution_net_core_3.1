using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.Common
{
    public class PagingReqBase
    {
        public int PageIndex { set; get; }
        public int pageSize { set; get; }
    }
}
