using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaskMgmtSystem.Models;

namespace TaskMgmtSystem.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext db;
        public TaskController()
        {
            db = new ApplicationDbContext();
        }
        //
        // GET: /Task/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllTask(jQueryDataTableParamModel param)
        {
            IQueryable<TaskModel> allTasks = db.TaskModel.AsNoTracking();


            IQueryable<TaskModel> filteredallTasks=allTasks;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredallTasks = allTasks
                         .Where(c => c.Name.ToLower().Contains(param.sSearch) ||
                             c.Description.ToLower().Contains(param.sSearch)
                         );
            }
            

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Expression<Func<TaskModel, DateTime>> orderingFunction = (c =>
                sortColumnIndex == 1 ? c.CreatedDate:c.CreatedDate
                );

            var sortDirection = Request["sSortDir_0"];

         /*   if (sortDirection == "asc")
            {
                filteredallTasks = filteredallTasks.OrderBy(orderingFunction).AsQueryable();
            }
            else
            {*/
                filteredallTasks = filteredallTasks.OrderByDescending(orderingFunction).AsQueryable();
           // }

            var displayedTask = filteredallTasks.Skip(param.iDisplayStart).Take(param.iDisplayLength == 0 ? 10 : param.iDisplayLength).ToList();
            var result = displayedTask.Select(c => new
            {
                Id = c.Id,
                c.Name,
                c.Description,
                CreateDate = c.CreatedDate.ToString("dd-MM-yyyy HH:mm:ss")
            });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allTasks.Count(),
                iTotalDisplayRecords = filteredallTasks.Count(),
                aaData = result,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateTask()
        {
            ViewBag.Form = "Create Task";
            return View("Task",new TaskModel());
        }

        public ActionResult EditTask(Guid Id)
        {
            ViewBag.Form = "Edit Task";
            var entityToUpdate = db.TaskModel.Find(Id);
            return View("Task",entityToUpdate);
        }



        /// <summary>
        /// Save or update the task
        /// </summary>
        /// <param name="entity">TaskModel</param>
        /// <returns>json</returns>
        public JsonResult SaveTask(TaskModel entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
                if (entity.Id != Guid.Empty)
                {
                    var _update = db.TaskModel.Find(entity.Id);
                    _update.Name = entity.Name;
                    _update.Description = entity.Description;

                    _update.UpdatedDate=DateTime.Now;
                    
                    db.Entry(_update).State = EntityState.Modified;
                }
                else
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;
                    entity.Id=Guid.NewGuid();
                    db.TaskModel.Add(entity);
                    
                }

                var result = db.SaveChanges();
                bool ok = false;
                if (result > 0)
                {
                    ok = true;
                }

                return Json(new { success = ok }, JsonRequestBehavior.AllowGet);

                
            }
            catch (DbEntityValidationException ee)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false}, JsonRequestBehavior.AllowGet);
            }
        }

       /// <summary>
       /// Delete the tasks
       /// </summary>
       /// <param name="Ids">Id of the tasks to be delete </param>
       /// <returns></returns>
        public JsonResult DeleteTask(Guid Id)
        {

            try
            {
                var ok=true;
              //  var allTasks = db.TaskModel.AsNoTracking().ToList();

                    var entityToRemove = db.TaskModel.FirstOrDefault(x=>x.Id==Id);
                    db.TaskModel.Remove(entityToRemove);

                    var result = db.SaveChanges();
                    if (result <= 0)
                    {
                        ok=false;
                    }

                
                if(ok){
                    return Json(new { success = ok, message = "Tasks deleted successfully." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = ok, message ="Unabale to delete task please try again." }, JsonRequestBehavior.AllowGet);

                }


            }
            catch (DbEntityValidationException ee)
            {
                return Json(new { success = false,message="The query cannot be processed because of error." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false,message="The query cannot be processed because of error." }, JsonRequestBehavior.AllowGet);
            }
        }
	}
}