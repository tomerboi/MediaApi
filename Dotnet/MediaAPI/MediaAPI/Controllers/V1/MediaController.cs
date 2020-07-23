using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using MediaAPI.Contracts.V1.Requset;
using MediaAPI.Contracts.V1.Response;
using MediaAPI.Domain;
using MediaAPI.Domain.Media;
using MediaAPI.Domain.MediaFactory;
using MediaAPI.Services.MediaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediaAPI.Controllers.V1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService m_mediaService;
        private readonly IMediaFactory m_mediaFactory;
        public MediaController(IMediaService mediaService, IMediaFactory mediaFactory)
        {
            m_mediaService = mediaService;
            m_mediaFactory = mediaFactory;
        }

        [HttpGet("persons")]
        public async Task<IActionResult> GetAllParticipants()
        {
            return Ok(await m_mediaService.GetAllParticipants());
        }

        [HttpGet("eventtype")]
        public async Task<IActionResult> GetAllEventTypes()
        {
            return Ok(await m_mediaService.GetAllEventTypes());
        }

        [HttpGet("mediatype")]
        public async Task<IActionResult> GetAllMediaTypes()
        {
            return Ok(await m_mediaService.GetAllMediaTypes());
        }

        [HttpGet("allmedia")]
        public async Task<IActionResult> GetAllMedia()
        {
            return Ok(m_mediaService.GetAllMedia().Result.Select(x => new MediaResponse()
            { Name = x.Name, Id = x.Id }).ToList());


        }

        [HttpGet("getmedia/{id}")]
        public async Task<IActionResult> GetMediaById(string id)
        {
            var media = await m_mediaService.GetMediaById(Guid.Parse(id));
            if (media == null)
            {
                return NotFound();
            }
            var mediaType = Conversions.MediaTypeToStringRepresentation[media.GetType().Name];
            var eventType = Conversions.EventTypeToStringRepresentation[media.EventType];
            var response = new FullMediaResponse()
            {
                Date = media.Date,
                EventType = eventType,
                Location = media.Location,
                Participants = media.Participants,
                UsingPerson = media.UsingPerson,
                Name = media.Name,
                Id = media.Id,
                MediaType = mediaType
            };
            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost("addmedia")]
        public async Task<IActionResult> AddMedia([FromBody] MediaRequest mediaRequest)
        {
            MediaAbs media = await m_mediaFactory.CreateMedia(mediaRequest);
            if (media == null)
            {
                return BadRequest(new { Error = "Media Type Not Found" });
            }

            await m_mediaService.AddMedia(media);

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}://media";
            var locationUrl = baseUri + "/" + media.Id.ToString();

            var response = new MediaResponse() { Name = media.Name, Id = media.Id };
            return Created(locationUrl, response);
        }

        [HttpPut("updatemedia")]
        public async Task<IActionResult> UpdateMedia([FromBody] MediaRequest mediaRequest)
        {
            MediaAbs media = await m_mediaFactory.CreateMedia(mediaRequest);
            if (media == null)
            {
                return BadRequest(new { Error = "Media Type Not Found" });
            }

            var updated = await m_mediaService.UpdateMedia(media, mediaRequest.Id);
            if (!updated)
            {
                return NotFound();
            }
            return Ok(media);
        }
        [HttpGet("ismediainuse/{id}")]
        public async Task<IActionResult> IsMediaInUse(string id)
        {
            var media = await m_mediaService.GetMediaById(Guid.Parse(id));
            if (media == null)
            {
                return NotFound();
            }

            return Ok(media.UsingPerson);
        }

        [HttpGet("getmediastat/{id}")]
        public async Task<IActionResult> GetMediaStat(string id)
        {
            var stat = await m_mediaService.GetMediaStatistics(Guid.Parse(id));
            if(stat == null)
            {
                return NotFound();
            }

            return Ok(stat);
        }
    }
}
