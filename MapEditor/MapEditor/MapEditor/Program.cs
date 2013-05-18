using System;
using System.Windows.Forms;
using MapEditor.EditorForms;

namespace MapEditor
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (MapWinForms editor = new MapWinForms())
            {
                Application.Run(editor);
            }
        }


    }

}

