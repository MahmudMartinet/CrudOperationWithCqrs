using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreateDonorCommand
{
    public sealed record CreateDonorRequestModel/*(string firstName,string lastName, string email, string password)*/ : IRequest<CreateDonorResponseModel>
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
