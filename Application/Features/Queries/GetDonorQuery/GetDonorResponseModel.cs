using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetDonorQuery
{
    public class GetDonorResponseModel
    {
        public Donor? Donor { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}
