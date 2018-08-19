using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class Room
    {
        public TileMap tileMap { get; set; }

        public int[,] Data {
            get { return data; }
            set
            {
                data = value;
                width = data.GetLength(0);
                height = data.GetLength(1);
            }
        }
        private int[,] data;

        public int width { get; private set; }
        public int height { get; private set; }

        public Room()
        {
            Generate();
        }

        private void Generate()
        {
            Data = new int[,]
            {
                { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 2, 2, 2, 1, 1, 1, 1, 3 },
                { 2, 1, 2, 2, 2, 1, 1, 1, 1, 3 },
                { 2, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 1, 1, 1, 1, 1, 1, 1, 1, 3 },
                { 3, 2, 2, 2, 2, 2, 2, 2, 2, 3 },
                { 3, 3, 3, 3, 2, 2, 3, 3, 3, 3 }
            };
        }
    }
}
