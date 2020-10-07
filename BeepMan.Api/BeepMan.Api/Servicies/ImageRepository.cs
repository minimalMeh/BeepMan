using BeepMan.Model;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Servicies
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(Image item)
        {
            this._context.Images.Add(item);
        }

        public void Delete(Guid id)
        {
            var image = this.Get(id);
            if (image != null)
            {
                _context.Images.Remove(image);
            }
        }

        public Image Get(Guid id)
        {
            return this._context.Images.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Image> GetAll()
        {
            return this._context.Images;
        }

        public void Update(Image item)
        {
            var exItem = this.Get(item.Id);
            if (!item.Equals(exItem))
            {
                this._context.Images.Update(exItem);
            }
        }
    }
}
