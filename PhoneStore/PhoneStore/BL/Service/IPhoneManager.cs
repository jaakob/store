using System.Collections.Generic;
using PhoneStore.Models;

namespace PhoneStore.BL.Service
{
    public interface IPhoneManager
    {
        Phone GetPhone(int id);
        int GetPhoneId(Phone phone);
        List<Phone> FindPhones(string searchString);
        void Add(Phone phone);
        void AddImage(Image image);
        List<string> GetImagesForPhone(Phone phone);
        List<Phone> GetPhones(int from, int to);
        List<Phone> GetPhones();
    }
}
