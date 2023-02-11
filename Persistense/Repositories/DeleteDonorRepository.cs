using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DeleteDonorRepository : IDeleteDonorRepository
    {
        private readonly IApplicationDbContext _context;

        public DeleteDonorRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteDonor(Donor donor)
        {
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
