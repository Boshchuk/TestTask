using System.Collections.Generic;

namespace FlickrTest.Models
{
    /// <summary>
    /// Collection of Flickr Images
    /// </summary>
    public class FlickrImagesCollection
    {
        /// <summary>
        /// List of Flickr images
        /// </summary>
        public List<FlickrImage> Images { get; set; }

        /// <summary>
        /// Flag is data gettet from chache or not
        /// </summary>
        public bool ResultIsGettedFromCache {get; set; }
    }
}