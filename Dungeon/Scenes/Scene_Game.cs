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

        public Scene_Game(SceneManager manager) : base(manager)
        {
            rooms = new List<Room>();
        }

        internal override void Load()
        {
            Room room = new Room();
            TileMap3D tileMap = new TileMap3D();
            tileMap.room = room;
            tileMap.offset = new Point(400, 0);
            room.tileMap = tileMap;
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
                room.tileMap.Draw(spriteBatch);
            }
            // Draw 2D map
            

            // Draw 3D map
            
        }

        internal override void Activate()
        {

        }

        internal override void Deactivate()
        {

        }
    }
}
