using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyMarket.Classes
{
    public class BasicPageMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }

        public BasicPageMenuItem()
        {
            
        }
    }
}
