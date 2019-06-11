using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNavalUI
{
    enum Horientacao
    {
        VERTICAL,
        HORIGINAL
    }
    class Barco
    {
        public Point Ponto1 { get; private set; }
        public Point Ponto2 { get; private set; }
        public Image Image { get; private set; }

        public Barco(Point ponto1, int tamanho, Image image, Horientacao horientacao)
        {
            Ponto1 = ponto1;
            switch (horientacao)
            {
                case Horientacao.VERTICAL:

                    Ponto2 = new Point { X = ponto1.X , Y = ponto1.Y + tamanho };
                    break;
                case Horientacao.HORIGINAL:
                    Ponto2 = new Point { X = ponto1.X + tamanho, Y = ponto1.Y };
                    break;
                default:
                    break;
            }
            Image = image;
        }
    }
}
