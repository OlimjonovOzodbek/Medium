using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Commands
{
    public class UpdateUserCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
