using Dungeon.Utils;
using Dungeon.Utils.Services;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    public enum Direction
    {
        Up = 0,
        Right,
        Down,
        Left
    }

    class DungeonMap
    {
        IRandomService random;

        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public Room[,] Rooms { get; private set; }

        List<Room> createdRooms;

        public DungeonMap()
        {
            random = Play.gameServices.GetService<IRandomService>();
            createdRooms = new List<Room>();
            Length = Balance.DungeonLength;
        }

        public void Generate(int width, int height)
        {
            Width = width;
            Height = height;
            Rooms = null;
            Rooms = new Room[Height, Width];
            createdRooms.Clear();
            

            // Start room
            int startX = random.Next(9);
            int startY = random.Next(6);
            CreateRoom(startX, startY, true);

            // Other rooms
            while(createdRooms.Count < Length)
            {
                int index = random.Next(createdRooms.Count);
                Room selectedRoom = createdRooms[index];
                Direction direction = (Direction)random.Next(4);
                int x = selectedRoom.X;
                int y = selectedRoom.Y;
                if (direction == Direction.Up && selectedRoom.Y > 0)
                {
                    y--;
                }
                else if (direction == Direction.Right && selectedRoom.X < Width - 1)
                {
                    x++;
                }
                else if (direction == Direction.Down && selectedRoom.Y < Height - 1)
                {
                    y++;
                }
                else if (direction == Direction.Left && selectedRoom.X > 0)
                {
                    x--;
                }
                else continue;
                if (Rooms[y, x] == null)
                {
                    if(createdRooms.Count == Length - 1)
                    {
                        CreateRoom(x, y, true);
                    }
                    else
                    {
                        CreateRoom(x, y);
                    }
                    selectedRoom.CreateDoor(direction);
                    int inverseDirection = ((int)direction + 2) % 4;
                    Rooms[y, x].CreateDoor((Direction)inverseDirection);
                }
            }
        }

        private void CreateRoom(int x, int y, bool startOrLast = false)
        {
            Rooms[y, x] = new Room(x, y, startOrLast);
            TileMap3D tileMap = new TileMap3D();
            tileMap.Room = Rooms[y, x];

            tileMap.Offset = new Point(x * 320, y * 320);
            tileMap.Offset = IsometricTools.To3D(tileMap.Offset);

            Rooms[y, x].TileMap = tileMap;

            createdRooms.Add(Rooms[y, x]);
        }
    }
}
