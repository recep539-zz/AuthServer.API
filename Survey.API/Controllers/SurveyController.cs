using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.API.Response;
using SurveyCoreLayer.DTOs;
using SurveyCoreLayer.Model;
using SurveyUnitOfWork;
using System;
using System.Data;
using System.Linq;

namespace Survey.API.Controllers
{
    [Authorize(Roles = "admin", Policy = "PolicyControl")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        IUnitOfWork _uow;
        GeneralResponse _response;
        public SurveyController(IUnitOfWork uow, GeneralResponse response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet(Name = "ListOfSurvey")]
        public IQueryable<Surveys> ListOfSurvey()
        {
            return _uow._sr.SurveyList();
        }
        [HttpGet("{id:int}")]
        public IQueryable<SurveyDTO> SurveyListByCategory(int id)
        {
            return _uow._sr.ListByCategoryId(id);
        }           
        [HttpGet("{id:int}")]
        public Surveys Find_Surveys(int id)
        {
            return _uow._sr.Find(id);

        }
        [HttpPost(Name = "Create_Survey")]
        public GeneralResponse Create_Survey(Surveys surveys)
        {
            try
            {
                _uow._sr.Create(surveys);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Survey {surveys.SurveyId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Survey cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public GeneralResponse Delete_Survey(int id)
        {
            try
            {
                Surveys survey = _uow._sr.Find(id);
                if (survey != null)
                {
                    _uow._sr.Delete(survey);
                    _uow.Commit();
                    _uow.Dispose();
                    _response.msgSuccess = $"The Survey {survey.SurveyId} has deleted successfully.";
                }
                else
                {
                    _response.msgError = $"No such id found.";
                }
            }
            catch (Exception ex)
            {
                _response.msgError = $"Survey cannot be deleted! ({ex.Message})";
            }
            return _response;
        }

        [HttpPut(Name = "Update_Survey")]
        public GeneralResponse Update_Survey(Surveys surveys)
        {
            try
            {
                _uow._sr.Update(surveys);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Survey {surveys.SurveyId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Survey cannot be updated! ({ex.Message})";
            }
            return _response;
        }
    }

}
