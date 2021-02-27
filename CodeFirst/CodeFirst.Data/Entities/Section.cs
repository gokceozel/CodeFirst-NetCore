using System.Collections.Generic;

namespace CodeFirst.Data.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubSection> SubSections { get; set; }

    }
}
