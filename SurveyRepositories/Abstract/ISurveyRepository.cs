using SurveyCoreLayer.DTOs;
using SurveyCoreLayer.Model;
using SurveyRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyRepositories.Abstract
{
    public interface ISurveyRepository : IBaseRepository<Surveys>
    {
        IQueryable<Surveys> SurveyList();
        IQueryable<SurveyDTO> ListByCategoryId(int id);
    }
}
