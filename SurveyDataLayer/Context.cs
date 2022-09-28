using Microsoft.EntityFrameworkCore;
using SurveyCoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyDataLayer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> op) : base(op)
        {

        }
        DbSet<AnswerOption> Answers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<QuestionType> QuestionTypes { get; set; }
        DbSet<Surveys> Surveys { get; set; }
        DbSet<Questions> Questions { get; set; }
        DbSet<UserAnswer> UserAnswers { get; set; }

    }
}
