using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public interface IExamService
    {
        List<Exam> GetAllExams();
        void AddExam(Exam exam);
        Exam GetSingleExamById(int id);
        void UpdateExam(Exam newExam);
        void DeleteExam(int id);
        ExamViewModel ExamDeletionConfirmation(int id);
    }
}