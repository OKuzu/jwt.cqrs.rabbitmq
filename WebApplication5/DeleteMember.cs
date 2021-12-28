using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrs.Data;
using WebApplication5;

namespace WebApiCqrs.Features.Books
{
    public class DeleteMember
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id).GreaterThan(0);
            }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            //private readonly MemberContext _db;

            //public CommandHandler(MemberContext db) => _db = db;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //var member = await _db.Members.FindAsync(request.Id);
                //if (member == null) return Unit.Value;

                //_db.Members.Remove(member);
                //await _db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}