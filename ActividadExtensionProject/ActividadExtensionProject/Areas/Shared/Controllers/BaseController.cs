using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadExtensionProject.Areas.Shared.Controllers
{
	public class BaseController : Controller
	{
		private int _userId { get; set; }
		public int UserId
		{
			get
			{
				return _userId > 0 ? _userId : (_userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == CustomClaims.UserId).Value));
			}
		}
	}
}
