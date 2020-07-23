using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.Statistics
{
    public interface IMediaStatistics
    {
        Task RegisterMedia(Guid media, Person person);
        Task UnRegisterMedia(Guid media);
        Task<string> GetStatisticsForMedia(Guid id);
    }
}
