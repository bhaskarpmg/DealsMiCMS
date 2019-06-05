using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProDealsMI.Core.ViewModels;
using ProDealsMI.Infrastructure.EntityFramework;
using ProDealsMI.Infrastructure.Repository;
using PagedList;
using System.Web.Script.Serialization;
using ProDealsMI.Core.Common;

namespace ProDealsMI.WebUICMS.Controllers
{
    public class DealController : Controller
    {

        public IDealsRepository _dealRespository;
        public DealController()
        {

        }
        public DealController(IDealsRepository dealRepository)
        {
            dealRepository = _dealRespository;
        }
        // GET: Deal
        public ActionResult Index()
        {
            IDealsRepository dl = new DealsRepository();
            IEnumerable<Deals> dp = dl.GetDeals(new DealViewModel() { PageSize = 10, PageNumber = 1 });
            DealViewModel dvm = new DealViewModel();
            dvm.DealsList = dp.ToPagedList<Deals>(1, 10).ToList();
            dvm.Countries = dl.GetCountries().ToList();
            dvm.Status = dl.GetStatus().ToList();
            dvm.DealTypes = dl.GetDealTypes().ToList();

            //IPagedList<List<DealViewModel>> pageOrders = new StaticPagedList<List<DealViewModel>>();
            //dvm.


            return View(dvm);
        }

        // GET: Deal/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Deal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deal/Edit/5
        public ActionResult Edit(int id)
        {

            IDealsRepository dl = new DealsRepository();
            EditDealViewModel v = dl.FindDealById(id);
            v.Countries = dl.GetCountries();
            var selected = v.Countries.Where(x => x.Value ==v.CountryId.ToString()).First();
            selected.Selected = true;

            //v.SectorNames = dl.GetSectorNames();
            v.DealTypes = dl.GetDealTypes();
            var selectedDealType = v.DealTypes.Where(x => x.Value == v.DealTypeId.ToString()).First();
            selectedDealType.Selected = true;
            return View("EditDeal", v);
        }

        public ActionResult GetChildNodes(string selectedItems)
        {
            List<TreeViewModel> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewModel>>(selectedItems);
            return RedirectToAction("Edit");
        }
        public ActionResult SearchDeals(DealViewModel dvm)
        {
            IDealsRepository dl = new DealsRepository();
            IEnumerable<Deals> dp = dl.GetDeals(dvm);
            dvm.DealsList = dp.ToList();

            return View("Index", dvm);
        }

        // POST: Deal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Deal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Nodes()
        {
            DealsRepository dl = new DealsRepository();
            var data = dl.GetTaxonomies().ToList();

            var nodes = new List<JsTreeModel>();
            nodes = data.ToList().Select(p => new JsTreeModel() { id = p.id, text = p.text, parent = p.parentId, li_attr = p.fullTaxonomyPath }).ToList();
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveDealDetails(EditDealViewModel edvm)
        {
            try
            {
                DealsRepository dl = new DealsRepository();
                dl.SaveDealDetails(edvm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
