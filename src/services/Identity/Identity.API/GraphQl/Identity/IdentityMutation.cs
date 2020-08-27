using System;
using System.Threading.Tasks;
using GraphQL;
using Identity.API.Application.User;
using Identity.Infrastructure.Models;
using MediatR;

namespace Identity.API.GraphQl.Identity
{
    public class IdentityMutation
    {
        private readonly IMediator _mediator;

        public IdentityMutation(IMediator mediator)
        {
            _mediator = mediator;
        }

        [GraphQLMetadata("login")]
        public async Task<AppUser> Login() => await _mediator.Send(new LoginUserRequest());

        [GraphQLMetadata("register")]
        public bool Register()
        {
            Console.WriteLine("register");
            return false;
            // return await _mediator.Send(new CreateUserRequest());
        }
    }
}