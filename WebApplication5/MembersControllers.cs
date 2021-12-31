using MediatR;
using MemberJWTDemo;
using MemberJWTDemo.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCqrs.Features.Books;
using WebApplication5;
using System;
using MassTransit;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberJWTDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class MembersController : ControllerBase
    {



        //[HttpPost]
        //public async Task<IActionResult> CreateOrder(Member order)
        //{
        //    Uri uri = new Uri("rabbitmq://localhost/order-queue");

        //    var endPoint = await _bus.GetSendEndpoint(uri);
        //    await endPoint.Send(order);

        //    return Ok("Success");
        //}

        private readonly IJwtAuth jwtAuth;
        private readonly IMediator _mediator;
        private readonly IBusControl _bus;

        public MembersController(IMediator mediator, IBusControl bus, IJwtAuth jwtAuth)
        {
            _mediator = mediator;
            _bus = bus;
            this.jwtAuth = jwtAuth;
        } 

        [HttpGet]
        public async Task<IEnumerable<Member>> GetMenmbers() => await _mediator.Send(new GetMembers.Query());

        [HttpGet("{id}")]
        public async Task<Member> GetMember(int id) => await _mediator.Send(new GetMemberById.Query { Id= id});

        [HttpPost]
        public async Task<ActionResult> CreateMember([FromBody] AddNewMember.Command command)
        {
            var createdMemberId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMember), new { id = createdMemberId }, null);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            await _mediator.Send(new DeleteMember.Command { Id= id });
            return NoContent();
        }

        //// GET: api/<MembersController>
        //[HttpGet]
        //public IEnumerable<Member> AllMembers()
        //{
        //    return lstMember;
        //}

        //private readonly List<Member> lstMember = new List<Member>()
        //{
        //    new Member{Id=1, Name="Kirtesh" },
        //    new Member {Id=2, Name="Nitya" },
        //    new Member{Id=3, Name="pankaj"}
        //};

        //// GET api/<MembersController>/5
        //[HttpGet("{id}")]
        //public Member MemberByid(int id)
        //{
        //    return lstMember.Find(x => x.Id == id);
        //}

        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }


    }
}