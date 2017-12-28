using System.Diagnostics;
using EmrDocker.Glossary;

namespace IHIS.OCSO
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using PaintDotNet;
    using PaintDotNet.SystemLayer;

    public delegate void InsertToEditor(byte[] imageData, float scaleX, float scaleY);

    public interface IImageEditor
    {
        void Edit(string filePath, string linkLocation, TypeEnum typeEnum, float scaleX, float scaleY, InsertToEditor callback, Control control, bool showControl);
    }

    class PdnEditor : IImageEditor
    {
        private MainForm mainForm;
        private string[] args;

        public void Edit(string filePath, string linkLocation, TypeEnum typeEnum, float scaleX, float scaleY, InsertToEditor callback, Control control, bool showControl)
        {
            // Create main window
            if (typeEnum == TypeEnum.Pdf)
            {
                Process.Start(linkLocation);
            }
            else
            {
                //Check for jpg
                SingleInstanceManager singleInstanceManager = new SingleInstanceManager("PaintDotNet");

                args = new string[] { filePath };
                // If this is not the first instance of PDN.exe, then forward the command-line
                // parameters over to the first instance.
                if (!singleInstanceManager.IsFirstInstance)
                {
                    singleInstanceManager.FocusFirstInstance();

                    foreach (string arg in this.args)
                    {
                        singleInstanceManager.SendInstanceMessage(arg, 30);
                    }

                    singleInstanceManager.Dispose();

                    return;
                }

                if (showControl)
                {
                    this.mainForm = new MainForm(this.args);

                    // if the display is set to a portrait mode (tall), then orient the PDN window the same way
                    if (this.mainForm.ScreenAspect < 1.0)
                    {
                        int width = mainForm.Width;
                        int height = mainForm.Height;

                        this.mainForm.Width = height;
                        this.mainForm.Height = width;
                    }

                    // if the window opens and part of it is off screen, correct this
                    Screen screen = Screen.FromControl(this.mainForm);

                    Rectangle intersect = Rectangle.Intersect(screen.Bounds, mainForm.Bounds);
                    if (intersect.Width == 0 || intersect.Height == 0)
                    {
                        mainForm.Location = new Point(screen.Bounds.Left + 16, screen.Bounds.Top + 16);
                    }

                    // if the window is not big enough, correct this
                    if (this.mainForm.Width < 200)
                    {
                        this.mainForm.Width = 200; // this value was chosen arbitrarily
                    }

                    if (this.mainForm.Height < 200)
                    {
                        this.mainForm.Height = 200; // this value was chosen arbitrarily
                    }

                    Startup startup = new Startup(mainForm);
                    this.mainForm.SingleInstanceManager = singleInstanceManager;

                    this.mainForm.ShowDialog(control);
                    this.mainForm.Dispose();
                }
            }

            callback(File.ReadAllBytes(filePath), scaleX, scaleY);
        }
    }

    class ImageEditor : IImageEditor
    {
        public void Edit(string filePath, string linkLocation, TypeEnum typeEnum, float scaleX, float scaleY, InsertToEditor callback, Control control, bool showControl)
        {
            callback(File.ReadAllBytes(filePath), scaleX, scaleY);
        }
    }
}