﻿using RawRabbit;
using System;
using System.Threading.Tasks;
using Talent.Common.Commands;
using Talent.Common.Events;

namespace Talent.Services.Profile.Handler
{
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser>
    {
        private readonly IBusClient _busClient;
        public AuthenticateUserHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }
        public async Task HandleAsync(AuthenticateUser command)
        {
            Console.WriteLine($"Authenticate new user");
            await _busClient.PublishAsync(new UserAuthenticated(command.Email));
        }
    }
}
