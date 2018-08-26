using GuardaDigital.Models;
using DataTables.Mvc;
using GD.Entity;
using GD.Infrastructure.Context.EF;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace GuardaDigital.Controllers
{
    public class GuardaDigitalController : Controller
    {
        public ActionResult Ocorrencias()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult DatatablesOcorrencias([ModelBinder(typeof(DataTablesBinder))] DataTables.Mvc.IDataTablesRequest requestModel)
        {
            using (var db = new GuardaDigitalContext())
            {

                IQueryable<Ocorrencia> query = db.Ocorrencia;

                var totalCount = query.Count();

                if (requestModel.Search.Value != String.Empty)
                {
                    decimal valor = 0;
                    decimal.TryParse(requestModel.Search.Value, out valor);

                    var value = requestModel.Search.Value.Trim();
                    query = query.Where(p => p.Nome.ToString().Contains(value));
                    query = query.Where(p => p.Codigo.ToString().Contains(value));
                }

                var filteredCount = query.Count();

                var sortedColumns = requestModel.Columns.GetSortedColumns();
                var orderByString = String.Empty;

                foreach (var column in sortedColumns)
                {
                    orderByString += orderByString != String.Empty ? "," : "";
                    orderByString += (column.Data == "Category" ? "ProductCategory.Name" : column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
                }

                query = query.OrderBy(orderByString == String.Empty ? "name asc" : orderByString);
                query = query.Skip(requestModel.Start).Take(requestModel.Length);

                return Json(new DataTablesResponse(requestModel.Draw, query.ToList(), filteredCount, totalCount), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TipoOcorrencias()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult DatatablesTipoOcorrencias([ModelBinder(typeof(DataTablesBinder))] DataTables.Mvc.IDataTablesRequest requestModel)
        {
            using (var db = new GuardaDigitalContext())
            {

                IQueryable<RelatorioTipoOcorrencia> query = db.TipoOcorrencia;

                var totalCount = query.Count();

                if (requestModel.Search.Value != String.Empty)
                {
                    decimal valor = 0;
                    decimal.TryParse(requestModel.Search.Value, out valor);

                    var value = requestModel.Search.Value.Trim();
                    query = query.Where(p => p.Codigo.ToString().Contains(value));
                    query = query.Where(p => p.Ocorrencia.ToString().Contains(value));
                    query = query.Where(p => p.Tipo.ToString().Contains(value));
                }

                var filteredCount = query.Count();

                var sortedColumns = requestModel.Columns.GetSortedColumns();
                var orderByString = String.Empty;

                foreach (var column in sortedColumns)
                {
                    orderByString += orderByString != String.Empty ? "," : "";
                    orderByString += (column.Data == "Category" ? "ProductCategory.Name" : column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
                }

                query = query.OrderBy(orderByString == String.Empty ? "name asc" : orderByString);
                query = query.Skip(requestModel.Start).Take(requestModel.Length);

                return Json(new DataTablesResponse(requestModel.Draw, query.ToList(), filteredCount, totalCount), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        // GET: DatatablesClientes
        [System.Web.Mvc.HttpGet]
        public JsonResult DatatablesUsuarios([ModelBinder(typeof(DataTablesBinder))] DataTables.Mvc.IDataTablesRequest requestModel)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Database.SqlQuery<AspNetUsers>("SELECT * FROM AspNetUsers").ToList();
                     
                return Json(new DataTablesResponse(requestModel.Draw, query, query.Count, query.Count), JsonRequestBehavior.AllowGet);
            }
        }
    }
}