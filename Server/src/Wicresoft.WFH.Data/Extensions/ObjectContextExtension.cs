namespace Wicresoft.WFH.Data
{
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;

    public static class ObjectContextExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// If ObjectContext.SaveChanges() fails, the same ObjectContext still contains the changes, if it is used
        ///     later to save other changes, these failed changes will be saved to database again and cause problem (either
        ///     exceptions are thrown again or incorrect data are saved).
        ///     This workaround will make sure the changes are discarded
        ///     TODO: this method needs more testing.
        /// </summary>
        /// <param name="dbContext">
        /// </param>
        public static void DiscardChanges(this ObjectContext dbContext)
        {
            // delete added objects that did not get saved
            foreach (var entry in dbContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                if (entry.Entity != null)
                {
                    dbContext.DeleteObject(entry.Entity);
                }
            }

            // Refetch modified objects from database
            var entities =
                dbContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Deleted)
                    .Where(entry => entry.Entity != null)
                    .ToList();
            if (entities.Count > 0)
            {
                dbContext.Refresh(RefreshMode.StoreWins, entities);
            }

            dbContext.AcceptAllChanges();
        }

        #endregion
    }
}
