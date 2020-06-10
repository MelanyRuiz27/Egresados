using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EgresadosU.Models
{
    public class SubirArchivoModelo
    {
        public string Confirmacion { get; set; }
        public Exception error { get; set; }
        public void SubirArchivo(string ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                this.Confirmacion = "Archivo guardado";
            }
            catch (Exception ex)
            {
                this.error = ex;
            }
        }
    }
}