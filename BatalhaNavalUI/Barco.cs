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
        HORIZONTAL
    }
    class Barco
    {
        public Point Ponto1 { get; private set; }
        public int Tamanho { get; }
        public Point Ponto2 { get; private set; }
        public List<Image> Image { get; private set; }
        public Horientacao Horientacao { get; }

        public Dictionary<Point, Image> partesBarco;

        public Barco(Point ponto1, int tamanho, List<Image> imagens, Horientacao horientacao)
        {
            partesBarco = new Dictionary<Point, Image>();
            Ponto1 = ponto1;
            Tamanho = tamanho;

            switch (horientacao)
            {
                case Horientacao.VERTICAL:
                    for (int indice = 0; indice < imagens.Count; indice++)
                    {
                        partesBarco.Add(new Point { X = ponto1.X + indice, Y = ponto1.Y  }, imagens.ElementAt(indice));
                    }

                    break;
                case Horientacao.HORIZONTAL:
                    for (int indice = 0; indice < imagens.Count; indice++)
                    {
                        partesBarco.Add(new Point { X = ponto1.X , Y = ponto1.Y + indice }, imagens.ElementAt(indice));
                    }
                    break;
                default:
                    break;
            }
            Image = imagens;
            Horientacao = horientacao;
        }

        public Image acertou(Point point)
        {
            Image value;
            if (partesBarco.TryGetValue(point, out value))
            {
                if (Horientacao == Horientacao.HORIZONTAL)
                {
                    value.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            
            return value;
        }
    }
}
