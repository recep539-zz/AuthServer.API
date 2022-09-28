using SurveyCoreLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.DTOs
{
    public class QuestionsDTO
    {
        public int QuestionId { get; set; }
        public string ?QuestionLine { get; set; }
        public int QuestionTypeId { get; set; }
        public int SurveyId { get; set; }
        public string ?AnswerOptions { get; set; }
    }
}
