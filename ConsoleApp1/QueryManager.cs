using System;

namespace ConsoleApp1
{
    public class QueryManager
    {
        private KeyValueStore storeValue;
        private TransactionManager transaction;

        public QueryManager()
        {
            storeValue = new KeyValueStore();
            transaction = new TransactionManager();
        }

        internal void ExecuteQuery(string inputQuery)
        {
            /*
            * Need to use exceptions for parsing and use try catch block for FormatException
            * Assuming that input commands will be valid(eg. GET will have 2 params, 
            * SET will have three params etc.)
            */
            string[] parameters = inputQuery.Split(' ');
            string cmd = parameters[0];

            //assigning variables value inside switch because Trnsaction will have only one param
            string variable;
            int value;
            switch (cmd.ToUpper())
            {
                case "GET":
                    variable = parameters[1];
                    int? val = storeValue.Get(variable);
                    //Console NULL if no data found
                    Console.WriteLine(val.Equals(null) ? "NULL" : val.ToString());
                    break;

                case "SET":
                    variable = parameters[1];
                    value = int.Parse(parameters[2]);
                    storeValue.Set(variable, value);
                    break;

                case "DELETE":
                    variable = parameters[1];
                    storeValue.Delete(variable);
                    break;

                case "COUNT":
                    value = int.Parse(parameters[1]);
                    Console.WriteLine(storeValue.Count(value));
                    break;

                case "BEGIN":
                    storeValue = transaction.Begin(storeValue);
                    break;

                case "ROLLBACK":
                    storeValue = transaction.Rollback(storeValue);
                    break;

                case "COMMIT":
                    storeValue = transaction.Commit(storeValue);
                    break;

                default:
                    Console.WriteLine("Invalid operation: " + cmd + "\nTry again.");
                    break;
            }
        }

    }
}
