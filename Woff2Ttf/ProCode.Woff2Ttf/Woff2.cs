using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCode.Woff2Ttf
{
    /// <summary>
    /// Reference: https://www.w3.org/TR/WOFF2/
    /// </summary>
    public class Woff2
    {
        #region Constructor

        public Woff2(Stream inputData)
        {
            streamLength = inputData.Length;
            header = new Woff2Header(inputData);
            ValidateHeader();
        }

        #endregion

        #region Public Methods

        public void ConvertToTtf()
        {

        }

        #endregion

        #region Public Properties

        public Woff2Header Header { get; }
        public float CompressionRatio { get { return header.MetaOrigLength / streamLength; } }

        #endregion

        #region Private Properties

        Woff2Header header;
        long streamLength;

        #endregion

        #region PrivateMethods

        private void ValidateHeader()
        {
            if (CompressionRatio > maxCompressionRatio)
                throw new Exception("Bad uncompressed size.");
        }
        #endregion

        #region Private Constants

        const uint maxCompressionRatio = 100;

        #endregion
    }
}
