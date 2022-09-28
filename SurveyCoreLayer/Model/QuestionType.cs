using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.Model
{
    public class QuestionType
    {
        [Key]
        public int QuestionTypeId { get; set; }
        public string? QuestionTypeName { get; set; }
    }
}
