using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    public static class Extensions
    {
        public static List<T> WhereNew<T>(this List<T> data, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (var dat in data)
            {
                if (predicate(dat))
                {
                    result.Add(dat);
                }
            }
            //return data.Where(predicate);
            return result;
        }
    }
}
