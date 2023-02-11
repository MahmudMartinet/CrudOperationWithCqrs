using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGetDonorRepository
    {
        Task<Donor> GetDonor(Expression<Func<Donor, bool>> expression);
    }
}
