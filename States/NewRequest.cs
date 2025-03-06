using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    class NewRequest : IRequestState
    {
        public void HandleRequest(ClientRequest request)
        {
            Console.WriteLine("Запрос принят. Переводим в обработку...");
            request.SetState(new InProgress());
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Статус: Новый запрос");
        }
    }

}
