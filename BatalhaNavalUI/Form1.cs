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
                    PictureBox celula = CreateCelula(grid, player, tamanhoCelula, x, y);
                    celula.Size = tamanhoCelula;
                    grid.Controls.Add(celula, x, y);
                }
            }
        }

        public PictureBox CreateCelula(TableLayoutPanel grid, Player player, Size tamanho, int x, int y)
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
            btn.DragDrop += (o,s) => dropBarco(grid, btn, x, y);

            return btn;
        }

        void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        void dropBarco(TableLayoutPanel tb, PictureBox pb, int x, int y)
        {
            PictureBox pb1 = criaImagemParteBarco(BatalhaNavalUI.Properties.Resources.b0101);
            PictureBox pb2 = criaImagemParteBarco(BatalhaNavalUI.Properties.Resources.b0102);
            PictureBox pb3 = criaImagemParteBarco(BatalhaNavalUI.Properties.Resources.b0103);
            PictureBox pb4 = criaImagemParteBarco(BatalhaNavalUI.Properties.Resources.b0104);
            PictureBox pb5 = criaImagemParteBarco(BatalhaNavalUI.Properties.Resources.b0105);
            tb.Controls.Add(pb1, x, y);
            tb.Controls.Add(pb2, x+1, y);
            tb.Controls.Add(pb3, x+2, y);
            tb.Controls.Add(pb4, x+3, y);
            tb.Controls.Add(pb5, x+4, y);

        }

        private PictureBox criaImagemParteBarco(Bitmap b0101)
        {
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = b0101;
            pb.Size = new Size { Height = 40, Width = 40 };
            return pb;
        }

        void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            if (sender == barco1)
            {
                
            }
            ((PictureBox)sender).Image = bmp;
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
            var img = barco1.Image;
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
