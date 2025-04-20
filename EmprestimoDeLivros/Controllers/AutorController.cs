using EmprestimoDeLivros.Models;
using EmprestimoDeLivros.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoDeLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorInterface;
        public AutorController( IAutorService autorInterface )
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        
        public async Task<ActionResult<ResponseModel<AutorModel>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);   
        }
    }
}
