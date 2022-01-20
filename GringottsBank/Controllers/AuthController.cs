using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GringottsBank.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                string credentialValues = header.ToString().Substring("Basic ".Length).Trim();
                string usernameAndPassword = Encoding.UTF8.GetString(Convert.FromBase64String(credentialValues)); //Admin:pass
                string[] userCredentials = usernameAndPassword.Split(":");

                //Normally checks from Db
                if (userCredentials[0] == "Admin" && userCredentials[1] == "pass")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, userCredentials[0]) };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahbasshfbsahjfbshajbfhjasbfashjbfsajhfvashjfashfbsahfbsahfksdjf"));
                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var token = new JwtSecurityToken(

                         issuer: "www.cagataykiziltan.net",
                         audience: "tokenConsumer",
                         expires: DateTime.Now.AddMinutes(5),
                         claims: claimsdata,
                         signingCredentials: signInCred

                         );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenString);
                }
            }
            return BadRequest("wrong request");

        }
    }
}
