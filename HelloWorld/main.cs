using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using System.Drawing;

namespace HelloWorld
{
    class main
    {

        private static Surface _videoScreen;
        private static Surface _image;
        private static Point _imagePos;

        private static void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }

        private static void ApplicationTickEventHandler(object sender, TickEventArgs args)
        {
            _videoScreen.Blit(_image, _imagePos);
            _videoScreen.Update();
        }

        static int Main(string[] agrs)
        {
            _videoScreen = Video.SetVideoMode(800, 600);

            _image = (new Surface(@"Hello-World.png")).Convert(_videoScreen, true, false);

            _imagePos = new Point(_videoScreen.Width / 2 - _image.Width / 2,
                                  _videoScreen.Height / 2 - _image.Height / 2);


            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);
            Events.Tick += new EventHandler<TickEventArgs>(ApplicationTickEventHandler);
            Events.Run();

            return 0;
        }
    }
}
