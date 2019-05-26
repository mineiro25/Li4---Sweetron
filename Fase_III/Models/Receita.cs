namespace $safeprojectname$.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receita")]
    public partial class Receita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receita()
        {
            Possui = new HashSet<Possui>();
            Solicita = new HashSet<Solicita>();
        }

        [Key]
        public int ID_Receita { get; set; }

        public double Rating { get; set; }

        [Required]
        [StringLength(50)]
        public string Dificuldade { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int Duracao { get; set; }

        [Required]
        [StringLength(200)]
        public string Preparacao { get; set; }

        [Required]
        [StringLength(300)]
        public string Video { get; set; }

        [Required]
        [StringLength(300)]
        public string Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Possui> Possui { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicita> Solicita { get; set; }
    }
}
