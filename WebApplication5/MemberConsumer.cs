using MassTransit;
using MemberJWTDemo;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class MemberConsumer: IConsumer<Member>
    {
        public async Task Consume(ConsumeContext<Member> context)
        {
            var data = context.Message;
            System.Console.WriteLine("Message received: " + data);
        }
    }
}
