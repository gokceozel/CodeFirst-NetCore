using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Data.Entities.Canteen
{
    public class SubCategory
    {
        public int Code { get; set; }
        [ForeignKey("ProductCode")]
        public int  ProductCode { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
    }
}
