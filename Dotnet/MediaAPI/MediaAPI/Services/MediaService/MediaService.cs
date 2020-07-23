using MediaAPI.Data;
using MediaAPI.Domain.Library;
using MediaAPI.Domain.Media;
using MediaAPI.Domain.Statistics;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Services.MediaService
{
    public class MediaService : IMediaService
    {
        private readonly DbConnector m_dbConnector;
        private readonly ILibrary m_library;
        private readonly IMediaStatistics m_mediaStatictics;

        public MediaService(DbConnector dbConnector, ILibrary library, IMediaStatistics mediaStatistics)
        {
            m_dbConnector = dbConnector;
            m_library = library;
            m_mediaStatictics = mediaStatistics;
        }

        public async Task AddMedia(MediaAbs media)
        {
            await m_library.AddMediaToLibrary(media);
            if (media.UsingPerson != null)
            {
                await m_mediaStatictics.RegisterMedia(media.Id, media.UsingPerson);
            }
        }

        public Task<List<string>> GetAllEventTypes()
        {
            return m_library.GetAllEventTypes();
        }

        public async Task<List<MediaAbs>> GetAllMedia()
        {
            return await m_library.GetAllMediaInLibrary();
        }

        public Task<List<string>> GetAllMediaTypes()
        {
            return m_library.GetAllMediaTypes();
        }

        public async Task<List<Person>> GetAllParticipants()
        {
            return m_dbConnector.GetAllPersons();
        }

        public async Task<MediaAbs> GetMediaById(Guid id)
        {
            return m_library.GetAllMediaInLibrary().Result.FirstOrDefault(x => x.Id == id);
        }

        public async Task<string> GetMediaStatistics(Guid id)
        {
            return await m_mediaStatictics.GetStatisticsForMedia(id);
        }

        public async Task<Person> GetPersonById(Guid usingPerson)
        {
            return m_dbConnector.GetAllPersons().FirstOrDefault(x => x.Id == usingPerson);
        }

        public async Task<bool> UpdateMedia(MediaAbs media, string id)
        {
            Guid mediaId = Guid.Parse(id);
            var currentMedia = await m_library.GetMediaById(mediaId);
            var changedUsingPerson = currentMedia.UsingPerson != media.UsingPerson;
            var updated = await m_library.ChangeMedia(media, id);
            if (!updated)
                return false;

            var mediaStatUpdated = true;
            if (changedUsingPerson)
            {
                await m_mediaStatictics.UnRegisterMedia(mediaId);
                await m_mediaStatictics.RegisterMedia(mediaId, media.UsingPerson);
            }

            return mediaStatUpdated;

        }
    }
}
