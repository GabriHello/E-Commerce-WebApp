namespace E_Commerce_WebApp.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public int ItemID { get; set; }

        public double OrderPrice { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderStatus { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderBuyDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderCompDate { get; set; }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }
    }
}
