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
        private void uploadFile(string FTPAddress, string filePath, string username, string password)
        {
            FtpWebRequest prueba = (FtpWebRequest)FtpWebRequest.Create(FTPAddress + "/" + Path.GetFileName(filePath));
            prueba.Method = WebRequestMethods.Ftp.UploadFile;
            prueba.Credentials = new NetworkCredential(username, password);
            prueba.UsePassive = true;
            prueba.UseBinary = true;
            prueba.KeepAlive = false;

            //Load the file
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Upload file
            Stream streamQuery = prueba.GetRequestStream();
            streamQuery.Write(buffer, 0, buffer.Length);
            streamQuery.Close();

            MessageBox.Show("Uploaded Successfully"); 
           }
            private void subir_Click(object sender, EventArgs e)
        {
            subir.Enabled = false;
            Application.DoEvents();

            uploadFile(servidor.Text, archivo.Text, usuario.Text, contraseña.Text);
            subir.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                archivo.Text = openFileDialog1.FileName;
        }
    }
}
