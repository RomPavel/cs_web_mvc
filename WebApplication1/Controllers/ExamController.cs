using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {

        private IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        [AllowAnonymous]
        public IActionResult AllExams()
        {
            return View(_examService.GetAllExams());
        }

        public IActionResult CreateExam()
        {
            return View();
        }
        public IActionResult ExamCreated(Exam exam)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("CreateExam");
            }
            _examService.AddExam(exam);
            return View();
        }
        public IActionResult EditExam(int id)
        {
            return View(_examService.GetSingleExamById(id));
        }
        public IActionResult ExamEdited(Exam newExam)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("EditExam", newExam);
            }
            _examService.UpdateExam(newExam);
            return View();

        }

        public IActionResult DeleteExam(int id) => View(_examService.ExamDeletionConfirmation(id));


        public IActionResult ExamDeleted(int id)
        {
            _examService.DeleteExam(id);
            return View();

        }
    }
}