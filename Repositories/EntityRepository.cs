namespace Repositories
{
    using Domain;
    using NHibernate;
    using System.Collections.Generic;


    public class EntityRepository<T>
        where T : Entity
    {
        public ISession Session { get; private set; }

        public EntityRepository(ISession session)
        {
            this.Session = session;
        }

        public IList<T> Load()
        {
            return this.Session.QueryOver<T>().List();
        }
        public T GetByIndex(int index)
        {
            return this.Session.QueryOver<T>()
                .Where(x => x.id == index)
                .SingleOrDefault();
        }

        
        /*
        public IList<T> GetBookByName(string bookName)
        {
        }
        */
    }
}
