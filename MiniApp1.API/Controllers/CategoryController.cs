using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.API.Response;
using SurveyCoreLayer.Model;
using SurveyUnitOfWork;
using System;
using System.Data;
using System.Linq;

namespace Survey.API.Controllers
{
    //[Authorize(Roles = "admin", Policy = "PolicyControl")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IUnitOfWork _uow;
        GeneralResponse _response;
        public CategoryController(IUnitOfWork uow, GeneralResponse response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet(Name = "ListOfCategory")]
        public IQueryable<Category> ListOfCategory()
        {
            return _uow._cr.CategoryList();
        }

        [HttpGet("{id:int}")]
        public Category Find_Category(int id)
        {
            return _uow._cr.Find(id);

        }

        [HttpPost(Name = "Create_Category")]
        public GeneralResponse Create_Category(Category category)
        {
            try
            {
                _uow._cr.Create(category);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Category {category.CategoryId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Category cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public GeneralResponse Delete_Category(int id)
        {
            try
            {
                Category category = _uow._cr.Find(id);
                if (category != null)
                {
                    _uow._cr.Delete(category);
                    _uow.Commit();
                    _uow.Dispose();
                    _response.msgSuccess = $"The Category {category.CategoryId} has deleted successfully.";
                }
                else
                {
                    _response.msgError = $"No such id found.";
                }
            }
            catch (Exception ex)
            {
                _response.msgError = $"Category cannot be deleted! ({ex.Message})";
            }
            return _response;
        }

        [HttpPut(Name = "Update_Category")]
        public GeneralResponse Update_Category(Category category)
        {
            try
            {
                _uow._cr.Update(category);
                _uow.Commit();
                _uow.Dispose();
                _response.msgSuccess = $"The Category {category.CategoryId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Category cannot be updated! ({ex.Message})";
            }
            return _response;
        }
    }
}
