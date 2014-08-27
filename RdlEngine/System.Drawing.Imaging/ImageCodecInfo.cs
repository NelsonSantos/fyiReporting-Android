using System;

namespace System.Drawing.Imaging
{
	public class ImageCodecInfo
	{
		public ImageCodecInfo ()
		{
		}

		public Guid Clsid {get; set;}

		public string CodecName { get; set; }

		public string DllName { get; set; }

		public string FilenameExtension { get; set; }

		public ImageCodecFlags Flags { get; set; }

	    private string m_FormatDescription = "";
        public string FormatDescription 
        {
            get { return m_FormatDescription; }
            set { m_FormatDescription = value; }
        }

		public Guid FormatID { get; set; }

		public string MimeType { get; set; }

		[CLSCompliantAttribute(false)]
		public byte[][] SignatureMasks { get; set; }

		[CLSCompliantAttribute(false)]
		public byte[][] SignaturePatterns { get; set; }
		
		public int Version { get; set; }

		public static ImageCodecInfo[] GetImageEncoders()
		{
            return GetCodedInfos();
        }

	    private static ImageCodecInfo[] GetCodedInfos()
	    {
	        var _ici = new ImageCodecInfo[]
	        {
	            new ImageCodecInfo()
	            {
	                CodecName = "JPEG",
	                MimeType = "image/jpeg",
	                FilenameExtension = ".jpg",
                    FormatDescription = "JPEG"
	            },
	            new ImageCodecInfo()
	            {
	                CodecName = "PNG",
	                MimeType = "image/PNG",
	                FilenameExtension = ".png",
                    FormatDescription = "PNG"
	            }
	        };

	        return _ici;
	    }

	    public static ImageCodecInfo[] GetImageDecoders()
		{
            return GetCodedInfos();			
		}

	}
}

