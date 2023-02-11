using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateDonorCommand
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorRequestModel, CreateDonorResponseModel>
    {
        private readonly ICreateDonorRepository _createDonor;
        public CreateDonorCommandHandler(ICreateDonorRepository createDonor)
        {
            _createDonor = createDonor;
        }
        public async Task<CreateDonorResponseModel> Handle(CreateDonorRequestModel request, CancellationToken cancellationToken) 
        {
            //var donor = new Donor(request.firstName, request.lastName, request.email, request.password);
            //var donorCreate = await _createDonor.CreateDonor(donor);

            //var donorresponse = donorCreate.Adapt<CreateDonorResponseModel>();

            //return await Task<CreateDonorRequestModel>
            if (request == null)
            {
                return new CreateDonorResponseModel
                {
                    Message = "Fields cannot be empty",
                    Success = false
                };
            }
            var donor = new Donor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
            };
            await _createDonor.CreateDonor(donor); 
            return new CreateDonorResponseModel
            {
                Success = true,
                Message = "Account created successfully",
            };
        }
    }
}
