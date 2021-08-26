namespace Wicresoft.WFH.Repository
{
    using  System.Collections.Generic;

    public class PagedData<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
