using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppReservas.Backend.Entity;
using AppReservas.Backend.Data;

namespace AppReservas.Backend.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : Controller
    {
        private readonly IEspecialidadRepository _repo;
        public EspecialidadController(IEspecialidadRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        [Route("ListarEspecialidades")]
        public BaseResponse<List<EspecialidadDTO>> ListarEspecialidades()
        {
            var response = new BaseResponse<List<EspecialidadDTO>>();
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
    }
}
