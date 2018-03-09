namespace Data
{
    using System;
    using System.IO;
    using NHibernate;
    using NHibernate.Cfg;
    using FluentNHibernate.Automapping;
    using Domain;
    using Data.Conventions;

    /// <summary>
    /// Base class for session factory
    /// </summary>
    public class DbSessionFactory : IDisposable
    {
        #region Fields

        /// <summary>
        /// NHibernate session factory object        
        /// </summary>
        private ISessionFactory factory;

        private string connectionString;

        /// <summary>
        /// Object for synchronisation
        /// </summary>
        private object syncObject = new object();

        private static DbSessionFactory instance;

        #endregion

        #region Constructors

        static DbSessionFactory()
        {
            instance = new DbSessionFactory();
        }

        #endregion

        #region Properties

        public static DbSessionFactory Instance
        {
            get { return instance; }
        }

        private string ConnectionString
        {
            get { return this.connectionString; }
        }

        public bool IsOpen
        {
            get { return this.factory != null; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a factory instance using the connection string specified
        /// </summary>
        /// <param name="connectionString">A path to the configuration file</param>
        /// <returns>True on success, false otherwise</returns>		
        public bool CreateFactory(string connectionString)
        {
            lock (syncObject)
            {
                if (factory != null)
                {
                    throw new Exception("Factory has already created. Before creating new one close current.");
                }

                //try to build Session factory twice


                Configuration configuration = BuildConfiguration(
                    connectionString);

                // Build NHibernate session factory
                this.factory = configuration.BuildSessionFactory();

                this.connectionString = connectionString;

                // Whether session factory created
                return this.factory != null;
            }
        }

        private static Configuration BuildConfiguration(
            string connectionString)
        {

            Configuration configuration = new Configuration();


            AutoPersistenceModel model = AutoMap.AssemblyOf<Entity>();
            model.IgnoreBase<Entity>();
            model.Conventions.Add<TableNameConvention>();
            model.Conventions.Add<IdConvention>();
            model.Conventions.Add<ReferenceConvention>();

#if DEBUG
            try
            {
                // Writes into specific folder
                string folder = Path.Combine(@"c:\MyProjectMapping", "Mapping");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                model.WriteMappingsTo(folder);
            }
            catch { }
#endif
            model.Configure(configuration);

            if (!string.IsNullOrEmpty(connectionString))
            {
                configuration.SetProperty("connection.connection_string", connectionString);
            }

            return configuration;
        }

        /// <summary>
        /// Closes the NHibernate session factory
        /// </summary>
        private void Close()
        {
            lock (syncObject)
            {
                if (this.factory != null)
                {
                    this.factory.Close();
                    this.factory = null;
                    this.connectionString = null;
                }
            }
        }

        /// <summary>
        /// Opens the new session.
        /// </summary>
        /// <returns>just created session object</returns>
        public ISession OpenSession()
        {
            lock (syncObject)
            {
                return this.factory.OpenSession();
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Close();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Destructor

        ~DbSessionFactory()
        {
            this.Dispose();
        }

        #endregion
    }
}