//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneStore.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using PhoneStore.Models;
    using PhoneStore.BL.Service;

    public partial class ImageEntity : IStorageModel<ApplicationImage> 
    {
        public int ImageId { get; set; }
        public string Image { get; set; }
        public int PhoneId { get; set; }
    
        public virtual PhoneEntity Phones { get; set; }
    }
}
