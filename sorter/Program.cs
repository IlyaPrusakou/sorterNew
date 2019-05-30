using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\sorter\source\fullcatalog.yml";
            IdStore store = new IdStore();
            using (Stream fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlReader rdr = XmlReader.Create(fs);
                store.GetOfferList(rdr);
                foreach (string key in store.CategoryAndOffers.Keys)
                {
                    foreach (var item in store.CategoryAndOffers[key])
                    {
                        Console.WriteLine(key + "   " + item); ///
                    }
                    
                }
            }
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
