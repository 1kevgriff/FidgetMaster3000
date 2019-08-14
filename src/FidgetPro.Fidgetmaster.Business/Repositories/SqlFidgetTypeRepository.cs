using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateOrUpdate(FidgetType fidgetType)
        {
            var existing = await _context.FidgetTypes.FindAsync(fidgetType.Id);
            if (existing == null)
            {
                // create
                fidgetType.DesignedDate = DateTime.UtcNow;
                await _context.FidgetTypes.AddAsync(fidgetType);
            }
            else
            {
                // update
                existing.IsBouncing = fidgetType.IsBouncing;
                existing.IsFlying = fidgetType.IsFlying;
                existing.IsSpinning = fidgetType.IsSpinning;
                existing.TypeName = fidgetType.TypeName;
            }

            await _context.SaveChangesAsync(true);
        }

        public async Task DeleteFidgetType(long id)
        {
            var existing = await _context.FidgetTypes.FindAsync(id);
            if (existing != null)
            {
                _context.FidgetTypes.Remove(existing);

                await _context.SaveChangesAsync(true);
            }
        }
    }
}
