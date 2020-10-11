using BeepMan.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IImageService
    {
        Task<bool> AddImage(Guid productId, ImageViewModel image);

        Task<bool> RemoveImage(Guid imageId);

        IList<ImageViewModel> GetProductImages(Guid productId);
    }
}
