using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using JTools.Extensions;
using Xunit;

namespace JTools.Tests.Extensions;

public class EnumerableExtensionTests
{
    [Fact]
    public void EmptyIfNull_NullIEnumerable_ValueType_ReturnsEmpty()
    {
        IEnumerable<int>? enumerable = null;
        var result = enumerable.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void EmptyIfNull_EmptyIEnumerable_ValueType_ReturnsEmpty()
    {
        IEnumerable<int> enumerable = Enumerable.Empty<int>();
        var result = enumerable.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void EmptyIfNull_NotEmptyIEnumerable_ValueType_ReturnsOriginal()
    {
        IEnumerable<int> enumerable = new List<int> { 5, 6, 7 };
        var result = enumerable.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(enumerable.Count());
    }
    
    [Fact]
    public void EmptyIfNull_NullList_ValueType_ReturnsEmpty()
    {
        List<int>? list = null;
        var result = list.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void EmptyIfNull_EmptyList_ValueType_ReturnsEmpty()
    {
        var list = new List<int>();
        var result = list.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void EmptyIfNull_NotEmptyList_ValueType_ReturnsOriginal()
    {
        var list = new List<int> { 5, 6, 7 };
        var result = list.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(list.Count);
    }
    
    [Fact]
    public void EmptyIfNull_NullArray_ValueType_ReturnsEmpty()
    {
        int[]? array = null;
        var result = array.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void EmptyIfNull_EmptyArray_ValueType_ReturnsEmpty()
    {
        var array = Array.Empty<int>();
        var result = array.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void EmptyIfNull_NotEmptyArray_ValueType_ReturnsOriginal()
    {
        var array = new[] { 5, 6, 7 };
        var result = array.EmptyIfNull();

        result.Should().NotBeNull();
        result.Count().Should().Be(array.Length);
    }
}