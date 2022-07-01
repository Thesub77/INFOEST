using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_prueba.Formularios
{
    public partial class FrmLogin : Form
    {
        bool Valido = true; //Validar los datos
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            //Obtener el directorio base del proyecto
            string rutaBase = Directory.GetCurrentDirectory();
            //Establecer la ruta del archivo
            string rutaFile = rutaBase.Replace(@"\bin\Debug", @"\Ficheros\Usuarios.txt");

            //Definir una variable del objeto para procesar el archivo
            StreamReader leer; //Lee el archivo linea por linea
            leer = new StreamReader(rutaFile);

            bool encontrado = false;
            string usuario;
            string clave;

            usuario = leer.ReadLine(); //Lee la primer linea
            clave = leer.ReadLine(); //Lee la segunda linea

            while (!encontrado && usuario != null)
            {
                if (TxtUsuario.Text.Equals(usuario) && TxtClave.Text.Equals(clave))
                {
                    encontrado = true;
                }//Fin del if
                else
                {
                    usuario = leer.ReadLine(); //Seguir leyendo el archivo
                    clave = leer.ReadLine();
                }

            }//Fin del ciclo While
            //Cerrar el archivo
            if (encontrado = true)
            {
                FrmComandos Frmnav = new FrmComandos();
                Frmnav.MdiParent = this.MdiParent;
                Frmnav.Show();
            }

            //Leer el primer registro del usuario


        }//Fin del metodo
    }
}
