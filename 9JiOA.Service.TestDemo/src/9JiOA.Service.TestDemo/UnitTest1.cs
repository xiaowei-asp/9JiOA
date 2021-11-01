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
            var address = "����ʡ������Ͽ����";
            var reg = "(.*?ʡ|.*?��)";
            var r = new Regex(reg);
            var result = r.Match(address);
            Console.WriteLine(result);
        }

        [Test]
        public void Test5()
        {
            string regex = "(?<province>[^ʡ]+������|.*?ʡ|.*?������|.*?��)?(?<city>[^��]+������|.*?����|.*?������λ|.+��|��Ͻ��|.*?��|.*?��)?(?<county>[^��]+��|.+��|.+��|.+��|.+����|.+��)?(?<town>[^��]+��|.+��)?(?<village>.*)";
            var address = "����Ͽ����";
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