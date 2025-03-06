namespace Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger consoleLogger = new ConsoleLogger();
            Logger fileLogger = new FileLogger();

            consoleLogger.Log("Сообщение для консоли");
            fileLogger.Log("Сообщение для файла");

            Console.WriteLine("Логирование завершено.");
        }
    }
}
