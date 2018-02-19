using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCode.Woff2Ttf
{
    public class CantReadStreamException : Exception
    {
        #region Constructors

        public CantReadStreamException(string message, Stream stream)
            : base(message)
        {
            NoReadStream = stream;
        }

        #endregion

        #region Public Properties

        public Stream NoReadStream { get; private set; }

        #endregion
    }
}
