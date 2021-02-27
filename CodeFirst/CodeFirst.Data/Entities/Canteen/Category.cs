using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Data.Entities.Canteen
{
    public class Category
    {
        public int Code { get; set; }
        public int ProductCode { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
