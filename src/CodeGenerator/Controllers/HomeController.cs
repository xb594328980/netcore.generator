using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeGenerator.Models;
using CodeGenerator.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace CodeGenerator.Controllers
{
    public class HomeController : BaseController
    {

        private IViewRenderService _viewRenderService;
        private ISqliteFreeSql _sqliteFreeSql;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private AppsettingConfig _appsettingConfig = new AppsettingConfig();

        public HomeController(IViewRenderService viewSendeRenderService,
            ISqliteFreeSql sqliteFreeSql,
            IConfiguration configuration,
            IMemoryCache cache)
        {
            _viewRenderService = viewSendeRenderService;
            _sqliteFreeSql = sqliteFreeSql;
            _cache = cache;
            _configuration = configuration;
            _configuration.GetSection("Solution").Bind(_appsettingConfig);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        #region 连接

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            SetSqlTypeList();
            return View();
        }

        /// <summary>
        /// 修改连接
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(string Id)
        {
            SetSqlTypeList();
            var model = _sqliteFreeSql.Select<SqlConnect>().Where(m => m.Id.Equals(Id)).ToOne();
            _sqliteFreeSql.Dispose();
            return View(model);
        }

        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="sqlconnect"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddServer(SqlConnect sqlconnect)
        {
            PageResponse reponse = new PageResponse();
            var insert = _sqliteFreeSql.Insert<SqlConnect>();
            sqlconnect.Id = Guid.NewGuid().ToString();
            string strConn = "";
            if (sqlconnect.SqlType == FreeSql.DataType.MySql)
                strConn = $"server={sqlconnect.Host}:{sqlconnect.Port};database={sqlconnect.DbName};uid={sqlconnect.Account};pwd={sqlconnect.Pwd};charset='utf8'";
            else
                strConn = $"data source={sqlconnect.Host},{sqlconnect.Port};initial catalog={sqlconnect.DbName};persist security info=True;user id={sqlconnect.Account};password={sqlconnect.Pwd};";
            sqlconnect.Address = strConn;
            var res = insert.AppendData(sqlconnect);
            var i = insert.ExecuteAffrows();
            _sqliteFreeSql.Dispose();
            return i > 0 ? Response(sqlconnect) : Response("添加失败");
        }

        /// <summary>
        /// 修改服务
        /// </summary>
        /// <param name="sqlconnect"></param>
        /// <returns></returns>
        public ActionResult UpdateServer(SqlConnect sqlconnect)
        {
            PageResponse reponse = new PageResponse();
            var update = _sqliteFreeSql.Update<SqlConnect>();
            string strConn = "";
            if (sqlconnect.SqlType == FreeSql.DataType.MySql)
                strConn = $"server={sqlconnect.Host}:{sqlconnect.Port};uid={sqlconnect.Account};pwd={sqlconnect.Pwd};charset='utf8'";
            else
                strConn = $"data source={sqlconnect.Host},{sqlconnect.Port};persist security info=True;user id={sqlconnect.Account};password={sqlconnect.Pwd};";
            sqlconnect.Address = strConn;
            var i = update.SetSource(sqlconnect).ExecuteAffrows();
            _sqliteFreeSql.Dispose();

            return i > 0 ? Response(sqlconnect) : Response("修改失败");
        }


        /// <summary>
        /// 删除服务
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteServer(string Id)
        {
            PageResponse reponse = new PageResponse();
            var i = _sqliteFreeSql.Delete<SqlConnect>().Where(m => m.Id.Equals(Id)).ExecuteAffrows();
            _sqliteFreeSql.Dispose();
            return i > 0 ? Response(true) : Response("删除失败");
        }
        #endregion
        #region 获取所有的库
        /// <summary>
        /// 获取所有的库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetTreeDBList()
        {
            List<zTree> list_ztree = new List<zTree>();
            var list_sqlconnect = _sqliteFreeSql.Select<SqlConnect>().ToList();
            _sqliteFreeSql.Dispose();
            list_ztree = await GetTreeList(list_sqlconnect);
            return Response(list_ztree, list_ztree.Count());
        }
        #endregion
        #region 获取服务器下指定的库全部信息
        /// <summary>
        /// 获取服务下指定的库全部信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetServerByID(string id)
        {
            PageResponse reponse = new PageResponse();
            var list_ztree = new List<zTree>();
            var sqlconnect = _sqliteFreeSql.Select<SqlConnect>().Where(p => p.Id == id).ToOne();
            _sqliteFreeSql.Dispose();
            try
            {
                IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                              .UseConnectionString(sqlconnect.SqlType, sqlconnect.Address)
                              .Build();
                var dbs = fsql.DbFirst.GetDatabases();
                if (!string.IsNullOrEmpty(sqlconnect.DbName))
                {
                    dbs = dbs.Where(p => p == sqlconnect.DbName).ToList();
                }
                foreach (var db in dbs)//数据库
                {
                    var dbId = Guid.NewGuid().ToString();
                    var ztree = new zTree()
                    {
                        id = dbId,
                        pId = id,
                        name = db,
                        noEditBtn = true,
                        noRemoveBtn = true
                    };
                    list_ztree.Add(ztree);
                    var tables = fsql.DbFirst.GetTablesByDatabase(db);
                    foreach (var table in tables)//表
                    {
                        var tableid = Guid.NewGuid().ToString();
                        ztree = new zTree()
                        {
                            id = tableid,
                            pId = dbId,
                            name = table.Name,
                            noEditBtn = true,
                            noRemoveBtn = true
                        };
                        list_ztree.Add(ztree);
                        //将table信息缓存

                        TableConfig tableConfig = new TableConfig()
                        {
                            Id = tableid,
                            TableName = table.Name,
                            DbName = db,
                            Comment = table.Comment,
                            ColumnConfig = new List<ColumnConfig>()
                        };
                        foreach (var column in table.Columns)
                        {
                            tableConfig.ColumnConfig.Add(new ColumnConfig()
                            {
                                ColumnName = column.Name,
                                CsType = column.CsType.FullName,
                                Remark = column.Coment,
                                IsNullable = column.IsNullable,
                                IsPrimary = column.IsPrimary
                            });
                        }
                        _cache.Set(tableid, tableConfig);
                    }

                }
                return Response(list_ztree, list_ztree.Count);
            }
            catch (Exception ex)
            {
                return Response(ex);
            }
        }

        #endregion
        #region 获取服务下的库
        /// <summary>
        /// 获取服务下的库
        /// </summary>
        /// <param name="sqlconnect"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetServerDbList(SqlConnect sqlconnect)
        {
            sqlconnect.DbName = "";
            string strConn = "";
            if (sqlconnect.SqlType == FreeSql.DataType.MySql)
                strConn = $"server={sqlconnect.Host}:{sqlconnect.Port};database={sqlconnect.DbName};uid={sqlconnect.Account};pwd={sqlconnect.Pwd};charset='utf8'";
            else
                strConn = $"data source={sqlconnect.Host},{sqlconnect.Port};initial catalog={sqlconnect.DbName};persist security info=True;user id={sqlconnect.Account};password={sqlconnect.Pwd};";
            sqlconnect.Address = strConn;
            return ServerDbList(sqlconnect);
        }

        #endregion


        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="tables">表集合</param>
        /// <param name="temps">模板集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Generator(string[] tables, string[] temps)
        {
            try
            {
                //查询所有需要生成的模板信息
                var templateList = _sqliteFreeSql.Select<TemplateConfig>().Where(p => temps.Contains(p.Id)).ToList();
                foreach (var item in tables)
                {
                    var talbe = _cache.Get<TableConfig>(item);
                    //处理表名
                    talbe.TableName = talbe.TableName.ProcessingTableName(_appsettingConfig.TablePascal, _appsettingConfig.TablePrefix);
                    foreach (var temp in templateList)
                    {
                        if (!string.IsNullOrEmpty(temp.FileName))
                            talbe.FullName = temp.FileName.Replace("{TableName}", talbe.TableName);
                        else
                            talbe.FullName = talbe.TableName;
                        temp.TempatePath = temp.TempatePath.Replace(".cshtml", "").Trim().TrimStart('/');
                        Dictionary<string, object> viewData = new Dictionary<string, object>();
                        viewData.Add("FieldPascal", _appsettingConfig.FieldPascal);
                        viewData.Add("Auth", _appsettingConfig.Auth);
                        var result = await _viewRenderService.RenderToStringAsync(temp.TempatePath, talbe, viewData);
                        result = result.Replace("<pre>", "").Replace("</pre>", "");
                        var name = $"{talbe.FullName}{temp.FileSuffix}";
                        var path = $"{_appsettingConfig.Path.TrimEnd('/')}/{temp.FilePath}".Replace("{TableName}", talbe.TableName);

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        path = Path.Combine(path, name);
                        if (System.IO.File.Exists(path))
                            continue;// System.IO.File.Delete(path);
                        FileInfo f = new FileInfo(path);
                        using (var stream = f.OpenWrite())
                            stream.Write(Encoding.UTF8.GetBytes(result));
                    }
                }
                return Response();
            }
            catch (Exception ex)
            {
                return Response(ex);
            }
        }




        /// <summary>
        /// 将视图写入文件
        /// </summary>
        /// <param name="url">相对路径</param>
        /// <param name="name">文件名(包括后缀)</param>
        /// <param name="html">内容</param>
        /// <returns></returns>
        private async Task WriteViewAsync(string url, string name, string html)
        {
            //获取根目录
            var path = AppContext.BaseDirectory;
            //文件夹路径
            var dirpath = path + "../StaticFile/" + url;
            //文件完整路径
            path = dirpath + name;

            //判断文件夹是否存在
            if (!System.IO.Directory.Exists(dirpath))//如果不存在就创建file文件夹
            {
                System.IO.Directory.CreateDirectory(dirpath);
            }
            //创建文件流  
            FileStream myfs = new FileStream(path, FileMode.Create);
            //打开方式  
            //1:Create  用指定的名称创建一个新文件,如果文件已经存在则改写旧文件  
            //2:CreateNew 创建一个文件,如果文件存在会发生异常,提示文件已经存在  
            //3:Open 打开一个文件 指定的文件必须存在,否则会发生异常  
            //4:OpenOrCreate 打开一个文件,如果文件不存在则用指定的名称新建一个文件并打开它.  
            //5:Append 打开现有文件,并在文件尾部追加内容.  

            //创建写入器  
            StreamWriter mySw = new StreamWriter(myfs);//将文件流给写入器  
            //将录入的内容写入文件  
            mySw.Write(html);
            //关闭写入器  
            mySw.Close();
            //关闭文件流  
            myfs.Close();
        }


        private async Task<List<zTree>> GetTreeList(List<SqlConnect> list_SqlConnect)
        {
            List<zTree> list_ztree = new List<zTree>();
            //根节点
            zTree ztree = new zTree()
            {
                id = "0",
                pId = "#",
                name = "服务器",
                noEditBtn = true,
                noRemoveBtn = true,
                open = true
            };
            list_ztree.Add(ztree);

            foreach (var SqlConnect in list_SqlConnect)
            {
                ztree = new zTree()
                {
                    id = SqlConnect.Id,
                    pId = "0",
                    name = SqlConnect.FullName,
                    open = true
                };
                list_ztree.Add(ztree);
            }
            return list_ztree;
        }
        #region 辅助
        /// <summary>
        /// 获取服务器数据库
        /// </summary>
        /// <param name="sqlconnect"></param>
        /// <returns></returns>
        private ActionResult ServerDbList(SqlConnect sqlconnect)
        {
            PageResponse reponse = new PageResponse();
            try
            {
                IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                              .UseConnectionString(sqlconnect.SqlType, sqlconnect.Address)
                              .Build();
                var dbs = fsql.DbFirst.GetDatabases();
                fsql.Dispose();
                if (!string.IsNullOrEmpty(sqlconnect.DbName))
                {
                    dbs = dbs.Where(p => p == sqlconnect.DbName).ToList();
                }
                List<TableConfig> list_table = new List<TableConfig>();
                foreach (var name in dbs)
                {
                    TableConfig tableConfig = new TableConfig()
                    {
                        Id = Guid.NewGuid().ToString(),
                        TableName = name
                    };
                    list_table.Add(tableConfig);
                }
                return Response(list_table, list_table.Count());

            }
            catch (Exception ex)
            {
                return Response(ex);
            }
        }
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        private void SetSqlTypeList()
        {
            var list = new List<SqlConnect>();
            list.Add(new SqlConnect() { Name = "0", DbName = "MySql" });
            list.Add(new SqlConnect() { Name = "1", DbName = "SqlServer" });
            ViewBag.SqlTypeList = new SelectList(list, "Name", "DbName");
        }
        #endregion
    }
}
