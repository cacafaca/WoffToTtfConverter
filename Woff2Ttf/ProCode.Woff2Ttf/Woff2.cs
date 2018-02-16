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
            header = new Woff2Header(inputData);
        }

        #endregion

        #region Public Methods

        public void ConvertToTtf()
        {

        }

        #endregion

        #region Public Properties

        public Woff2Header Header { get; }

        #endregion

        #region Private Properties

        Woff2Header header;
        #endregion
    }
}
