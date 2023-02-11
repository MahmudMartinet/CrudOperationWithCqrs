using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteDonorCommand
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorRequestModel, DeleteDonorResponseModel>
    {
        private readonly IDeleteDonorRepository _deleteDonor;
        private readonly IGetDonorRepository _getDonor;


        public DeleteDonorCommandHandler(IDeleteDonorRepository deleteDonor, IGetDonorRepository getDonor)
        {
            _deleteDonor = deleteDonor;
            _getDonor = getDonor;
        }
        public async Task<DeleteDonorResponseModel> Handle(DeleteDonorRequestModel request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return new DeleteDonorResponseModel
                {
                    Message = "Donor does not exist",
                    Success = false
                };
            }
            var getDonor = await _getDonor.GetDonor(x => x.Id == request.Id);
            if (getDonor == null)
            {
                return new DeleteDonorResponseModel
                {
                    Message = "Donor does not exist",
                    Success = false
                };
            }

            var donor = new Donor
            {
                FirstName = getDonor.FirstName,
                LastName = getDonor.LastName,
                Password = getDonor.Password,
                Email = getDonor.Email,
                Id = getDonor.Id,
            };
            await _deleteDonor.DeleteDonor(donor);
            return new DeleteDonorResponseModel
            {
                Message = "Donor deleted successfully",
                Success = true
            };
        }
    }
}
