using SurveyCoreLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.DTOs
{
    public class AnswerOptionsDTO
    {
        public int AnswerId { get; set; }
        public string ?AnswerName { get; set; }
        public int QuestionId { get; set; }
    }
}
