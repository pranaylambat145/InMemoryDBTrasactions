using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class KeyValueStore
    {
        /*not private because it should be accessible to TransactionManager class to implement IsEquals method*/
        internal readonly Dictionary<string, int> inMemoryStore;

        public KeyValueStore()
        {
            inMemoryStore = new Dictionary<string, int>();
        }

        //Used for copying old data for supporting transactions
        public KeyValueStore(KeyValueStore operation)
        {
            inMemoryStore = new Dictionary<string, int>(operation.inMemoryStore);
        }

        internal void Set(string variable, int value)
        {
            if (!inMemoryStore.ContainsKey(variable))
            {
                inMemoryStore.Add(variable, value);
            }
            else
            {
                inMemoryStore[variable] = value;
            }
        }

        /*use {? or Nullable<int>} to hold null value*/
        internal int? Get(string variable)
        {
            if (inMemoryStore.ContainsKey(variable))
                return inMemoryStore[variable];
            
            return null;
        }

        internal int Count(int value)
        {
            int count = 0;
            foreach (var entry in inMemoryStore)
            {
                if (entry.Value == value)
                {
                    count++;
                }
            }
            return count;
        }
        internal void Delete(string variable)
        {
            if (inMemoryStore.ContainsKey(variable))
            {
                inMemoryStore.Remove(variable);
            }
        }

    }
}
