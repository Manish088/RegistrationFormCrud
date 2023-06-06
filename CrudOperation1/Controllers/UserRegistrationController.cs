using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CrudOperation1.Models;
using CrudOperation1.Repositories.Contract;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace CrudOperation1.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IGenericRepository<TblUserRegistration> _UserRegistrationRepository;
        private readonly IGenericStateRepository<tblState> _TblUserRegistrationStateRepository;
        private readonly IGenericCityRepository<tblCity> _TblUserRegistrationCityRepository;
       
        public UserRegistrationController(IGenericRepository<TblUserRegistration> UserRegistrationRepository, IGenericStateRepository<tblState> tblUserRegistrationStateRepository,IGenericCityRepository<tblCity> tblUserRegistrationCityRepository)
        {
            _UserRegistrationRepository = UserRegistrationRepository;
            _TblUserRegistrationStateRepository = tblUserRegistrationStateRepository;
            _TblUserRegistrationCityRepository = tblUserRegistrationCityRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetUserRegistrationList()        {
            List<TblUserRegistration> _tblUserRegistrations = await _UserRegistrationRepository.GetList();
            
            return View(_tblUserRegistrations);
        }
        [HttpGet]
        public async Task<JsonResult> StateName()
        {
            List<tblState> _tblStates=await _TblUserRegistrationStateRepository.GetStateList();
            return Json(_tblStates);
        }
        [HttpGet]
        public async Task<JsonResult> CityName(string parentValue)
        {
            int StateId=Convert.ToInt32(parentValue);
            List<tblCity> _tblCities = await _TblUserRegistrationCityRepository.GetCityList(StateId);
            return Json(_tblCities);
        }

       

        

        
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<JsonResult> Add([FromBody] TblUserRegistration model)
        {
            try
            {
                var _result = await _UserRegistrationRepository.Save(model);
                if (_result)
                    return Json("success");
                else
                    return Json("error");
               
            }
            catch
            {
                return Json("error");
            }
        }

        
        public async Task<JsonResult> getbyID(int id)
        {
            var _result= await _UserRegistrationRepository.GetById(id);
            return Json(_result);
        }

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Update([FromBody] TblUserRegistration collection)
        {
            try
            {
                var _result = await _UserRegistrationRepository.Edit(collection);
                return Json(_result);
                
            }
            catch
            {
                return Json("Error");
            }
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int id)
        {
            var _result = await _UserRegistrationRepository.Delete(id);
            return Json(_result);
        }

       
        
    }
}
