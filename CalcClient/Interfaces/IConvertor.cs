using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Interfaces
{
    public interface IConvertor
    {
        public Queue<char> ToPostfix(string expression);
    }
}
