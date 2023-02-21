using GC_EF_API_Example.Models;

namespace GC_EF_API_Example.DAL
{
    public class FishRepository
    {
        private GameContext _db = new GameContext();

        public FishRepository() { }
        public Fish AddFish(Fish fishToAdd)
        {
            _db.Add(fishToAdd);
            _db.SaveChanges();
            return GoFishingForLatest();
        }
        public Fish GoFishingForLatest()
        {
            return _db.Fishes
                .OrderByDescending(fish => fish.Id)
                .FirstOrDefault();
        }
    }
}
