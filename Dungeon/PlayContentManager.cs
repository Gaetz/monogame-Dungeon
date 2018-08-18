using Dungeon.Utils.Services;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    internal class PlayContentManager : ContentManager, IContentService
    {
        public PlayContentManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public PlayContentManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory)
        {
        }

        public override T Load<T>(string path)
        {
            return base.Load<T>(path);
        }
    }
}
