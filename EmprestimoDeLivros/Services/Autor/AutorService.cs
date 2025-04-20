using EmprestimoDeLivros.Data;
using EmprestimoDeLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoDeLivros.Services.Autor
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {

            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    response.Message = "Autor não encontrado!";
                    return response;
                }

                response.Data = autor;
                response.Message = "Autor encontrado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();

                response.Data = autores;
                response.Message = "Autores coletados com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
