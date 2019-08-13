using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Models;

namespace FidgetPro.Fidgetmaster.Business.Contracts
{
    public interface IFidgetTypeRepository
    {
        Task<List<FidgetType>> GetFidgetTypes();
    }
}
