using DAL.Core.Entities;
using DAL.Core.Interfaces;

namespace CrudMediatr.Api
{
    public class MockupCarLocalRepository : IMockupLocalRepository<CarEntity>
    {
        private readonly IRepository<SparePartsEntity> _sparePartsRepository;

        public MockupCarLocalRepository(IRepository<SparePartsEntity> sparePartsRepository)
        {
            _sparePartsRepository = sparePartsRepository;
        }

        public IQueryable<CarEntity> GetQuery()
        {
            return new List<CarEntity>()
            {
                new CarEntity()
                {
                    Id = 0,
                    Name = "BMW",
                    SpareParts = GetSparePartsByIndex(0, 1, 2)
                },
                new CarEntity()
                {
                    Id = 1,
                    Name = "VW",
                    SpareParts = GetSparePartsByIndex(0, 1, 3)
                },
                new CarEntity()
                {
                    Id = 2,
                    Name = "Toyota",
                    SpareParts = GetSparePartsByIndex(0, 1, 4)
                },
                new CarEntity()
                {
                    Id = 3,
                    Name = "BMW-1",
                    SpareParts = GetSparePartsByIndex(0, 1)
                },
                new CarEntity()
                {
                    Id = 4,
                    Name = "BMW-2",
                    SpareParts = GetSparePartsByIndex(0, 1)
                },
                new CarEntity()
                {
                    Id = 5,
                    Name = "BMW-3",
                    SpareParts = GetSparePartsByIndex(0, 1)
                },
                new CarEntity()
                {
                    Id = 6,
                    Name = "BMW-4",
                    SpareParts = GetSparePartsByIndex(0, 1)
                },
                new CarEntity()
                {
                    Id = 7,
                    Name = "BMW-5",
                    SpareParts = GetSparePartsByIndex(0, 1)
                },
                new CarEntity()
                {
                    Id = 8,
                    Name = "BMW-6",
                    SpareParts = GetSparePartsByIndex(0, 1)
                },
                new CarEntity()
                {
                    Id = 9,
                    Name = "BMW-7",
                    SpareParts = GetSparePartsByIndex(0, 1)
                }
            }.AsQueryable();
        }

        private IQueryable<SparePartsEntity> GetSparePartsByIndex(params long[] ids)
        {
            return _sparePartsRepository.GetQuery()
                .Where(x => ids.Contains(x.Id));
        }
    }


}
