
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetDonorQuery
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorRequestModel, GetDonorResponseModel>
    {
        private readonly IGetDonorRepository _getDonor;
        public GetDonorByIdQueryHandler(IGetDonorRepository getDonor)
        {
            _getDonor = getDonor;
        }

        public async Task<GetDonorResponseModel> Handle(GetDonorRequestModel request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return new GetDonorResponseModel
                {
                    Message = "Donor not found",
                    Success = false
                };
            }
            var getDonor = await _getDonor.GetDonor(x => x.Id == request.Id);
            if(getDonor == null)
            {
                return new GetDonorResponseModel
                {
                    Message = "Donor not found",
                    Success = false
                };
            }
            var donor = new Donor
            {
                FirstName = getDonor.FirstName,
                LastName = getDonor.LastName,
                Email = getDonor.Email,
                Password = getDonor.Password,
                Id = getDonor.Id
            };
            return new GetDonorResponseModel
            {
                Donor = donor,
                Message = "Credentials fetcged successfully",
                Success = true
            };
        }
    }
}
