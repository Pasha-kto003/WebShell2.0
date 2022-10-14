using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using WebShellAsp2.Models;

namespace WebShellAsp2.Controllers
{
    public class HistoryController : Controller
    {
        // GET: HistoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoryController/Details/5
        //public async Task<ActionResult> Details(int id)
        //{
        //    var commands = new List<CommandHistory>();
        //    commands = await Api.GetListAsync<List<CommandHistory>>("CommandHistory");
        //    if (id != null)
        //    {
        //        CommandHistory history = commands.FirstOrDefault(s=> s.ID == id);
        //        if (history != null)
        //            return View(history);
        //    }
        //    return NotFound();
        //    //if (id != null)
        //    //{
        //    //    CommandHistory phone = await db.Phones.FirstOrDefaultAsync(p => p.ID == id);
        //    //    if (phone != null)
        //    //        return View(phone);
        //    //}
        //    //return NotFound();
        //}

        // GET: HistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
