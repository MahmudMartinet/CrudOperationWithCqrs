using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UpdateDonorRepository : IUpdateDonorRepository
    {
        private readonly IApplicationDbContext _context;
        public UpdateDonorRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Donor> UpdateDonor(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
            return donor;
        }
    }
}
