using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IKoiImagesRepository _repository;
        public ImageService()
        {
            _repository = new KoiImagesRepository();
        }

        public void DeleteImage(string imageId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<string>> GetImagesForAllKois()
        {
            return _repository.GetImagesForAllKois();
        }

        public ObservableCollection<KoiImage> GetImagesForKoi(int koiId)
        {
            return _repository.GetImagesForKoi(koiId);
        }
    }
}
