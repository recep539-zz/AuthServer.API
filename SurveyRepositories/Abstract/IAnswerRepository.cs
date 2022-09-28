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
    public interface IAnswerRepository:IBaseRepository<UserAnswer>
    {
        IQueryable<UserAnswerDTO> ListByUserName(string name);
        IQueryable<UserAnswerDTO> AnswerList();
    }
}
