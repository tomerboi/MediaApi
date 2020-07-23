using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.Library
{
    public interface ILibrary
    {
        Task<bool> IsMediaInUse(MediaAbs media);
        Task AddMediaToLibrary(MediaAbs media);
        Task<List<MediaAbs>> GetAllMediaInLibrary();
        Task<bool> ChangeMedia(MediaAbs media, string id);
        Task<List<string>> GetAllMediaTypes();
        Task<List<string>> GetAllEventTypes();
        Task<MediaAbs> GetMediaById(Guid id);

    }
}
