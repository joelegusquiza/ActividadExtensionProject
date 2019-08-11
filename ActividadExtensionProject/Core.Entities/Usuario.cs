using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using static Core.Constants;

namespace Core.Entities
{
	public class Usuario : BaseEntity
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string Salt { get; set; }
		public SystemRoles Rol { get; set; }
		public Guid ResetPasswordGuid { get; set; }
		public DateTime ResetPasswordGuidExpiration { get; set; }
		public SystemRoles Role { get; set; }


		public void SetPassword(string password)
		{
			var salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));
			var saltOut = Convert.ToBase64String(salt);
			Salt = saltOut;
			PasswordHash = hashed;
		}

		public bool CheckPassword(string password)
		{
			var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: Convert.FromBase64String(Salt),
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));
			return hashed == PasswordHash;
		}
	}
}
