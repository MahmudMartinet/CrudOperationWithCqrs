using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GetDonorsRepository : IGetDonorsRepository
    {
        private readonly IApplicationDbContext _context;

        public GetDonorsRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Donor>> GetAll()
        {
            return await _context.Donors.ToListAsync();
        }
    }
}
