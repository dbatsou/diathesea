using System.Security.Claims;
using API.Models;
using Application.User;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator)
        { }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> OnPostAsync(AuthenticationModel model)
        {
            var user = await _mediator.Send(new Login.Query() { Username = model.Username, Password = model.Password });

            //Todo this piece is to be refactored when i merge the other branch that includes relevant controller changes

            if (user == null)
                return BadRequest();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AuthenticationModel model)
        {
            var user = await _mediator.Send(new Register.Command() { Username = model.Username, Password = model.Password });

            if (user == null)
                return BadRequest("Single-user account already exists.");
            return Ok(user);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("signedin")]
        public async Task<IActionResult> SignedIn() => Ok(HttpContext.User.Identity.IsAuthenticated);
    }
}