using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Areas.Admin.Models.Services.HTMLDataSourceServices;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    public class ExpenseController : BaseController
    {
        // GET: Admin/Expense
        public ActionResult Index()
        {
            List<ExpenseVM> model = db.Expenses.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new ExpenseVM()
            {
                Name = x.Name,
                ProjectTitle = x.Project.Title,
                Description = x.Description,
                Amount = x.Amount,
                Unit = x.Unit,
                Quantity = x.Quantity,
                AddDate = x.AddDate,
                ID = x.ID
                                
            }).ToList();

            return View(model);
        }

        public ActionResult AddExpense()
        {
            ExpenseVM model = new ExpenseVM();
            model.drpProject = DrpServicesExpense.getDrpExpense();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddExpense(ExpenseVM model)
        {
            ExpenseVM vmodel = new ExpenseVM();
            vmodel.drpProject = DrpServicesExpense.getDrpExpense();

            if (ModelState.IsValid)
            {
                Expense expense = new Expense();
                expense.Name = model.Name;
                expense.Description = model.Description;
                expense.Amount = model.Amount;
                expense.Unit = model.Unit;
                expense.Quantity = model.Quantity;
                expense.ProjectID = model.ProjectID;

                db.Expenses.Add(expense);
                db.SaveChanges();

                ViewBag.IslemDurum = 1;

                return View(vmodel);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }

        }

        public ActionResult UpdateExpense(int id)
        {
            Expense expense = db.Expenses.FirstOrDefault(x => x.ID == id);
            ExpenseVM model = new ExpenseVM();
            model.ProjectID = expense.ProjectID;
            model.Name = expense.Name;
            model.Description = expense.Description;
            model.Quantity = expense.Quantity;
            model.Unit = expense.Unit;
            model.Amount = expense.Amount;
            model.drpProject = DrpServicesExpense.getDrpExpense();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateExpense(ExpenseVM model)
        {
            model.drpProject = DrpServicesExpense.getDrpExpense();
            if (ModelState.IsValid)
            {
                Expense expense = db.Expenses.FirstOrDefault(x => x.ID == model.ID);
                expense.Name = model.Name;
                expense.Description = model.Description;
                expense.Quantity = model.Quantity;
                expense.Unit = model.Unit;
                expense.Amount = model.Amount;
                expense.ProjectID = model.ProjectID;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;

                return View(model);
                //return RedirectToAction("Index", "Expense");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(model);
            }

        }

        public JsonResult DeleteExpense(int id)
        {
            Expense expense = db.Expenses.FirstOrDefault(x => x.ID == id);
            expense.IsDeleted = true;
            expense.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }
    }
}