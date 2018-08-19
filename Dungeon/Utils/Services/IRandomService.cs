using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Utils.Services
{
    interface IRandomService
    {
        int Next(int max);
    }
}
