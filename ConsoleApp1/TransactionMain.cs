using System;

namespace ConsoleApp1
{
    internal class TransactionMain
    {
        static void Main(string[] args)
        {
            QueryManager queryManager = new QueryManager();
            Console.WriteLine("Please enter some commands");
            string query;
            while ((query = Console.ReadLine()) != null)
            {
                if (query == "END")
                    break;
                else
                {
                    queryManager.ExecuteQuery(query);
                }
            }
           
            
        }
    }
}
