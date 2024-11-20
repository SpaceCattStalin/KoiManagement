using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IKoiFishRepository
    {
        public List<KoiFish> GetAllKois();
        public void Add(KoiFish koi);
        public void Delete(KoiFish koi);
        public void Update(KoiFish koi);

        public List<KoiFish> GetAllKois(decimal? minPrice, decimal? maxPrice, int? breedTypeId, decimal? minSize, decimal? maxSize);
        public List<KoiBreedType> GetAllBreedTypes();
    }
}
