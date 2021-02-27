using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Data.Entities.Canteen
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}
