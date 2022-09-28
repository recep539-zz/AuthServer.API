using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.Model
{
    public class UserAnswer
    {
        [Key]
        public int UserAnswerId { get; set; }
        public string? UserName { get; set; }
        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public AnswerOption? AnswerOption { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Questions? Questions { get; set; }
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public Surveys? Surveys { get; set; }

    }
}
