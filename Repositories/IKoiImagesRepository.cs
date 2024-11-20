using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IKoiImagesRepository
    {
        public ObservableCollection<KoiImage> GetImagesForKoi(int koiId);

        public Dictionary<int, List<string>> GetImagesForAllKois();


    }
}
