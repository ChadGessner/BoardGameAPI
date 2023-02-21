using GC_EF_API_Example.DAL;
using GC_EF_API_Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace GC_EF_API_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        BoardGameRespository repo = new BoardGameRespository();

        [HttpPost("add")]
        public BoardGame AddBoardGame(string title, string description, int year, int count)
        {
            BoardGame newBoardGame = new BoardGame
            {
                Title = title,
                Description = description,
                YearPublished = year,
                RecommendedPlayerCount = count
            };
            return repo.AddBoardGame(newBoardGame);
        }
        [HttpGet()]
        public List<BoardGame> GetAll()
        {
            return repo
                .GetAllBoardGames()
                .ToList();
        }
        [HttpGet("{id}")]
        public BoardGame GetById(int id)
        {
            return repo.FindById(id);
        }
        [HttpPost("delete")]
        public HttpResponseMessage DeleteById(int id)
        {
            try
            {
                if (repo.DeleteById(id) == true)
                {
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
            
        }
        [HttpPost("update")]
        public HttpResponseMessage UpdateBoardGame(int id, string title, string description, int year, int count)
        {
            BoardGame newBoardGame = new BoardGame
            {
                Id = id,
                Title = title,
                Description = description,
                YearPublished = year,
                RecommendedPlayerCount = count
            };
            try
            {
                if (repo.UpdateBoardGame(newBoardGame) == true)
                {
                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
            
        }

    }
}
