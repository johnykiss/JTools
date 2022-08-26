namespace JTools.Range;

public class Range<T>
{
    public T LowerBound { get; }
    public T UpperBound { get; }
    public bool InclusiveLowerBound { get; }
    public bool InclusiveUpperBound { get; }
    private IComparer<T> Comparer { get; }

    public Range(T lowerBound, T upperBound,
        bool inclusiveLowerBound = true,
        bool inclusiveUpperBound = true,
        IComparer<T>? comparer = null)
    {
        LowerBound = lowerBound;
        UpperBound = upperBound;
        InclusiveLowerBound = inclusiveLowerBound;
        InclusiveUpperBound = inclusiveUpperBound;
        Comparer = comparer ?? Comparer<T>.Default;

        if (Comparer.Compare(LowerBound, UpperBound) > 0)
            throw new ArgumentException();
    }

    public bool Contains(T item)
    {
        var lowerCompare = Comparer.Compare(LowerBound, item);
        if (lowerCompare > (InclusiveLowerBound ? 0 : -1))
            return false;
        
        var upperCompare = Comparer.Compare(UpperBound, item);
        if (upperCompare < (InclusiveUpperBound ? 0 : 1))
            return false;
        
        return true;
    }

    public bool Contains(Range<T> other)
    {
        if (LowerBoundsAreEqualButInclusionsAreNot(other))
            return false;
        
        if (UpperBoundsAreEqualButInclusionsAreNot(other))
            return false;
        
        return Contains(other.LowerBound) && Contains(other.UpperBound);
    }

    private bool LowerBoundsAreEqualButInclusionsAreNot(Range<T> other)
    {
        return Comparer.Compare(LowerBound, other.LowerBound) == 0 && InclusiveLowerBound != other.InclusiveLowerBound;
    }
    
    private bool UpperBoundsAreEqualButInclusionsAreNot(Range<T> other)
    {
        return Comparer.Compare(UpperBound, other.UpperBound) == 0 && InclusiveUpperBound != other.InclusiveUpperBound;
    }
}