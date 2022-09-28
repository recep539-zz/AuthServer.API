using SurveyCoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyCoreLayer.DTOs
{
    public class SurveyDTO
    {
        public int SurveyId { get; set; }
        public string ?SurveyName { get; set; }
        public int CategoryId { get; set; }

    }
}
