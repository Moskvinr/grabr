using AutoMapper;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace System.Threading.Tasks
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            _mapper.Map(request, user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}