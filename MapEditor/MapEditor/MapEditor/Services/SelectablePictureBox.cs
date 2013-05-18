using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.Services
{
    public class SelectablePictureBox : PictureBox
    {
        public string PictureFileName { get; set; }
        public string PictureFilePath { get; set; }

        public Image OriginalImage { get; set; }

        private bool selected = false;

        public SelectablePictureBox()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }

        public bool IsSelected()
        {
            return selected;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            selected = true;

            MapEditor.Services.UsefulTools.hasSelectedSprite = true;
            MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox = this;

            base.OnMouseDown(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }   

        protected override void OnPaint(PaintEventArgs pe)
        {
            
            base.OnPaint(pe);
            if (this.Focused)
            {
                var rc = this.ClientRectangle;
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            selected = false;

           /* if (MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox == this)
            {
                MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox = null;
                MapEditor.Services.UsefulTools.hasSelectedSprite = false;
            }*/

            this.Invalidate();
            base.OnLeave(e);
        }

        public int GetPictureWidth()
        {
            return this.Image.Width;
        }

        public int GetPictureHeight()
        {
            return this.Image.Height;
        }

    }
}
