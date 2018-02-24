using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProCode.Woff2Ttf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCode.Woff2Ttf.Tests
{
    [TestClass()]
    public class ConverterTests
    {
        [TestMethod()]
        public void ConvertToTtfTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadUIntBase128Test()
        {
            Stream stream = new MemoryStream(new byte[6] { 0x1c, 0x1a, 0x81, 0x2e, 0x1b, 0xa1 });
            UInt32 expected = 0x070d01;
            UInt32 actual;
            bool conversionSucceded = Converter.ReadUIntBase128(stream, out actual);
            Assert.IsTrue(conversionSucceded);
            Assert.AreEqual(expected, actual);
        }
    }
}