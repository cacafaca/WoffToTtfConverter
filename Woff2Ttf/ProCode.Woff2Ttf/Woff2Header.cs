using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCode.Woff2Ttf
{
    /// <summary>
    /// 
    /// Header Structure:
    /// 
    /// - UInt32 signature            0x774F4632 'wOF2'
    /// - UInt32 flavor               The "sfnt version" of the input font.
    /// - UInt32 length               Total size of the WOFF file.
    /// - UInt16 numTables            Number of entries in directory of font tables.
    /// - UInt16 reserved             Reserved; set to 0.
    /// - UInt32 totalSfntSize        Total size needed for the uncompressed font data, including the sfnt header, directory, and font tables(including padding).
    /// - UInt32 totalCompressedSize  Total length of the compressed data block.
    /// - UInt16 majorVersion         Major version of the WOFF file.
    /// - UInt16 minorVersion         Minor version of the WOFF file.
    /// - UInt32 metaOffset           Offset to metadata block, from beginning of WOFF file.
    /// - UInt32 metaLength           Length of compressed metadata block.
    /// - UInt32 metaOrigLength       Uncompressed size of metadata block.
    /// - UInt32 privOffset           Offset to private data block, from beginning of WOFF file.
    /// - UInt32  privLength          Length of private data block.    
    /// 
    /// </summary>
    public class Woff2Header
    {
        #region Constructor

        public Woff2Header(Stream headerStream)
        {
            if (headerStream != null)
                throw new ArgumentNullException(nameof(headerStream));

            if (headerStream.CanRead)
            {
                if (headerStream.Position > 0)
                    headerStream.Position = 0;

                int currentByte;

                // UInt32 signature            0x774F4632 'wOF2'
                ReadSignature(headerStream);
                byte[] signatureByte = new byte[4];

                currentByte = headerStream.ReadByte();
                if (currentByte > -1)
                    signatureByte[0] = (byte)currentByte;
            }
            else
                throw new ArgumentException("Can't read.");
        }

        #endregion

        #region Public Properties

        public UInt32 Signature { get { return signature; } }
        public UInt32 Flavor { get { return flavor; } }
        UInt32 Length { get { return length; } }
        UInt16 NumTables { get { return numTables; } }
        UInt16 Reserved { get { return reserved; } }
        UInt32 TotalSfntSize { get { return totalSfntSize; } }
        UInt32 TotalCompressedSize { get { return totalCompressedSize; } }
        UInt16 MajorVersion { get { return majorVersion; } }
        UInt16 MinorVersion { get { return minorVersion; } }
        UInt32 MetaOffset { get { return metaOffset; } }
        UInt32 MetaLength { get { return metaLength; } }
        UInt32 MetaOrigLength { get { return metaOrigLength; } }
        UInt32 PrivOffset { get { return privOffset; } }
        UInt32 PrivLength { get { return privLength; } }

        #endregion

        #region Private Properties

        UInt32 signature;
        UInt32 flavor;
        UInt32 length;
        UInt16 numTables;
        UInt16 reserved;
        UInt32 totalSfntSize;
        UInt32 totalCompressedSize;
        UInt16 majorVersion;
        UInt16 minorVersion;
        UInt32 metaOffset;
        UInt32 metaLength;
        UInt32 metaOrigLength;
        UInt32 privOffset;
        UInt32 privLength;

        #endregion
    }
}
