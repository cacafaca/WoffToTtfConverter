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

        public static Stream FromBase128(Stream encodedStream)
        {
            Stream decodedStream = new MemoryStream();

            if (encodedStream.CanRead)
            {
                UInt32 acum = 0;
                for (int i = 0; i < 5; i++)
                {
                    var readValue = encodedStream.ReadByte();
                    if (readValue != -1)
                    {
                        byte data = Convert.ToByte(readValue);

                    }
                }
            }
            else
                throw new Exception("Can't read stream.");

            return decodedStream;
        }
        #endregion
    }
}
