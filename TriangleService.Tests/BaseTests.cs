using System;
using Xunit;
using TriangleService.Models;

namespace TriangleService.Tests
{
    public class BaseTests
    {
        [Fact]
        public void TestScalene()
        {
            Triangle t = new Triangle() {Segment1= 9.1F, Segment2 = 7.3F, Segment3 = 4.4F};
            Assert.True(t.Type == TriangleTypes.SCALENE);
        }

        [Fact]
        public void TestIsosceles()
        {
            Triangle t = new Triangle() {Segment1= 3, Segment2 = 4, Segment3 = 4};
            Assert.True(t.Type == TriangleTypes.ISOSCELES);
        }

        [Fact]
        public void TestEquilateral()
        {
            Triangle t = new Triangle() {Segment1= 1.5F, Segment2 = 1.5F, Segment3 = 1.5F};
            Assert.True(t.Type == TriangleTypes.EQUILATERAL);
        }

        [Fact]
        public void TestNotATriangle()
        {
            Triangle t = new Triangle() {Segment1= 11, Segment2 = 4, Segment3 = 6};
            Assert.True(t.Type == TriangleTypes.NOT_A_TRIANGLE);
            Assert.False(t.Type == TriangleTypes.EQUILATERAL || t.Type == TriangleTypes.ISOSCELES || t.Type == TriangleTypes.SCALENE);
        }
    }
}