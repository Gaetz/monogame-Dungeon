using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class TileMap3D : TileMap
    {
        public TileMap3D()
        {
            textures.Add(content.Load<Texture2D>("Tiles/dirt3D"));
            textures.Add(content.Load<Texture2D>("Tiles/stone3D"));
            textures.Add(content.Load<Texture2D>("Tiles/wall3D"));
            SetTileSize(32, 32);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (room == null) return;
            for (int r = 0; r < room.width; r++)
            {
                for (int c = 0; c < room.height; c++)
                {
                    int id = GetTileId(r, c);
                    if (id >= 0)
                    {
                        Point pos = new Point(c * tileWidth, r * tileHeight);
                        pos = To3D(pos);
                        Texture2D texture = textures[id - 1];
                        if (texture != null)
                        {
                            spriteBatch.Draw(texture, new Rectangle(pos + offset, new Point(texture.Width, texture.Height)), Color.White);
                        }
                    }
                }
            }
        }

        public Point To3D(Point coords)
        {
            return new Point(
                coords.X - coords.Y,
                (coords.X + coords.Y) / 2
            );
        }
    }
}
