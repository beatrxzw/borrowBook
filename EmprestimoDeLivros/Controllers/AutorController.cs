using EmprestimoDeLivros.Dto.Autor;
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
        
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
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

        [HttpGet("BuscarAutorPorLivroId/{idLivro}")]
       public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarAutorPorLivroId(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("RegistrarAutor")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> RegistrarAutor(AutorRegistroDto autorRegistroDto)
        {
            var autores = await _autorInterface.RegistrarAutor(autorRegistroDto);
            return Ok(autores);
        }

        [HttpDelete("DeletarAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> DeletarAutor(int idAutor)
        {
            var autor = await _autorInterface.RemoverAutor(idAutor);
            return Ok(autor);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autor = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autor);
        }

    }
}
 