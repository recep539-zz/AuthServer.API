using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.API.Response;
using SurveyCoreLayer.Model;
using System.Linq;
using System;
using SurveyUnitOfWork;
using SurveyCoreLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Survey.API.Controllers
{
    [Authorize(Roles = "admin", Policy = "PolicyControl")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IUnitOfWork _uow;
        GeneralResponse _response;
        public QuestionController(IUnitOfWork uow, GeneralResponse response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet(Name = "ListOfQuestions")]
        public IQueryable<Questions> ListOfQuestions()
        {
            return _uow._qr.GetAll();
        }
        [HttpGet("{id:int}")]
        public IQueryable<QuestionsDTO> QuestionListByQuestionType(int id)
        {
            return _uow._qr.ListByQuestionTypeId(id);
        }
        [HttpGet("{id:int}")]
        public IQueryable<QuestionsDTO> QuestionListBySurvey(int id)
        {
            return _uow._qr.ListBySurveyId(id);
        }

        [HttpGet("{id:int}")]
        public Questions Find_Question(int id)
        {
            return _uow._qr.Find(id);

        }

        [HttpPost(Name = "Create_Question")]
        public GeneralResponse Create_Question(Questions questions)
        {
            try
            {
                _uow._qr.Create(questions);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Questions {questions.QuestionId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Questions cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public GeneralResponse Delete_Question(int id)
        {
            try
            {
                Questions questions = _uow._qr.Find(id);
                if (questions != null)
                {
                    _uow._qr.Delete(questions);
                    _uow.Commit();
                    _uow.Dispose();
                    _response.msgSuccess = $"The Questions {questions.QuestionId} has deleted successfully.";
                }
                else
                {
                    _response.msgError = $"No such id found.";
                }
            }
            catch (Exception ex)
            {
                _response.msgError = $"Questions cannot be deleted! ({ex.Message})";
            }
            return _response;
        }

        [HttpPut(Name = "Update_Question")]
        public GeneralResponse Update_Question(Questions questions)
        {
            try
            {
                _uow._qr.Update(questions);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Questions {questions.QuestionId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Questions cannot be updated! ({ex.Message})";
            }
            return _response;
        }
    }
}
