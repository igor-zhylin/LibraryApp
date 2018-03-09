namespace Data
{
    using System;
    using System.Data;
    using NHibernate;

    /// <summary>
    /// Wrapper for transaction object
    /// </summary>
    public class DbTransaction : IDisposable
    {
        /// <summary>
        /// Stores nhibernate transaction object.
        /// </summary>
        private ITransaction transaction;

        public DbTransaction(ITransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction");
            }

            this.transaction = transaction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBTransaction"/> class.
        /// </summary>
        public DbTransaction(ISession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.transaction = session.BeginTransaction();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBTransaction"/> class.
        /// </summary>
        /// <param name="isolationLevel">The transaction isolation level.</param>
        public DbTransaction(ISession session, IsolationLevel isolationLevel)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.transaction = session.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Commits this transaction.
        /// </summary>
        public void Commit()
        {
            if (this.transaction == null)
            {
                throw new Exception("Transaction is already finished (commited or rollbacked).");
            }

            this.transaction.Commit();
            this.transaction = null;
        }

        /// <summary>
        /// Rollbacks this transaction.
        /// </summary>
        public void Rollback()
        {
            if (this.transaction == null)
            {
                throw new Exception("Transaction is already finished (commited or rollbacked).");
            }

            this.transaction.Rollback();
            this.transaction = null;
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.transaction != null)
            {
                //this.transaction.Rollback();
                this.transaction.Dispose();
                this.transaction = null;
            }
        }

        #endregion
    }
}
