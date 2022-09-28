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
    public class AnswerOptionRepository : BaseRepository<AnswerOption>, IAnswerOptionRepository
    {
        public AnswerOptionRepository(Context db) : base(db)
        {

        }

        public IQueryable<AnswerOptionsDTO> ListByQuestionId(int id)
        {

            return Set().Select(x => new AnswerOptionsDTO
            {
                AnswerId = x.AnswerId,
                AnswerName = x.AnswerName,
                QuestionId = x.QuestionsId
            }).Where(x => x.QuestionId == id);
        }
    }
}
