using MediatR;
using MemberJWTDemo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrs.Data;

namespace WebApplication5
{
    public class GetMembers
    {
        public class Query : IRequest<IEnumerable<Member>> 
        { 
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IEnumerable<Member>>
        {
            //public readonly MemberContext _db;

            //public QueryHandler(MemberContext db) => _db = db;
            
            public async Task<IEnumerable<Member>> Handle(Query request, CancellationToken cancellationToken)
            {
                return new List<Member>(); // await _db.Members.ToListAsync(cancellationToken);
            }
        }
    }
}
