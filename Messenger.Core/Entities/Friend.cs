using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Entities
{
    public class Friend : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Friend(string name, string id)
        {
            Id = id;
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }
    }
}
