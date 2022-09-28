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
    public class SurveyRepository : BaseRepository<Surveys>, ISurveyRepository
    {
        public SurveyRepository(Context db) : base(db)
        {
        }

        public IQueryable<SurveyDTO> ListByCategoryId(int id)
        {
            return Set().Select(x => new SurveyDTO
            {
                SurveyId = x.SurveyId,
                SurveyName =x.SurveyName,
                CategoryId=x.CategoryId,
            }).Where(x => x.CategoryId == id);
        }

        public IQueryable<Surveys> SurveyList()
        {
            return GetAll();
        }
    }
}
