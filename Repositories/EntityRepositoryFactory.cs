
namespace Repositories
{
    using System;
    using Data;
    using Domain;
    using NHibernate;

    public class EntityRepositoryFactory : IDisposable
    {
        private ISession session;

        public EntityRepositoryFactory()
        {
            this.session = this.GetSession();
        }

        private ISession GetSession()
        {
            return DbSessionFactory.Instance.OpenSession();
        }

        public void CloseSession()
        {
            if (this.session != null && this.session.IsOpen)
            {
                this.session.Close();
            }
            this.session = null;
        }

        public EntityRepository<T> GetRepository<T>()
            where T : Entity
        {
            if (typeof(T) == typeof(User))
            {
                return new UserRepository(this.session) as EntityRepository<T>;
            }

            if (typeof(T) == typeof(Book))
            {
                return new BookRepository(this.session) as EntityRepository<T>;
            }
            return null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.CloseSession();
        }

        #endregion
    }
}
