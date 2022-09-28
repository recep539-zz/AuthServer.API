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
    public class AnswerOptionsController : ControllerBase
    {
        IUnitOfWork _uow;
        GeneralResponse _response;
        public AnswerOptionsController(IUnitOfWork uow, GeneralResponse response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet(Name = "ListOfAnswerOptions")]
        public IQueryable<AnswerOption> ListOfAnswerOptions()
        {
            return _uow._aor.GetAll();
        }
        [HttpGet("{id:int}")]
        public IQueryable<AnswerOptionsDTO> AnswerListByQuestion(int id)
        {
            return _uow._aor.ListByQuestionId(id);
        }

        [HttpGet("{id:int}")]
        public AnswerOption Find_Answer(int id)
        {
            return _uow._aor.Find(id);

        }

        [HttpPost(Name = "Create_AnswerOption")]
        public GeneralResponse Create_AnswerOption(AnswerOption answerOption)
        {
            try
            {
                _uow._aor.Create(answerOption);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The AnswerOption {answerOption.AnswerId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"AnswerOption cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public GeneralResponse Delete_AnswerOption(int id)
        {
            try
            {
                AnswerOption answerOption = _uow._aor.Find(id);
                if (answerOption != null)
                {
                    _uow._aor.Delete(answerOption);
                    _uow.Commit();
                    _uow.Dispose();
                    _response.msgSuccess = $"The AnswerOption {answerOption.AnswerId} has deleted successfully.";
                }
                else
                {
                    _response.msgError = $"No such id found.";
                }
            }
            catch (Exception ex)
            {
                _response.msgError = $"AnswerOption cannot be deleted! ({ex.Message})";
            }
            return _response;
        }

        [HttpPut(Name = "Update_AnswerOption")]
        public GeneralResponse Update_AnswerOption(AnswerOption answerOption)
        {
            try
            {
                _uow._aor.Update(answerOption);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The AnswerOption {answerOption.AnswerId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"AnswerOption cannot be updated! ({ex.Message})";
            }
            return _response;
        }
    }
}
