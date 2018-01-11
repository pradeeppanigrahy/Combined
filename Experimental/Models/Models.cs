using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    public class Models
    {
        public class model
        {
            public int Id { get; set; }

            public string name { get; set; }

            public override bool Equals(object obj)
            {
                if (this.GetType().FullName == obj.GetType().FullName)
                    return true;
                else
                    return false;

                //return base.Equals(obj);
            }
        }
    }
}
