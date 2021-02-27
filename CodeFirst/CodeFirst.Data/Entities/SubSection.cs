using System.Collections.Generic;

namespace CodeFirst.Data.Entities
{  
    public class SubSection
    {
        public int SubSectionId { get; set; }
        public string Name { get; set; }
        public int SectionCode { get; set; }
        public Section Section { get; set; }
    }
}
