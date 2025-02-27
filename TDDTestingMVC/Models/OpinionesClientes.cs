using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC.Models
{
    public class OpinionesClientes
    {
        [Key]
        public int OpinionID { get; set; } // Identificador único autoincremental

        [Required]
        public int ClienteID { get; set; } // Cliente que deja la opinión

        public int? ProductoID { get; set; } // Producto sobre el que opina (puede ser NULL)

        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion { get; set; } // Rango de calificación de 1 a 5

        [MaxLength(500)]
        public string? Comentario { get; set; } // Opinión en texto

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Fecha { get; set; } = DateTime.Now; // Fecha de la opinión con valor por defecto

        // Relaciones con Cliente y Producto (si usas Entity Framework)
        [ForeignKey("ClienteID")]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Productos? Producto { get; set; }

    }
}
