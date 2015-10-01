using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    public class Menu : MenuItem
    {
        private List<MenuItem> _menu;

        public string Header { get; private set; }


        public Menu(string header) : this(header, 0, null) {}

        public Menu(string header,  int id, string title) : base(id, title)
        {
            Header = header;
            _menu = new List<MenuItem>();
        }


        public void Additem(int id, string title)
        {
            _menu.Add(new MenuItem(id, title));
        }


        public void AddSubMenu(Menu menu)
        {
            _menu.Add(menu);
        }
     
        public Menu GetSubMenu(int id)
        {
            if (id == ID)
                return this;

            foreach(MenuItem i in _menu)
            {
                if(i.GetType() == typeof(Menu))
                {
                    if (i.ID == id)
                        return (Menu)i;
                    else
                    {
                        Menu m = ((Menu)i).GetSubMenu(id);
                        if (m != null)
                            return m;
                    }                       
                }
            }

            return null;  
        }


        public int GetListIndex(MenuItem item)
        {
            int idx = _menu.IndexOf(item);

            if (idx == -1)
                return idx;

            return idx + 1;
        }

        public int GetItemId(int listIndex)
        {
            return _menu[listIndex - 1].ID;
        }


        public IEnumerable<MenuItem> GetItems()
        {
            return _menu.AsEnumerable();
        }

    }

    public class MenuItem
    {

        public int ID { get; }
        public string Title { get; private set; }

        public MenuItem(int id, string title)
        {
            ID = id;
            Title = title;
        }

    }

}
