using Data;
using Domain;
using DTO;
using Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DbSessionFactory.Instance.CreateFactory(ConfigurationManager.ConnectionStrings["libraryMySQL"].ConnectionString);

            IList<User> users = null;
            List<UserDTO> usersDTO = new List<UserDTO>();

            try
            {
                using (EntityRepositoryFactory factory = new EntityRepositoryFactory())
                {
                    users = factory.GetRepository<User>().Load();
                }
            }
            catch (Exception e)
            {

            }
            foreach (User user in users)
            {
                UserDTO dto = new UserDTO()
                {
                    id = user.id.Value,
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Limit = user.Limit,
                    /*
                    bookDTO = new BookDTO
                    {
                        id = user.book.id.Value,
                        Author = user.book.Author,
                        Name = user.book.Name,
                        ReleaseDate = user.book.Releasedate,
                        TotalCount = user.book.Totalcount
                    }
                    
                };
                 usersDTO.Add(dto);
            }
            for (int i = 0; i < usersDTO.Capacity - 1; i++)
            {
                Console.WriteLine($"{usersDTO[i].id}");
            }*/
            dynamic d;

            d = new Car();
            Console.WriteLine(d);
            d = 5;
            Console.WriteLine(d);
            Console.ReadKey();

        }
    }
}
