using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Process;
using Entities;
using UI.Session;

namespace UI.Controllers
{
    [SessionCookie]
    public class SettingController : Controller
    {
        // GET: Settings/Setting
        public ActionResult Index()
        {
            var sp = new SettingProcess();
            var lista = sp.SelectList();
            return View(lista);
        }

        // GET: Settings/Details
        public ActionResult Details(int id)
        {
            var sp = new SettingProcess();
            var stng = sp.Find(id);

            return View(stng);
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: Settings/Create
        public ActionResult Create(Setting stng)
        {
            var sp = new SettingProcess();
            sp.Insert(stng);
            return RedirectToAction("Index");
        }

        // GET: Settings/Delete
        public ActionResult Delete(int id)
        {
            var sp = new SettingProcess();
            sp.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Settings/Edit
        public ActionResult Edit(int id)
        {
            var sp = new SettingProcess();
            var stng = sp.Find(id);

            return View(stng);
        }

        [HttpPost]
        // POST: Settings/Edit
        public ActionResult Edit(Setting stng)
        {
            var sp = new SettingProcess();
            sp.Edit(stng);
            return RedirectToAction("Index");
        }

    }
}
