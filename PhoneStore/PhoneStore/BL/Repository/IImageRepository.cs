using System.Collections.Generic;
using PhoneStore.Models;

namespace PhoneStore.BL.Repository
{
    public interface IImageRepository<T>
    {
        T GetImage(int id);
        List<T> GetImagesForPhone(Phone phone);
        void Add(T image);
    }
}
