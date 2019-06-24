using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            private void subir_Click(object sender, EventArgs e)
        {
           
            FtpWebRequest prueba = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + " / " + Path.GetFileName(@"C:\Users\rivas\Documents\a20136710.txt"));
            prueba.Method = WebRequestMethods.Ftp.UploadFile;
            prueba.Credentials = new NetworkCredential("test1pweb", "computadora321");
            prueba.UsePassive = true;
            prueba.UseBinary = true;
            prueba.KeepAlive = false;


            FileStream stream = File.OpenRead(@"C:\Users\rivas\Documents\a20136710.txt");
            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            Stream reqStream = prueba.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
            MessageBox.Show("Archivo subido exitosamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* if (openFileDialog1.ShowDialog() == DialogResult.OK)
                archivo.Text = openFileDialog1.FileName;*/
        }
    }
}
