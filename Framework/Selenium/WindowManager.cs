using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Support.Extensions;

namespace Framework.Selenium
{
    public class WindowManager
    {
        public ReadOnlyCollection<string> CurrentWindows => Driver.Current.WindowHandles;

        public void SwitchTo(int windowIndex)
        {
            Driver.Current.SwitchTo().Window(CurrentWindows[windowIndex]);
        }

        public Size ScreenSize
        {
            get
            {
                var js = "return [window.screen.availWidth, window.screen.availHeight];";
                var dimensions = Driver.Current.ExecuteJavaScript<ReadOnlyCollection<object>>(js, null);
                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public void Maximize()
        {
            Driver.Current.Manage().Window.Position = new Point(0, 0);
            Driver.Current.Manage().Window.Size = ScreenSize;
        }
    }
}
