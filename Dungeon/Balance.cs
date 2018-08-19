using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    static class Balance
    {
        /// <summary>
        /// 1: Always corridor, except first and last room
        /// 2 or more: the higher the scarcer are corridors
        /// </summary>
        public static int CorridorScarcity = 2;

        /// <summary>
        /// Dungeon's number of rooms
        /// </summary>
        public static int DungeonLength = 15;
    }
}
