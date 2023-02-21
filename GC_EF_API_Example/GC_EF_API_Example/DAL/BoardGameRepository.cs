using GC_EF_API_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace GC_EF_API_Example.DAL
{
    public class BoardGameRespository
    {
        private GameContext _dbContext = new GameContext();

        public BoardGame AddBoardGame(BoardGame game)
        {
            _dbContext.BoardGames.Add(game);
            _dbContext.SaveChanges();
            return GetLatestBoardGame();
        }
        private BoardGame GetLatestBoardGame()
        {
            return _dbContext.BoardGames
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();
        }
        public IEnumerable<BoardGame> GetAllBoardGames()
        {
            return _dbContext.BoardGames.ToList();
        }
        public BoardGame FindById(int id)
        {
            return _dbContext.BoardGames
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
        public bool DeleteById(int id)
        {
            if(FindById(id) == null)
            {
                return false;
            }
            _dbContext.BoardGames.Remove(FindById(id));
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateBoardGame(BoardGame game)
        {
            if (FindById(game.Id) == null)
            {
                return false;
            }
            _dbContext.BoardGames.Update(game);
            _dbContext.SaveChanges();
            return true;
        }
    }

}
