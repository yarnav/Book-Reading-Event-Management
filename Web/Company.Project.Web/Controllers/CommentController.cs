using Company.Project.Web.Interfaces;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _iCommentRepository;

        public CommentController(ICommentRepository iCommentRepository)
        {
            this._iCommentRepository = iCommentRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetComments()
        {
            var commentList = await _iCommentRepository.GetComments();
            return View(commentList);
        }

        public async Task<ActionResult> ViewComment(int id)
        {
            var comment = await _iCommentRepository.ViewComment(id);
            if (comment == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(CommentViewModel commentViewModel)
        {
            var result = await _iCommentRepository.PostComment(commentViewModel);
            return RedirectToAction("", "Home");
        }

        public async Task<ActionResult> EditComment(int id)
        {
            var ans = await _iCommentRepository.ViewComment(id); ;
            if (ans == null)
            {
                return RedirectToAction("GetComments");
            }

            return View(ans);
        }

        [HttpPost]
        public ActionResult EditComment(CommentViewModel commentViewModel)
        {
            var _id = _iCommentRepository.EditComment(commentViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewComment", new { id = _id });
            }
            return View();
        }
    }
}
