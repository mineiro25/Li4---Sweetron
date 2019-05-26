namespace $safeprojectname$.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Solicita")]
    public partial class Solicita
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Utilizador { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Receita { get; set; }

        public int? Avaliacao { get; set; }

        public bool? Favorito { get; set; }

        [StringLength(200)]
        public string Comentario { get; set; }

        public virtual Receita Receita { get; set; }

        public virtual Utilizador Utilizador { get; set; }
    }
}
