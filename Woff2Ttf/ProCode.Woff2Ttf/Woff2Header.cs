﻿using System;
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
    /// Sum is 48 Bytes to read.
    /// 
    /// </summary>
    public class Woff2Header
    {
        #region Constructor

        public Woff2Header(Stream headerStream)
        {
            if (headerStream == null)
                throw new ArgumentNullException(nameof(headerStream));

            if (headerStream.CanRead)
            {
                if (headerStream.Position > 0)
                    headerStream.Position = 0;

                ReadSignature(headerStream); // UInt32 signature            0x774F4632 'wOF2'
            }
            else
                throw new ArgumentException("Can't read.");
        }

        #endregion

        #region Public Properties

        public UInt32 Signature { get { return signature; } }
        public UInt32 Flavor { get { return flavor; } }
        public UInt32 Length { get { return length; } }
        public UInt16 NumTables { get { return numTables; } }
        public UInt16 Reserved { get { return reserved; } }
        public UInt32 TotalSfntSize { get { return totalSfntSize; } }
        public UInt32 TotalCompressedSize { get { return totalCompressedSize; } }
        public UInt16 MajorVersion { get { return majorVersion; } }
        public UInt16 MinorVersion { get { return minorVersion; } }
        public UInt32 MetaOffset { get { return metaOffset; } }
        public UInt32 MetaLength { get { return metaLength; } }
        public UInt32 MetaOrigLength { get { return metaOrigLength; } }
        public UInt32 PrivOffset { get { return privOffset; } }
        public UInt32 PrivLength { get { return privLength; } }

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

        #region Private Methods

        void ReadProperty(Stream headerStream, out object property)
        {
            property = null;
            int size = System.Runtime.InteropServices.Marshal.SizeOf(property);
            byte[] propertyArray = new byte[size];
            headerStream.Read(propertyArray, 0, size);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(propertyArray);

            switch ((string)property.GetType().ToString().Split('.').Last())
            {
                case UInt16Name:
                    property = BitConverter.ToUInt16(propertyArray, 0);
                    break;
                case UInt32Name:
                    property = BitConverter.ToUInt32(propertyArray, 0);
                    break;
                default:
                    throw new ArgumentException("Unexpected type of property.");
            }
            
        }

        #endregion

        #region Read Header Properties

        /// <summary>
        /// UInt32 signature            0x774F4632 'wOF2'
        /// </summary>
        /// <param name="headerStream"></param>
        private void ReadSignature(Stream headerStream)
        {
            object outputValue;
            ReadProperty(headerStream, out outputValue);
            signature = (UInt32)outputValue;
        }

        /// <summary>
        /// UInt32 flavor               The "sfnt version" of the input font.
        /// </summary>
        /// <param name="headerStream"></param>
        private void ReadFlavor(Stream headerStream)
        {
            object outputValue;
            ReadProperty(headerStream, out outputValue);
            flavor = (UInt32)outputValue;
        }

        /// <summary>
        /// UInt32 length               Total size of the WOFF file.
        /// </summary>
        /// <param name="headerStream"></param>
        private void ReadLength(Stream headerStream)
        {
            object outputValue;
            ReadProperty(headerStream, out outputValue);
            length = (UInt32)outputValue;
        }

        /// <summary>
        /// UInt16 numTables            Number of entries in directory of font tables.
        /// </summary>
        /// <param name="headerStream"></param>
        private void ReadNumTables(Stream headerStream)
        {
            object outputValue;
            ReadProperty(headerStream, out outputValue);
            numTables = (UInt16)outputValue;
        }

        #endregion

        #region Private Constatns

        const string UInt16Name = "UInt16";
        const string UInt32Name = "UInt32";

        #endregion

        #region Public Constants

        /// <summary>
        /// Size of Header in Bytes.
        /// </summary>
        public static readonly int HeaderSize = 48;

        #endregion
    }
}
