using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    class Resolved : IRequestState
    {
        public void HandleRequest(ClientRequest request)
        {
            Console.WriteLine("Запрос решен. Закрываем...");
            request.SetState(new Closed());
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Статус: Решен");
        }
    }
}
