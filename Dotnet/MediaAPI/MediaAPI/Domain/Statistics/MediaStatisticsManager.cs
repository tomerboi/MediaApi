using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaAPI.Domain.Statistics
{
    public class MediaStatisticsManager : IMediaStatistics
    {
        private Dictionary<Guid, List<MediaStatistics>> m_allStatistics;
        private Dictionary<Guid, MediaStatistics> m_currentStatistics;

        public MediaStatisticsManager()
        {
            m_allStatistics = new Dictionary<Guid, List<MediaStatistics>>();
            m_currentStatistics = new Dictionary<Guid, MediaStatistics>();
        }

        public async Task<string> GetStatisticsForMedia(Guid id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Media was in use at these dates: ");
            sb.Append(Environment.NewLine);
            if (m_allStatistics.ContainsKey(id))
            {
                foreach (var stat in m_allStatistics[id])
                {
                    sb.Append($"From : {stat.StartTime} To: {stat.EndTime} By: {stat.UsingPerson.Name}");
                    sb.Append(Environment.NewLine);
                }
            }
            if (m_currentStatistics.ContainsKey(id))
            {
                var media = m_currentStatistics[id];
                sb.Append($"From: {media.StartTime} Till now By: {media.UsingPerson.Name}");
            }

            return sb.ToString();
        }

        public async Task RegisterMedia(Guid id, Person person)
        {
            if (m_currentStatistics.ContainsKey(id))
            {
                return;
            }
                
            var mediaStat = new MediaStatistics();
            mediaStat.StartTime = DateTime.Now;
            mediaStat.UsingPerson = person;

            m_currentStatistics.Add(id, mediaStat);
        }

        public async Task UnRegisterMedia(Guid id)
        {
            if (!m_currentStatistics.ContainsKey(id))
            {
                return;
            }

            var media = m_currentStatistics[id];
            media.EndTime = DateTime.Now;
            if (!m_allStatistics.ContainsKey(id))
            {
                m_allStatistics.Add(id, new List<MediaStatistics>() { media });
            }
            else
            {
                m_allStatistics[id].Add(media);
            }

            m_currentStatistics.Remove(id);
        }
    }
}
