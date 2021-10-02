using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppReservas.Backend.Data.Interface;
using AppReservas.Backend.Entity;
using AppReservas.Backend.Entity.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppReservas.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoRepository _repo;
        public EmpleadoController(IEmpleadoRepository repo)
        {
            this._repo = repo;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getEmpleados")]
        public ActionResult GetEmpleados()
        {
            var response = new BaseResponse<List<EmpleadoDTO>>();
            response.Data = _repo.Listar();
            response.Succeeded = true;

            return Json(response);
        }

        [HttpGet]
        [Route("Listar")]
        public BaseResponse<List<EmpleadoDTO>> Listar()
        {
            var response = new BaseResponse<List<EmpleadoDTO>>();
            try
            {
                response.Data = _repo.Listar();
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("Mantener")]
        public BaseResponse<int> Mantener([FromBody] EmpleadoRequest request)
        {
            var response = new BaseResponse<int>();
            try
            {
                response.Data = _repo.MantenerEmpleado(request);
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}