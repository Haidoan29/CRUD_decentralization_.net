using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _200124.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string username , string password)
        {
            //tim xem co nguoi dung co user name phu hop khong
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                //kiem tra password 
                var checker = await _userManager.CheckPasswordAsync(user, password);
                if(checker == true)
                {
                    //login thanh cong
                    var tokenString = await GenerateJWTTokenAsync(user);
                    dynamic result = new ExpandoObject();
                    result.token = tokenString;
                    result.message = "dang nhap thanh cong";
                    return Ok(result);
                }
                else
                {
                    //login that bai
                }

            }
            return BadRequest("co loi ! vui long thu lai");
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register (string username , string password , string role = "CUSTOMER")
        {
            await this.InitRoles();
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return BadRequest("Tai khoan da ton tai ! vui long ve trang dang nhap!");
            }
            else
            {
                var newUser = new IdentityUser(username);
                var checker = await _userManager.CreateAsync(newUser , password);
                if(checker.Succeeded)
                {
                    //Phan quyen cho user
                    await _userManager.AddToRoleAsync(newUser, role);

                    //tien hanh login

                    var tokenString = await GenerateJWTTokenAsync(newUser);
                    dynamic result = new ExpandoObject();
                    result.token = tokenString;
                    result.message = "dang ky thanh cong!";
                    return Ok(result);
                }

            }
            return BadRequest("Dang ky khong thanh cong ! Vui long thu lai!");
        }

        private async Task InitRoles()
        {
            //init data cho roles
            var roleAdmin = new IdentityRole("ADMIN");
            var roleSubAdmin = new IdentityRole("SUBADMIN");
            var roleCustomer = new IdentityRole("CUSTOMER");
            if (await _roleManager.RoleExistsAsync("ADMIN") == false)
            {
                await _roleManager.CreateAsync(roleAdmin);
            }
            if (await _roleManager.RoleExistsAsync("SUBADMIN") == false)
            {
                await _roleManager.CreateAsync(roleSubAdmin);
            }
            if (await _roleManager.RoleExistsAsync("CUSTOMER") == false)
            {
                await _roleManager.CreateAsync(roleCustomer);
            }
        }

        private async Task<string> GenerateJWTTokenAsync(IdentityUser user)
        {
            var secretKey = _configuration.GetSection("JWT")["Secret"];
            var audithen = _configuration.GetSection("JWT")["Audithen"];
            var isuser = _configuration.GetSection("JWT")["Isuser"];
            // Cau hinh ma khoa
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Tao ra cac claimns de xem ma hoa thong tin gi
            // Chinh la cac thong tin ma chung ta se mang theo khi tien hanh gui token
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(",", roles)),
                new Claim(ClaimTypes.Email, user.Email??"")

            };

            // Tao ra token
            var token = new JwtSecurityToken(

                issuer: isuser,
                audience: audithen,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials

                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

    }
}
