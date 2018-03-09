namespace Repositories
{
    using Domain;
    using NHibernate;

    public class BookRepository: EntityRepository<Book>
    {
        public BookRepository(ISession session)
            : base(session)
        {
        }
    }
}
