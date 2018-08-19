using Dungeon.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Camera camera;

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

            // Camera
            camera = new Camera();
        }

        internal override void Unload()
        {

        }

        bool hit = false;

        public override void Update(float dt)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && !hit)
            {
                dungeon.Generate(9, 6);
                hit = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && hit)
            {
                hit = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camera.Y -= camera.Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                camera.Y += camera.Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camera.X -= camera.Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camera.X += camera.Speed;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            /*foreach(Room room in rooms)
            {
                room.TileMap.Draw(spriteBatch);
            }*/
            for (int i = 0; i < dungeon.Height; i++)
            {
                for (int j = 0; j < dungeon.Width; j++)
                {
                    if(dungeon.Rooms[i, j] != null)
                    {
                        dungeon.Rooms[i, j].TileMap.Draw(spriteBatch, camera);
                    }
                }
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
