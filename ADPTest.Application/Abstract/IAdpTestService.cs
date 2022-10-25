using ADPTest.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Application.Abstract
{
    public interface IAdpTestService
    {
        Task<ResponseObjectDto> ExecuteOperation(bool save = false);

        double GetOperationResult(double left, double right, string operation);
    }
}
