using SurveyCoreLayer.DTOs;
using SurveyCoreLayer.Model;
using SurveyDataLayer;
using SurveyRepositories.Abstract;
using SurveyRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyRepositories.Concrete
{
    public class AnswerRepository : BaseRepository<UserAnswer>, IAnswerRepository
    {
        public AnswerRepository(Context db) : base(db)
        {
        }

        public IQueryable<UserAnswerDTO> AnswerList()
        {
            return Set().Select(x => new UserAnswerDTO
            {
                UserAnswerId = x.UserAnswerId,
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                SurveyId = x.SurveyId,
                UserName = x.UserName
            });
        }

        public IQueryable<UserAnswerDTO> ListByUserName(string Name)
        {
            return Set().Select(x=>new UserAnswerDTO
            {
                UserAnswerId = x.UserAnswerId,
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                SurveyId = x.SurveyId,
                UserName=x.UserName          
            }).Where(x=>x.UserName == Name);
        }
    }
}
