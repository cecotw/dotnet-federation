using System.Threading;
using System.Threading.Tasks;
using Identity.Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.API.Application.User
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, bool>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CreateUserRequestHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var userManager = scopedServices.GetRequiredService<UserManager<AppUser>>();
            // TODO: automap
            var user = new AppUser
            {
                UserName = request.Username
            };
            var res = await userManager.CreateAsync(user, request.Password);
            return res.Succeeded;
        }
    }
}