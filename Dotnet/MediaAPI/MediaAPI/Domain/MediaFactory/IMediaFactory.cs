using MediaAPI.Contracts.V1.Requset;
using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain.MediaFactory
{
    public interface IMediaFactory
    {
        Task<MediaAbs> CreateMedia(MediaRequest mediaRequest);
    }
}
