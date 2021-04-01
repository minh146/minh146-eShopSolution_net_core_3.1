using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.Catalog.Products.Public
{
   public class ProductImageViewModel
    {
        public int Id { set; get; }
        public string FilePath { set; get; }
        public bool IsDefault { set; get; }
        public long FileSize { set; get; }
        public string ImagePath { set; get; }
    }
}
