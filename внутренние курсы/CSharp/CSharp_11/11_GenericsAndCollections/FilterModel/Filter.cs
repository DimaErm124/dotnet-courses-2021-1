using System.Collections.Generic;

namespace FilterModel
{
    public abstract class Filter<T>
    {
        public abstract IEnumerable<T> Apply(IEnumerable<T> collection);
    }
}