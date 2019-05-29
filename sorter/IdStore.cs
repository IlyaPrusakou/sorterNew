using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace sorter
{
     public class IdStore
    {
        public string Category { get; set; }
        public List<string> Offer { get; set; }
        public Dictionary<string, string> CategoryAndOffers { get; set; }
        public IdStore()
        {
            CategoryAndOffers = new Dictionary<string, string>();
        }

        private string GetCategoryId (XmlReader rdr)
        {
            string result = null;
            XDocument doc = XDocument.Load(rdr);
            XElement rootYmlElement = doc.Root;
            IEnumerable<XElement> CollectionOfCategories = rootYmlElement.Descendants("category");
            foreach (XElement el in CollectionOfCategories)
            {
                CategoryAndOffers.Add(el.FirstAttribute.Value, null);
            }
            return result;
        }
        public void  GetOfferList(XmlReader rdr)
        {
            GetCategoryId(rdr);
        }
    }
}
