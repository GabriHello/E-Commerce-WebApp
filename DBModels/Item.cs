namespace E_Commerce_WebApp.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Orders = new HashSet<Order>();
        }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        public int ItemID { get; set; }

        public double ItemPrice { get; set; }

        [StringLength(2000)]
        public string ItemDescription { get; set; }

        public int Remaining { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
