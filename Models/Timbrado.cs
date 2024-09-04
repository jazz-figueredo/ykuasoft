namespace ykuasoft.Models
{
    public class Timbrado
    {
        public int Nro_timbrado { get; set; }
        public string? Establecimiento { get; set; }
        public string? Punto_expedicion { get; set; }
        public DateTime? Fecha_desde { get; set; }
        public DateTime? Fecha_hasta { get; set; }
        public int? Desde_nro_fac { get; set; }
        public int? Hasta_nro_fac { get; set; }
        public int? Numero_actual { get; set; }
    }
}
