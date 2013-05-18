using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MapEditor.Services;

namespace MapEditor.EditorForms
{
    public partial class MapWinForms : Form
    {
        private OpenFileDialog openFileDialog;

        private int picturebox_CurrentColumn = 0;
        private int picturebox_CurrentRow = 0;

        

        public MapWinForms()
        {
            InitializeComponent();

            this.CustomInitialize();
        }

        private void CustomInitialize()
        {
            MapEditor.Services.UsefulTools.SelectedSprite = new Models.SelectedSprite();
            MapEditor.Services.UsefulTools.hasSelectedSprite = false;
            MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox = null;
            MapEditor.Services.UsefulTools.SelectedSprite.AddedToPanel = false;

            this.addSprite_button.Click += new EventHandler(AddButton_Click);

           // this.Paint += new PaintEventHandler(Form_Paint);
           // this.mainPanel.MouseMove += new MouseEventHandler(MouseMove_Handler);

            #region init openfileDialog

            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.Filter = "Images (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|" +
        "All files (*.*)|*.*";

            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select Images";

            #endregion

            this.pictureBox_panel.AutoScroll = true;
            this.ItemsPanel.AutoScroll = true;
            this.pictureBoxName_textBox.TextChanged += new EventHandler(TextChanged_handler);
        }


        private void Form_Paint(object sender, PaintEventArgs e)
        {
            if (MapEditor.Services.UsefulTools.hasSelectedSprite == true)
            {
           // var mouseState = Mouse.GetState();

            var local = Cursor.Position;
            if (MapEditor.Services.UsefulTools.hasSelectedSprite == true)
                e.Graphics.DrawImage(MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox.OriginalImage, local.X, local.Y);
            }
        }

        private void MouseMove_Handler(object sender, MouseEventArgs e)
        {
            var mouseState = Cursor.Position;

            Console.WriteLine("x : " + e.X + " Y : " + e.Y + "\nMouseState_X: " + mouseState.X + " MouseState_Y: " + mouseState.Y);

            if (MapEditor.Services.UsefulTools.hasSelectedSprite == true)
            {
               // if (MapEditor.Services.UsefulTools.SelectedSprite.AddedToPanel == false)
                //{
                    //this.Controls.Add(MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox);
                   // this.Cursor = new Cursor(MapEditor.Services.UsefulTools.SelectedSprite.SelectedPicBox.PictureFilePath);
                Invalidate();
                //}
            }
        }

        private void TextChanged_handler(object sender, System.EventArgs e)
        {

        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    try
                    {
                        Image img = new Bitmap(file);

                       var pic = new SelectablePictureBox
                       {
                           OriginalImage = img,
                           PictureFilePath = file,
                           PictureFileName = openFileDialog.SafeFileName,
                           Width = 120,
                           Height = 120,
                           Location = new Point
                           {
                               X = picturebox_CurrentColumn * (100 + 3),
                               Y = picturebox_CurrentRow * (100 + 3)
                           },
                           Image = MapEditor.Services.UsefulTools.GetThumbnail(img),
                       };
                       picturebox_CurrentColumn++;
                       if (picturebox_CurrentColumn >= 3)
                       {
                           picturebox_CurrentColumn = 0;
                           picturebox_CurrentRow++;
                       }
                       pic.MouseDown += new MouseEventHandler(PictureBox_Clicked);
                       pic.MouseDown += new MouseEventHandler(PictureBox_MouseDown);

                        pictureBox_panel.Controls.Add(pic);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private Image Bitmap(string file)
        {
            throw new NotImplementedException();
        }

        #region pictureBox click event handler 

        private void PictureBox_Clicked(object sender, MouseEventArgs e)
        {
            SelectablePictureBox pictureBox = sender as SelectablePictureBox;

            pictureBoxName_textBox.Text = pictureBox.PictureFileName;
            this.pictureWidth_textBox.Text = pictureBox.GetPictureWidth().ToString();
            this.pictureHeight_textBox.Text = pictureBox.GetPictureHeight().ToString();

        }

        #endregion

        #region pictureBox drag operation

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            SelectablePictureBox pictureBox = sender as SelectablePictureBox;

            pictureBox.DoDragDrop(pictureBox.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        #endregion

        private void MapWinForms_Load(object sender, EventArgs e)
        {
        }

        


    }

}
