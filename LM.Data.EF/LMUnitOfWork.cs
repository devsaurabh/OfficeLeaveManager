#region using

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LM.Data.Model;
using LM.Framework.Data.Entity;

#endregion

namespace LM.Data.EF
{
    public class LmUnitOfWork : UnitOfWork
    {
        private readonly bool _autoDetectChanges;
        
        public LmUnitOfWork(DbContext dbContext) : base(dbContext)
        {
            _autoDetectChanges = true; // autoDetectChanges;
            dbContext.Configuration.AutoDetectChangesEnabled = _autoDetectChanges;
        }

        public override int SaveChanges()
        {
            //UpdateNotModifiedStateEntries();
            DbContext.Configuration.AutoDetectChangesEnabled = true;

            UpdateChangelog();
            var validationErrors = DbContext.GetValidationErrors().ToList();
            var result = -1;
            if (validationErrors.Count == 0)
            {
                result = base.SaveChanges();
            }
            else
            {
                //ExceptionLogger.GetLogger().LogError("DB Context Validation Error");
            }

            DbContext.Configuration.AutoDetectChangesEnabled = _autoDetectChanges;

            return result;
        }

        private void UpdateChangelog()
        {
            var utcTimeStamp = DateTime.UtcNow;
            foreach (var entry in DbContext.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = utcTimeStamp;
                    entry.Entity.ModifiedOn = utcTimeStamp;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(t => t.CreatedOn).IsModified = false;
                    entry.Entity.ModifiedOn = utcTimeStamp;
                }
            }
        }
    }
}