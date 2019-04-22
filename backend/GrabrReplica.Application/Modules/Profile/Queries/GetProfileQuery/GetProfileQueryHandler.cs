using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Application.Modules.Profile.Models;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Profile.Queries.GetProfileQuery
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(ApplicationDbContext dbContext, UserManager<User> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(x => x.UserOrders)
                .Include(x => x.OrdersDelivered)
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            return _mapper.Map<ProfileDto>(user);
        }
    }
}