using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.Interfaces
{
    public interface IClient
    {
        public Task<double> Connect(double first, string action, double second);

    }
}
