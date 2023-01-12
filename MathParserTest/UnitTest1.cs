using NUnit.Framework;
using MathParser;

namespace MathParserTest
{
    public class Tests
    {
        private Parser parser;

        [SetUp]
        public void Setup()
        {
            System.Console.WriteLine("initialize...");
            this.parser = new Parser();
            
        }

        [Test]
        public void Test1()
        {
            double resoult = this.parser.Parse("2+2");
            Assert.AreEqual(4, resoult);
        }

        [Test]
        public void Test2()
        {
            double resoult = this.parser.Parse("2.5+2");
            Assert.AreEqual(4.5, resoult);
        }

        [Test]
        public void Test3()
        {
            double resoult = this.parser.Parse("2,5+2");
            Assert.AreEqual(4.5, resoult);
        }

        [Test]
        public void Test4()
        {
            double resoult = this.parser.Parse("2,5*2");
            Assert.AreEqual(5, resoult);
        }

        [Test]
        public void Test5()
        {
            double resoult = this.parser.Parse("10/2");
            Assert.AreEqual(5, resoult);
        }

        [Test]
        public void Test6()
        {
            double resoult = this.parser.Parse("10*2");
            Assert.AreEqual(20, resoult);
        }

        [Test]
        public void Test7()
        {
            double resoult = this.parser.Parse("10-2");
            Assert.AreEqual(8, resoult);
        }

        [Test]
        public void Test8()
        {
            double resoult = this.parser.Parse("2+2*2");
            Assert.AreEqual(6, resoult);
        }

        [Test]
        public void Test9()
        {
            double resoult = this.parser.Parse("(2+2)*2");
            Assert.AreEqual(8, resoult);
        }

        [Test]
        public void Test10()
        {
            double resoult = this.parser.Parse("(2+2)^2");
            Assert.AreEqual(16, resoult);
        }

    }
}