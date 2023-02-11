using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetDonorsQuery
{
    public class GetDonorsResponseModel
    {
        public IList<Donor> Donors { get; set; } = new List<Donor>();
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
