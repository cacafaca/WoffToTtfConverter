using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCode.Woff2Ttf
{
    /// <summary>
    /// UInt32 signature   0x774F4632 'wOF2'
    /// UInt32 flavor  The "sfnt version" of the input font.
    /// UInt32  length Total size of the WOFF file.
    /// UInt16 numTables   Number of entries in directory of font tables.
    /// UInt16 reserved    Reserved; set to 0.
    /// UInt32 totalSfntSize   Total size needed for the uncompressed font data, including the sfnt header,
    /// directory, and font tables(including padding).
    /// UInt32 totalCompressedSize Total length of the compressed data block.
    /// UInt16 majorVersion    Major version of the WOFF file.
    /// UInt16  minorVersion Minor version of the WOFF file.
    /// UInt32 metaOffset  Offset to metadata block, from beginning of WOFF file.
    /// UInt32 metaLength  Length of compressed metadata block.
    /// UInt32 metaOrigLength  Uncompressed size of metadata block.
    /// UInt32 privOffset  Offset to private data block, from beginning of WOFF file.
    /// UInt32  privLength Length of private data block.    
    /// </summary>
    public class Woff2Header
    {
        #region Constructor

        public Woff2Header()
        {

        }

        #endregion

        #region Public Properties

        public UInt32 Signature { get; set; }
        public UInt32 Flavor { get; set; }

        #endregion
    }
}
