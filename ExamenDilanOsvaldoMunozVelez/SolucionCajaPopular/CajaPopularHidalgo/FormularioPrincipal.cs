using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaPopularHidalgo
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ValidacionIdentificador())
            {
                int identificacion = Int32.Parse(txtIdCliente.Text);

                using (WcfCajaPopular.ClienteClient cliente = new WcfCajaPopular.ClienteClient())
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar el regitro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var respuestaCliente = cliente.EliminarCliente(identificacion);
                        if (respuestaCliente.CodigoError != 0)
                        {
                            MessageBox.Show("Se elimino la informacion correctamente");
                        }
                    }
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidacionIdentificador())
            {
                int identificacion = Int32.Parse(txtIdCliente.Text);

                using (WcfCajaPopular.ClienteClient cliente = new WcfCajaPopular.ClienteClient())
                {
                    var respuestaCliente = cliente.BuscarCliente(identificacion);
                    respuestaClientesBindingSource.DataSource = respuestaCliente.lsClientes;
                }
            }
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidacionCampos())
                {
                    if (float.Parse(txtMonto.Text) >= 1000)
                    {
                        using (WcfCajaPopular.ClienteClient cliente = new WcfCajaPopular.ClienteClient())
                        {
                            WcfCajaPopular.Cliente nuevoCliente = new WcfCajaPopular.Cliente();
                            nuevoCliente.Nombre = txtNombre.Text;
                            nuevoCliente.Apellido = txtApellidos.Text;
                            nuevoCliente.FechaNacimiento = txtFecha.Value.Date;
                            nuevoCliente.Correo = txtCorreo.Text;
                            nuevoCliente.Telefono = Convert.ToDecimal(txtTelefono.Text);

                            var respuestaCliente = cliente.AgregarCliente(nuevoCliente, float.Parse(txtMonto.Text), null);

                            if (respuestaCliente.CodigoError > 1)
                            {
                                MessageBox.Show("Cliente registrado con exito");
                                txtNombre.Text = "";
                                txtApellidos.Text = "";
                                txtCorreo.Text = "";
                                txtTelefono.Text = "";
                                txtMonto.Text = "1000.00";
                            }
                            else
                                MessageBox.Show("No se pudo registrar al cliente");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public bool ValidacionIdentificador()
        {
            if (String.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Debe llenar el campo del identificador");
                return false;
            }
            return true;
        }

        public bool ValidacionCampos()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtApellidos.Text) ||
                String.IsNullOrEmpty(txtFecha.Text) || String.IsNullOrEmpty(txtCorreo.Text) ||
                String.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos deben tener informacion");
                return false;
            }
            return true;
        }


        public void ValidacionNumeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void ValidacionCaracteres(object sender, KeyEventArgs e)
        {
            bool resultado = Regex.IsMatch(e.KeyValue.ToString(), @"^[a-zA-Z]+$");
            if (!resultado)
            {
                e.Handled = true;
                return;
            }
            else
            {

                //Se valida si es un caracter especial

                resultado = Regex.IsMatch(e.KeyValue.ToString(), @"^[^ ][a-zA-Z ]+[^ ]$");
                if (resultado)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

    }
}
