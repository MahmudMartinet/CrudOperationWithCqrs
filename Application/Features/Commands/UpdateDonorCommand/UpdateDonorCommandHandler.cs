using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdateDonorCommand
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorRequestModel, UpdateDonorResponseModel>
    {
        private readonly IUpdateDonorRepository _updateDonor;
        private readonly IGetDonorRepository _getDonor;

        public UpdateDonorCommandHandler(IUpdateDonorRepository updateDonor, IGetDonorRepository getDonor)
        {
            _updateDonor = updateDonor;
            _getDonor = getDonor;
        }

        public async Task<UpdateDonorResponseModel> Handle(UpdateDonorRequestModel request, CancellationToken cancellationToken)
        {
            
            if(request == null)
            {
                return new UpdateDonorResponseModel
                {
                    Message = "Fields cannot be empty",
                    Success = false
                };
            }
            var getDonor = await _getDonor.GetDonor(x => x.Id == request.Id);
            if(getDonor == null)
            {
                return new UpdateDonorResponseModel
                {
                    Message = "Donor not found",
                    Success = false
                };
            }
            getDonor.FirstName = request.FirstName ?? getDonor.FirstName;
            getDonor.LastName = request.LastName ?? getDonor.LastName;
            getDonor.Password = request.Password ?? getDonor.Password;

            await _updateDonor.UpdateDonor(getDonor);
            return new UpdateDonorResponseModel
            {
                Message = "Donor's credencials updated successfully",
                Success = true
            };

        }
    }
}
