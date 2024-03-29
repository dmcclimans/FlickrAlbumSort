﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlickrAlbumSort
{
    // Represent a photoset (album).
    // Similar to FlickrNet.Photoset, but
    // - only has fields that I use
    // - add fields:
    //      - EnableSearch
    //      - Status 
    //      - OriginalSortOrder
    public class Photoset
    {
        public Photoset(FlickrNet.Photoset ps)
        {
            EnableSearch = false;
            OriginalSortOrder = -1;

            Title = ps.Title;
            Description = ps.Description;
            NumberOfPhotos = ps.NumberOfPhotos;
            DateCreated = ps.DateCreated;
            PhotosetId = ps.PhotosetId;
            Status = "";
        }

        public bool EnableSearch { get; set; } = false;
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfPhotos { get; set; }
        public DateTime DateCreated { get; set; }
        public string PhotosetId { get; set; }
        public string Status { get; set; } = "";
        public int OriginalSortOrder { get; set; }
    }
}
