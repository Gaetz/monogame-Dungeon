using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Utils
{
    static class IsometricTools
    {
        static public Point To3D(Point coords)
        {
            return new Point(
                coords.X - coords.Y,
                (coords.X + coords.Y) / 2
            );
        }
    }
}
