using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    public class Delegates
    {
        public delegate bool del1(List<Experimental.Models.model> a);

        public delegate T1 del1<T, T1>(List<T> a);

        public dynamic GenerateDynamicObject(IDictionary<string, string> rows)
        {

            dynamic expand = new ExpandoObject();
            IDictionary<string, object> expanddic = (IDictionary<string, object>)expand;
            foreach (var row in rows)
            {
                expanddic.Add(row.Key, row.Value);
            }
            expanddic.Add("ToString1", new Action(() =>
            {
                Type type = expand.GetType();

                PropertyInfo[] propertyinfo = type.GetProperties();
                foreach (var prop in propertyinfo)
                {
                    //Console.WriteLine(string.Format("{0}:{1}", prop.Name, propvalue));
                    var propvalue = prop.GetValue(expand, null);
                    Console.WriteLine(string.Format("{0}:{1}", prop.Name, propvalue));
                }

                Console.ReadLine();
            }
            ));


            return expand;
        }


        public void method1(del1<Experimental.Models.model, int> del)
        {
            List<Experimental.Models.model> models = new List<Experimental.Models.model>() { new Experimental.Models.model() { Id = 1, name = "pradeep" }, new Experimental.Models.model() { Id = 2, name = "panigrahy" } };

            var result = del(models);
        }



        public void method2()
        {
            method1(a => 20);
            //method1(a => a.FirstOrDefault().Id == 1);
        }

        public void method5(Func<float, int> c)
        {
            List<Experimental.Models.model> models = new List<Experimental.Models.model>();
            models.WhereNew(t => t.Id == 1);

            dynamic contacts = new List<dynamic>();

            contacts.Add(new ExpandoObject());

            contacts[0].Name = "Patrick Hines";

            contacts[0].Phone = "206-555-0144";


            contacts.Add(new ExpandoObject());

            contacts[1].Name = "Ellen Adams";

            contacts[1].Phone = "206-555-0155";

            IDictionary<string, object> dyno = new Dictionary<string, object>();


            dynamic person = new ExpandoObject(); var dictionary = (IDictionary<string, object>)person;
            dictionary.Add("Name", "Filip");
            dictionary.Add("Age", 24);
            person.Add("Method", new Action(() => Console.Write("Test")));
            person.method();
        }
    }
}
