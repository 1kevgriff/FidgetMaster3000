using System.Collections.Generic;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Models;

namespace FidgetPro.Fidgetmaster.Business.Contracts
{
    public interface IFidgetRepository
    {
        Task<List<Fidget>> GetFidgets();
        Task CreateOrUpdate(Fidget fidget);
    }
}