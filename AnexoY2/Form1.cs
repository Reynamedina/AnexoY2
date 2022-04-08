using System.Collections;
using System.Text.RegularExpressions;

namespace AnexoY2
{
    public partial class Form1 : Form
    {
        ArrayList Personas = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona Persona1 = new Persona();
            Persona1.ID = "1010";
            Persona1.Nombre = "Reyna";
            Persona1.Apellido = "Medina";
            Persona1.Correo = "reynamedinae@gmail.com";
            Persona1.FechaNacimiento = new DateTime(2002, 1, 3);
            Persona1.Salario = 40000;
            Personas.Add(Persona1);

            Persona Persona2 = new Persona();
            Persona2.ID = "2020";
            Persona2.Nombre = "Chikis";
            Persona2.Apellido = "Romero";
            Persona2.Correo = "chikisromero@gmail.com";
            Persona2.FechaNacimiento = new DateTime(2016, 7, 3);
            Persona2.Salario = 50000;
            Personas.Add(Persona2);

            dgvDatos.DataSource = Personas;

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                errorProvider1.SetError(txtID, "Debe ingresar ID de la persona");
                txtID.Focus();
                return;
            }
            errorProvider1.SetError(txtID, "");

            if(Existe(txtID.Text))
            {
                errorProvider1.SetError(txtID, "ID del empleado ya ha sido registrado");
                txtID.Focus();
                return;
            }
            errorProvider1.SetError(txtID, "");

            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Debe ingresar nombre de la persona");
                txtNombre.Focus();
                return;
            }
            errorProvider1.SetError(txtNombre, "");

            if (txtApellido.Text == "")
            {
                errorProvider1.SetError(txtApellido, "Debe ingresar apellido de la persona");
                txtApellido.Focus();
                return;
            }
            errorProvider1.SetError(txtApellido, "");

            Regex regEmail = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+"
                                       + @"(\. [^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                       + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                       + @"\ - [0-9]{1,3}\])|(([a-zA-Z\-0-9]+\. )+"
                                       + @"[a-zA-Z]{2,}))$",
                                       RegexOptions.Compiled);
            
            if(!regEmail.IsMatch(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "Debe ingresar un correo valido");
                txtCorreo.Focus();
                return;
            }
            errorProvider1.SetError(txtCorreo, "");

            decimal Salario;
            if(!decimal.TryParse(txtSalario.Text, out Salario))
            {
                errorProvider1.SetError(txtSalario, "Debe ingresar solo numeros");
                txtSalario.Focus();
                return;

            }

            if (Salario < 0)
            {
                errorProvider1.SetError(txtSalario, "Debe ingresar un numero valido");
                txtSalario.Focus();
                return;
            }

            Persona miPersona = new Persona();
            miPersona.ID = txtID.Text;
            miPersona.Nombre = txtNombre.Text;
            miPersona.Apellido = txtApellido.Text;
            miPersona.Correo = txtCorreo.Text;
            miPersona.FechaNacimiento = dtpFechaNacimiento.Value;
            miPersona.Salario = Salario;
            Personas.Add(miPersona);


            dgvDatos.DataSource = null;
            dgvDatos.DataSource = Personas;


            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtSalario.Clear();
            txtID.Focus();

        }

        private bool Existe(string text)
        {
            throw new NotImplementedException();
        }
    }
}