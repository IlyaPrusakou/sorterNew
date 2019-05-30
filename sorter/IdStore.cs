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
        //public string Category { get; set; }
        //public List<string> Offer { get; set; }
        public Dictionary<string, List<string>> CategoryAndOffers { get; set; } //
        public IdStore()
        {
            CategoryAndOffers = new Dictionary<string, List<string>>();
        }

        private List<string> GetListOfCategoryId (XmlReader rdr)
        {
            List<string> Keys = new List<string>();
            XDocument doc = XDocument.Load(rdr);
           XElement rootYmlElement = doc.Root;
            IEnumerable<XElement> CollectionOfCategories = rootYmlElement.Descendants("category");
            foreach (XElement item in CollectionOfCategories)
            {
                Keys.Add(item.FirstAttribute.Value);
            }
            return Keys;
        }

        private void GetCollectionOfOfferId(XmlReader rdr, string categoryid)
        {
            string result = null;
            List<string> Values = new List<string>();
            XDocument doc = XDocument.Load(rdr);
            XElement rootYmlElement = doc.Root;
            XElement offers = rootYmlElement.Element("Offers");
            IEnumerable<XElement> CollectionOfOffers = offers.Descendants("CategoryId");
            foreach (XElement item in CollectionOfOffers)
            {
                if (item.Value == categoryid)
                {
                    XElement baseElement = item.Parent;
                    result = baseElement.Attribute("id").Value;
                    Values.Add(result);
                }
                CategoryAndOffers.Add(categoryid, Values);
            }

        }
        public void  GetOfferList(XmlReader rdr)
        {
            List<string> ggg = GetListOfCategoryId(rdr);
            foreach (string item in ggg)
            {
                GetCollectionOfOfferId(rdr, item);
            }
        }
    }
}
