

using System;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMvcAppTestSwitch.Models;

namespace TelerikMvcAppTestSwitch.Controllers
{
	public partial class DashboardController : Controller
    {
        public static Random random = new Random();
        public static List<string> firstNames = new List<string> { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige" };
        public static List<string> lastNames = new List<string> { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth", "White" };
        public static List<string> platforms = new List<string> { "Apple Podcasts", "Spotify", "Other", "Overcast", "Anchor", "Stitcher" };
        public static List<string> devices = new List<string> { "iOS", "Android", "Other", "Web" };
        public static List<PodcastViewModel> podcasts = new List<PodcastViewModel>();

        public ActionResult Podcasts_Read([DataSourceRequest] DataSourceRequest request)
        {

            var result = GetPodcasts().ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Downloads_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetPodcasts(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Devices_Read([DataSourceRequest] DataSourceRequest request)
        {
            var deviceViews = GetPodcasts().GroupBy(x => x.Device)
                                .Select(x => new
                                {
                                    Device = x.Key,
                                    Views = x.Sum(v => v.Views)
                                });
            return Json(deviceViews);
        }

        public ActionResult Platforms_Read([DataSourceRequest] DataSourceRequest request)
        {
            var platformViews = GetPodcasts().GroupBy(x => x.PlatformName)
                                .Select(x => new
                                {
                                    PlatformName = x.Key,
                                    Views = x.Sum(v => v.Views)
                                });

            return Json(platformViews);
        }
        private IEnumerable<PodcastViewModel> GetPodcasts()
        {
            if (podcasts.Count == 0)
            {
                podcasts = Enumerable.Range(1, 50).Select(x => new PodcastViewModel()
                {
                    Name = string.Format("Episode #{0} with guest {1} {2}", random.Next(0, 200), firstNames[random.Next(0, firstNames.Count)], lastNames[random.Next(0, lastNames.Count)]),
                    Streams = random.Next(0, 18000),
                    Downloads = random.Next(0, 15000),
                    PlatformName = platforms[random.Next(0, platforms.Count)],
                    Device = devices[random.Next(0, devices.Count)],
                    Date = DateTime.Now.AddDays(-x),
                    Reach = x * random.Next(0, 1000),
                }).ToList();
            }

            return podcasts;
        }
    }
}

