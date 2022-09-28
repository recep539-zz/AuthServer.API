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
    public class QuestionTypeRepository : BaseRepository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(Context db) : base(db)
        {
        }

        public IQueryable<QuestionType> questionTypesList()
        {
            return GetAll();
        }
    }
}
