using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.API.Response;
using SurveyCoreLayer.DTOs;
using SurveyCoreLayer.Model;
using System.Linq;
using System;
using SurveyUnitOfWork;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Survey.API.Controllers
{
    [Authorize(Roles = "user")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IUnitOfWork _uow;
        GeneralResponse _response;

        public AnswerController(IUnitOfWork uow, GeneralResponse response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet(Name = "ListOfAnswer")]
        public IQueryable<UserAnswerDTO> ListOfAnswer()
        {
            return _uow._ar.AnswerList();
        }
        [HttpGet(Name = "AnswerListByUserName")]
        public IQueryable<UserAnswerDTO> AnswerListByUserName(string name)
        {
            return _uow._ar.ListByUserName(name);
        }

        [HttpGet("{id:int}")]
        public UserAnswer Find_Answer(int id)
        {
            return _uow._ar.Find(id);
        }

        [HttpPost(Name = "Create_Answer")]
        public GeneralResponse Create_Answer(UserAnswer answer)
        {
            try
            {
                _uow._ar.Create(answer);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Answer {answer.AnswerId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Answer cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public GeneralResponse Delete_Answer(int id)
        {
            try
            {
                UserAnswer answer = _uow._ar.Find(id);
                if (answer != null)
                {
                    _uow._ar.Delete(answer);
                    _uow.Commit();
                    _uow.Dispose();
                    _response.msgSuccess = $"The Answer {answer.AnswerId} has deleted successfully.";
                }
                else
                {
                    _response.msgError = $"No such id found.";
                }
            }
            catch (Exception ex)
            {
                _response.msgError = $"Answer cannot be deleted! ({ex.Message})";
            }
            return _response;
        }

        [HttpPut(Name = "Update_Answer")]
        public GeneralResponse Update_Answer(UserAnswer answer)
        {
            try
            {
                _uow._ar.Update(answer);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Answer {answer.AnswerId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Answer cannot be updated! ({ex.Message})";
            }
            return _response;
        }
    }
}
