using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPersonasUni
{
    public abstract class clsPersonasUni
    {
        #region "Atributos protegidos"
        protected string strDocumento;
        protected string strNombres;
        protected DateTime dtmFechaNac;
        protected string strTelefono;
        protected string strError;
        #endregion

        #region "Propiedades"
        public string Documento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }
        public string Nombre
        {
            get { return strNombres; }
            set { strNombres = value; }
        }
        public DateTime FechaNac
        {
            get { return dtmFechaNac; }
            set { dtmFechaNac = value; }
        }
        public string Telefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }
        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos publicos"
        public abstract bool Grabar();
        #endregion
    }
}
