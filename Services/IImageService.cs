using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageService
    {
        public ObservableCollection<KoiImage> GetImagesForKoi(int koiId);
        public void DeleteImage(string imageId);

        public Dictionary<int, List<string>> GetImagesForAllKois();
    }
}
