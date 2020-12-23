using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Saver_App
{
    public partial class formScreenSaver : Form
    {
        List<Image> SCImages = new List<Image>(); //This holds an array of images.
        List<SpaceCatPic> SpaceCatPics = new List<SpaceCatPic>(); //This holds an array of objects that will define the posistions of pictures.
        Random random = new Random();

        class SpaceCatPic {
            public int PicNum;
            public float X;
            public float Y;
        }

        public formScreenSaver()
        {
            InitializeComponent();
        }

        private void formScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void formScreenSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("images");

            foreach (string image in images)
            {
                SCImages.Add(new Bitmap(image));
            }

            for (int i = 0; i < 125; ++i)
            {
                SpaceCatPic scp = new SpaceCatPic();
                scp.PicNum = i % SCImages.Count;
                scp.X = random.Next(0, Width);
                scp.Y = random.Next(0, Height);

                SpaceCatPics.Add(scp);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void formScreenSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach (SpaceCatPic s in SpaceCatPics)
            {
                e.Graphics.DrawImage(SCImages[s.PicNum], s.X, s.Y);
                s.X = random.Next(0, Width);
                s.Y = random.Next(0, Height);
            }
        }
    }
}
