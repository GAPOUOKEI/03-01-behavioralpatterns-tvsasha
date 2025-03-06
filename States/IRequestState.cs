using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    interface IRequestState
    {
        void HandleRequest(ClientRequest request);
        void DisplayStatus();
    }
}
