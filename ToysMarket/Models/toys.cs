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
    
    public partial class toys
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public toys()
        {
            this.Jurnal_postavok = new HashSet<Jurnal_postavok>();
            this.jurnal_zakazovs = new HashSet<jurnal_zakazovs>();
            this.ToysPhoto = new HashSet<ToysPhoto>();
        }
    
        public int id { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int id_type_toys { get; set; }
        public int id_brends { get; set; }
        public int id_category { get; set; }
        public byte[] image { get; set; }
        public string name { get; set; }
    
        public virtual brends brends { get; set; }
        public virtual categories categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jurnal_postavok> Jurnal_postavok { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<jurnal_zakazovs> jurnal_zakazovs { get; set; }
        public virtual type_toys type_toys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToysPhoto> ToysPhoto { get; set; }
    }
}