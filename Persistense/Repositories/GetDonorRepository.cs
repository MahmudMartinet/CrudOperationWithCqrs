using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GetDonorRepository : IGetDonorRepository
    {
        private readonly IApplicationDbContext _context;

        public GetDonorRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Donor> GetDonor(Expression<Func<Donor, bool>> expression)
        {
            var donor = await _context.Donors.FirstOrDefaultAsync(expression);
            return donor;
        }
    }
}
