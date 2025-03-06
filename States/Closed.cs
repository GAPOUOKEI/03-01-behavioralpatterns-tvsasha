using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    class Closed : IRequestState
    {
        public void HandleRequest(ClientRequest request)
        {
            Console.WriteLine("Запрос уже закрыт. Дальнейшие действия невозможны.");
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Статус: Закрыт");
        }
    }
}
