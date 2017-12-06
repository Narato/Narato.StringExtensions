using Newtonsoft.Json;
using Xunit;

namespace Narato.StringExtensions.Test
{
    public class StringExtensionsTest
    {
        private enum TestEnum { First, Second };
        private class TestClass
        {
            public TestEnum A { get; set; }
        }

        [Fact]
        public void ToJsonSimpleTest()
        {
            Assert.Equal("[\"5\"]", new string[] {"5"}.ToJson());
        }

        [Fact]
        public void ToJsonNonDefaultSettingsTest()
        {
            var obj = new
            {
                FIRSTNAME = 1,
                NIco = 2,
                Florian = 3,
                rRNnumber = 4
            };
            Assert.Equal("{\"FIRSTNAME\":1,\"NIco\":2,\"Florian\":3,\"rRNnumber\":4}", obj.ToJson(new JsonSerializerSettings()));
        }

        [Fact]
        public void ToJsonCamelCaseTest()
        {
            var obj = new
            {
                A = 1,
                b = 2,
                cd = 3,
                EfG = 4
            };

            Assert.Equal("{\"a\":1,\"b\":2,\"cd\":3,\"efG\":4}", obj.ToJson());
        }

        [Fact]
        public void ToJsonEnumTest()
        {
            var obj = new
            {
                A = TestEnum.First
            };

            Assert.Equal("{\"a\":\"First\"}", obj.ToJson());
        }

        [Fact]
        public void FromJsonTest()
        {
            var json = "{\"a\":\"First\"}";
            var obj = json.FromJson<TestClass>();

            Assert.Equal(obj.A, TestEnum.First);
        }

        [Fact]
        public void EncodeJsonTest()
        {
            var json = "{\"a\":\"First\"}";

            Assert.Equal("\"{\\\"a\\\":\\\"First\\\"}\"", json.EncodeJson());
        }

        [Fact]
        public void EncodeXmlTest()
        {
            var xml = "<test>i'm xml & crap</test>";

            Assert.Equal("&lt;test&gt;i&apos;m xml &amp; crap&lt;/test&gt;", xml.EncodeXml());
        }
    }
}
