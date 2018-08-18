using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Utils.Services
{
    interface IContentService
    {
        T Load<T>(string path); 
    }
}
