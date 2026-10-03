using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public Dictionary<string, string> accounts = (
            new Dictionary<string, string>
            {
                { "pablo@gmai.com", "pablo" },
                { "nefta@gmai.com", "nefta" },
                { "user@gmai.com", "user" }
            }
        );
        [HttpGet]
        public string Auth([FromQuery] string email)
        {
            if (accounts.ContainsKey(email))
            {
                return $"Hola {email}, your username is {accounts[email]}";
            }
            else
            {
                return $"Usuario no encontrado para correo {email}";
            }
        }
    }

}
