using Messenger.Core.Abstracts.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Concrete.Observer
{
    public class SmileObservervable : IObservable
    {
        private List<IObserver> observers;
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }
}
