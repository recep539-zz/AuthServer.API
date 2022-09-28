using SurveyDataLayer;
using SurveyRepositories.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        Context _db;
        public UnitOfWork(Context db, IAnswerOptionRepository aor, ICategoryRepository cr, IQuestionTypeRepository qtr,IQuestionsRepository qr, ISurveyRepository sr, IAnswerRepository ar)
        {
            _db = db;
            _aor = aor;
            _qtr = qtr;
            _sr = sr;
            _cr=cr;
            _qr=qr;
            _ar=ar;
        }

        public IAnswerOptionRepository _aor { get;  set; }
        public IAnswerRepository _ar { get; set; }
        public ICategoryRepository _cr { get;  set; }

        public IQuestionTypeRepository _qtr { get;  set; }

        public IQuestionsRepository _qr { get;  set; }

        public ISurveyRepository _sr { get;  set; }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
