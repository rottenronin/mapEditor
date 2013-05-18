namespace MapEditor.EditorForms
{
    partial class MapWinForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapDisplayer_panel = new System.Windows.Forms.Panel();
            this.mapDisplayer1 = new MapEditor.CustomControls.MapDisplayer();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapDisplayer_hScrollBar = new System.Windows.Forms.HScrollBar();
            this.mapDisplayer_vScrollBar = new System.Windows.Forms.VScrollBar();
            this.items_GBox = new System.Windows.Forms.GroupBox();
            this.addSprite_button = new System.Windows.Forms.Button();
            this.pictureBox_panel = new System.Windows.Forms.Panel();
            this.property_groupBox = new System.Windows.Forms.GroupBox();
            this.pictureSize_groupBox = new System.Windows.Forms.GroupBox();
            this.picture_height = new System.Windows.Forms.Label();
            this.pictureHeight_textBox = new System.Windows.Forms.TextBox();
            this.pictureWidth_textBox = new System.Windows.Forms.TextBox();
            this.picture_width = new System.Windows.Forms.Label();
            this.pictureBoxName_textBox = new System.Windows.Forms.TextBox();
            this.pictureBox_name = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ItemsGroupeBox = new System.Windows.Forms.GroupBox();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.mapDisplayer_panel.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.items_GBox.SuspendLayout();
            this.property_groupBox.SuspendLayout();
            this.pictureSize_groupBox.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.ItemsGroupeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapDisplayer_panel
            // 
            this.mapDisplayer_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapDisplayer_panel.Controls.Add(this.mapDisplayer1);
            this.mapDisplayer_panel.Location = new System.Drawing.Point(12, 3);
            this.mapDisplayer_panel.Name = "mapDisplayer_panel";
            this.mapDisplayer_panel.Size = new System.Drawing.Size(784, 590);
            this.mapDisplayer_panel.TabIndex = 0;
            // 
            // mapDisplayer1
            // 
            this.mapDisplayer1.Location = new System.Drawing.Point(36, 19);
            this.mapDisplayer1.Name = "mapDisplayer1";
            this.mapDisplayer1.Size = new System.Drawing.Size(712, 522);
            this.mapDisplayer1.TabIndex = 0;
            this.mapDisplayer1.Text = "mapDisplayer1";
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1289, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mapDisplayer_hScrollBar
            // 
            this.mapDisplayer_hScrollBar.Location = new System.Drawing.Point(12, 596);
            this.mapDisplayer_hScrollBar.Name = "mapDisplayer_hScrollBar";
            this.mapDisplayer_hScrollBar.Size = new System.Drawing.Size(776, 22);
            this.mapDisplayer_hScrollBar.TabIndex = 2;
            // 
            // mapDisplayer_vScrollBar
            // 
            this.mapDisplayer_vScrollBar.Location = new System.Drawing.Point(799, 3);
            this.mapDisplayer_vScrollBar.Name = "mapDisplayer_vScrollBar";
            this.mapDisplayer_vScrollBar.Size = new System.Drawing.Size(19, 615);
            this.mapDisplayer_vScrollBar.TabIndex = 3;
            // 
            // items_GBox
            // 
            this.items_GBox.Controls.Add(this.addSprite_button);
            this.items_GBox.Location = new System.Drawing.Point(834, 3);
            this.items_GBox.Name = "items_GBox";
            this.items_GBox.Size = new System.Drawing.Size(416, 379);
            this.items_GBox.TabIndex = 4;
            this.items_GBox.TabStop = false;
            this.items_GBox.Text = "Items";
            // 
            // addSprite_button
            // 
            this.addSprite_button.Location = new System.Drawing.Point(296, 350);
            this.addSprite_button.Name = "addSprite_button";
            this.addSprite_button.Size = new System.Drawing.Size(114, 23);
            this.addSprite_button.TabIndex = 1;
            this.addSprite_button.Text = "Add";
            this.addSprite_button.UseVisualStyleBackColor = true;
            // 
            // pictureBox_panel
            // 
            this.pictureBox_panel.Location = new System.Drawing.Point(840, 23);
            this.pictureBox_panel.Name = "pictureBox_panel";
            this.pictureBox_panel.Size = new System.Drawing.Size(404, 325);
            this.pictureBox_panel.TabIndex = 2;
            // 
            // property_groupBox
            // 
            this.property_groupBox.Controls.Add(this.pictureSize_groupBox);
            this.property_groupBox.Controls.Add(this.pictureBoxName_textBox);
            this.property_groupBox.Controls.Add(this.pictureBox_name);
            this.property_groupBox.Location = new System.Drawing.Point(834, 396);
            this.property_groupBox.Name = "property_groupBox";
            this.property_groupBox.Size = new System.Drawing.Size(413, 180);
            this.property_groupBox.TabIndex = 5;
            this.property_groupBox.TabStop = false;
            this.property_groupBox.Text = "Property";
            // 
            // pictureSize_groupBox
            // 
            this.pictureSize_groupBox.Controls.Add(this.picture_height);
            this.pictureSize_groupBox.Controls.Add(this.pictureHeight_textBox);
            this.pictureSize_groupBox.Controls.Add(this.pictureWidth_textBox);
            this.pictureSize_groupBox.Controls.Add(this.picture_width);
            this.pictureSize_groupBox.Location = new System.Drawing.Point(21, 91);
            this.pictureSize_groupBox.Name = "pictureSize_groupBox";
            this.pictureSize_groupBox.Size = new System.Drawing.Size(370, 63);
            this.pictureSize_groupBox.TabIndex = 2;
            this.pictureSize_groupBox.TabStop = false;
            this.pictureSize_groupBox.Text = "size";
            // 
            // picture_height
            // 
            this.picture_height.AutoSize = true;
            this.picture_height.Location = new System.Drawing.Point(208, 29);
            this.picture_height.Name = "picture_height";
            this.picture_height.Size = new System.Drawing.Size(36, 13);
            this.picture_height.TabIndex = 3;
            this.picture_height.Text = "height";
            // 
            // pictureHeight_textBox
            // 
            this.pictureHeight_textBox.Location = new System.Drawing.Point(249, 26);
            this.pictureHeight_textBox.Name = "pictureHeight_textBox";
            this.pictureHeight_textBox.Size = new System.Drawing.Size(100, 20);
            this.pictureHeight_textBox.TabIndex = 2;
            // 
            // pictureWidth_textBox
            // 
            this.pictureWidth_textBox.Location = new System.Drawing.Point(48, 26);
            this.pictureWidth_textBox.Name = "pictureWidth_textBox";
            this.pictureWidth_textBox.Size = new System.Drawing.Size(100, 20);
            this.pictureWidth_textBox.TabIndex = 1;
            // 
            // picture_width
            // 
            this.picture_width.AutoSize = true;
            this.picture_width.Location = new System.Drawing.Point(7, 29);
            this.picture_width.Name = "picture_width";
            this.picture_width.Size = new System.Drawing.Size(32, 13);
            this.picture_width.TabIndex = 0;
            this.picture_width.Text = "width";
            // 
            // pictureBoxName_textBox
            // 
            this.pictureBoxName_textBox.Location = new System.Drawing.Point(93, 33);
            this.pictureBoxName_textBox.Name = "pictureBoxName_textBox";
            this.pictureBoxName_textBox.Size = new System.Drawing.Size(100, 20);
            this.pictureBoxName_textBox.TabIndex = 1;
            // 
            // pictureBox_name
            // 
            this.pictureBox_name.AutoSize = true;
            this.pictureBox_name.Location = new System.Drawing.Point(18, 33);
            this.pictureBox_name.Name = "pictureBox_name";
            this.pictureBox_name.Size = new System.Drawing.Size(68, 13);
            this.pictureBox_name.TabIndex = 0;
            this.pictureBox_name.Text = "picture name";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.ItemsGroupeBox);
            this.mainPanel.Controls.Add(this.pictureBox_panel);
            this.mainPanel.Controls.Add(this.property_groupBox);
            this.mainPanel.Controls.Add(this.mapDisplayer_panel);
            this.mainPanel.Controls.Add(this.mapDisplayer_hScrollBar);
            this.mainPanel.Controls.Add(this.mapDisplayer_vScrollBar);
            this.mainPanel.Controls.Add(this.items_GBox);
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1289, 753);
            this.mainPanel.TabIndex = 6;
            // 
            // ItemsGroupeBox
            // 
            this.ItemsGroupeBox.Controls.Add(this.ItemsPanel);
            this.ItemsGroupeBox.Location = new System.Drawing.Point(12, 641);
            this.ItemsGroupeBox.Name = "ItemsGroupeBox";
            this.ItemsGroupeBox.Size = new System.Drawing.Size(784, 101);
            this.ItemsGroupeBox.TabIndex = 6;
            this.ItemsGroupeBox.TabStop = false;
            this.ItemsGroupeBox.Text = "Items";
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.Location = new System.Drawing.Point(6, 16);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(770, 79);
            this.ItemsPanel.TabIndex = 0;
            // 
            // MapWinForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 782);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MapWinForms";
            this.Text = "MapWinForms";
            this.Load += new System.EventHandler(this.MapWinForms_Load);
            this.mapDisplayer_panel.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.items_GBox.ResumeLayout(false);
            this.property_groupBox.ResumeLayout(false);
            this.property_groupBox.PerformLayout();
            this.pictureSize_groupBox.ResumeLayout(false);
            this.pictureSize_groupBox.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ItemsGroupeBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mapDisplayer_panel;
        private CustomControls.MapDisplayer mapDisplayer1;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.HScrollBar mapDisplayer_hScrollBar;
        private System.Windows.Forms.VScrollBar mapDisplayer_vScrollBar;
        private System.Windows.Forms.GroupBox items_GBox;
        private System.Windows.Forms.Button addSprite_button;
        private System.Windows.Forms.Panel pictureBox_panel;
        private System.Windows.Forms.GroupBox property_groupBox;
        private System.Windows.Forms.Label pictureBox_name;
        private System.Windows.Forms.TextBox pictureBoxName_textBox;
        private System.Windows.Forms.GroupBox pictureSize_groupBox;
        private System.Windows.Forms.TextBox pictureWidth_textBox;
        private System.Windows.Forms.Label picture_width;
        private System.Windows.Forms.Label picture_height;
        private System.Windows.Forms.TextBox pictureHeight_textBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox ItemsGroupeBox;
        private System.Windows.Forms.Panel ItemsPanel;

    }
}