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
        List<Texture2D> textures2D;
        List<Texture2D> textures3D;
        Tilemap map;

        Point mapOrigin2D;
        Point mapOrigin3D;


        public Scene_Game(SceneManager manager) : base(manager)
        {
            map = new Tilemap();
            textures2D = new List<Texture2D>();
            textures3D = new List<Texture2D>();
        }

        internal override void Load()
        {
            textures2D.Add(content.Load<Texture2D>("Tiles/dirt2D"));
            textures2D.Add(content.Load<Texture2D>("Tiles/stone2D"));
            textures3D.Add(content.Load<Texture2D>("Tiles/dirt3D"));
            textures3D.Add(content.Load<Texture2D>("Tiles/stone3D"));

            map.SetTileSize2D(32, 32);
            map.SetTileSize3D(64, 32);
            int[,] data = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 2, 2, 2, 1, 1, 1, 1, 1 },
                { 1, 1, 2, 2, 2, 1, 1, 1, 1, 1 },
                { 1, 1, 2, 2, 2, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            map.SetData(data);
            mapOrigin2D = new Point(20, 80);
            mapOrigin3D = new Point(650, 80);
        }

        internal override void Unload()
        {

        }

        public override void Update(float dt)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw 2D map
            for (int r = 0; r < map.mapWidth; r++)
            {
                for (int c = 0; c < map.mapHeight; c++)
                {
                    int id = map.GetTileId(r, c);
                    if (id >= 0)
                    {
                        Point pos = new Point(c * map.tileWidth2D, r * map.tileHeight2D);
                        Texture2D texture = textures2D[id - 1];
                        if(texture != null)
                        {
                            spriteBatch.Draw(texture, new Rectangle(pos + mapOrigin2D, new Point(texture.Width, texture.Height)), Color.White);
                        }
                    }
                }
            }

            // Draw 3D map
            for (int r = 0; r < map.mapWidth; r++)
            {
                for (int c = 0; c < map.mapHeight; c++)
                {
                    int id = map.GetTileId(r, c);
                    if (id >= 0)
                    {
                        Point pos = new Point(c * map.tileWidth2D, r * map.tileHeight2D);
                        pos = map.To3D(pos);
                        Texture2D texture = textures3D[id - 1];
                        if (texture != null)
                        {
                            spriteBatch.Draw(texture, new Rectangle(pos + mapOrigin3D, new Point(texture.Width, texture.Height)), Color.White);
                        }
                    }
                }
            }
        }

        internal override void Activate()
        {

        }

        internal override void Deactivate()
        {

        }
    }
}
