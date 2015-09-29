using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BoatClub.Model
{
    [Serializable]
    public class Boat : IXmlSerializable
    {
        public enum BoatModel
        {
            Sailboat,
            Motorsailor,
            KayakCanoe,
            Other
        }

        private int _id;
        private double _length;
        private string _model;


        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public double Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value;
            }
        }


        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();
            _id = reader.ReadElementContentAsInt("Id", reader.NamespaceURI);
            _model = reader.ReadElementContentAsString("Model", reader.NamespaceURI);
            _length = reader.ReadElementContentAsDouble("Length", reader.NamespaceURI);
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Id", _id.ToString());
            writer.WriteElementString("Model", _model);
            writer.WriteElementString("Length", _length
                .ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
