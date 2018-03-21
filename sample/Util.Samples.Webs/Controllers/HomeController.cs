﻿using Microsoft.AspNetCore.Mvc;
using Util.Ui.Attributes;

namespace Util.Samples.Webs.Controllers {
    /// <summary>
    /// 主控制器
    /// </summary>
    public class HomeController : Controller {
        /// <summary>
        /// 首页
        /// </summary>
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// 主界面
        /// </summary>
        [Html(Path = "Typings/app/app.component.html" )]
        public IActionResult Main() {
            return View();
        }

        /// <summary>
        /// 404页面
        /// </summary>
        [Html( Path = "Typings/app/base/not-found.component.html" )]
        public IActionResult NotFoundPage() {
            return View();
        }
    }
}
