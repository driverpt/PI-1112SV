using System.IO;
using System.Text;
using System.Xml.Serialization;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels.Interfaces;

namespace PI.WebGarten.Demos.FollowMyTv.HttpContent.Xml
{
    public class XmlDoc : IHttpContent
    {
        public string Namespace { get; private set; }
        public object Object { get; private set; }

        public XmlDoc(string ns, object obj)
        {
            Namespace = ns;
            Object = obj;
        }

        public void WriteTo(TextWriter tw)
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attrs = new XmlAttributes {XmlIgnore = true};

            overrides.Add(Object.GetType(), "Id", attributes: attrs);

            XmlSerializer xs = new XmlSerializer(Object.GetType(), overrides);            
            
            xs.Serialize(tw, Object);
        }

        public string ContentType
        {
            get { return "text/xml"; }
        }
    }
}