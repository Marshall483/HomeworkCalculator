using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Data
{
    public static class CharExtention
    {
        public static int Priority(this char ch)
        {
            switch (ch)
            {
                case '(': case ')': return 1;
                case '+': case '-': return 2;
                case '*': case '/': return 3;
                default: throw new KeyNotFoundException();
            }
        }
    }
}
