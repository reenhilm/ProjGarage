﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGarage
{
    internal static class Extensions
    {
        public static IEnumerable<T> MergeWith<T>(
            this IEnumerable<T> source, IEnumerable<T> replacement)
        {
            using (var sourceIterator = source.GetEnumerator())
            using (var replacementIterator = replacement.GetEnumerator())
            {
                while (sourceIterator.MoveNext())
                    yield return replacementIterator.MoveNext()
                        ? replacementIterator.Current
                        : sourceIterator.Current;

                // you can remove this loop if you want to preserve source length
                //while (replacementIterator.MoveNext())
                //    yield return replacementIterator.Current;
            }
        }
    }
}
