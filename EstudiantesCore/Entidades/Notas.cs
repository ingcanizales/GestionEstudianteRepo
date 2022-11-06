using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesCore.Entidades
{
    [Table("Notas", Schema = "GE")]
    public class Notas
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Nota1 { get; set; }

        public decimal Nota2 { get; set; }

        public decimal Nota3 { get; set; }

        [NotMapped]
        public decimal Promedio {

            get
            {
                
                decimal suma = ((this.Nota1 + this.Nota2 + this.Nota3)/3);
               
                return Math.Round(suma, 2);
               
            }

        }

        public virtual Materia Materia { get; set; }

        public virtual Estudiante Estudiante { get; set; }



    }

}