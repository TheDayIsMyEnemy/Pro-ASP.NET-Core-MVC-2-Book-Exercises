using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponents.Models;

namespace ViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository cityRepository;

        public CitySummary(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", cityRepository.Cities);
            }
            else
            {
                return View(new CityViewModel
                {
                    Cities = cityRepository.Cities.Count(),
                    Population = cityRepository.Cities.Sum(c => c.Population)
                });
            }
        }

        //public IViewComponentResult Invoke()
        //{
        //    return new HtmlContentViewComponentResult(
        //    new HtmlString("This is a <h3><i>string</i></h3>"));
        //}
    }
}
