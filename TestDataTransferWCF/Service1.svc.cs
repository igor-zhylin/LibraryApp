using Data;
using Domain;
using DTO;
using Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestDataTransferWCF
{

    public class Service1 : IService1
    {
        public Service1()
        {
            if (!DbSessionFactory.Instance.IsOpen)
            {
                DbSessionFactory.Instance.CreateFactory(ConfigurationManager.ConnectionStrings["libraryMySQL"].ConnectionString);
            }
        }

        public List<BookDTO> GetBooks()
        {
            IList<Book> books = null;
            List<BookDTO> booksDTO = new List<BookDTO>();

            using (EntityRepositoryFactory factory = new EntityRepositoryFactory())
            {
                books = factory.GetRepository<Book>().Load();
            }
            foreach (Book book in books)
            {
                BookDTO dto = new BookDTO() {
                    id = book.id.Value,
                    Author = book.Author,
                    Name = book.Name,
                    ReleaseDate = book.Releasedate,
                    TotalCount = book.Totalcount
                };
                
                booksDTO.Add(dto);
            }
            return booksDTO;
        }

        public List<UserDTO> GetUsers()
        {
            IList<User> users = null;
            List<UserDTO> usersDTO = new List<UserDTO>();
            using (EntityRepositoryFactory factory = new EntityRepositoryFactory())
            {
                users = factory.GetRepository<User>().Load();
            }
            foreach (User user in users)
            {
                UserDTO dto = new UserDTO()
                {
                    id = user.id.Value,
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Limit = user.Limit
                };

                usersDTO.Add(dto);
            }
            return usersDTO;
        }
    }
}
