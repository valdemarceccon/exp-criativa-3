using System.Collections.Generic;
using System.Drawing;

namespace BatalhaNavalGameLogic
{
    public class Player
    {
        public List<Point> posicoesBarcos;

        public Player()
        {
            posicoesBarcos = new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(1,3)
            };
        }

        public bool atirar(Player outroPlayer, int x, int y)
        {
            return temBarco(x, y);
        }

        public bool temBarco(int x, int y)
        {
            return posicoesBarcos.Contains(new Point(x, y));
        }
    }
}