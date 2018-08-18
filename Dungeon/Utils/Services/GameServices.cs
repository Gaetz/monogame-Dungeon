using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Utils.Services
{
    /// <summary>
    /// Wraps access to global services, using built-in monogame capabilities, with better syntax.
    /// Implements the Service Locator pattern.
    /// </summary>
    public class GameServices
    {
        Game game;

        public GameServices(Game _game)
        {
            game = _game;
        }

        public void AddService<T>(object provider)
        {
            game.Services.AddService(typeof(T), provider);
        }

        public T GetService<T>()
        {
            return (T)game.Services.GetService(typeof(T));
        }
    }
}