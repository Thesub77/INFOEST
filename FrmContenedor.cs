using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_prueba.Formularios;

namespace Proyecto_prueba
{
    public partial class FrmContenedor : Form
    {
        public FrmContenedor()
        {
            InitializeComponent();
        }//Fin del constructor

        private void Form1_Load(object sender, EventArgs e)
        {
            FrmLogin FrmLog = new FrmLogin();
            FrmLog.MdiParent = this; //Mostrar en este formulario
            FrmLog.Show();


        }//Fin del evento del Formulario contenedor
    }//Fin de la clase
}//Fin del namespace
