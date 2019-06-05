using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BatalhaNavalGameLogic;

namespace BatalhaNavalUI
{
    public partial class Form1 : Form
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player1 = new Player();
            Player2 = new Player();
            PreparaGrid(this.tableLayoutPanel1, Player1);
            PreparaGrid(this.tableLayoutPanel2, Player2);
        }

        private void PreparaGrid(TableLayoutPanel grid, Player player)
        {
            var tamanhoCelula = new Size { Height = tableLayoutPanel1.Size.Height / 10, Width = tableLayoutPanel1.Size.Width / 10 };
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    grid.Padding = new Padding { All = 0 };
                    PictureBox celula = CreateCelula(player, tamanhoCelula, x, y);
                    celula.Size = tamanhoCelula;
                    grid.Controls.Add(celula, x, y);
                }
            }
        }

        public PictureBox CreateCelula(Player player, Size tamanho, int x, int y)
        {
            PictureBox btn = new PictureBox();
            btn.BackColor = Color.Transparent;
            btn.Size = tamanho;
            btn.SizeMode = PictureBoxSizeMode.StretchImage;

            btn.Click += (o, s) => atirar(player, btn, x, y);
            btn.MouseEnter += (o, s) => btn.BackColor = Color.Red;
            btn.MouseLeave += (o, s) => btn.BackColor = Color.Transparent;
            btn.AllowDrop = true;
            btn.DragEnter += pictureBox2_DragEnter;
            btn.DragDrop += pictureBox2_DragDrop;

            return btn;
        }

        void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            ((PictureBox)sender).Image = bmp;
            //pictureBox2.Image = bmp;
        }

        public void atirar(Player player, PictureBox btn, int x, int y)
        {
            if (player.temBarco(x, y))
            {
                btn.Image = BatalhaNavalUI.Properties.Resources.explosão;
            }
            else
            {
                btn.Image = BatalhaNavalUI.Properties.Resources.splash;
            }
        }

        private void TableLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var img = pictureBox1.Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                
            }
        }

        private void B_rotacao_Click(object sender, EventArgs e)
        {

        }
    }
}
