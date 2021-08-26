namespace Wicresoft.WFH.Data
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    public static class MainDbEntitiesExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="queryText">
        /// The query text.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="ObjectQuery"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static ObjectQuery<T> CreateQuery<T>(
            this DbContext context,
            string queryText,
            params KeyValuePair<string, object>[] parameters)
        {
            if (context != null)
            {
                return ((IObjectContextAdapter)context).ObjectContext.CreateQuery<T>(
                    queryText,
                    parameters.Select(p => new ObjectParameter(p.Key, p.Value)).ToArray());
            }

            throw new NotImplementedException();
        }

        public static ObjectQuery<T> CreateQuery<T>(
            this ObjectContext context,
            string queryText,
            params KeyValuePair<string, object>[] parameters)
        {
            if (context != null)
            {
                return context.CreateQuery<T>(
                    queryText,
                    parameters.Select(p => new ObjectParameter(p.Key, p.Value)).ToArray());
            }

            throw new NotImplementedException();
        }

        #endregion
    }
}
