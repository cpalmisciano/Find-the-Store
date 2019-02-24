using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private Store FindMostLikely(List<StoreTransactions> all_stores)
        {
            Store most_likely = null;
            int max_ccns = 0;
            int count = 0;

            foreach (StoreTransactions st in all_stores)
            {
                if (st == null || st.Transactions == null || st.Transactions.Count < max_ccns)
                    continue;

                count = st.Transactions.Select(x => x.CCN).Distinct().Count();

                if (count > max_ccns)
                {
                    most_likely = st.Store;
                    max_ccns = count;
                }
            }

            return most_likely;
        }
    }

    public class Store
    {
        public string Name { get; set; }
        // other store info
    }

    public class Transaction
    {
        public string CCN { get; set; }
        // other details like amount, transaction date, etc
    }

    public class StoreTransactions
    {
        public Store Store { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
