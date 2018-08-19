using Dungeon.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Scenes
{
    internal class Scene_Game : Scene
    {
        List<Room> rooms;
        DungeonMap dungeon;
        DungeonMinimap minimap;

        public Scene_Game(SceneManager manager) : base(manager)
        {
            rooms = new List<Room>();
        }

        internal override void Load()
        {
            // Dungeon
            dungeon = new DungeonMap();
            dungeon.Generate(9, 6);
            minimap = new DungeonMinimap();
            minimap.DungeonMap = dungeon;

            // Room
            Room room = new Room();
            TileMap3D tileMap = new TileMap3D();
            tileMap.Room = room;
            tileMap.Offset = new Point(400, 100);
            room.TileMap = tileMap;
            rooms.Add(room);
        }

        internal override void Unload()
        {

        }

        public override void Update(float dt)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach(Room room in rooms)
            {
                room.TileMap.Draw(spriteBatch);
            }
            minimap.Draw(spriteBatch);
        }

        internal override void Activate()
        {

        }

        internal override void Deactivate()
        {

        }
    }
}
