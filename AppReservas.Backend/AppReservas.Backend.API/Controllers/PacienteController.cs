using AppReservas.Backend.Data;
using AppReservas.Backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppReservas.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repo;
        public PacienteController(IPacienteRepository repo)
        {
            this._repo = repo;
        } 

        [HttpGet]
        [Route("Listar")]
        public BaseResponse<List<PacienteDTO>> Listar([FromBody] PacienteFilter filter)
        {
            var response = new BaseResponse<List<PacienteDTO>>();
            try
            {
                response.Data = _repo.Listar(filter);
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
        public BaseResponse<int> Mantener([FromBody] PacienteRequest request)
        {
            var response = new BaseResponse<int>();
            try
            {
                response.Data = _repo.MantenerPaciente(request);
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
