using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Dungeon.Utils.Services;

namespace Dungeon.Map
{
    abstract class TileMap
    {
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }
        public Room Room { protected get; set; }
        public Point Offset { get; set; }

        protected IContentService content;
        protected List<Texture2D> textures;
        
        public TileMap()
        {
            content = Play.gameServices.GetService<IContentService>();
            textures = new List<Texture2D>();
        }

        public void SetTileSize(int tileWidth, int tileHeight)
        {
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
        }

        public int GetTileId(int row, int col)
        {
            if (row >= 0 && row < Room.Height && col >= 0 && col < Room.Width)
                return Room.Data[row, col];
            return -1;
        }

        public abstract void Draw(SpriteBatch spritebatch, Camera camera);
    }
}
