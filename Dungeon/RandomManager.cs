using Dungeon.Utils.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class RandomManager : IRandomService
    {
        Random random;

        public RandomManager()
        {
            random = new Random();
        }

        public int Next(int max)
        {
            return random.Next(max);
        }
    }
}
