using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoatClub.Model
{
    class MemberRegister
    {
        private List<Member> _memberList;


        public MemberRegister()
        {
            _memberList = new List<Member>();
            Load();
        }

        public void Load()
        {
            TextReader reader = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Member>));
                reader = new StreamReader("member_register.xml");
                _memberList = (List<Member>)serializer.Deserialize(reader);
            }
            catch (Exception) { }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public void Save()
        {
            TextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Member>));
                writer = new StreamWriter("member_register.xml", false);
                serializer.Serialize(writer, _memberList);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public void AddMember(Member member)
        {
            _memberList.Add(member);
        }

        public void DeleteMember(Member member)
        {
            _memberList.Remove(member);
        }


        public Member GetMember(int memberId)
        {
            Member m;
            for (int i = 0; i < _memberList.Count(); i++)
            {
                m = _memberList[i];
                if (m.ID == memberId)
                {
                    return m;
                }
            }

            throw new ArgumentException("No member exists with id " + memberId);
        }

        public int GetNextMemberId()
        {
            int max = 0;

            foreach (Member m in _memberList)
            {
                if (m.ID > max)
                {
                    max = m.ID;
                }
            }

            return max + 1;
        }

        public int GetNextBoatIdFor(Member member)
        {
            if (member == null)
                throw new ArgumentException("member cannot be null");

            int max = 0;
            foreach (Boat b in member.GetBoats())
            {
                if (b.ID > max)
                {
                    max = b.ID;
                }
            }

            return max + 1;
        }

        public IEnumerable<Member> GetMemberList()
        {
            return _memberList.AsEnumerable();
        }

    }
}
