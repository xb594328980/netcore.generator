using CodeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="result">结果</param>
        /// <returns></returns>
        protected new AjaxResult Response(object result = null, int total = 0)
        {
            return new AjaxResult(result, total);
        }

        /// <summary>
        /// 返回错信息
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        protected new AjaxResult ErrorResponse(int code, string msg)
        {
            return new AjaxResult(code, msg);
        }

        /// <summary>
        /// 返回错信息
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        protected new AjaxResult ErrorResponse(string msg)
        {
            return new AjaxResult(500, msg);
        }
    }
}
