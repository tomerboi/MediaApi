using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Services.MediaService
{
    public interface IMediaService
    {
        Task<List<Person>> GetAllParticipants();
        Task<List<string>> GetAllMediaTypes();
        Task<List<string>> GetAllEventTypes();
        Task<List<MediaAbs>> GetAllMedia();
        Task AddMedia(MediaAbs media);
        Task<Person> GetPersonById(Guid usingPerson);
        Task<MediaAbs> GetMediaById(Guid id);
        Task<bool> UpdateMedia(MediaAbs media, string id);
        Task<string> GetMediaStatistics(Guid id);
    }
}
