using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookDTO : EntityDTO
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int TotalCount { get; set; }
    }
}
