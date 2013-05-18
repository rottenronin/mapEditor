using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace MapEditor.Models
{
    public class Sprite
    {
        private Rectangle textureRec;
        Texture2D _texture;

        private bool initialized = false;

        public Sprite()
        {
           
        }

        public bool HasInitialized
        {
            get
            {
                return initialized;
            }
            set
            {
                initialized = value;
            }
        }

        public Texture2D SpriteTexture 
        { get
            {
                return _texture;
            }
            set
            {
                _texture = value;
            }
        }

        public void InitializeTexture2D(GraphicsDevice gDevice, int width, int height)
        {
            _texture = new Texture2D(gDevice, width, height);
        }

        public Rectangle TextureRec 
        {
            get { return textureRec; }
            set { textureRec = value; }
        }

        public void SetTexturePosition(int x, int y)
        {
            textureRec.X = x;
            textureRec.Y = y;
        }

        public Point GetTextureSize()
        {
            return new Point(SpriteTexture.Width, SpriteTexture.Height);
        }

        public void Update()
        {

        }

        public void UpdatePosition(int x, int y)
        {
            textureRec.X = x;
            textureRec.Y = y;
        }

        public bool MouseClickDetected(Point mousePosition)
        {
            Point pixelPosition = new Point(mousePosition.X - textureRec.X, mousePosition.Y - textureRec.Y);

            uint[] PixelData = new uint[1];

            SpriteTexture.GetData<uint>(0, new Rectangle(pixelPosition.X, pixelPosition.Y, (1), (1)),
                PixelData, 0, 1);

            if (((PixelData[0] & 0xFF000000) >> 24) > 20)
            {
                return true;
            }
            return false;
        }

    }
}
