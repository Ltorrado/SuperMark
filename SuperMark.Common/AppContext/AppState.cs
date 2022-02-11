using SuperMark.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.Common
{
    public class AppState
    {
        public int _counter { get; private set; }

        private User _User;
        public User User
        {
            get { return _User; }
            set
            {
                _User = value;
                NotifyStateChanged();
            }
        }
  
        public event Action OnChange;
        public event Action OnshowCart;

        public void SetCounter(int counter)
        {
            _counter = counter;
            NotifyStateChanged();
        }



        public void ShowCart()
        {

            NotifyShowCartChanged();
        }

        private void NotifyShowCartChanged() => OnshowCart?.Invoke();
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
