using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTSeleccion.Backend.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.ObjectPool;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace PTSeleccion.Backend.Controllers
{

    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        // Otros campos necesarios para las credenciales, si los hay
    }

    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly DBContext _dbContext;

        public AuthController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration configuration,
            DBContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentials credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.Username);
            Console.WriteLine("User object before GenerateClaimsAsync:");
            Console.WriteLine(JsonConvert.SerializeObject(user));

            if (user == null || !await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
                return Unauthorized("Credenciales inválidas");
            }

           
            var token = GenerateJwtToken(user);


            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
                token
                // Otros datos del usuario que desees devolver
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCredentials credentials)
        {
            var existingUser = await _userManager.FindByNameAsync(credentials.Username);

            if (existingUser != null)
            {
                return BadRequest("El usuario ya existe");
            }

            var newUser = new User { UserName = credentials.Username, Email = credentials.Username }; // Ajusta según tu modelo de datos

            var result = await _userManager.CreateAsync(newUser, credentials.Password);

            if (result.Succeeded)
            {
                // Aquí podrías generar el token JWT si es necesario

                return Ok(new
                {
                    Message = "Usuario registrado con éxito",
                    User = newUser // Aquí podrías enviar solo los datos necesarios del usuario, sin enviar la contraseña u otros datos sensibles
                });
            }

            var errors = string.Join("\n", result.Errors.Select(e => e.Description));
            return BadRequest($"Error al registrar el usuario: {errors}");
        }
        

        public async Task<IActionResult> Login2([FromBody] UserCredentials credentials)
        {
            Console.WriteLine(credentials);

            Console.WriteLine("ASdasd");
            var users = await _dbContext.Users.ToListAsync(); // Obtener todos los usuarios
            var user = users.FirstOrDefault(u => u.UserName == credentials.Username);

            Console.WriteLine("Username:", credentials.Username);
            foreach (var _user in users)
            {
                Console.WriteLine("Username: " + _user.UserName); // Mostrar el nombre de usuario de cada usuario
            }


            if (user != null)
            {
                Console.WriteLine("exito");
                var result = await _signInManager.PasswordSignInAsync(user, credentials.Password, isPersistent: false, lockoutOnFailure: false);


                if (result.Succeeded)
                {

                    var jwt = GenerateJwtToken(user);

                    var response = new
                    {
                        success = true,
                        message = "Authentication successful",
                        data = new
                        {
                            token = jwt,
                            expiration = DateTime.UtcNow.AddHours(1),
                            user = new
                            {
                                id = user.Id,
                                username = user.UserName,
                                email = user.Email
                                // Add other user details if needed
                            }
                        }
                    };
                    return Ok(response);
                }
                else
                {
                    var newPassword = credentials.Password; // Define la contraseña temporal
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

                    if (resetPasswordResult.Succeeded)
                    {
                        // Asignación de contraseña exitosa
                        // Tu código adicional si es necesario
                        Console.WriteLine("se actualizo la contraseña");

                    }
                    else
                    {
                        // Si la asignación de contraseña falla
                        return BadRequest("Error al asignar una contraseña temporal al usuario.");
                    }
                }
            }
            return Ok("NO HAY USER");

        }


        private bool ValidCredentials(UserCredentials credentials, User user)
        {

            string hashedEnteredPassword = HashPassword(credentials.Password);
            Console.WriteLine(hashedEnteredPassword);


            // Comparar el hash de la contraseña ingresada con el hash almacenado
            return false;
        }

        private string HashPassword(string password)
        {
            // Hashing seguro para almacenamiento de contraseña
            // NOTA: ¡Evita usar MD5! Deberías usar algoritmos más seguros como bcrypt o PBKDF2.
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private string GenerateJwtToken(User user)
        {
            Console.WriteLine(1);
            Console.WriteLine(_configuration);
            Console.WriteLine("before");
            var apiKey = _configuration["Settings:ApiKey"];
            Console.WriteLine(apiKey);
            byte[] key = new byte[0];
            try
            {

                // Verificar si apiKey es nulo antes de usarlo
                Console.WriteLine("before");

                if (apiKey != null)
                {
                    key = Encoding.ASCII.GetBytes(apiKey);
                    // Resto de tu lógica con la clave...
                    Console.WriteLine(key);
                }
                else
                {
                    // Manejo de la situación en la que la clave API es nula
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(123123);
            }

            Console.WriteLine(11);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    // Otros claims que desees incluir
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            Console.WriteLine(3);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Console.WriteLine("llego al final");
            return tokenHandler.WriteToken(token);
        }
    }
}
