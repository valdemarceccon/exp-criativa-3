using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNavalUI
{
    public partial class Form1 : Form
    {

        Random random = new Random();

        List<Barco> barcos;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iniciarJogo();          
        }

        private void iniciarJogo()
        {

            //limpaTabuleiro();
            PreparaGrid(this.tableLayoutPanel1);
            barcos = new List<Barco>();
            List<List<Image>> imageBarcos = new List<List<Image>>() {
                new List<Image>() { BatalhaNavalUI.Properties.Resources.b0101, BatalhaNavalUI.Properties.Resources.b0102, BatalhaNavalUI.Properties.Resources.b0103, BatalhaNavalUI.Properties.Resources.b0104, BatalhaNavalUI.Properties.Resources.b0105 },
                new List<Image>() { BatalhaNavalUI.Properties.Resources.b0201, BatalhaNavalUI.Properties.Resources.b0202, BatalhaNavalUI.Properties.Resources.b0203, BatalhaNavalUI.Properties.Resources.b0204 },
                new List<Image>() { BatalhaNavalUI.Properties.Resources.b0301, BatalhaNavalUI.Properties.Resources.b0302, BatalhaNavalUI.Properties.Resources.b0303 },
                new List<Image>() { BatalhaNavalUI.Properties.Resources.b0401, BatalhaNavalUI.Properties.Resources.b0402, BatalhaNavalUI.Properties.Resources.b0403 },
                new List<Image>() { BatalhaNavalUI.Properties.Resources.b0501, BatalhaNavalUI.Properties.Resources.b0502 },
            };

            foreach (List<Image> barco in imageBarcos)
            {
                Barco novoBarco = criarBarcoRandomico(barco.Count, barco);
                barcos.Add(novoBarco);
            }

        }

        private Barco criarBarcoRandomico(int tamanho, List<Image> imagem)
        {
            int x1 = random.Next(10);
            int y1 = random.Next(10);
            Point origin = new Point(x1, y1);
            Horientacao horientacao = randomHorientacao();
            return new Barco(origin, tamanho, imagem, horientacao);
        }

        private Horientacao randomHorientacao()
        {
            Array values = Enum.GetValues(typeof(Horientacao));
            return (Horientacao)values.GetValue(random.Next(values.Length));
        }

        private void PreparaGrid(TableLayoutPanel grid)
        {
            var tamanhoCelula = new Size { Height = tableLayoutPanel1.Size.Height / 10, Width = tableLayoutPanel1.Size.Width / 10 };
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    grid.Padding = new Padding { All = 0 };
                    PictureBox celula = CreateCelula(tamanhoCelula, new Point { X = x, Y = y });
                    celula.Size = tamanhoCelula;
                    grid.Controls.Add(celula, x, y);
                }
            }
        }

        private Image getBarco(Point p)
        {

            foreach (Barco barco in barcos)
            {
                Image image = barco.acertou(p);
                if (image != null)
                {
                    return image;
                }
            }

            return null;
        }

        public PictureBox CreateCelula(Size tamanho, Point p)
        {
            PictureBox btn = new PictureBox();
            btn.BackColor = Color.Transparent;
            btn.Size = tamanho;
            btn.SizeMode = PictureBoxSizeMode.StretchImage;

            btn.Click += (o, s) => atirar(btn, p);
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
        }

        public void atirar(PictureBox btn, Point p)
        {
            Image barco = getBarco(p);
            if (barco != null)
            {
                //btn.Image = barco;
                btn.BackColor = Color.Green;
            }
            else
            {
                btn.BackColor = Color.Red;
            }
        }

        private void TableLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine();
        }

        bool vertical;

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
            vertical = !vertical;
            Size novoTamanho = new Size { Height = barco1.Size.Width, Width = barco1.Size.Height };
            barco1.Size = novoTamanho;

            if (vertical == true)
            {
                barco1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            if (vertical == false)
            {
                barco1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            barco1.Refresh();

        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            iniciarJogo();
        }
    }
}
