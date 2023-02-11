using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetDonorsQuery
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetDonorsRequestModel, GetDonorsResponseModel>
    {
        private readonly IGetDonorsRepository _getDonors;

        public GetAllDonorsQueryHandler(IGetDonorsRepository getDonors)
        {
            _getDonors = getDonors;
        }
        public async Task<GetDonorsResponseModel> Handle(GetDonorsRequestModel request, CancellationToken cancellationToken)
        {
            var getDonors = await _getDonors.GetAll();
            if(getDonors == null)
            {
                return new GetDonorsResponseModel
                {
                    Message = "No donor found",
                    Success = false,
                };
            }
            if(getDonors.Count == 0)
            {
                return new GetDonorsResponseModel
                {
                    Message = "No donor found",
                    Success = false,
                };
            }
            var donors = getDonors.Select(x => new Donor
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password
            }).ToList();

            return new GetDonorsResponseModel
            {
                Donors = donors,
                Success = true,
                Message = "List of Donors"
            };
        }
    }
}
