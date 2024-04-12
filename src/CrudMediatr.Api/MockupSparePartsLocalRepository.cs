using DAL.Core.Entities;
using DAL.Core.Interfaces;

namespace CrudMediatr.Api
{
    public class MockupSparePartsLocalRepository : IMockupLocalRepository<SparePartsEntity>
    {
        private readonly List<SparePartsEntity> _spareParts = new List<SparePartsEntity>()
        {
            new SparePartsEntity() { Id = 0, Name = "Steering wheel"},
            new SparePartsEntity() { Id = 1, Name = "Wheels"},
            new SparePartsEntity() { Id = 2, Name = "Engine"},
            new SparePartsEntity() { Id = 3, Name = "Electric motor"},
            new SparePartsEntity() { Id = 4, Name = "Durability"},
        };

        public IQueryable<SparePartsEntity> GetQuery()
        {
            return _spareParts.AsQueryable();
        }
    }
}
