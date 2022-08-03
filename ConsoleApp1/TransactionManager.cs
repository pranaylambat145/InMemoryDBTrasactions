using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class TransactionManager
    {
        private readonly Stack<KeyValueStore> transactions;

        public TransactionManager()
        {
            transactions = new Stack<KeyValueStore>();
        }

        //pushing storeValue object in trasaction stack
        internal KeyValueStore Begin(KeyValueStore storeValue)
        {
            transactions.Push(storeValue);
            return new KeyValueStore(storeValue);
        }

        //clearing the transaction and pushing the new commit to trasaction stack
        internal KeyValueStore Commit(KeyValueStore storeValue)
        {
            transactions.Clear();
            transactions.Push(storeValue);
            return new KeyValueStore(storeValue);
        }

        //comparing the last commit with current, returning last Commit if no match(Rollback)
        internal KeyValueStore Rollback(KeyValueStore storeValue)
        {
            if (transactions.Count != 0)
            {
                KeyValueStore lastCommitted = transactions.Pop();
                if (IsEquals(storeValue, lastCommitted))
                {
                    Console.WriteLine("NO TRANSACTION");
                    transactions.Push(lastCommitted);
                }
                return lastCommitted;
            }
            else
            {
                Console.WriteLine("NO TRANSACTION");
                return storeValue;
            }
        }
        /*
        *method to compare last commit and current
        * returns true if there is No Transaction
        */
        private bool IsEquals(KeyValueStore storeValue, KeyValueStore lastCommitted)
        {
            if (storeValue.inMemoryStore.Keys.Count == lastCommitted.inMemoryStore.Keys.Count)
            {
               foreach (string variable in lastCommitted.inMemoryStore.Keys)
                {
                    if (storeValue.inMemoryStore.ContainsKey(variable)
                            && storeValue.inMemoryStore[variable] == lastCommitted.inMemoryStore[variable])
                        continue;
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
