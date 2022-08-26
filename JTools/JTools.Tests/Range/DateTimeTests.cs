using System;
using FluentAssertions;
using JTools.Range;
using Xunit;

namespace JTools.Tests.Range;

public class DateTimeTests
{
    [Fact]
    public void Initialization()
    {
        var lowerBound = DateTime.MinValue;
        var upperBound = DateTime.MaxValue;
        var range = new Range<DateTime>(lowerBound: lowerBound, upperBound: upperBound);
        
        range.Should().NotBeNull();
        range.LowerBound.Should().Be(lowerBound);
        range.UpperBound.Should().Be(upperBound);
        range.InclusiveLowerBound.Should().Be(true);
        range.InclusiveUpperBound.Should().Be(true);
    }
    
    [Fact]
    public void InitializationWithDefaultParametersGiven()
    {
        var lowerBound = DateTime.MinValue;
        var upperBound = DateTime.MaxValue;
        var range = new Range<DateTime>(
            lowerBound: lowerBound, upperBound: upperBound,
            inclusiveLowerBound: true, inclusiveUpperBound: false);
        
        range.Should().NotBeNull();
        range.LowerBound.Should().Be(lowerBound);
        range.UpperBound.Should().Be(upperBound);
        range.InclusiveLowerBound.Should().Be(true);
        range.InclusiveUpperBound.Should().Be(false);
    }
}