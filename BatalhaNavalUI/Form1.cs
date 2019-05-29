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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            preparaGrid(this.tableLayoutPanel1);
            //preparaGrid(this.tableLayoutPanel2);
        }

        private void preparaGrid(TableLayoutPanel grid)
        {
            var tamanhoCelula = new Size { Height = tableLayoutPanel1.Size.Height / 10, Width = tableLayoutPanel1.Size.Width / 10 };
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    grid.Padding = new Padding { All = 0 };
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.Transparent;
                    btn.Size = tamanhoCelula;
                    btn.Click += new AcaoTiro(x, y).atirar;
                    btn.Margin = new Padding { All = 0 };
                    grid.Controls.Add(btn, x, y);
                }
            }
        }


    }

    public class AcaoTiro
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public AcaoTiro(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void atirar(object o, EventArgs a)
        {
            Button btn = (Button)o;
            btn.Image = BatalhaNavalUI.Properties.Resources.splash;
        }
    }
}
