using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public static class Extensions 
    {
        public static int SumOfValue<K>(this IDictionary<K, int> dict)
        {
            int total = 0;
            foreach (int value in dict.Values)
            {
                total += value;
            }
            return total;
        }
    }
}