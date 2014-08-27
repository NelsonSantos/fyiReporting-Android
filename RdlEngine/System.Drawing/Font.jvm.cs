
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel;
//using awt = java.awt;
//using TextAttribute = java.awt.font.TextAttribute;

namespace System.Drawing {
    //[Serializable]
    //public sealed class Font: Android.Graphics.Typeface, ISerializable, ICloneable, IDisposable {

    //}
    public class Font : IDisposable
    {
        public FontFamily FontFamily { get; set; }
        public int Size { get; set; }
        public FontStyle Style { get; set; }
        public string Name { get; set; }

        public Font(FontFamily family, int size, FontStyle style)
        {
            Size = size;
            FontFamily = family;
            Style = style;
        }

        public Font(FontFamily family, int size)
        {
            Size = size;
            FontFamily = family;
            Style = FontStyle.Normal;
        }

        public Font(string familyName, float emSize)
        {
            this.Size = (int)emSize;
            this.Style = FontStyle.Normal;
            this.FontFamily = new FontFamily(familyName); //Drawing.FontFamily.GenericSansSerif;
            this.Name = familyName;


            //throw new NotImplementedException();

        }

        public Font(FontFamily family, float emSize, FontStyle style)
        {
            this.FontFamily = family;
            this.Size = (int)emSize;
            this.Style = style;
        }

        public Font(string familyName, float emSize, FontStyle style)
        {
            this.FontFamily = new FontFamily(familyName); //Drawing.FontFamily.GenericSansSerif;
            this.Size = (int)emSize;
            this.Style = style;
            this.Name = familyName;
        }

        public Font(string familyName, float emSize, FontStyle style, GraphicsUnit unit)
        {
            this.FontFamily = new FontFamily(familyName); //Drawing.FontFamily.GenericSansSerif;
            this.Size = (int)emSize;
            this.Style = style;
            this.Name = familyName;
        }

        public bool Italic
        {
            get
            {
                return this.Style == FontStyle.Italic;
            }
        }

        public bool Bold
        {
            get
            {
                return this.Style == FontStyle.Bold;
            }
        }

        public bool Underline
        {
            get
            {
                return this.Style == FontStyle.Underline;
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }

}
