using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class Room
    {
        public TileMap TileMap { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int[,] Data {
            get { return data; }
            set
            {
                data = value;
                Width = data.GetLength(0);
                Height = data.GetLength(1);
            }
        }
        private int[,] data;

        /// <summary>
        /// True if there is a door Up / Right / Down / Left
        /// </summary>
        public bool[] Doors { get; private set; }

        public Room(int x, int y)
        {
            X = x;
            Y = y;
            Generate();
            Doors = new bool[4] { false, false, false, false };
        }

        private void Generate()
        {
            Data = new int[,]
            {
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 2, 2, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 2, 2, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }
            };
        }
    }
}
