using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.Model
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public string? QuestionLine { get; set; }
        public int QuestionTypeId { get; set; }
        [ForeignKey("QuestionTypeId")]
        public QuestionType? questionType { get; set; }
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public Surveys? Surveys { get; set; }
    }
}
