using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FidgetPro.Fidgetmaster.Business.Contracts;
using FidgetPro.Fidgetmaster.Business.Database;
using FidgetPro.Fidgetmaster.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FidgetPro.Fidgetmaster.Business.Repositories
{
    public class SqlFidgetRepository : IFidgetRepository
    {
        private readonly FidgetContext _context;

        public SqlFidgetRepository(FidgetContext context)
        {
            _context = context;
        }
        public async Task<List<Fidget>> GetFidgets()
        {
            return await _context.Fidgets.Include("Type").ToListAsync();
        }

        public async Task CreateOrUpdate(Fidget fidget, string userName, bool canApproveFidgets)
        {
            var existing = await _context.Fidgets.FindAsync(fidget.Id);
            if (existing == null)
            {
                await _context.Fidgets.AddAsync(fidget);
            }
            else
            {
                var findType = await _context.FidgetTypes.FindAsync(fidget.TypeId);

                existing.Color = fidget.Color;
                existing.Name = fidget.Name;
                if (canApproveFidgets && !existing.IsApproved && fidget.IsApproved)
                {
                    existing.IsApproved = fidget.IsApproved;
                    existing.ApprovedBy = userName;
                }

                existing.Type = findType; // better, but i don't like this
            }

            await _context.SaveChangesAsync(true);
        }
    }
}