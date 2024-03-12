using MediatR;
using Medium.Application.Absatractions;
using Medium.Application.UseCases.MediumUser.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handler
{
    public class UpdateCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (res == null)
            {
                return "Not Found";
            }
            res.Name = request.Name;
            res.ModifiedDate = DateTime.UtcNow;
            _context.Users.Update(res);
            await _context.SaveChangesAsync(cancellationToken);
            return "Yangilandi";
        }
    }

}


