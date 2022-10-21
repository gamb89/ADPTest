using ADPTest.Domain.Abstract.Repository;
using ADPTest.Domain.Entity;
using ADPTest.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Repository.Repository
{
    public class AdpTestRepository : IAdpTestRepository
    {
        protected AdpContext _context;
        public AdpTestRepository(AdpContext context)
        {
            _context = context;
        }
        public async Task SaveResult(TaskResult taskOperation)
        {
            await _context.AddAsync(taskOperation);
        }
    }
}
