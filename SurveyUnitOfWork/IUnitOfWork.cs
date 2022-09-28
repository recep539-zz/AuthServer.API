using SurveyRepositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyUnitOfWork
{
    public interface IUnitOfWork
    {
        IAnswerOptionRepository _aor { get; }
        IAnswerRepository _ar { get; }
        ICategoryRepository _cr { get; }
        IQuestionTypeRepository _qtr { get; }
        IQuestionsRepository _qr { get; }
        ISurveyRepository _sr { get; }
        void Commit();
        void Dispose();
    }
}
