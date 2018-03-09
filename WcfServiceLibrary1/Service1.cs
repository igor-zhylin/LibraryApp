namespace WcfServiceLibrary1
{
    using Data;
    using Domain;
    using DTO;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Configuration;


    public class Service1 : IService1
    {
        public Service1()
        {
            if (!DbSessionFactory.Instance.IsOpen)
            {
                DbSessionFactory.Instance.CreateFactory(ConfigurationManager.ConnectionStrings["libraryMySQL"].ConnectionString);
            }
        }

        public BookDTO GetBookById(int index)
        {
            BookDTO book = new BookDTO();
            
            using (EntityRepositoryFactory factory = new EntityRepositoryFactory())
            {
                var cache = factory.GetRepository<Book>().GetByIndex(index);
                book.id = cache.id;
                book.Name = cache.Name;
                book.Author = cache.Author;
                book.ReleaseDate = cache.Releasedate;
                book.TotalCount = cache.Totalcount;
            }

            return book;
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
                BookDTO dto = new BookDTO()
                {
                    id = book.id,
                    Author = book.Author,
                    Name = book.Name,
                    ReleaseDate = book.Releasedate,
                    TotalCount = book.Totalcount
                };

                booksDTO.Add(dto);
            }

            return booksDTO;
        }

        public UserDTO GetByUserName(string name)
        {
            User user = null;
            UserDTO userDTO;
            try
            {
                using (EntityRepositoryFactory factory = new EntityRepositoryFactory())
                {
                    user = factory.GetRepository<User>().GetByName(name);
                }
            }
            catch
            {

            }
            userDTO = new UserDTO()
            {
                id = user.id,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Limit = user.Limit
            };

            return userDTO;
        }

        public List<UserDTO> GetUsers()
        {
            IList<User> users = null;
            List<UserDTO> usersDTO = new List<UserDTO>();

            try
            {
                using (EntityRepositoryFactory factory = new EntityRepositoryFactory())
                {
                    users = factory.GetRepository<User>().Load();
                }
            }
            catch
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
                    */
                };

                usersDTO.Add(dto);
            }
            ///here shit happens 
            return usersDTO;
        }
    }
}
