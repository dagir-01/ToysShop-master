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
    
    public partial class Jurnal_postavok
    {
        public int id { get; set; }
        public int id_postavki { get; set; }
        public int id_toys { get; set; }
        public int count { get; set; }
    
        public virtual postavki postavki { get; set; }
        public virtual toys toys { get; set; }
    }
}
