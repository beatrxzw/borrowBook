using EmprestimoDeLivros.Dto.Autor;
using EmprestimoDeLivros.Models;

namespace EmprestimoDeLivros.Services.Autor
{
    public interface IAutorService
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId( int idAutor );
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> RegistrarAutor(AutorRegistroDto autorRegistroDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto );
        Task<ResponseModel<List<AutorModel>>> RemoverAutor(int idAutor);

    }
}
