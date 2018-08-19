using Dungeon.Utils.Services;
using Microsoft.Xna.Framework.Content;
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
        protected SceneManager manager;
        protected IContentService content;

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
            this.manager = manager;
            content = Play.gameServices.GetService<IContentService>();
        }

        internal abstract void Load();
        internal abstract void Unload();

        internal abstract void Activate();
        internal abstract void Deactivate();

        public abstract void Update(float dt);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
