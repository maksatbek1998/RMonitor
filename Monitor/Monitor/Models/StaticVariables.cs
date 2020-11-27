using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor.Models
{
    static class StaticVariables
    {
        public static string Number_Name;
        public static string Operator_Name;
        public static ObservableCollection<Turns> MainListColl = new ObservableCollection<Turns>();
    }
}
