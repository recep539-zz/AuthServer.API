using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.Model
{
    public class AnswerOption
    {
        [Key]
        public int AnswerId { get; set; }
        public string? AnswerName { get; set; }
        public int QuestionsId { get; set; }
        [ForeignKey("QuestionsId")]
        public Questions? Questions { get; set; }
    }
}
