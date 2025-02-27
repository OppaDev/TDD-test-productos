namespace TDDTestingMVC.Models
{
    public class Productos
    {
        public int ProductoID { get; set; } 
        public string Nombre { get; set; } = string.Empty; 
        public string? Descripcion { get; set; } 
        public decimal Precio { get; set; } 
        public int Stock { get; set; } 

        
        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombre) && Precio > 0 && Stock >= 0;
        }
    }
}
