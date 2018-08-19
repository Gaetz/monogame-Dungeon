using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    public enum Direction
    {
        Up = 1,
        Right,
        Down,
        Left
    }

    class DungeonMap
    {
        Random random = new Random();

        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public Room[,] Rooms { get; private set; }

        List<Room> createdRooms;

        public DungeonMap()
        {
            createdRooms = new List<Room>();
            Length = 15;
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
            CreateRoom(startX, startY);

            // Other rooms
            while(createdRooms.Count < Length)
            {
                int index = random.Next(createdRooms.Count);
                Room selectedRoom = createdRooms[index];
                Direction direction = (Direction)(random.Next(4) + 1);
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
                    CreateRoom(x, y);
                }
            }
        }

        private void CreateRoom(int x, int y)
        {
            Rooms[y, x] = new Room(x, y);
            createdRooms.Add(Rooms[y, x]);
        }
    }
}
