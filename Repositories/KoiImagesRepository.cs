using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class KoiImagesRepository : IKoiImagesRepository
    {
        private readonly KoiManagementContext _context;
        public KoiImagesRepository()
        {
            _context = new KoiManagementContext();
        }

        public Dictionary<int, List<string>> GetImagesForAllKois()
        {
            return _context.KoiImages
                .GroupBy(ki => ki.KoiId)
                .ToDictionary(
                group => group.Key,
                group => group.Select(ki => ki.ImageUrl).ToList()
                );
        }

        //public ObservableCollection<KoiImage> GetImagesForKoi(int koiId)
        //{
        //    return _context.KoiImages
        //        .Where(ki => ki.KoiId == koiId)
        //        .ToList();
        //}
        public ObservableCollection<KoiImage> GetImagesForKoi(int koiId)
        {
            return new ObservableCollection<KoiImage>(
              _context.KoiImages
              .Where(ki => ki.KoiId == koiId)
              .ToList()
            );
        }
    }
}
