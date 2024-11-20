using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KoiFishService : IKoiFIshService
    {
        private readonly IKoiFishRepository _repository;

        public KoiFishService()
        {
            _repository = new KoiFishRepository();
        }

        public void Add(KoiFish koi)
        {
            _repository.Add(koi);
        }

        public void Delete(KoiFish koi)
        {
            _repository.Delete(koi);
        }

        public List<KoiBreedType> GetAllBreedTypes()
        {
            return _repository.GetAllBreedTypes();
        }

        public List<KoiFish> GetAllKois()
        {
            return _repository.GetAllKois();
        }

        public List<KoiFish> GetAllKois(decimal? minPrice, decimal? maxPrice, int? breedTypeId, decimal? minSize, decimal? maxSize)
        {
            return _repository.GetAllKois(minPrice, maxPrice, breedTypeId, minSize, maxSize);
        }

        public void Update(KoiFish koi)
        {
            _repository.Update(koi);
        }


    }
}
