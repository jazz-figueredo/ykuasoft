namespace ykuasoft.Models
{
    public class FormaPago
    {
        public int Id_forma_pago { get; set; }
        public string? Descripcion { get; set; }
        public string? Requiere_nro_comprob { get; set; }
        public int Porcentaje_recargo { get; set; }
        public int Porcentaje_descuento { get; set; }
    }
}
