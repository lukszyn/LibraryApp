using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Services
{
    public interface IDbService
    {
        void EnsureDatabaseMigration();
    }

    public class DbService : IDbService
    {
        private Func<IAppDbContext> _dbContextFactoryMethod;

        public DbService(Func<IAppDbContext> dbContextFactoryMethod)
        {
            _dbContextFactoryMethod = dbContextFactoryMethod;
        }

        public void EnsureDatabaseMigration()
        {
            using (var context = _dbContextFactoryMethod())
            {
                context.Database.Migrate();
            }
        }
    }
}
