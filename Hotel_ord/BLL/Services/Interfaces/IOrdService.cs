using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IOrdService
    {
        IEnumerable<OrdDTO> GetOrds(int page);
    }
}
