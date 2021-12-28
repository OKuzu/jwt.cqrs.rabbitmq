using MediatR;
using MemberJWTDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrs.Data;
using WebApplication5;

namespace WebApiCqrs.Features.Books
{
    public class GetMemberById
    {
        public class Query : IRequest<Member>
        {
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Member>
        {
            //private readonly MemberContext _db;

            //public QueryHandler(MemberContext db) => _db = db;

            public async Task<Member> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Member(); //await _db.Members.FindAsync(request.Id);
            }
        }
    }
}