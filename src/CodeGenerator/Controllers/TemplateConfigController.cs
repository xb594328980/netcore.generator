using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeGenerator.Common;
using CodeGenerator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeGenerator.Controllers
{
    public class TemplateConfigController : BaseController
    {

        private ISqliteFreeSql _sqliteFreeSql;
        public TemplateConfigController(ISqliteFreeSql sqliteFreeSql)
        {
            _sqliteFreeSql = sqliteFreeSql;
        }




        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var model = _sqliteFreeSql.Select<TemplateConfig>().Where(m => m.Id.Equals(Id)).ToOne();
            _sqliteFreeSql.Dispose();
            return View(model);
        }


        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="sqlconnect"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddTemp(TemplateConfig temp)
        {
            var insert = _sqliteFreeSql.Insert<TemplateConfig>();
            temp.Id = Guid.NewGuid().ToString();
            var res = insert.AppendData(temp);
            var i = insert.ExecuteAffrows();
            _sqliteFreeSql.Dispose();
            return i > 0 ? Response(temp) : Response("添加失败");
        }

        /// <summary>
        /// 修改服务
        /// </summary>
        /// <param name="sqlconnect"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateTemp(TemplateConfig temp)
        {
            PageResponse reponse = new PageResponse();
            var update = _sqliteFreeSql.Update<TemplateConfig>();
            var i = update.SetSource(temp).ExecuteAffrows();
            _sqliteFreeSql.Dispose();
            return i > 0 ? Response(temp) : Response("添加失败");
        }


        /// <summary>
        /// 删除服务
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> DeleteTemp(string Id)
        {
            PageResponse reponse = new PageResponse();
            var i = _sqliteFreeSql.Delete<TemplateConfig>().Where(m => m.Id.Equals(Id)).ExecuteAffrows();
            _sqliteFreeSql.Dispose();
            return i > 0 ? Response(true) : Response("添加失败");
        }




        /// <summary>
        /// 获取所有的配置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetTempList()
        {
            PageResponse reponse = new PageResponse();
            List<zTree> list_ztree = new List<zTree>();
            var list = _sqliteFreeSql.Select<TemplateConfig>().ToList();
            _sqliteFreeSql.Dispose();
            //根节点
            zTree ztree = new zTree()
            {
                id = "temp0",
                pId = "#",
                name = "模板配置",
                noEditBtn = true,
                noRemoveBtn = true,
                open = true
            };
            list_ztree.Add(ztree);
            foreach (var temp in list)
            {
                ztree = new zTree()
                {
                    id = temp.Id,
                    pId = "temp0",
                    name = temp.Name,
                    open = true
                };
                list_ztree.Add(ztree);
            }

            return Response(list_ztree, list_ztree.Count());
        }
    }
}