using System;
using System.Collections.Generic;
using Xunit;
using ProectIS;

namespace ProectIS.Tests
{
    public class SeaAppTests
    {
        [Fact]
        public void Sea_Constructor_SetsProperties()
        {
            var sea = new Sea("Черное", 2210.5, 18.2);
            Assert.Equal("Черное", sea.Name);
            Assert.Equal(2210.5, sea.Depth);
            Assert.Equal(18.2, sea.Salinity);
        }
        [Fact]
        public void Sea_Print_ReturnsCorrectFormat()
        {
            var sea = new Sea("Черное", 2210.5, 18.0);
            var result = sea.ToString();
            Assert.Contains("название: Черное", result);
            Assert.Contains("глубина: 2210,5", result.Replace('.', ','));
        }

        [Fact]
        public void MarginalSea_Print_ReturnsCorrectFormat()
        {
            var sea = new MarginalSea("Баренцево", 600, 34.0, "Северный Ледовитый");
            var result = sea.ToString();
            Assert.Contains("название океана: Северный Ледовитый", result);
        }

        [Fact]
        public void InlandSea_Print_ReturnsCorrectFormat()
        {
            var sea = new InlandSea("Средиземное", 5121, 38.0, true);
            var result = sea.ToString();
            Assert.Contains("обладает высокой испаряемостью: True", result);
        }

        [Fact]
        public void InterIslandSea_Print_ReturnsCorrectFormat()
        {
            var sea = new InterIslandSea("Яванское", 111, 32.0, 5);
            var result = sea.ToString();
            Assert.Contains("количество окружающих островов: 5", result);
        }

        [Fact]
        public void Splitting_WithMultipleSpaces_ReturnsCleanList()
        {
            var factory = new Factory();
            var result = factory.Splitting("море   Черное  2210   18");
            Assert.Equal(new List<string> { "море", "Черное", "2210", "18" }, result);
        }

        [Fact]
        public void CreateSea_ValidMarginalSea_ReturnsMarginalSeaObject()
        {
            var factory = new Factory();
            var props = new List<string> { "окраинное", "Баренцево", "600", "34.0", "Северный_Ледовитый" };
            var sea = factory.CreateSea(props);
            Assert.IsType<MarginalSea>(sea);
            Assert.Equal("Баренцево", sea.Name);
        }

        [Fact]
        public void CreateSea_ValidInlandSea_ReturnsInlandSeaObject()
        {
            var factory = new Factory();
            var props = new List<string> { "внутреннее", "Средиземное", "5121", "38.0", "true" };
            var sea = factory.CreateSea(props);
            Assert.IsType<InlandSea>(sea);
            Assert.Equal("Средиземное", sea.Name);
        }

        [Fact]
        public void CreateSea_ValidInterIslandSea_ReturnsInterIslandSeaObject()
        {
            var factory = new Factory();
            var props = new List<string> { "межостровное", "Яванское", "111", "32.0", "5" };
            var sea = factory.CreateSea(props);
            Assert.IsType<InterIslandSea>(sea);
            Assert.Equal(5, ((InterIslandSea)sea).SurroundingIslandsCount);
        }

        [Fact]
        public void CreateSea_ValidBaseSea_ReturnsSeaObject()
        {
            var factory = new Factory();
            var props = new List<string> { "море", "Черное", "2210", "18.0" };
            var sea = factory.CreateSea(props);
            Assert.IsType<Sea>(sea);
            Assert.Equal(2210, sea.Depth);
        }

        [Fact]
        public void CreateSea_UnknownType_ReturnsNullAndLogsInfo()
        {
            var factory = new Factory();
            var props = new List<string> { "озеро", "Байкал", "1642", "0" };
            var sea = factory.CreateSea(props);
            Assert.Null(sea);
        }

        [Fact]
        public void CreateSea_InvalidData_ReturnsNullAndLogsError()
        {
            var factory = new Factory();
            var props = new List<string> { "море", "Черное", "abc", "18.0" };
            var sea = factory.CreateSea(props);
            Assert.Null(sea);
        }

        [Fact]
        public void Logger_Instance_ReturnsSameObject()
        {
            var logger1 = AppLogger.Instance;
            var logger2 = AppLogger.Instance;
            Assert.Same(logger1, logger2);
        }

    }
}