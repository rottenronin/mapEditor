using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MapEditor.Services
{
    public class FolderBrowserService
    {
        private FolderBrowserDialog folderBrowserDialog;

        public FolderBrowserService()
        {
            folderBrowserDialog = new FolderBrowserDialog();
        }

        public bool HaveFilesSelected()
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return true;
            }

            return false;
        }

        public string[] GetSelectedFiles()
        {
            string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);

            return files;
        }
    }
}
