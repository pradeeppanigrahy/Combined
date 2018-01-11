using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpressionTree ex = new ExpressionTree();
            var expression=ex.GetExpression();
            List<Experimental.Models.model> models = new List<Experimental.Models.model>() { new Experimental.Models.model() { Id = 1, name = "pradeep" }, new Experimental.Models.model() { Id = 2, name = "panigrahy" } };

            


            var result=models.AsQueryable().Provider.CreateQuery<Models.model>(expression);

            Console.ReadLine();
        }
    }

   
}
