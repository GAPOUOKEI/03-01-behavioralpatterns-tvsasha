using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    internal class InProgress : IRequestState
    {
        public void HandleRequest(ClientRequest request)
        {
            Console.WriteLine("Запрос в обработке. Решаем проблему...");
            request.SetState(new Resolved());
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Статус: В процессе");
        }
    }
}
