using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class ExamService : IExamService
    {
        private ApplicationDbContext _context;
        public ExamService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void DeleteExam(int id)
        {
            Exam examToBeDeleted = GetSingleExamById(id);
            _context.Exams.Remove(examToBeDeleted);
            _context.SaveChanges();
        }

        public List<Exam> GetAllExams()
        {
            List<Exam> exams = _context.Exams.ToList();
            return exams;
        }

        public Exam GetSingleExamById(int id) => _context.Exams.Where(n => n.Id == id).FirstOrDefault();



        public void UpdateExam(Exam newExam)
        {
            Exam oldExam = GetSingleExamById(newExam.Id);
            oldExam.name = newExam.name;
            oldExam.mark = newExam.mark;
            _context.SaveChanges();
        }

        public ExamViewModel ExamDeletionConfirmation(int id)
        {

            Exam exam = GetSingleExamById(id);
            ExamViewModel examVM = new ExamViewModel()
            {
                Id = exam.Id,
                name = exam.name
            };

            return examVM;

        }
    }
}