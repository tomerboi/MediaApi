using MediaAPI.Contracts.V1.Requset;
using MediaAPI.Domain.Media;
using MediaAPI.Services.MediaService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.MediaFactory
{
    public class MediaFactory : IMediaFactory
    {
        private readonly IMediaService m_mediaService;

        public MediaFactory(IMediaService mediaService)
        {
            m_mediaService = mediaService;
        }

        public async Task<MediaAbs> CreateMedia(MediaRequest mediaRequest)
        {
            try
            {
                EventType eventType = Conversions.EventTypeToStringRepresentation
                                                .Where(x => x.Value == mediaRequest.EventType)
                                                .Select(x => x.Key).First();
                List<Person> participants = JsonConvert.DeserializeObject<List<Person>>(mediaRequest.Participants);
                DateTime date = DateTime.Parse(mediaRequest.Date);

                switch (mediaRequest.MediaType)
                {
                    case "Book":
                        var bookMedia = new BookMedia(mediaRequest.Name, eventType, participants,
                                            date, mediaRequest.Location);
                        await SetUsingPersonIfNeede(bookMedia, mediaRequest.UsingPerson);
                        return bookMedia;
                    case "CD":
                        var cdMedia = new CDMedia(mediaRequest.Name, eventType, participants,
                                            date, mediaRequest.Location);
                        await SetUsingPersonIfNeede(cdMedia, mediaRequest.UsingPerson);
                        return cdMedia;
                    case "Disk On Key":
                        var DiskOnKeyMedia = new DiskOnKeyMedia(mediaRequest.Name, eventType, participants,
                                            date, mediaRequest.Location);
                        await SetUsingPersonIfNeede(DiskOnKeyMedia, mediaRequest.UsingPerson);
                        return DiskOnKeyMedia;
                    case "Photo Album":
                        var PhotoAlbumMedia = new PhotoAlbumMedia(mediaRequest.Name, eventType, participants,
                                            date, mediaRequest.Location);
                        await SetUsingPersonIfNeede(PhotoAlbumMedia, mediaRequest.UsingPerson);
                        return PhotoAlbumMedia;
                    default:
                        return null;

                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        private async Task SetUsingPersonIfNeede(MediaAbs media, string usingPerson)
        {
            if (usingPerson != null)
            {
                Guid UsingPersonId = Guid.Parse(usingPerson);
                Person person = await m_mediaService.GetPersonById(UsingPersonId);
                media.SetUsingPerson(person);
            }
        }
    }
}
