﻿using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_UI.ViewComponents.HomePage
{
	public class _DefaultFeatureComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			return View();
		}
	}
}
