using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TrainingApp.Interfaces
{
    interface IVisitor
    {
        public async Task<double> VisitAsync(Expression expression) { return default(double); }
    }
}
