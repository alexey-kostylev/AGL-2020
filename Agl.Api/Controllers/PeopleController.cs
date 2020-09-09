using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Agl.Api.Services;
using Agl.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Agl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("cats")]
        public async Task<IActionResult> GetCats(string contentType)
        {
            var cats = await _peopleService.GetCatsByGender();

            if (contentType == "json")
            {
                return Ok(cats);
            }

            var htmlContent = ToHtml(cats);

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = $"<html><body>{htmlContent}</body></html>"
            };
        }

        static string ToHtml(ICollection<PetByGenderViewModel> vm)
        {
            if (vm == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (var rec in vm)
            {
                sb.AppendLine($"<h5>{WebUtility.HtmlEncode(rec.Gender.ToString())}</h5>");
                sb.AppendLine("<ul>");
                foreach (var name in rec?.CatNames)
                {
                    sb.AppendLine($"<li>{WebUtility.HtmlEncode(name)}</li>");
                }
                sb.AppendLine("</ul>");
            }

            return sb.ToString();
        }
    }
}
