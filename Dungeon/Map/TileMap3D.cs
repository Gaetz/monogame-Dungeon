using Dungeon.Utils;
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

        public override void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if (Room == null) return;
            for (int r = 0; r < Room.Width; r++)
            {
                for (int c = 0; c < Room.Height; c++)
                {
                    int id = GetTileId(r, c);
                    if (id > 0)
                    {
                        Point pos = new Point(c * TileWidth, r * TileHeight);
                        pos = IsometricTools.To3D(pos);
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
