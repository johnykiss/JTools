using System;
using FluentAssertions;
using JTools.Range;
using Xunit;

namespace JTools.Tests.Range;

public class GenericTests
{
    [Theory]
    [InlineData(0, 10)]
    [InlineData(-10, 0)]
    [InlineData(-10, 10)]
    public void Initialization(int lowerBound, int upperBound)
    {
        var range = new Range<int>(lowerBound, upperBound);
        
        range.LowerBound.Should().Be(lowerBound);
        range.UpperBound.Should().Be(upperBound);
        range.InclusiveLowerBound.Should().Be(true);
        range.InclusiveUpperBound.Should().Be(true);
    }
    
    [Theory]
    [InlineData(0, 10, true, false)]
    [InlineData(-10, 0, false, true)]
    [InlineData(-10, 10, false, false)]
    public void InitializationWithDefaultParametersGiven(int lowerBound, int upperBound, bool inclusiveLowerBound, bool inclusiveUpperBound)
    {
       var range = new Range<int>(
            lowerBound: lowerBound, upperBound: upperBound,
            inclusiveLowerBound: inclusiveLowerBound, inclusiveUpperBound: inclusiveUpperBound);
        
        range.LowerBound.Should().Be(lowerBound);
        range.UpperBound.Should().Be(upperBound);
        range.InclusiveLowerBound.Should().Be(inclusiveLowerBound);
        range.InclusiveUpperBound.Should().Be(inclusiveUpperBound);
    }
    
    [Theory]
    [InlineData(0, -10)]
    [InlineData(10, 0)]
    [InlineData(10, -10)]
    public void Initialization_ThrowsException(int lowerBound, int upperBound)
    {
        Assert.Throws<ArgumentException>(() => new Range<int>(lowerBound, upperBound));
    }

    [Theory]
    [InlineData(-10, 10, 5, true)]
    [InlineData(-10, 10, 0, true)]
    [InlineData(-10, 10, -5, true)]
    [InlineData(-10, 10, 10, true)]
    [InlineData(-10, 10, -10, true)]
    [InlineData(-10, 10, 11, false)]
    [InlineData(-10, 10, -11, false)]
    public void Contains_Item_InclusiveRange(int lowerBound, int upperBound, int element, bool expected)
    {
        var range = new Range<int>(lowerBound, upperBound);

        var contains = range.Contains(element);
        contains.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(-10, 10, 5, true)]
    [InlineData(-10, 10, 0, true)]
    [InlineData(-10, 10, -5, true)]
    [InlineData(-10, 10, 10, false)]
    [InlineData(-10, 10, -10, false)]
    [InlineData(-10, 10, 11, false)]
    [InlineData(-10, 10, -11, false)]
    public void Contains_Item_ExclusiveRange(int lowerBound, int upperBound, int element, bool expected)
    {
        var range = new Range<int>(lowerBound, upperBound, false, false);

        var contains = range.Contains(element);
        contains.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(-10, 10, 0, 5, true)]
    [InlineData(-10, 10, -10, 10, true)]
    [InlineData(-10, 10, -11, 0, false)]
    [InlineData(-10, 10, 0, 11, false)]
    public void Contains_Range_BothRangeIsInclusive(
        int lowerBound, int upperBound,
        int lowerBound2, int upperBound2,
        bool expected)
    {
        var range = new Range<int>(lowerBound, upperBound);
        var range2 = new Range<int>(lowerBound2, upperBound2);

        var contains = range.Contains(range2);
        contains.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(-10, 10, 0, 5, true)]
    [InlineData(-10, 10, -9, 9, true)]
    [InlineData(-10, 10, -10, 0, false)]
    [InlineData(-10, 10, 0, 10, false)]
    [InlineData(-10, 10, -11, 0, false)]
    [InlineData(-10, 10, 0, 11, false)]
    public void Contains_Range_OneRangeIsInclusive_OtherIsExclusive(
        int lowerBound, int upperBound,
        int lowerBound2, int upperBound2,
        bool expected)
    {
        var range = new Range<int>(lowerBound, upperBound);
        var range2 = new Range<int>(lowerBound2, upperBound2, false, false);

        var contains = range.Contains(range2);
        contains.Should().Be(expected);
    }
}