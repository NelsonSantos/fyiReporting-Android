using System;
using System.IO;
using Android.Graphics;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace System.Drawing
{
    public class Bitmap : Image
    {

        public Android.Graphics.Bitmap ABitmap;

        /// <summary>
        /// Initializes a new instance of the Bitmap class from the specified existing image.
        /// </summary>
        /// <param name='img'>
        /// Image.
        /// </param>
        public Bitmap(int w, int h)
        {
            ABitmap = Android.Graphics.Bitmap.CreateBitmap(w, h, Android.Graphics.Bitmap.Config.Argb8888);
        }

        public Bitmap(MemoryStream ms)
        {
            ABitmap = Android.Graphics.BitmapFactory.DecodeStream(ms);
        }

        /// <summary>
        /// Initializes a new instance of the Bitmap class from the specified data stream.
        /// </summary>
        /// <param name='img'>
        /// Image.
        /// </param>
        public Bitmap(Stream rs)
        {
            ABitmap = Android.Graphics.BitmapFactory.DecodeStream(rs);
        }

        // <summary>
        /// Initializes a new instance of the Bitmap class from the specified file.
        /// </summary>
        /// <param name='file'>
        /// File.
        /// </param>
        public Bitmap(string filename)
        {
            ABitmap = Android.Graphics.BitmapFactory.DecodeFile(filename);
        }

        /// <summary>
        /// Initializes a new instance of the Bitmap class from the specified existing image, scaled to the specified size.
        /// </summary>
        /// <param name='img'>
        /// Image.
        /// </param>
        /// <param name='sz'>
        /// Size.
        /// </param>
        public Bitmap(Image img, Size sz)
        {
            throw new NotImplementedException();
        }


        public Bitmap(int width, int height, Imaging.PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Alpha:
                case PixelFormat.Canonical:
                case PixelFormat.DontCare:
                case PixelFormat.Extended:
                case PixelFormat.Format16bppArgb1555:
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                case PixelFormat.Format1bppIndexed:
                case PixelFormat.Format24bppRgb:
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                case PixelFormat.Format48bppRgb:
                case PixelFormat.Format4bppIndexed:
                case PixelFormat.Format64bppArgb:
                case PixelFormat.Format64bppPArgb:
                case PixelFormat.Format8bppIndexed:
                case PixelFormat.Gdi:
                case PixelFormat.Indexed:
                case PixelFormat.Max:
                case PixelFormat.PAlpha:
                case PixelFormat.Undefined:
                    ABitmap = Android.Graphics.Bitmap.CreateBitmap(width, height, Android.Graphics.Bitmap.Config.Argb8888);
                    break;
            }
            //throw new NotImplementedException();
        }


        public void Clear(Color color)
        {
            ABitmap.EraseColor(color.ToArgb());
        }

        public override int Width
        {
            get { return ABitmap.Width; }
        }
        public override int Height
        {
            get { return ABitmap.Height; }
        }

        public override void Dispose()
        {
            if (ABitmap != null)
            {
                ABitmap.Dispose();
                ABitmap = null;
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(ABitmap.Width, ABitmap.Height);
            }
        }

        public void Save(System.IO.Stream stream, Imaging.ImageCodecInfo info, Imaging.EncoderParameters e)
        {
            Android.Graphics.Bitmap.CompressFormat _format;
            switch (info.FormatDescription)
            {

                case "PNG":
                    _format = Android.Graphics.Bitmap.CompressFormat.Png;
                    break;

                case "JPEG":
                default:
                    _format = Android.Graphics.Bitmap.CompressFormat.Jpeg;
                    break;

            }
            ABitmap.Compress(_format, 100, stream);
        }

        public void SaveAdd(Image image, Imaging.EncoderParameters encoderParams)
        {
            throw new NotImplementedException();
        }

        public void SaveAdd(Imaging.EncoderParameters encoderParams)
        {
            throw new NotImplementedException();
        }

        public static Bitmap FromByteArray(byte[] bytes)
        {
            var _stream = new MemoryStream(bytes);
            return new Bitmap(_stream);
        }

        public static Bitmap FromStream(System.IO.Stream stream)
        {
            return new Bitmap(stream);
        }

        public static Bitmap CreateBitmap(int width, int height, PixelFormat config)
        {
            return new Bitmap(width, height, config);
        }

        public void MakeTransparent(Color transparentColor)
        {
            throw new NotImplementedException();
        }


        public void SetResolution(float xDpi, float yDpi)
        {
            throw new NotImplementedException();
        }


        private Imaging.PixelFormat _pixelformat;
        public Imaging.PixelFormat PixelFormat
        {
            get
            {
                throw new NotImplementedException();
                return _pixelformat;
            }
        }

        public Imaging.BitmapData LockBits(Rectangle rect, Imaging.ImageLockMode flags, Imaging.PixelFormat format)
        {
            throw new NotImplementedException();
        }

        public void UnlockBits(Imaging.BitmapData bitmapdata)
        {
            throw new NotImplementedException();
        }


        public Color GetPixel(int x, int y)
        {
            int pixel = ABitmap.GetPixel(x, y);

            int red = Android.Graphics.Color.GetRedComponent(pixel);
            int blue = Android.Graphics.Color.GetBlueComponent(pixel);
            int green = Android.Graphics.Color.GetGreenComponent(pixel);

            return Color.FromArgb(red, green, blue);

        }

        public void SetPixel(int x, int y, Color color)
        {
            Android.Graphics.Color c = new Android.Graphics.Color(color.R, color.G, color.B);

            ABitmap.SetPixel(x, y, c);

        }

    }
}

