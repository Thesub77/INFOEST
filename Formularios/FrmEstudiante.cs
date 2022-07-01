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
    public partial class FrmEstudiante : Form
    {
        public FrmEstudiante()
        {
            InitializeComponent();
        }

        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            //Establecer la ruta donde está la aplicación
            string rutaBase = Directory.GetCurrentDirectory();
            //Establecer la ruta donde está el fichero de departamentos
            string rutaArch = rutaBase.Replace(@"\bin\Debug", @"\Ficheros\Departamentos.txt");
            //Crear un StreamReader para la lectura de datos del archivo
            StreamReader leer = new StreamReader(rutaArch);
            //Definir una variable strng para ir sacando los datos del archivo
            string linea = leer.ReadLine();
            //Procesar la lectura del archivo
            while (linea != null)
            {
                //
                CmbDepartamento.Items.Add(linea); //Agregar lineas leidas al combobox
                linea = leer.ReadLine();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool valid = true; //Utilizar un booleano para validar los campos

            if (valid)
            {
                FileStream fs; //Preparar el archivo donde guardaran los datos
                StreamWriter escribir; //Objeto para manipular la escritura en el archivo
                string linea; //Almacena los datos del formulario
                //Identificar el directorio de la ejecucion de la aplicacion
                string rutaBase = Directory.GetCurrentDirectory();
                //Definir la ruta del archivo
                string rutaArch = rutaBase.Replace(@"\bin\Debug", @"\Ficheros\Estudiantes.txt");
                //Crear el objeto que define el estado del archivo
                fs = new FileStream(rutaArch, FileMode.Append);

                //Crear el objeto que permitirá la escritura en el archivo
                escribir = new StreamWriter(fs);
                //Capturar todo lo que hay en las cajas de texto, separando los datos con punto y coma
                linea = TxtCarnet.Text + ";";
                linea += TxtNombre.Text + ";";
                linea += TxtApellido.Text + ";";
                linea += TxtCorreo.Text + ";";
                linea += TxtTelefono.Text + ";";
                linea += TxtDomicilio.Text + ";";
                linea += CmbDepartamento.SelectedItem.ToString();
                escribir.WriteLine(linea); //Escribir en el archivo lo que tiene la linea
                escribir.Close();// Cerrar la manipulacion del archivo

            }
            MessageBox.Show("Datos guardados correctamente!");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string rutaBase = Directory.GetCurrentDirectory(); //obtener ruta base
            string rutaArch = rutaBase.Replace(@"\bin\Debug", @"\Ficheros\Estudiantes.txt");
            string carnet; // variable para recorrer el archivo
            bool busqueda = false;
            //Objeto para manipular la lectura del archivo
            StreamReader leer = new StreamReader(rutaArch);
            carnet = leer.ReadLine();
            //iniciar la iteracion de la ruta
            while (!busqueda && carnet != null)
            {
                string[] valor = carnet.Split(';'); //Separar los elementos separados por ;

                if (valor[0].Equals(TxtCarnet.Text))
                {
                    busqueda = true; //para detener la iteracion
                    TxtNombre.Text = valor[1];
                    TxtApellido.Text = valor[2];
                    TxtCorreo.Text = valor[3];
                    TxtTelefono.Text = valor[4];
                    TxtDomicilio.Text = valor[5];
                    CmbDepartamento.SelectedItem = valor[6];

                }//Fin del if
                else
                {
                    //Continuar leyendo hasta encontar si existe
                    carnet = leer.ReadLine();
                }

            }//Fin del While
            leer.Close();
        }
    }
}
