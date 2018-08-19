using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class DungeonMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Room[,] Rooms { get; private set; }

        public DungeonMap()
        {

        }

        public void Generate(int width, int height)
        {
            Width = width;
            Height = height;
            Rooms = new Room[Height, Width];
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (c % 2 == 0) CreateRoom(r, c);
                }
            }
        }

        private void CreateRoom(int r, int c)
        {
            Rooms[r, c] = new Room();
        }
    }
}
