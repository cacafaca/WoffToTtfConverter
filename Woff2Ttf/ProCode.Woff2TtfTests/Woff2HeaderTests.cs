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
            Woff2Header woff2Header = new Woff2Header(headerResource);

            
            // Expected values.
            
            // Address 00000000:
            UInt32 expectedSignature = 0x774F4632;
            UInt32 expectedFlavor = 0x00010000; // ??
            UInt32 expectedLength = 0x01CD7C;
            UInt16 expectedNumTables = 0x0013;
            UInt16 expectedReserved = 0x0000;

            // Address 00000010:
            UInt32 expectedTotalSfntSize = 0x3FC00;
            UInt32 expectedTotalCompressedSize  =0x1CD10;
            UInt16 expectedMajorVersion = 0x0001;
            UInt16 expectedMinorVersion = 0x0000;
            UInt32 expectedMetaOffset = 0x00000000;

            // Address 00000020:
            UInt32 expectedMetaLength = 0x00000000;
            UInt32 expectedMetaOrigLength = 0x0;
            UInt32 expectedPrivOffset = 0x0;
            UInt32 expectedPrivLength = 0x0;


            // Assertions.

            // Address 00000000:
            Assert.AreEqual(expectedSignature, woff2Header.Signature);
            Assert.AreEqual(expectedFlavor, woff2Header.Flavor);
            Assert.AreEqual(expectedLength, woff2Header.Length);
            Assert.AreEqual(expectedNumTables, woff2Header.NumTables);
            Assert.AreEqual(expectedReserved, woff2Header.Reserved);

            // Address 00000010:
            Assert.AreEqual(expectedTotalSfntSize, woff2Header.TotalSfntSize);
            Assert.AreEqual(expectedTotalCompressedSize, woff2Header.TotalCompressedSize);
            Assert.AreEqual(expectedMajorVersion, woff2Header.MajorVersion);
            Assert.AreEqual(expectedMinorVersion, woff2Header.MinorVersion);
            Assert.AreEqual(expectedMetaOffset, woff2Header.MetaOffset);

            // Address 00000020:
            Assert.AreEqual(expectedMetaLength, woff2Header.MetaLength);
            Assert.AreEqual(expectedMetaOrigLength, woff2Header.MetaOrigLength);
            Assert.AreEqual(expectedPrivOffset, woff2Header.PrivOffset);
            Assert.AreEqual(expectedPrivLength, woff2Header.PrivLength);
        }
    }
}