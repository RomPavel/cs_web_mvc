using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public object mark { get; internal set; }
    }
}