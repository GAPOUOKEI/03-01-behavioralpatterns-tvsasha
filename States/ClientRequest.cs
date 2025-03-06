using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    internal class ClientRequest
    {
        private IRequestState _state;

        public ClientRequest()
        {
            _state = new NewRequest(); 
        }

        public void SetState(IRequestState state)
        {
            _state = state;
        }

        public void Process()
        {
            _state.HandleRequest(this);
        }

        public void ShowStatus()
        {
            _state.DisplayStatus();
        }
    }
}
