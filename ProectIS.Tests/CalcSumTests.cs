using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS.Tests
{
    public class CalcSumTests
    {
        [Fact]
        public void Funct_NoPositive_ReturnZero()
        {
            var list = new List<int>() { -1, -1, -1 };
            int sum = Factory.CalcSum(list);
            Assert.Equal(0, sum);
        }
        [Fact]
        public void Funct_NoNegative_ReturnZero()
        {
            var list = new List<int>() { 1, 1, 1 };
            int sum = Factory.CalcSum(list);
            Assert.Equal(0, sum);
        }
        [Fact]
        public void Funct_AllZero_ReturnZero()
        {
            var list = new List<int>() { 0, 0, 0 };
            int sum = Factory.CalcSum(list);
            Assert.Equal(0, sum);
        }
        [Fact]
        public void Funct_OneNumber_ReturnZero()
        {
            var list = new List<int>() { 1 };
            int sum = Factory.CalcSum(list);
            Assert.Equal(0, sum);
        }
        [Fact]
        public void Funct_FirstNegativeSecondPositive_CorrectSum()
        {
            var list = new List<int>() { -1, 1, 2 };
            int sum = Factory.CalcSum(list);
            Assert.Equal(1, sum);
        }
        [Fact]
        public void Funct_EmptyList_ReturnZero()
        {
            var list = new List<int>() { };
            int sum = Factory.CalcSum(list);
            Assert.Equal(0, sum);
        }
    }
}
