using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCapture2
{
    public partial class Form1 : Form
    {
        ImageFormat img; Bitmap bt; Graphics screenShot;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.Hide();
                    // This gives time to the Form to hide before it takes the screenshot. 500 miliseconds are enough.
                    Thread.Sleep(500);
                    // Set the image to the size of the screen.
                    bt = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                    // Creates the graphic object for the image (bt).    
                    screenShot = Graphics.FromImage(bt);
                    // Takes the screenshot.
                    screenShot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size,

                CopyPixelOperation.SourceCopy);
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 0: img = ImageFormat.Bmp; break;
                        case 1: img = ImageFormat.Png; break;
                        case 2: img = ImageFormat.Jpeg; break;
                    }
                    // Saves the image.
                    bt.Save(saveFileDialog1.FileName, img);
                    // After the screenshot is taken the Form reappears.
                    this.Show();
                }
            }

            catch (Exception i)
            {
                MessageBox.Show("Error: "+i.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome To iCapture (i For Ijaz :p)\n"+
                "Simple Screen Capturing Tool\n"+
                "Just Click On Capture And Select Save Path with Image Format\n"+
                "Currently Three Image Type Supported\n"+
                "1: .PNG\n2: .BMP\n3: .JPG\n"+
                "Syntax --> File_Name.Format\n"+
                "Must Describe Image Format After . (Dot), Otherwise Blank File");
        }
    }
}
