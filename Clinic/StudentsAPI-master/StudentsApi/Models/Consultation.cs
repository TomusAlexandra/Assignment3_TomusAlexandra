namespace StudentsApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consultation")]
    public partial class Consultation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public int? DoctorId { get; set; }

        [StringLength(50)]
        public string Consult { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
