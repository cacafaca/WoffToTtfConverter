using System;
using System.IO;

namespace ProCode.Woff2Ttf
{
    public class Woff2TableDirectoryEntry
    {
        #region Constructors

        public Woff2TableDirectoryEntry(Stream tableDirectoryEntryStream)
        {
            if (tableDirectoryEntryStream == null)
                throw new ArgumentNullException(nameof(tableDirectoryEntryStream));

            if (tableDirectoryEntryStream.CanRead)
            {

            }
            else
                throw new CantReadStreamException("Can't read.", tableDirectoryEntryStream);
        }

        #endregion

        #region Public Properties

        byte Flags { get { return flags; } }
        UInt32 Tag { get { return tag; } }
        UInt32 OrigLength { get { return origLength; } }
        UInt32 TransformLength { get { return transformLength; } }

        #endregion

        #region Private Properties

        byte flags;
        UInt32 tag;
        UInt32 origLength;
        UInt32 transformLength;

        #endregion
    }
}
