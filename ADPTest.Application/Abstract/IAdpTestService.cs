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
        Task<ResponseObjectDto> Calculate(bool save = false);
    }
}
