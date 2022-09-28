using SurveyCoreLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.DTOs
{
    public class UserAnswerDTO
    {
        public int UserAnswerId { get; set; }
        public string? UserName { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
    }
}
