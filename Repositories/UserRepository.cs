namespace Repositories
{
    using Domain;
    using NHibernate;

    class UserRepository:EntityRepository<User>
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }
    }
}
