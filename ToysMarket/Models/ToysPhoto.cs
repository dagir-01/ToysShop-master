//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToysMarket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToysPhoto
    {
        public int ID { get; set; }
        public int ToysID { get; set; }
        public byte[] PhotoPath { get; set; }
    
        public virtual toys toys { get; set; }
    }
}
