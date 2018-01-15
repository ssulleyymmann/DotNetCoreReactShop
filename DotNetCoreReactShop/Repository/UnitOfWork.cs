using System;
using DotNetCoreReactShop.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreReactShop.Repository
{
    public class UnitOfWork<T> : IDisposable where T : class
    {
        private DefaultDbContext context;

        private Repository<T> repository;

        private bool ifDispose;

        public UnitOfWork(DefaultDbContext contextPass, bool ifDisposeContext=true)
        {
            context = contextPass;
            ifDispose = ifDisposeContext;
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)  // DbEntityValidationException is not supported yet
            {
                throw;
            }
            
        }

        public Repository<T> Repository
        {
            get
            {
                if (repository == null)
                {
                    return repository= new Repository<T>(context);
                }
                return repository;
            }
        }

        public void Dispose()
        {
            if (ifDispose)
            {
                context?.Dispose();
            }
            
        }
    }

    public class UnitOfWork<T,T1> : UnitOfWork<T>, IDisposable 
        where T1: class 
        where T : class
    {
        private DefaultDbContext context;

        private Repository<T,T1> repositoryMany;

        private bool ifDispost;

        public UnitOfWork(DefaultDbContext contextPass, bool ifDisposeContext = true) : base(contextPass,ifDisposeContext)
        {
            context = contextPass;
            ifDispost = ifDisposeContext;
        }

        public Repository<T,T1> RepositoryMany
        {
            get
            {
                if (repositoryMany == null)
                {
                    return repositoryMany = new Repository<T,T1>(context);
                }
                return repositoryMany;
            }
        }

    }
}
