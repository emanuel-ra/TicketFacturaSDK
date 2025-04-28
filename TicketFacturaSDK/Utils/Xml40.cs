using System;
using System.Collections.Generic;
using System.Xml;
using static TicketFacturaSDK.DTOs.Xml40DTO;

namespace TicketFacturaSDK.Utils
{
    public class Xml40
    {
        private readonly string CFDI_NAMESPACE = "http://www.sat.gob.mx/cfd/4";
        private readonly string CFDI_TFD_NAMESPACE = "http://www.sat.gob.mx/TimbreFiscalDigital";
        public Comprobante Deserialize(string xml)
        {
            Comprobante comprobante = new Comprobante();
            Emisor emisor = new Emisor();
            Receptor receptor = new Receptor();
            Conceptos conceptos = new Conceptos();
            Complemento complemento = new Complemento();
            TimbreFiscalDigital timbreFiscalDigital = new TimbreFiscalDigital();

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);

                XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDocument.NameTable);
                XmlNamespaceManager tfd = new XmlNamespaceManager(xmlDocument.NameTable);

                nsm.AddNamespace("cfdi", CFDI_NAMESPACE);
                tfd.AddNamespace("tfd", CFDI_TFD_NAMESPACE);

                // Comprobante 
                XmlNode nodeComprobante = xmlDocument.SelectSingleNode("//cfdi:Comprobante", nsm);
                // Emisor
                XmlNode nodeEmisor = nodeComprobante.SelectSingleNode("cfdi:Emisor", nsm);
                //Receptor
                XmlNode nodeReceptor = nodeComprobante.SelectSingleNode("cfdi:Receptor", nsm);
                //Conceptos
                XmlNode nodeConceptos = nodeComprobante.SelectSingleNode("//cfdi:Conceptos", nsm);
                //Complemento
                XmlNode nodeComplemento = nodeComprobante.SelectSingleNode("//cfdi:Complemento", nsm);
                //TimbreFiscalDigital
                XmlNode nodeTimbreFiscalDigital = nodeComplemento.SelectSingleNode("//tfd:TimbreFiscalDigital", tfd);

                // COMPROBANTE 
                comprobante.Version = nodeComprobante.Attributes["Version"].Value;
                comprobante.Fecha = nodeComprobante.Attributes["Fecha"].Value;
                comprobante.Serie = nodeComprobante.Attributes["Serie"].Value;
                comprobante.Folio = nodeComprobante.Attributes["Folio"].Value;
                comprobante.FormaPago = nodeComprobante.Attributes["FormaPago"].Value;
                comprobante.Moneda = nodeComprobante.Attributes["Moneda"].Value;
                comprobante.TipoDeComprobante = nodeComprobante.Attributes["TipoDeComprobante"].Value;
                comprobante.MetodoPago = nodeComprobante.Attributes["MetodoPago"].Value;
                comprobante.LugarExpedicion = nodeComprobante.Attributes["LugarExpedicion"].Value;
                comprobante.Exportacion = nodeComprobante.Attributes["Exportacion"].Value;
                comprobante.SubTotal = Convert.ToDecimal(nodeComprobante.Attributes["SubTotal"].Value);
                comprobante.Total = Convert.ToDecimal(nodeComprobante.Attributes["Total"].Value);

                // EMISOR 
                emisor.Nombre = nodeEmisor.Attributes["Nombre"].Value;
                emisor.Rfc = nodeEmisor.Attributes["Rfc"].Value;
                emisor.RegimenFiscal = nodeEmisor.Attributes["RegimenFiscal"].Value;

                // RECEPTOR
                receptor.Nombre = nodeReceptor.Attributes["Nombre"].Value;
                receptor.Rfc = nodeReceptor.Attributes["Rfc"].Value;
                receptor.UsoCFDI = nodeReceptor.Attributes["UsoCFDI"].Value;
                receptor.DomicilioFiscalReceptor = nodeReceptor.Attributes["DomicilioFiscalReceptor"].Value;
                receptor.RegimenFiscalReceptor = nodeReceptor.Attributes["RegimenFiscalReceptor"].Value;

                timbreFiscalDigital.UUID = nodeTimbreFiscalDigital.Attributes["UUID"].Value;
                timbreFiscalDigital.FechaTimbrado = nodeTimbreFiscalDigital.Attributes["FechaTimbrado"].Value;

                complemento.TimbreFiscalDigital = timbreFiscalDigital;

                // CONCEPTOS 
                List<Concepto> concepto = new List<Concepto>();
                foreach (XmlNode node in nodeConceptos.SelectNodes("//cfdi:Concepto", nsm))
                {
                    concepto.Add(new Concepto
                    {
                        NoIdentificacion = node.Attributes["NoIdentificacion"].Value,
                        Descripcion = node.Attributes["Descripcion"].Value,
                        ClaveProdServ = node.Attributes["ClaveProdServ"].Value,
                        ClaveUnidad = node.Attributes["ClaveUnidad"].Value,
                        ObjetoImp = node.Attributes["ObjetoImp"].Value,
                        Cantidad = Convert.ToDecimal(node.Attributes["Cantidad"].Value),
                        ValorUnitario = Convert.ToDecimal(node.Attributes["ValorUnitario"].Value),
                        Importe = Convert.ToDecimal(node.Attributes["Importe"].Value)
                    });

                }
                conceptos.Concepto = concepto;
                comprobante.Emisor = emisor;
                comprobante.Receptor = receptor;
                comprobante.Conceptos = conceptos;
                comprobante.Complemento = complemento;


            }
            catch (Exception ex)
            {
                throw new Exception("Error deserializando el XML", ex);
            }
            return comprobante;
        }
    }
}
