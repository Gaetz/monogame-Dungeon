using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Map
{
    class DungeonMinimap
    {
        Texture2D roomTx = null;
        Texture2D emptyTx = null;
        Rectangle roomRect;

        public DungeonMap DungeonMap { private get; set; }

        public DungeonMinimap()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int txWidth = 10;
            int txHeight = 10;
            if (roomTx == null)
            {
                roomTx = new Texture2D(spriteBatch.GraphicsDevice, txWidth, txHeight);

                Color[] data = new Color[txWidth * txHeight];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
                roomTx.SetData(data);
            }

            if (emptyTx == null)
            {

                emptyTx = new Texture2D(spriteBatch.GraphicsDevice, txWidth, txHeight);

                Color[] data = new Color[txWidth * txHeight];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.DarkGray;
                emptyTx.SetData(data);
            }

            for (int r = 0; r < DungeonMap.Height; r++)
            {
                for (int c = 0; c < DungeonMap.Width; c++)
                {
                    roomRect = new Rectangle(c * (roomTx.Width + 2) + 5, r * (roomTx.Height + 2) + 5, roomTx.Width, roomTx.Height);
                    if(DungeonMap.Rooms[r, c] == null)
                        spriteBatch.Draw(roomTx, roomRect, Color.DarkGray);
                    else
                        spriteBatch.Draw(roomTx, roomRect, Color.White);
                }
            }
        }
    }
}
