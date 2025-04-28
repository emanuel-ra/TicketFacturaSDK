using System.Collections.Generic;

namespace TicketFacturaSDK.DTOs
{
    public class Xml40DTO
    {
        public class Comprobante
        {
            public string Version { get; set; }
            public string Fecha { get; set; }
            public string Serie { get; set; }
            public string Folio { get; set; }
            public string FormaPago { get; set; }
            public string Moneda { get; set; }
            public string TipoDeComprobante { get; set; }
            public string MetodoPago { get; set; }
            public string LugarExpedicion { get; set; }
            public string Exportacion { get; set; }
            public decimal SubTotal { get; set; }
            public decimal Total { get; set; }
            public Emisor Emisor { get; set; }
            public Receptor Receptor { get; set; }
            public Conceptos Conceptos { get; set; }
            public Complemento Complemento { get; set; }
        }
        public class Emisor
        {
            public string Rfc { get; set; }
            public string Nombre { get; set; }
            public string RegimenFiscal { get; set; }
        }
        public class Receptor
        {
            public string Rfc { get; set; }
            public string Nombre { get; set; }
            public string UsoCFDI { get; set; }
            public string DomicilioFiscalReceptor { get; set; }
            public string RegimenFiscalReceptor { get; set; }
        }
        public class Conceptos
        {
            public List<Concepto> Concepto { get; set; }
        }
        public class Concepto
        {
            public string NoIdentificacion { get; set; }
            public string Descripcion { get; set; }
            public string ClaveProdServ { get; set; }
            public string ClaveUnidad { get; set; }
            public string ObjetoImp { get; set; }
            public decimal Cantidad { get; set; }
            public decimal ValorUnitario { get; set; }
            public decimal Importe { get; set; }
            //public Impuestos Impuestos { get; set; }
        }
        public class Impuestos
        {
            public Traslados Traslados { get; set; }
        }
        public class Traslados
        {
            public Traslado Traslado { get; set; }
        }
        public class Traslado
        {
            public decimal Base { get; set; }
            public string Impuesto { get; set; }
            public string TipoFactor { get; set; }
            public decimal TasaOCuota { get; set; }
            public decimal Importe { get; set; }
        }
        public class Complemento
        {
            public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
        }
        public class TimbreFiscalDigital
        {
            public string FechaTimbrado { get; set; }
            public string UUID { get; set; }
        }
    }
}
