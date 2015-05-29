using System.Collections.Generic;
using FlickrTest.Models;

namespace FlickrTest.Repository
{
    /// <summary>
    /// The Repository interface
    /// </summary>
    public interface IRepository
    {
        FlickrImagesCollection GetImagesByTags(string tags);
    }
}
