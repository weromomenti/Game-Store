using Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreTests
{
    internal class EqualityComparer : IEqualityComparer<Game>
    {
        public bool Equals(Game? x, Game? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id && x.Name == y.Name;
        }
        public int GetHashCode([DisallowNull] Game obj)
        {
            return obj.GetHashCode();
        }
    }
}
