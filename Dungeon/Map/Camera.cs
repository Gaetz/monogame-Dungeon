using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class Camera
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point Coords
        {
            get
            {
                return new Point(X, Y);
            }
        }
        public int Speed { get; private set; }


        public Camera()
        {
            X = 0;
            Y = 0;
            Speed = 10;
        }
    }
}
