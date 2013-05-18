using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapEditor.Services
{
    class UsefulTools
    {
        private static bool ThumbnailCallback()
        {
            return false;
        }

        public static Image GetThumbnail(Image originalBitmap)
        {
            Image.GetThumbnailImageAbort mycallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image thumbnail = (originalBitmap as Bitmap).GetThumbnailImage(120, 120, mycallback, IntPtr.Zero);
            return thumbnail;
        }

        public static bool hasSelectedSprite { get; set; }
        public static MapEditor.Models.SelectedSprite SelectedSprite { get; set; }
    }
}
