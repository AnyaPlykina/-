using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class ItemMenu
    {
        public int Id {  get; set; }
        public Action Function { get; set; }
        public string Description {  get; set; }
        public ItemMenu(int id, Action func, string description)
        {
            Id = id;
            Function = func;
            Description = description;
        }
    }
}
