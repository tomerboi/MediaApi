using MediaAPI.Domain.Media;
using MediaAPI.Domain.Statistics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.Library
{
    public class Library : ILibrary
    {
        private readonly ConcurrentBag<MediaAbs> _myMedia;
        public Library()
        {
            _myMedia = new ConcurrentBag<MediaAbs>();
        }

        public async Task AddMediaToLibrary(MediaAbs media)
        {
            _myMedia.Add(media);
        }

        public async Task<bool> ChangeMedia(MediaAbs media, string id)
        {
            MediaAbs selectedMedia = await GetMediaById(Guid.Parse(id));
            if (selectedMedia != null)
            {
                selectedMedia.Date = media.Date;
                selectedMedia.EventType = media.EventType;
                selectedMedia.Location = media.Location;
                selectedMedia.Participants = media.Participants;
                selectedMedia.UsingPerson = media.UsingPerson;
                selectedMedia.Name = media.Name;
                return true;
            }

            return false;
        }

        public async Task<List<string>> GetAllEventTypes()
        {
            return Conversions.EventTypeToStringRepresentation.Values.ToList();
        }

        public async Task<List<MediaAbs>> GetAllMediaInLibrary()
        {
            return _myMedia.ToList();
        }

        public async Task<List<string>> GetAllMediaTypes()
        {
            return Conversions.MediaTypeToStringRepresentation.Values.ToList();
        }

        public async Task<bool> IsMediaInUse(MediaAbs media)
        {
            MediaAbs selectedMedia = await GetMediaById(media.Id);
            return selectedMedia.IsInUse();
        }

        public async Task<MediaAbs> GetMediaById(Guid id)
        {
            return _myMedia.FirstOrDefault(x => x.Id == id);
        }

    }
}
