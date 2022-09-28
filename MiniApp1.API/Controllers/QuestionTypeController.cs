using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.API.Response;
using SurveyCoreLayer.Model;
using System.Linq;
using System;
using SurveyUnitOfWork;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Survey.API.Controllers
{
    //[Authorize(Roles = "admin", Policy = "PolicyControl")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        IUnitOfWork _uow;
        GeneralResponse _response;
        public QuestionTypeController(IUnitOfWork uow, GeneralResponse response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet(Name = "ListOfQuestionType")]
        public IQueryable<QuestionType> ListOfQuestionType()
        {
            return _uow._qtr.questionTypesList();
        }

        [HttpGet("{id:int}")]
        public QuestionType Find_QuestionType(int id)
        {
            return _uow._qtr.Find(id);

        }

        [HttpPost(Name = "Create_QuestionType")]
        public GeneralResponse Create_QuestionType(QuestionType questionType)
        {
            try
            {
                _uow._qtr.Create(questionType);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The QuestionType {questionType.QuestionTypeId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"QuestionType cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public GeneralResponse Delete_QuestionType(int id)
        {
            try
            {
                QuestionType questionType = _uow._qtr.Find(id);
                if (questionType != null)
                {
                    _uow._qtr.Delete(questionType);
                    _uow.Commit();
                    _uow.Dispose();
                    _response.msgSuccess = $"The QuestionType {questionType.QuestionTypeId} has deleted successfully.";
                }
                else
                {
                    _response.msgError = $"No such id found.";
                }
            }
            catch (Exception ex)
            {
                _response.msgError = $"QuestionType cannot be deleted! ({ex.Message})";
            }
            return _response;
        }

        [HttpPut(Name = "Update_QuestionType")]
        public GeneralResponse Update_QuestionType(QuestionType questionType)
        {
            try
            {
                _uow._qtr.Update(questionType);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The QuestionType {questionType.QuestionTypeId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"QuestionType cannot be updated! ({ex.Message})";
            }
            return _response;
        }
    }
}
