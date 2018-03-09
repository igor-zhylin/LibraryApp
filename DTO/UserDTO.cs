using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO : EntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Limit { get; set; }

        public BookDTO bookDTO { get; set; }
        //public BookDTO idBook { get; set; }
        public string this[int index]
        {
            get
            {
                return id + FirstName + LastName + Limit;
            }
        }
    }
}
