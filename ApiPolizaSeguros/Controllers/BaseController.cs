using Common.Extensions;
using Common.Models;
using Common.Resources;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiPolizaSeguros.Controllers
{
    public abstract class BaseController<TDTO> : Controller
        where TDTO : class
    {
        IBaseService<TDTO> _service;

        public BaseController(IBaseService<TDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public virtual async Task<IActionResult> Index()
        {
            var data =  _service.GetAll();
            return Json(data.AsResponseDTO((int)HttpStatusCode.OK));
        }


        [HttpGet]
        [Route("details/{id}")]
        public virtual async Task<IActionResult> Details(string id)
        {
            var data =  _service.FindById(id);
            if (data == null)
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, GlobalResource.ItemNotFoundMessage));

            return Json(data.AsResponseDTO((int)HttpStatusCode.OK));
        }


        [HttpPost]
        [Route("create")]
        public virtual async Task<IActionResult> Create([FromBody]TDTO modelDTO)
        {
            var data =  _service.Create(modelDTO);
            return Json(data.AsResponseDTO((int)HttpStatusCode.OK,
                GlobalResource.CreateSuccessMessage));
        }


        [HttpPost]
        [Route("edit")]
        public virtual async Task<IActionResult> Edit([FromBody]TDTO modelDTO)
        {
            var id = modelDTO.GetPrimaryKeyValue();
            if (id == null)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                  (int)HttpStatusCode.NotAcceptable, GlobalResource.ItemNotFoundMessage));
            }

            var data =  _service.FindById(id);
            if (data == null)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, GlobalResource.ItemNotFoundMessage));
            }

            var result =  _service.Update(modelDTO);

            return Json(result.AsResponseDTO((int)HttpStatusCode.OK,
                GlobalResource.UpdateSuccessMessage));
        }

        [HttpPost]
        [Route("delete")]
        public virtual async Task<IActionResult> Delete([FromBody]RequestDTO request)
        {
            var data = _service.FindById(request.Id);
            if (data == null)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                                        (int)HttpStatusCode.NotAcceptable, GlobalResource.ItemNotFoundMessage));
            }

             _service.Delete(request.Id);
            return Json(ResponseExtension.AsResponseDTO<string>(null,
                (int)HttpStatusCode.OK, GlobalResource.DeleteSuccessMessage));
        }
    }
}
