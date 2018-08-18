using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Scenes
{
    abstract class Scene
    {
        public SceneManager Manager { get; }

        /// <summary>
        /// True when scene updates while other scene is running
        /// </summary>
        public bool IsTranscendent { get; set; }

        /// <summary>
        /// True if scene draws while other scene is drawn
        /// </summary>
        public bool IsTransparent { get; set; }

        public Scene(SceneManager manager)
        {
            Manager = manager;
        }

        internal abstract void OnCreate();
        internal abstract void OnDestroy();

        internal abstract void Activate();
        internal abstract void Deactivate();

        public abstract void Update(float dt);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
