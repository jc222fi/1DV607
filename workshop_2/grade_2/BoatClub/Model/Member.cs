using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BoatClub.Model
{
    [Serializable]
    public class Member : IXmlSerializable
    {
        private int _id;
        private string _name;
        private string _personalNumber;
        private List<Boat> _boats;

        /* Empty contructor needed for serialization */
        private Member() { }

        public Member(int id)
        {
            _id = id;
            _boats = new List<Boat>();

            Boat b = new Boat();
            b.Length = 2.5;
            b.Model = "Sailorboat";
            _boats.Add(b);
        }


        public int ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("Name was empty.");
                }
                _name = value;
            }
        }

        public string PersonalNumber
        {
            get
            {
                return _personalNumber;
            }

            set
            {
                // todo, perform validation
                _personalNumber = value;
            }
        }

        public List<Boat> Boats
        {
            get
            {
                return _boats;
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
            _name = reader.ReadElementContentAsString("Name", reader.NamespaceURI);
            _personalNumber = reader.ReadElementContentAsString("PersonalNumber", reader.NamespaceURI);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Boat>));
            _boats = (List<Boat>)serializer.Deserialize(reader);

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Id", _id.ToString());
            writer.WriteElementString("Name", _name);
            writer.WriteElementString("PersonalNumber", _personalNumber);
                     
            // Serialize list of boats.
            new XmlSerializer(typeof(List<Boat>))
                .Serialize(writer, this._boats);
        }
    }
}
