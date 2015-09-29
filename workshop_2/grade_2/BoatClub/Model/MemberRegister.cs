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
            catch (Exception e) { }
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

        public void AddMember(Member newMember)
        {
            _memberList.Add(newMember);
        }

        public void DeleteMember(int memberId)
        {
            _memberList.RemoveAt(memberId - 1);
        }


        public Member GetMember(int id)
        {
            //return Member;
            return null;
        }

        public String GetMemberInfo(int memberId)
        {
            return null;
            //return memberList.ElementAt(memberId - 1).toString();
        }

        public void UpdateMember(int memberId, String name, String pnr)
        {
            Member memb = _memberList.ElementAt(memberId - 1);
            //memb.SetName(name);
            //memb.SetPersonalNumber(pnr);
        }



        public int GetNextMemberId()
        {         
            int max = 0;

            foreach(Member m in _memberList)
            {
                if(m.ID > max)
                {
                    max = m.ID;
                }
            }

            return max + 1;
        }

        public int GetNetBoatIdFor(Member member)
        {
            if (member == null)
                throw new ArgumentException("member cannot be null");

            int max = 0;
            foreach(Boat b in member.Boats)
            {
                if(b.ID > max)
                {
                    max = b.ID;
                }
            }

            return max + 1;
        }

        public IEnumerable<Member> GetMemberList()
        {
            return (IEnumerable<Member>)_memberList.AsEnumerable();
        }

    }
}
