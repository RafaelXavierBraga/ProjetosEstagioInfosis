using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VilaoEletrico
{
    class OrdernarItemPorUso : IComparer<Item>
    {
        public int Compare([AllowNull] Item x, [AllowNull] Item y)
        {
            return x.GetTempoDeUso().CompareTo(y.GetTempoDeUso());
        }
    }
}
