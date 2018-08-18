using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Dungeon.Map
{
    class Tilemap
    {
        public int mapWidth { get; private set; }
        public int mapHeight { get; private set; }
        public int tileWidth2D { get; private set; }
        public int tileHeight2D { get; private set; }
        public int tileWidth3D { get; private set; }
        public int tileHeight3D { get; private set; }

        private int[,] data;

        public Tilemap()
        {

        }

        public void SetTileSize2D(int tileWidth, int tileHeight)
        {
            tileWidth2D = tileWidth;
            tileHeight2D = tileHeight;
        }


        public void SetTileSize3D(int tileWidth, int tileHeight)
        {
            tileWidth3D = tileWidth;
            tileHeight3D = tileHeight;
        }

        public void SetData(int[,] data)
        {
            this.data = data;
            mapWidth = data.GetLength(0);
            mapHeight = data.GetLength(1);
        }

        public int GetTileId(int row, int col)
        {
            if (row >= 0 && row < mapHeight && col >= 0 && col < mapWidth)
                return data[row, col];
            return -1;
        }

        public Point To3D(Point coords)
        {
            return new Point(
                coords.X - coords.Y,
                (coords.X + coords.Y) / 2
            );
        }
    }
}
