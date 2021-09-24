using AppReservas.Backend.Data;
using AppReservas.Backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppReservas.Backend.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilController : ControllerBase
    {
        private readonly IUtilRepository _repo;
        public UtilController(IUtilRepository repo)
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
                response.Data = _repo.ListarEspecialidades();
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("ListarCargos")]
        public BaseResponse<List<CargoDTO>> ListarCargos()
        {
            var response = new BaseResponse<List<CargoDTO>>();
            try
            {
                response.Data = _repo.ListarCargos();
                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet]
        [Route("ListarTipoDocumento")]
        public BaseResponse<List<TipoDocumentoDTO>> ListarTipoDocumento()
        {
            var response = new BaseResponse<List<TipoDocumentoDTO>>();
            try
            {
                response.Data = _repo.ListarTipoDocumento();
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
