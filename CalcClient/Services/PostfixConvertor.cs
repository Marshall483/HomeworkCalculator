using System.Collections.Generic;
using System.Linq;
using TrainingApp.Data;
using TrainingApp.Interfaces;

namespace TrainingApp.Services
{
    class PostfixConvertor : IConvertor
    {
        public Stack<char> opStack = new Stack<char>();
        public Queue<char> posfixForm = new Queue<char>();
        public Queue<char> ToPostfix(string expression) 
        {
            foreach(char token in expression)
            {
                if(char.IsDigit(token))
                    posfixForm.Enqueue(token);
                else if (token.Equals('(')) 
                        opStack.Push(token);
                else if (token.Equals(')'))
                {
                    char op = opStack.Pop();
                    while (op != '(')
                    {
                        posfixForm.Enqueue(op);
                        op = opStack.Pop();
                    }
                }
                else
                {
                    while (!opStack.Count.Equals(0) && token.Priority() <= opStack.Peek().Priority())
                        posfixForm.Enqueue(opStack.Pop());
                    opStack.Push(token);
                }
            }
            while (!opStack.Count.Equals(0))
                posfixForm.Enqueue(opStack.Pop());

            return posfixForm;
        }
    }
}
