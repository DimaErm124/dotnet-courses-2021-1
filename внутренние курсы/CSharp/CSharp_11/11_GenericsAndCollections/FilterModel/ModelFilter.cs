using System;

namespace FilterModel
{
    [Serializable]
    public class ModelFilter<T> : IComparable<ModelFilter<T>>, IEquatable<ModelFilter<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        public T EqualFilter { get; set; }

        public T MinBorderFilter { get; set; }

        public T MaxBorderFilter { get; set; }

        public bool UseEqual { get; set; }

        public ModelFilter()
        {
        }

        public ModelFilter(T equalFilter, T minBorderFilter, T maxBorderFilter, bool useEqual)
        {
            EqualFilter = equalFilter;
            MinBorderFilter = minBorderFilter;
            MaxBorderFilter = maxBorderFilter;
            UseEqual = useEqual;
        }

        public int CompareTo(ModelFilter<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();

            if (UseEqual.CompareTo(other.UseEqual) == 0)
                if (EqualFilter.CompareTo(other.EqualFilter) == 0)
                    if (MinBorderFilter.CompareTo(other.MinBorderFilter) == 0)
                        if (MaxBorderFilter.CompareTo(other.MaxBorderFilter) == 0)
                            return 0;
                        else
                            return MaxBorderFilter.CompareTo(other.MaxBorderFilter);
                    else
                        return MinBorderFilter.CompareTo(other.MinBorderFilter);
                else
                    return EqualFilter.CompareTo(other.EqualFilter);
            else
                return UseEqual.CompareTo(other.UseEqual);
        }

        public bool Equals(ModelFilter<T> other)
        {
            if (other == null)
                return false;

            if (CompareTo(other) != 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModelFilter<T>);
        }

        public override string ToString()
        {
            string returningString = "{";
            if (UseEqual)
                returningString += "EQUAL " + EqualFilter.ToString();
            else
                returningString += "BETWEEN " + MinBorderFilter.ToString() + " AND " + MaxBorderFilter.ToString();

            return returningString + "}";
        }
    }
}