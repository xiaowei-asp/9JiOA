using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace _9JiOA.Service.TestDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void RegxTest1()
        {
            var address = "江西省吉安市峡江县";
            var reg = "(.*?省|.*?市)";
            var r = new Regex(reg);
            var result = r.Match(address);
            Console.WriteLine(result);
        }

        [Test]
        public void Test5()
        {
            string regex = "(?<province>[^省]+自治区|.*?省|.*?行政区|.*?市)?(?<city>[^市]+自治州|.*?地区|.*?行政单位|.+盟|市辖区|.*?市|.*?县)?(?<county>[^县]+县|.+区|.+市|.+旗|.+海域|.+岛)?(?<town>[^区]+区|.+镇)?(?<village>.*)";
            var address = "吉安峡江县";
            var m = Regex.Match(address, regex, RegexOptions.IgnoreCase);

            var province = m.Groups["province"].Value;
            var city = m.Groups["city"].Value;
            var county = m.Groups["county"].Value;
            var town = m.Groups["town"].Value;
            var village = m.Groups["village"].Value;

            //return (province, city, county, town, village);
        }
    }
}