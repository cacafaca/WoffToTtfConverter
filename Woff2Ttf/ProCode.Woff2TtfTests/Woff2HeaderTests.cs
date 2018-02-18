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

            UInt32 expectedSignature = 0x774F4632;
            UInt32 expectedFlavor = 0x00010000; // ??
            UInt32 expectedLength = 0x01CD7C;
            UInt16 expectedNumTables = 0x0013;
            UInt16 expectedReserved = 0x0000;
            UInt32 expectedTotalSfntSize = 0x3FC00;
            UInt32 expectedTotalCompressedSize  =0x1CD10;
    /// - UInt16 majorVersion         Major version of the WOFF file.
    /// - UInt16 minorVersion         Minor version of the WOFF file.
    /// - UInt32 metaOffset           Offset to metadata block, from beginning of WOFF file.
    /// - UInt32 metaLength           Length of compressed metadata block.
    /// - UInt32 metaOrigLength       Uncompressed size of metadata block.
    /// - UInt32 privOffset           Offset to private data block, from beginning of WOFF file.
    /// - UInt32  privLength          Length of private data block.    

            Assert.AreEqual(expectedSignature, h.Signature);
            Assert.AreEqual(expectedFlavor, h.Flavor);
            Assert.AreEqual(expectedLength, h.Length);
            Assert.AreEqual(expectedNumTables, h.NumTables);
            Assert.AreEqual(expectedReserved, h.Reserved);
            Assert.AreEqual(expectedTotalSfntSize, h.TotalSfntSize);
            Assert.AreEqual(expectedTotalCompressedSize, h.TotalCompressedSize);
        }
    }
}