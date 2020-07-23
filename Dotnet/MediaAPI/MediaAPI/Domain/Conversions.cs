using MediaAPI.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaAPI.Domain
{
    public static class Conversions
    {
        public static Dictionary<EventType, string> EventTypeToStringRepresentation = new Dictionary<EventType, string>() 
        {
            { EventType.Bar_Mitzva, "Bar Mitzva"},
            { EventType.Birthday, "Birthday"},
            { EventType.Holiday, "Holiday"},
            { EventType.Wedding, "Wedding"}
        };
        public static Dictionary<string, string> MediaTypeToStringRepresentation = new Dictionary<string, string>() 
        {
            {nameof(BookMedia), "Book" },
            {nameof(CDMedia), "CD" },
            {nameof(DiskOnKeyMedia), "Disk On Key" },
            {nameof(PhotoAlbumMedia), "Photo Album" }
        };
    }
}
