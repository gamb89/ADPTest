using ADPTest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Domain.Abstract.Repository
{
    public interface IAdpTestRepository
    {
        Task SaveResult(TaskResult taskOperation); 
    }
}
