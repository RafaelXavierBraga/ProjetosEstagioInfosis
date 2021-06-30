using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace VilaoEletrico
{
    class OrdernarItemPorUso : IComparer<Item>
    {
        public int Compare([AllowNull] Item x, [AllowNull] Item y)
        {
            return x.GetUsoPorMeS().CompareTo(y.GetUsoPorMeS());
        }
    }
}
