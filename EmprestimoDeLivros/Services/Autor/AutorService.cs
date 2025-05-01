using EmprestimoDeLivros.Data;
using EmprestimoDeLivros.Dto.Autor;
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

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livro
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    response.Message = "Nenhum autor localizado!";
                    return response;
                } 

                response.Data = livro.Autor;
                response.Message = "Autor encontrado com sucesso!";
                return response;

            }
            catch(Exception ex)
            {
                    response.Message = ex.Message;
                    response.Status = false;
                    return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores
                                 .FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);
                if(autor == null)
                {
                    response.Message = "Autor não encontrado!";
                    return response;
                }

                autor.Name = autorEdicaoDto.Name;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                response.Data = await _context.Autores.ToListAsync();
                response.Message = "Alteração realizada com sucesso!";

                return response;

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
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

        public async Task<ResponseModel<List<AutorModel>>> RegistrarAutor(AutorRegistroDto autorRegistroDto)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel()
                {
                    Name = autorRegistroDto.Name,
                    Sobrenome = autorRegistroDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                response.Data = await _context.Autores.ToListAsync();
                response.Message = "Autor registrado com sucesso!";

                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> RemoverAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    response.Message = "Nenhum autor localizado!";
                    return response;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                response.Data = await _context.Autores.ToListAsync();
                response.Message = "Autor removido com sucesso!";

                return response;

            } catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
