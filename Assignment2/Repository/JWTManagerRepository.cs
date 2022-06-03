using Assignment2.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment2.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
		Dictionary<string, string> UsersRecords = new Dictionary<string, string>
		{
			{ "Rashid","test123"},
			{ "John","hello123"},
			{ "Jennifer","demo123"},
		};

		private readonly IConfiguration iconfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration)
		{
			this.iconfiguration = iconfiguration;
		}


		public Tokens Authenticate(User user)
        {
			if(!UsersRecords.Any(x => x.Key == user.Name && x.Value == user.Password))
			{
				return null;
			}
			var claims = new[] {
						new Claim(JwtRegisteredClaimNames.Sub, iconfiguration["JWT:Subject"]),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
						new Claim("UserId", user.Name),
						new Claim("IsSuperAdmin", "1")
					};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]));
			var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				iconfiguration["JWT:Issuer"],
				iconfiguration["JWT:Audience"],
				claims,
				expires: DateTime.UtcNow.AddDays(3),
				signingCredentials: signIn);

			return new Tokens { Token =  new JwtSecurityTokenHandler().WriteToken(token) };

		}

		public User GetUser(string userName)
		{

			if (!UsersRecords.Any(x => x.Key == userName))
			{
				return null;
			}

			return UsersRecords.Where(u => u.Key == userName).Select(usr => new User { Name = usr.Key, Password = usr.Value }).FirstOrDefault();
		}
	}
    
}
