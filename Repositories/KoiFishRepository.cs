using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiManagementContext _context;

        public KoiFishRepository()
        {
            _context = new KoiManagementContext();
        }

        public void Add(KoiFish koi)
        {
            _context.KoiFishes.Add(koi);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Delete(KoiFish koi)
        {
            var existingKoi = _context.KoiFishes.FirstOrDefault(k => k.KoiId == koi.KoiId);
            if (existingKoi != null)
            {
                existingKoi.IsListed = 0;
            }
            _context.Update(existingKoi);
            SaveChanges();
        }

        public List<KoiBreedType> GetAllBreedTypes()
        {
            return _context.KoiBreedTypes.ToList();
        }

        public List<KoiFish> GetAllKois()
        {
            return _context.KoiFishes.Include(k => k.KoiImages).Include(k => k.BreedType).ToList();
        }

        public List<KoiFish> GetAllKois(decimal? minPrice, decimal? maxPrice, int? breedTypeId, decimal? minSize, decimal? maxSize)
        {
            var query = _context.KoiFishes.AsQueryable();

            if (minPrice.HasValue)
                query = query.Where(k => k.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(k => k.Price <= maxPrice);

            if (breedTypeId.HasValue)
                query = query.Where(k => k.BreedTypeId == breedTypeId);

            if (minSize.HasValue)
                query = query.Where(k => k.Size >= minSize);

            if (maxSize.HasValue)
                query = query.Where(k => k.Size <= maxSize);

            return query.ToList();
        }

        public void Update(KoiFish koi)
        {
            var existingKoi = _context.KoiFishes.FirstOrDefault(k => k.KoiId == koi.KoiId);
            if (existingKoi != null)
            {
                existingKoi.KoiId = koi.KoiId;
                existingKoi.Name = koi.Name;
                existingKoi.Origin = koi.Origin;
                existingKoi.Age = koi.Age;
                existingKoi.Price = koi.Price;
                existingKoi.Color = koi.Color;
                existingKoi.StockQuantity = koi.StockQuantity;
                existingKoi.Size = koi.Size;
                existingKoi.BreedTypeId = koi.BreedTypeId;
            }
            _context.Update(existingKoi);
            SaveChanges();
        }
    }
}
