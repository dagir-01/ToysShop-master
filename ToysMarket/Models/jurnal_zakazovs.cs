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
    
    public partial class jurnal_zakazovs
    {
        public int id { get; set; }
        public int id_zakaz { get; set; }
        public int id_toys { get; set; }
        public int quantity { get; set; }
    
        public virtual toys toys { get; set; }
        public virtual zakaz zakaz { get; set; }
    }
}
