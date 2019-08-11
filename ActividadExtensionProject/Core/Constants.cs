using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core
{
    public class Constants
    {
        public static class CustomClaimTypes
        {            
            public static string UserId = "UserId";
        }

        public enum Sexo
        {
            Masculino = 1,
            Femenino = 2
        }

		public enum SystemRoles
		{
			[Description("Admin")]
			Admin = 0,
			[Description("Usuario Web")]
			User = 1,			
		}
	}
}
