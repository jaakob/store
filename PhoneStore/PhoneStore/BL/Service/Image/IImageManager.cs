using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;

namespace PhoneStore.BL.Service.Image
{
    public interface IImageManager
    {
        void Add(ApplicationImage image);
    }
}
