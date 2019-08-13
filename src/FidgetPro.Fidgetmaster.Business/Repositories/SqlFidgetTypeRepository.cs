using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Database;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FidgetPro.Fidgetmaster.Business.Repositories
{
    public class SqlFidgetTypeRepository : IFidgetTypeRepository
    {
        private readonly FidgetContext _context;

        public SqlFidgetTypeRepository(FidgetContext context)
        {
            _context = context;
        }

        public async Task<List<FidgetType>> GetFidgetTypes()
        {
            return await _context.FidgetTypes.ToListAsync();
        }
    }
}
