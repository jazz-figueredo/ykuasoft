namespace ykuasoft.Models
{
    public class Usuarios
    {
        public int Id_usuario { get; set; }
        public string? Nombre_usuario { get; set; }
        public string? Contrasenha { get; set; }
        public string? Activo { get; set; }
        public DateTime? Fecha_alta { get; set; }
        public DateTime? FechaInactivacion { get; set; }
    }
}
