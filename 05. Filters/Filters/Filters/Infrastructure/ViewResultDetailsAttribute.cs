﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class ViewResultDetailsAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var dict = new Dictionary<string, string>
            {
                ["Result Type"] = context.Result.GetType().Name
            };

            ViewResult vr = context.Result as ViewResult;

            if (vr != null)
            {
                dict["View Name"] = vr.ViewName;
                dict["Model Type"] = vr.ViewData.Model.GetType().Name;
                dict["Model Data"] = vr.ViewData.Model.ToString();
            }

            context.Result = new ViewResult
            {
                ViewName = "Message",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                { Model = dict }
            };
        }
    }
}
