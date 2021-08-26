namespace Wicresoft.WFH.Data
{
    using System.Data.Entity;

    public static class DbSetExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add object.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void AddObject<T>(this IDbSet<T> entities, T entity) where T : class
        {
            entities.Add(entity);
        }

        /// <summary>
        /// The delete object.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void DeleteObject<T>(this IDbSet<T> entities, T entity) where T : class
        {
            entities.Remove(entity);
        }

        #endregion
    }
}
