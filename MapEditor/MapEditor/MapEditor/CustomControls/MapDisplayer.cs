using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Reflection;
using System.IO;

using MapEditor.Services;
using MapEditor.Models;

namespace MapEditor.CustomControls
{
    public class MapDisplayer : WinFormsGraphicsDevice.GraphicsDeviceControl
    {
        SpriteBatch spriteBatch;        

        Sprite _selectedSprite;

        Sprite focusedSprite = null;

        bool hasFocusedSprite = false;

        List<Sprite> _listSprites;
        
        Stopwatch stopwatch;
        readonly TimeSpan TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        readonly TimeSpan MaxElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 10);

        TimeSpan accumulatedTime;
        TimeSpan lastTime;

        string assemblyLocation;
        string relativePath;
        string contentPath;

        ContentBuilder contentBuilder;
        ContentManager contentManager;

        public void Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopwatch.Elapsed;
            TimeSpan elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            if (elapsedTime > MaxElapsedTime)
            {
                elapsedTime = MaxElapsedTime;
            }

            accumulatedTime += elapsedTime;
            bool updated = false;

            while (accumulatedTime >= TargetElapsedTime)
            {
                ItemUpdate();

                accumulatedTime -= TargetElapsedTime;
                updated = true;
            }

            if (updated)
            {
                Invalidate();
            }
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);

           // convector = new ConvertBitmapToTexture2D(this.GraphicsDevice);

            stopwatch = Stopwatch.StartNew();

            _selectedSprite = new Sprite();

            Application.Idle += TickWhileIdle;

            #region Default to the directory which contains our content files

            assemblyLocation = Assembly.GetExecutingAssembly().Location;
            relativePath = Path.Combine(assemblyLocation, @"..\..\..\..\Content");
            contentPath = Path.GetFullPath(relativePath);



            #endregion

            /*this.AllowDrop = true;

            this.DragEnter += new DragEventHandler(Sprite_DragEnter);
            this.DragDrop += new DragEventHandler(Sprite_DragDrop);
            */
           // this.MouseMove += new MouseEventHandler(MouseMove_Handler);

            //this.Paint += new PaintEventHandler(Form_Paint);

            _listSprites = new List<Sprite>();

            this.MouseMove += new MouseEventHandler(MouseMove_Handler);
            this.MouseDown += new MouseEventHandler(MouseDown_Handler);
        }


        private Sprite HaveClickedASprite(MouseEventArgs e)
        {
            foreach (Sprite tmp in _listSprites)
            {
                if ((e.X > tmp.TextureRec.X && e.X < tmp.TextureRec.X + tmp.TextureRec.Width) && (e.Y > tmp.TextureRec.Y && e.Y < tmp.TextureRec.Y + tmp.TextureRec.Height))
                    return tmp;
            }

            return null;
        }

        private void AddNewItemToPanel()
        {
        }

        private void MouseDown_Handler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (UsefulTools.hasSelectedSprite == true)
                {
                    UsefulTools.hasSelectedSprite = false;
                    UsefulTools.SelectedSprite.SelectedPicBox = null;
                    _selectedSprite.HasInitialized = false;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (UsefulTools.hasSelectedSprite == true)
                {
                    Sprite newSprite = new Sprite();

                    LoadSprite2D(UsefulTools.SelectedSprite.SelectedPicBox.PictureFilePath, newSprite);
                    newSprite.TextureRec = new Microsoft.Xna.Framework.Rectangle(e.X - newSprite.SpriteTexture.Width / 2, e.Y - newSprite.SpriteTexture.Height / 2,
                                                                                 newSprite.SpriteTexture.Width, newSprite.SpriteTexture.Height);
                    newSprite.HasInitialized = true;
                    _listSprites.Add(newSprite);

                }
                else
                {
                    Sprite tmp = HaveClickedASprite(e);

                    if (tmp != null)
                    {
                        hasFocusedSprite = tmp.MouseClickDetected(new Microsoft.Xna.Framework.Point(e.X, e.Y));

                        if (hasFocusedSprite == true)
                            focusedSprite = tmp;
                        else
                            hasFocusedSprite = false;
                    }
                    else
                    {
                        hasFocusedSprite = false;
                    }
                }
            }
        }

        private void MouseMove_Handler(object sender, MouseEventArgs e)
        {
            if (this.Focused == false)
                this.Focus();

            var mouseState = Mouse.GetState();

            if (UsefulTools.hasSelectedSprite == true)
            {
                _selectedSprite.TextureRec = new Microsoft.Xna.Framework.Rectangle(e.X - _selectedSprite.SpriteTexture.Width / 2, e.Y - _selectedSprite.SpriteTexture.Height / 2, _selectedSprite.SpriteTexture.Width, _selectedSprite.SpriteTexture.Height);


            }

            if (hasFocusedSprite == true && mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                Cursor = Cursors.Hand;
                focusedSprite.UpdatePosition(e.X - _selectedSprite.SpriteTexture.Width / 2, e.Y - _selectedSprite.SpriteTexture.Height / 2);
            }
            else
            {
                Cursor = Cursors.Default;
            }
               
            //Console.WriteLine("x : " + e.X + " Y : " + e.Y + "\nMouseState_X: " + mouseState.X + " MouseState_Y: " + mouseState.Y);

           // if (MapEditor.Services.UsefulTools.SelectedSprite.hasSelectedSprite == true)
            //    Invalidate();
        }



        #region DragDrop Operation

        /*private void Sprite_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Sprite_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                try
                {
                   // texture2D = convector.ConvertBitmap((Bitmap)e.Data.GetData(DataFormats.Bitmap),
                    Bitmap img = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                    texture2D = convector.ConvertBitmap(img, img.Width, img.Height);
                    
                    var mouseState = Mouse.GetState();
                    textureRec = new Microsoft.Xna.Framework.Rectangle(e.X, e.Y, img.Width, img.Height);
                    test = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            this.Invalidate();
        }*/

        #endregion

        void LoadSprite2D(string fileName, Sprite sprite)
        {
            Cursor = Cursors.WaitCursor;

            contentBuilder = new ContentBuilder();
            contentManager = new ContentManager(this.Services,
                                                contentBuilder.OutputDirectory);

            contentManager.Unload();
            contentBuilder.Clear();

            contentBuilder.Add(fileName, fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - fileName.LastIndexOf(@"\") - 5), null, null);

            string buildError = contentBuilder.Build();
            if (string.IsNullOrEmpty(buildError))
            {
                sprite.SpriteTexture = contentManager.Load<Texture2D>(fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - fileName.LastIndexOf(@"\") - 5));
                
            }
            Cursor = Cursors.Default;
        }

        public void ItemUpdate()
        {
            if (MapEditor.Services.UsefulTools.hasSelectedSprite == true)
            {
                var mouseState = Mouse.GetState();

                if (_selectedSprite.HasInitialized == false)
                {
                    LoadSprite2D(UsefulTools.SelectedSprite.SelectedPicBox.PictureFilePath, _selectedSprite);

                    _selectedSprite.HasInitialized = true;

                }
            }
        }

        void TickWhileIdle(object sender, EventArgs e)
        {
            NativeMethods.Message message;

            while (!NativeMethods.PeekMessage(out message, IntPtr.Zero, 0, 0, 0))
            {
                Tick(sender, e);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (hasFocusedSprite == true)
            {
                var rc = new System.Drawing.Rectangle(focusedSprite.TextureRec.X, focusedSprite.TextureRec.Y, focusedSprite.TextureRec.Width, focusedSprite.TextureRec.Height);
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
            }
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);
                if (UsefulTools.hasSelectedSprite == true && _selectedSprite.SpriteTexture != null)
                    spriteBatch.Draw(_selectedSprite.SpriteTexture, _selectedSprite.TextureRec, Microsoft.Xna.Framework.Color.White);

                if (_listSprites.Count > 0)
                {
                   for(int i = 0; i < _listSprites.Count; i++)
                    {
                        spriteBatch.Draw(_listSprites[i].SpriteTexture, _listSprites[i].TextureRec, Microsoft.Xna.Framework.Color.White);
                    }
                }
                spriteBatch.End();
        }
    }
}
