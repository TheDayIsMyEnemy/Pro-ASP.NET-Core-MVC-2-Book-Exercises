using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ViewComponents.Components
{
    public class PageSize : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://abv.bg");
            return View(response.Content.Headers.ContentLength);
        }
    }
}
