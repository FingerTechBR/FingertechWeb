using System;
using System.Windows.Forms;
using Captura.Api;
using System.Diagnostics;

namespace Captura.Local
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    var ipLocal = RetornaIpLocal();
        //    if (!string.IsNullOrEmpty(ipLocal))
        //    {
        //        Microsoft.Owin.Hosting.WebApp.Start<Startup>(ipLocal);
        //        lbMsg.Text = @"Serviço Iniciado";
        //        btnStop.Enabled = true;
        //        btnStart.Enabled = false;
        //    }
        //}

        //private void btnStop_Click(object sender, EventArgs e)
        //{


        //    lbMsg.Text = @"Serviço Parado";
        //    btnStop.Enabled = false;
        //    btnStart.Enabled = true;
        //}

        private string RetornaIpLocal()
        {
            var ip = ArquivoIni.LeArquivoIni("Cliente", "IP", Application.StartupPath + "\\Configuracao.ini");
            var porta = ArquivoIni.LeArquivoIni("Cliente", "PORTA", Application.StartupPath + "\\Configuracao.ini");
            
            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(porta))
            {
                MessageBox.Show("Arquivo de configuração não encontrado!");
                return null;
            }
            //return string.Format("http://{0}:{1}", ip, porta);
            return string.Format("http://{0}:{1}", ip, porta);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ipLocal = RetornaIpLocal();
            if (!string.IsNullOrEmpty(ipLocal))
            {
                Microsoft.Owin.Hosting.WebApp.Start<Startup>(ipLocal);
                lbMsg.Text = @"Serviço Iniciado";
                this.WindowState = FormWindowState.Minimized;
                //btnStop.Enabled = true;
                //btnStart.Enabled = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void Notificacao_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void tsmAbrir_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void tsmFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void linkLabel1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://captura.fingertech.com.br/");
            Process.Start(sInfo);
        }
    }
}


//private void btnStart_Click(object sender, EventArgs e)
//{
//    var ipLocal = RetornaIpLocal();
//    if (!string.IsNullOrEmpty(ipLocal))
//    {
//        Microsoft.Owin.Hosting.WebApp.Start<Startup>(ipLocal);
//        lbMsg.Text = @"Serviço Iniciado";
//        btnStop.Enabled = true;
//        btnStart.Enabled = false;
//    }
//}

//private void btnStop_Click(object sender, EventArgs e)
//{


//    lbMsg.Text = @"Serviço Parado";
//    btnStop.Enabled = false;
//    btnStart.Enabled = true;
//}