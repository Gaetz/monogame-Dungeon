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
        Texture2D image;

        public Scene_Game(SceneManager manager) : base(manager)
        {

        }

        internal override void OnCreate()
        {
            image = Dungeon.Assets.Load<Texture2D>("Tiles/dirt2D");
        }

        internal override void OnDestroy()
        {

        }

        public override void Update(float dt)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Rectangle(0, 0, image.Width, image.Height), Color.White);
        }

        internal override void Activate()
        {

        }

        internal override void Deactivate()
        {

        }
    }
}
