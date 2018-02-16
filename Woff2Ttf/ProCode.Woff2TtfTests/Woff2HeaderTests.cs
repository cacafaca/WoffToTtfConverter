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
    public class Woff2HeaderTests
    {
        [TestMethod()]
        public void Woff2HeaderTest()
        {
            Stream headerResource;
            using (var resource = new MemoryStream(Woff2TtfTests.Properties.Resources.arial_woff2))
            {
                var header = new byte[Woff2Header.HeaderSize];
                resource.Read(header, 0, header.Length);
                headerResource = new MemoryStream(header);
            }
            Woff2Header h = new Woff2Header(headerResource);

            Assert.AreEqual(0x774F4632, h.Signature);
        }
    }
}