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
            Sailboat = 1,
            Motorsailor,
            KayakCanoe,
            Other
        }

        private int _id;
        private double _length;
        private BoatModel _model;


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
                if (value <= 0)
                {
                    throw new ArgumentException("Length must be greater than 0");
                }                  
                _length = value;
            }
        }

        public BoatModel Model
        {
            get
            {
                return _model;
            }

            set
            {
                if (!Enum.IsDefined(typeof(BoatModel), value)) 
                    throw new ArgumentException("Invalid Boat Model.");
                
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
            _model = (BoatModel)reader.ReadElementContentAsInt("Model", reader.NamespaceURI);
            _length = reader.ReadElementContentAsDouble("Length", reader.NamespaceURI);
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Id", _id.ToString());
            writer.WriteElementString("Model", ((int)_model).ToString());
            writer.WriteElementString("Length", _length
                .ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
