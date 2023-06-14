using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libPersonas;

namespace appPersona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.cmbPersona.SelectedIndex = 0;
            this.cmbPrograma.SelectedIndex = 0;
        }
        #region "Metodos propios"
        private void Mensaje(string texto)
        {
            MessageBox.Show(texto, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarDatos()
        {
            this.txtDocumento.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtFacultad.Text = string.Empty;
            this.txtCurso.Text = string.Empty;
            this.txtPrograma.Text = string.Empty;
            this.txtCarnet.Text = string.Empty;
            this.txtCargo.Text = string.Empty;
            this.txtSalario.Text = string.Empty;
            this.cmbPersona.SelectedIndex = 0;
            this.cmbPrograma.SelectedIndex = 0;
            this.dtmFecha.Value = DateTime.Today;
            grbEmpleado.Visible = false;
            grbEstudiante.Visible = false;
            grbExtension.Visible = false;
            grbPregrado.Visible = false;
            this.txtNombre.Focus();
        }
        #endregion

        #region "Variables globales"
        static int intBox;
        #endregion
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string Doc, Name, Tel, Facultad, Programa, Carnet, Cargo, Curso;
            int Salario;
            DateTime Fecha;
            try
            {
                intBox = this.cmbPersona.SelectedIndex;
                switch (intBox)
                {
                    case 1:
                        try
                        {
                            intBox = this.cmbPrograma.SelectedIndex;

                            switch (intBox)
                            {
                                case 1:
                                    Doc = this.txtDocumento.Text;
                                    Name = this.txtNombre.Text;
                                    Fecha = this.dtmFecha.Value;
                                    Tel = this.txtTelefono.Text;
                                    Facultad = this.txtFacultad.Text;
                                    Programa = this.txtPrograma.Text;
                                    Carnet = this.txtCarnet.Text;
                                    clsPreGrado Pre = new clsPreGrado(Doc, Name, Fecha, Tel, Facultad, Programa, Carnet);
                                    if (!Pre.Grabar())
                                    {
                                        Mensaje("Error, " + Pre.Error);
                                        Pre = null;
                                        return;
                                    }
                                    LimpiarDatos();
                                    this.Mensaje("Grabado con éxito");
                                    break;
                                default:
                                    Doc = this.txtDocumento.Text;
                                    Name = this.txtNombre.Text;
                                    Fecha = this.dtmFecha.Value;
                                    Tel = this.txtTelefono.Text;
                                    Facultad = this.txtFacultad.Text;
                                    Curso = this.txtCurso.Text;
                                    clsExtension Ext = new clsExtension(Doc, Name, Fecha, Tel, Facultad, Curso);
                                    if (!Ext.Grabar())
                                    {
                                        Mensaje("Error, " + Ext.Error);
                                        Ext = null;
                                        return;
                                    }
                                    LimpiarDatos();
                                    this.Mensaje("Grabado con éxito");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {

                            Mensaje("Error de ejecución -> " + ex.Message);
                        }
                        break;
                    default:
                        Doc = this.txtDocumento.Text;
                        Name = this.txtNombre.Text;
                        Fecha = this.dtmFecha.Value.Date;
                        Tel = this.txtTelefono.Text;
                        Cargo = this.txtCargo.Text;
                        Salario = Convert.ToInt32(this.txtSalario.Text);
                        clsEmpleado Emp = new clsEmpleado(Doc, Name, Fecha, Tel, Cargo, Salario);
                        if (!Emp.Grabar())
                        {
                            Mensaje("Error, " + Emp.Error);
                            Emp = null;
                            return;
                        }
                        LimpiarDatos();
                        this.Mensaje("Grabado con éxito");
                        break;
                }
                
            }
            catch (Exception ex)
            {

                Mensaje("Error de ejecución -> " + ex.Message);
            }
        }

        private void cmbPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

            intBox = this.cmbPersona.SelectedIndex;
            this.grbEstudiante.Visible = false;
            this.grbEmpleado.Visible = false;

            switch (intBox)
            {
                case 0:
                    this.grbEstudiante.Visible = false;
                    this.grbEmpleado.Visible = false;
                    break;
                case 1:
                    this.grbEstudiante.Visible = true;
                    this.txtFacultad.Focus();
                    break;
                default:
                    this.grbEmpleado.Visible = true;
                    this.txtCargo.Focus();
                    break;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void cmbPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            intBox = this.cmbPrograma.SelectedIndex;
            this.grbPregrado.Visible = false;
            this.grbExtension.Visible = false;

            switch (intBox)
            {
                case 0:
                    this.grbPregrado.Visible = false;
                    this.grbExtension.Visible = false;
                    break;
                case 1:
                    this.grbPregrado.Visible = true;
                    this.txtPrograma.Focus();
                    break;
                default:
                    this.grbExtension.Visible = true;
                    this.txtCurso.Focus();
                    break;
            }
        }
    }
}
