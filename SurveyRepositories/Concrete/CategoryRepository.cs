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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context db) : base(db)
        {
        }

        public IQueryable<Category> CategoryList()
        {
            return GetAll();
        }
    }
}
