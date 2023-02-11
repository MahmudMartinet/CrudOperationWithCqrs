using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteDonorCommand
{
    public class DeleteDonorResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
