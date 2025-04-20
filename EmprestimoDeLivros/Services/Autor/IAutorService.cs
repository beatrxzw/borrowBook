using EmprestimoDeLivros.Models;

namespace EmprestimoDeLivros.Services.Autor
{
    public interface IAutorService
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId( int idAutor );
        Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro);
    }
}
