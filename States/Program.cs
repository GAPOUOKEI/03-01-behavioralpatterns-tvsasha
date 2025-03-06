namespace States
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientRequest request = new ClientRequest();

            while (true)
            {
                request.ShowStatus();
                Console.WriteLine("Нажмите Enter для перехода к следующему этапу запроса");
                string input = Console.ReadLine();
                request.Process();
                Console.WriteLine();
            }
        }
    }
}
