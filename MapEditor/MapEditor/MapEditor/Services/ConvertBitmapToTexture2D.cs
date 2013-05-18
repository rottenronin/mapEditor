using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MapEditor.Services
{
    public class ConvertBitmapToTexture2D
    {
        byte[] bmpBytes;
        Texture2D texture2D;

        int width, height;
        GraphicsDevice graphicsDevice;

        public ConvertBitmapToTexture2D(GraphicsDevice gDevice)
        {
           // this.width = width;
            //this.height = height;
            this.graphicsDevice = gDevice;

            //GenerateBitmap(gDevice, width, height);
        }

        private void GenerateBitmap(GraphicsDevice graphicsDevice,
            int width, int height)
        {
            texture2D = new Texture2D(graphicsDevice, width, height);
        }

        public Texture2D ConvertBitmap(Bitmap b, int width, int height)
        {
            graphicsDevice.Textures[0] = null;

          /*  if (texture2D == null ||
                b.Width != texture2D.Width ||
                b.Height != texture2D.Height)
            {*/
                width = b.Width;
                height = b.Height;
                GenerateBitmap(graphicsDevice, width, height);
            //}

            BitmapData bData = b.LockBits(new System.Drawing.Rectangle(
                new System.Drawing.Point(), b.Size),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb);

            int byteCount = bData.Stride * b.Height;

            if (bmpBytes == null ||
                bmpBytes.Length != byteCount)
            {
                bmpBytes = new byte[byteCount];
            }

            Marshal.Copy(bData.Scan0, bmpBytes, 0, byteCount);

            b.UnlockBits(bData);

            texture2D.SetData(bmpBytes);

            return texture2D;

        }
    }
}
