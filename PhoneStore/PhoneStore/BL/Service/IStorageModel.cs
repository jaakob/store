using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;

namespace PhoneStore.BL.Service
{
   public interface IStorageModel<T>
        where T : IApplicationModel
    {
        T ConvertToApplicationModel();
        IStorageModel<T> FromApplicationModel(T model);
    }
}
