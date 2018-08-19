using Dungeon.Utils.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class Room
    {
        IRandomService random;

        public TileMap TileMap { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private bool isCorridor;

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

        public Room(int x, int y, bool startOrLast = false)
        {
            random = Play.gameServices.GetService<IRandomService>();
            X = x;
            Y = y;
            if (startOrLast) isCorridor = false;
            else
            {
                isCorridor = random.Next(Balance.CorridorScarcity) == 0;
            }
            Generate();
            Doors = new bool[4] { false, false, false, false };
        }

        private void Generate()
        {
            if(isCorridor)
            {
                Data = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    { 0, 0, 0, 3, 2, 2, 3, 0, 0, 0 },
                    { 0, 0, 0, 3, 2, 2, 3, 0, 0, 0 },
                    { 0, 0, 0, 3, 3, 3, 3, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };
            }
            else
            {
                Data = new int[,] 
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 3, 3, 3, 3, 3, 3, 3, 3, 0 },
                    { 0, 3, 1, 1, 1, 1, 1, 1, 3, 0 },
                    { 0, 3, 1, 1, 1, 1, 1, 1, 3, 0 },
                    { 0, 3, 1, 1, 2, 2, 1, 1, 3, 0 },
                    { 0, 3, 1, 1, 2, 2, 1, 1, 3, 0 },
                    { 0, 3, 1, 1, 1, 1, 1, 1, 3, 0 },
                    { 0, 3, 1, 1, 1, 1, 1, 1, 3, 0 },
                    { 0, 3, 3, 3, 3, 3, 3, 3, 3, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };
            }

        }

        public void CreateDoor(Direction direction)
        {
            if (isCorridor)
            {
                switch (direction)
                {
                    case Direction.Up:
                        Data[0, 4] = 2;
                        Data[0, 5] = 2;
                        Data[0, 3] = 3;
                        Data[0, 6] = 3;
                        Data[1, 4] = 1;
                        Data[1, 5] = 1;
                        Data[1, 3] = 3;
                        Data[1, 6] = 3;
                        Data[2, 4] = 1;
                        Data[2, 5] = 1;
                        Data[2, 3] = 3;
                        Data[2, 6] = 3;
                        Data[3, 4] = 1;
                        Data[3, 5] = 1;
                        break;
                    case Direction.Down:
                        Data[9, 4] = 2;
                        Data[9, 5] = 2;
                        Data[9, 3] = 3;
                        Data[9, 6] = 3;
                        Data[8, 4] = 1;
                        Data[8, 5] = 1;
                        Data[8, 3] = 3;
                        Data[8, 6] = 3;
                        Data[7, 4] = 1;
                        Data[7, 5] = 1;
                        Data[7, 3] = 3;
                        Data[7, 6] = 3;
                        Data[6, 4] = 1;
                        Data[6, 5] = 1;
                        break;
                    case Direction.Left:
                        Data[4, 0] = 2;
                        Data[5, 0] = 2;
                        Data[3, 0] = 3;
                        Data[6, 0] = 3;
                        Data[4, 1] = 1;
                        Data[5, 1] = 1;
                        Data[3, 1] = 3;
                        Data[6, 1] = 3;
                        Data[4, 2] = 1;
                        Data[5, 2] = 1;
                        Data[3, 2] = 3;
                        Data[6, 2] = 3;
                        Data[4, 3] = 1;
                        Data[5, 3] = 1;
                        break;
                    case Direction.Right:
                        Data[4, 9] = 2;
                        Data[5, 9] = 2;
                        Data[3, 9] = 3;
                        Data[6, 9] = 3;
                        Data[4, 8] = 1;
                        Data[5, 8] = 1;
                        Data[3, 8] = 3;
                        Data[6, 8] = 3;
                        Data[4, 7] = 1;
                        Data[5, 7] = 1;
                        Data[3, 7] = 3;
                        Data[6, 7] = 3;
                        Data[4, 6] = 1;
                        Data[5, 6] = 1;
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case Direction.Up:
                        Data[0, 3] = 3;
                        Data[0, 4] = 1;
                        Data[0, 5] = 1;
                        Data[0, 6] = 3;
                        Data[1, 4] = 2;
                        Data[1, 5] = 2;
                        break;
                    case Direction.Down:
                        Data[9, 3] = 3;
                        Data[9, 4] = 1;
                        Data[9, 5] = 1;
                        Data[9, 6] = 3;
                        Data[8, 4] = 2;
                        Data[8, 5] = 2;
                        break;
                    case Direction.Left:
                        Data[3, 0] = 3;
                        Data[4, 0] = 1;
                        Data[5, 0] = 1;
                        Data[6, 0] = 3;
                        Data[4, 1] = 2;
                        Data[5, 1] = 2;
                        break;
                    case Direction.Right:
                        Data[3, 9] = 3;
                        Data[4, 9] = 1;
                        Data[5, 9] = 1;
                        Data[6, 9] = 3;
                        Data[4, 8] = 2;
                        Data[5, 8] = 2;
                        break;
                }
            }
        }
    }
}
