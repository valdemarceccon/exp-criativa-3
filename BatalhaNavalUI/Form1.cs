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
                    Button celula = CreateCelula(player, tamanhoCelula, x, y);
                    //CelulaBatalhaNaval celula = new CelulaBatalhaNaval(x,y);
                    celula.Size = tamanhoCelula;
                    grid.Controls.Add(celula, x, y);
                }
            }
        }

        public Button CreateCelula(Player player, Size tamanho, int x, int y)
        {
            Button btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.Size = tamanho;

            btn.Click += (o, s) => atirar(player, btn, x, y);

            btn.MouseEnter += (o, s) => { btn.BackColor = Color.Red; };
            btn.MouseLeave += (o, s) => { btn.BackColor = Color.Transparent; };

            return btn;
        }

        public void atirar(Player player, Button btn, int x, int y)
        {
            if (player.temBarco(x, y))
            {
                btn.Image = BatalhaNavalUI.Properties.Resources.barco101;
            }
            else
            {
                btn.Image = BatalhaNavalUI.Properties.Resources.splash;
            }
        }
    }
}
