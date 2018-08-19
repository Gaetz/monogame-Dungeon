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
        public int tileWidth { get; private set; }
        public int tileHeight { get; private set; }
        public Room room { protected get; set; }
        public Point offset { protected get; set; }

        protected IContentService content;
        protected List<Texture2D> textures;
        
        public TileMap()
        {
            content = Play.gameServices.GetService<IContentService>();
            textures = new List<Texture2D>();
        }

        public void SetTileSize(int tileWidth, int tileHeight)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
        }

        public int GetTileId(int row, int col)
        {
            if (row >= 0 && row < room.height && col >= 0 && col < room.width)
                return room.Data[row, col];
            return -1;
        }

        public abstract void Draw(SpriteBatch spritebatch);
    }
}
