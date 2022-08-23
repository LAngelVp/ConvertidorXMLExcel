using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System;

namespace Convertidor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Ingresamos el xml por medio de openfiledialog
        //OpenFileDialog open = new OpenFileDialog();
        public OpenFileDialog open = new OpenFileDialog();
        public string ruta;
        private void button1_Click(object sender, EventArgs e)
        {
            
            open.InitialDirectory = "C://"; //Colocamos el directorio Raiz
            open.Filter = "Archivos XML (*.xml) |*.xml"; //Filtramos, le decimos al sistema que solo permita archivos xml
            if (open.ShowDialog() == DialogResult.OK) //Si todo se encuentra bien en el archivo
            {
                //asignamos la ruta del documento a una variable str
                ruta = open.FileName;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(ruta);
            XmlNode emisor = xmlDoc.GetElementsByTagName("cfdi:Emisor").Item(0);
            string rfcEmisor = emisor.Attributes.GetNamedItem("Rfc").Value;
            string nombreEmisor = emisor.Attributes.GetNamedItem("Nombre").Value;

            XmlNode receptor = xmlDoc.GetElementsByTagName("cfdi:Receptor").Item(0);
            string rfcReceptor = receptor.Attributes.GetNamedItem("Rfc").Value;
            string nombreReceptor = receptor.Attributes.GetNamedItem("Nombre").Value;

            XmlNode concepto = xmlDoc.GetElementsByTagName("cfdi:Concepto").Item(0);
            string ClaveProdServ = concepto.Attributes.GetNamedItem("ClaveProdServ").Value;
            string NoIdentificacion = concepto.Attributes.GetNamedItem("NoIdentificacion").Value;

            groupBox1.Text = rfcEmisor + " : " + nombreEmisor + " : " + rfcReceptor + " : " + nombreReceptor + " : " + ClaveProdServ + " hola " + NoIdentificacion;

        }
    }
}  
