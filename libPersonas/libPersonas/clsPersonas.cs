using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using libPersonasUni;

namespace libPersonas
{
    public class clsEstudiante : clsPersonasUni
    {
        #region "Atributos"
        protected string strFacultad;
        #endregion

        #region "Constructor"
        public clsEstudiante()
        {
            strDocumento = string.Empty;
            strNombres = string.Empty;
            dtmFechaNac = DateTime.MinValue;
            strTelefono = string.Empty;
            strFacultad = string.Empty;
        }
        #endregion

        #region "Propiedades"
        public string Facultad
        {
            get { return strFacultad; }
            set { strFacultad = value; }
        }
        #endregion

        #region "Metodos publicos"
        public override bool Grabar()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class clsPreGrado : clsEstudiante
    {
        #region "Atributos"
        private string strPrograma;
        private string strCarnet;
        #endregion

        #region "Constructor"
        public clsPreGrado()
        {
            strDocumento = string.Empty;
            strNombres = string.Empty;
            dtmFechaNac = DateTime.MinValue;
            strTelefono = string.Empty;
            strFacultad = string.Empty;
            strPrograma = string.Empty;
            strCarnet = string.Empty;
        }
        public clsPreGrado(string Doc, string Nom, DateTime Fech, string Tel, string Facu, string Progam, string Carnt)
        {
            strDocumento = Doc;
            strNombres = Nom;
            dtmFechaNac = Fech;
            strTelefono = Tel;
            strFacultad = Facu;
            strPrograma = Progam;
            strCarnet = Carnt;
        }
        #endregion

        #region "Propiedades"
        public string Programa
        {
            get { return strPrograma; }
            set { strPrograma = value; }
        }
        public string Carnet
        {
            get { return strCarnet; }
            set { strCarnet = value; }
        }
        #endregion

        #region "Metodos privados"
        public bool Validar()
        {
            if (strDocumento == string.Empty)
            {
                strError = " ingrese el documento";
                return false;
            }
            if (strNombres == string.Empty)
            {
                strError = " ingrese el nombre";
                return false;
            }
            if (strTelefono == string.Empty)
            {
                strError = " ingrese el telefono";
                return false;
            }
            if (strFacultad == string.Empty)
            {
                strError = " ingrese la facultad";
                return false;
            }
            if (strPrograma == string.Empty)
            {
                strError = " ingrese el Programa ";
                return false;
            }
            if (strCarnet == string.Empty)
            {
                strError = "ingrese el carnet";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos publicos"
        public override bool Grabar()
        {
            StreamWriter sw = File.AppendText("Pregrado.txt");
            try
            {
                if (!Validar())
                    return false;

                sw.WriteLine(Documento + ";" + Nombre + ";" + FechaNac + ";" + Telefono + ";" + Facultad + ";" + Programa + ";" + Carnet);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }
        #endregion
    }

    public class clsExtension : clsEstudiante
    {
        #region "Atributos"
        private string strCurso;
        #endregion

        #region "Constructor"
        public clsExtension()
        {
            strDocumento = string.Empty;
            strNombres = string.Empty;
            dtmFechaNac = DateTime.MinValue;
            strTelefono = string.Empty;
            strFacultad = string.Empty;
            strCurso = string.Empty;
        }
        public clsExtension(string Doc, string Nom, DateTime Fech, string Tel, string Facu, string Curso)
        {
            strDocumento = Doc;
            strNombres = Nom;
            dtmFechaNac = Fech;
            strTelefono = Tel;
            strFacultad = Facu;
            strCurso = Curso;
        }
        #endregion

        #region "Propiedades"
        public string Curso
        {
            get { return strCurso; }
            set { strCurso = value; }
        }
        #endregion

        #region "Metodos privados"
        public bool Validar()
        {
            if (strDocumento == string.Empty)
            {
                strError = " ingrese el documento";
                return false;
            }
            if (strNombres == string.Empty)
            {
                strError = " ingrese el nombre";
                return false;
            }
            if (strTelefono == string.Empty)
            {
                strError = " ingrese el telefono";
                return false;
            }
            if (strFacultad == string.Empty)
            {
                strError = " ingrese la facultad";
                return false;
            }
            if (strCurso == string.Empty)
            {
                strError = " ingrese el curso ";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos publicos"
        public override bool Grabar()
        {
            StreamWriter sw = File.AppendText("Extension.txt");
            try
            {
                if (!Validar())
                    return false;

                sw.WriteLine(Documento + ";" + Nombre + ";" + FechaNac + ";" + Telefono + ";" + Facultad + ";" + Curso);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
        }
        #endregion
    }

    public class clsEmpleado : clsPersonasUni
    {
        #region "Atributos"
        private string strCargo;
        private int intSalario;
        #endregion

        #region "Constructor"
        public clsEmpleado()
        {
            strDocumento = string.Empty;
            strNombres = string.Empty;
            dtmFechaNac = DateTime.MinValue;
            strTelefono = string.Empty;
            strCargo = string.Empty;
            intSalario = 0;
        }

        public clsEmpleado(string Doc, string Nom, DateTime Fech, string Tel, string cargo, int salario)
        {
            strDocumento = Doc;
            strNombres = Nom;
            dtmFechaNac = Fech;
            strTelefono = Tel;
            strCargo = cargo;
            intSalario = salario;
        }
        #endregion

        #region "Propiedades"
        public string Cargo
        {
            get { return strCargo; }
            set { strCargo = value; }
        }
        public int Salario
        {
            get { return intSalario; }
            set { intSalario = value; }
        }
        #endregion

        #region "Metodos privados"
        public bool Validar()
        {
            if (strDocumento == string.Empty)
            {
                strError = " ingrese el documento";
                return false;
            }
            if (strNombres == string.Empty)
            {
                strError = " ingrese el nombre";
                return false;
            }
            if (strTelefono == string.Empty)
            {
                strError = " ingrese el telefono";
                return false;
            }
            if (strCargo == string.Empty)
            {
                strError = " ingrese el cargo";
                return false;
            }
            if (intSalario == 0)
            {
                strError = " ingrese el salario";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos publicos"
        public override bool Grabar()
        {
            StreamWriter sw = File.AppendText("Empleado.txt");
            try
            {
                if (!Validar())
                    return false;

                sw.WriteLine(Documento + ";" + Nombre + ";" + FechaNac + ";" + Telefono + ";" + Cargo + ";" + Salario);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.strError = ex.Message;
                return false;
            }
            
        }
        #endregion
    }
}
