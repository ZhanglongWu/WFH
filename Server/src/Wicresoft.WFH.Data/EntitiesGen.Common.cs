namespace Wicresoft.WFH.Data
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// The fixup collection.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class FixupCollection<T> : ObservableCollection<T>
    {
        #region Methods

        /// <summary>
        ///     The clear items.
        /// </summary>
        protected override void ClearItems()
        {
            new List<T>(this).ForEach(t => this.Remove(t));
        }

        /// <summary>
        /// The insert item.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        protected override void InsertItem(int index, T item)
        {
            if (!this.Contains(item))
            {
                base.InsertItem(index, item);
            }
        }

        #endregion
    }

    /// <summary>
    /// The fake db set.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class FakeDbSet<T> : IDbSet<T>
        where T : class
    {
        #region Fields

        /// <summary>
        ///     The _data.
        /// </summary>
        private readonly ObservableCollection<T> _data;

        /// <summary>
        ///     The _query.
        /// </summary>
        private readonly IQueryable _query;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FakeDbSet{T}" /> class.
        /// </summary>
        public FakeDbSet()
        {
            this._data = new ObservableCollection<T>();
            this._query = this._data.AsQueryable();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the local.
        /// </summary>
        public ObservableCollection<T> Local
        {
            get
            {
                return this._data;
            }
        }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        ///     Gets the element type.
        /// </summary>
        Type IQueryable.ElementType
        {
            get
            {
                return this._query.ElementType;
            }
        }

        /// <summary>
        ///     Gets the expression.
        /// </summary>
        Expression IQueryable.Expression
        {
            get
            {
                return this._query.Expression;
            }
        }

        /// <summary>
        ///     Gets the provider.
        /// </summary>
        IQueryProvider IQueryable.Provider
        {
            get
            {
                return this._query.Provider;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Add(T item)
        {
            this._data.Add(item);
            return item;
        }

        /// <summary>
        /// The attach.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Attach(T item)
        {
            this._data.Add(item);
            return item;
        }

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        ///     The create.
        /// </summary>
        /// <typeparam name="TDerivedEntity">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="TDerivedEntity" />.
        /// </returns>
        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        /// <summary>
        /// The detach.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Detach(T item)
        {
            this._data.Remove(item);
            return item;
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="keyValues">
        /// The key values.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Remove(T item)
        {
            this._data.Remove(item);
            return item;
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        ///     The get enumerator.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerator" />.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._data.GetEnumerator();
        }

        /// <summary>
        ///     The get enumerator.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerator" />.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this._data.GetEnumerator();
        }

        #endregion
    }
}