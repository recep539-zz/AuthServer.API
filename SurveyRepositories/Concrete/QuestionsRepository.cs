using SurveyCoreLayer.DTOs;
using SurveyCoreLayer.Model;
using SurveyDataLayer;
using SurveyRepositories.Abstract;
using SurveyRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SurveyRepositories.Concrete
{
    public class QuestionsRepository : BaseRepository<Questions>, IQuestionsRepository
    {
        public QuestionsRepository(Context db) : base(db)
        {
        }

        public IQueryable<QuestionsDTO> ListByQuestionTypeId(int id)
        {
            return Set().Select(x => new QuestionsDTO
            {
                QuestionId=x.QuestionId,
                QuestionLine=x.QuestionLine,
                QuestionTypeId=x.QuestionTypeId,
                SurveyId=x.SurveyId,
            }).Where(x => x.QuestionTypeId == id);
        }

        public IQueryable<QuestionsDTO> ListBySurveyId(int id)
        {
            return Set().Select(x => new QuestionsDTO
            {
                QuestionId=x.QuestionId,
                QuestionTypeId=x.QuestionTypeId,
                QuestionLine=x.QuestionLine,
                SurveyId=x.SurveyId
            }).Where(x => x.SurveyId == id);
        }
    }
}
