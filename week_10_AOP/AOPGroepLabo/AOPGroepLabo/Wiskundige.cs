using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPGroepLabo
{
    
    public class Wiskundige
    {
        [EntryTeller]
        public int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (1 == n) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
