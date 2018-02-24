using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCode.Woff2Ttf
{
    public class Converter
    {
        #region Constructors

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts to TTF from WOFF/WOFF2.
        /// </summary>
        /// <param name="importingFont">WOFF or WOFF2 font.</param>
        /// <returns></returns>
        public Stream ConvertToTtf(Stream importingFont)
        {
            return null;
        }

        /// <summary>
        /// Reads UIntBase128 Data Type as written in https://www.w3.org/TR/WOFF2/.
        /// </summary>
        /// <param name="encodedStream"></param>
        /// <param name="result"></param>
        public static bool ReadUIntBase128(Stream encodedStream, out UInt32 result)
        {
            Stream decodedStream = new MemoryStream();
            result = UInt32.MinValue;

            if (encodedStream.CanRead)
            {
                UInt32 accum = 0;
                for (int i = 0; i < 5; i++)
                {
                    var dataByte = encodedStream.ReadByte();

                    // No leading 0's.  0x80 = 1000 0000
                    if (i == 0 && dataByte == 0x80)
                        return false;

                    // If any of top 7 bits are set then << 7 would overflow. 0xfe000000 = 1111 1110 0000 0000 0000 0000 0000 0000.
                    if ((accum & 0xfe000000) > 1)
                        return false;

                    accum = (accum << 7) | ((UInt32)dataByte & 0x7f); // 0x7f = 0111 1111

                    // Spin until most significant bit of data byte is false.
                    if((dataByte & 0x80) != 0)
                    {
                        result = accum;
                        return true;
                    }
                }
                // UIntBase128 sequence exceeds 5 bytes.
                return false;
            }
            else
                throw new Exception("Can't read stream.");
        }

        #endregion
    }
}
