using FluentValidation;
using MediatR;
using MemberJWTDemo;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrs.Data;
using MassTransit;


namespace WebApiCqrs.Features.Books
{
    public class AddNewMember
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Name).NotEmpty().MaximumLength(150);
                RuleFor(c => c.Password).NotEmpty().MaximumLength(100);
            }
        }

        public class CommandHandler : IRequestHandler<Command, int>
        {

            Uri uri = new Uri("rabbitmq://localhost/member-queue");

            private readonly IBusControl _bus;

            public CommandHandler(IBusControl bus) => _bus = bus;

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {

                var entity = new Member
                {
                    Name = request.Name,
                    Password = request.Password,
                    Id = request.Id,
                };

                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(entity, cancellationToken);
                return 200;
            }
        }
    }
}