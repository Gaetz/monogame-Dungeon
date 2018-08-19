using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon.Map
{
    class TileMap2D : TileMap
    {
        public TileMap2D() : base()
        {
            textures.Add(content.Load<Texture2D>("Tiles/dirt2D"));
            textures.Add(content.Load<Texture2D>("Tiles/stone2D"));
            textures.Add(content.Load<Texture2D>("Tiles/wall2D"));
            SetTileSize(32, 32);
        }

        public override void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if (Room == null) return;
            for (int r = 0; r < Room.Width; r++)
            {
                for (int c = 0; c < Room.Height; c++)
                {
                    int id = GetTileId(r, c);
                    if (id >= 0)
                    {
                        Point pos = new Point(c * TileWidth, r * TileHeight);
                        Texture2D texture = textures[id - 1];
                        if (texture != null)
                        {
                            spriteBatch.Draw(texture, new Rectangle(pos + Offset - camera.Coords, new Point(texture.Width, texture.Height)), Color.White);
                        }
                    }
                }
            }
        }
    }
}
