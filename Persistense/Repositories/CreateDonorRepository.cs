using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CreateDonorRepository : ICreateDonorRepository
    {
        private readonly IApplicationDbContext _context;
        public CreateDonorRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Donor> CreateDonor(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
            return donor;
        }
    }
}
