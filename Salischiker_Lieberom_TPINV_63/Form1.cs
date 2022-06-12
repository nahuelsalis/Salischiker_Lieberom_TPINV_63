namespace Salischiker_Lieberom_TPINV_63


{
    using System.Net;
    using System.Net.Mail;
    using System.Security.Cryptography;
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String AntiCheaters = "paulwalkerSalischiker";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
        private String ConvertHex (string pass){
            string ascii = string.Empty;

            for (int i = 0; i < pass.Length; i += 2)
            {
                String hs = string.Empty;

                hs = pass.Substring(i, 2);
                uint decval = System.Convert.ToUInt32(hs, 16);
                char character = System.Convert.ToChar(decval);
                ascii += character;

            }

            return ascii;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader leer = new StreamReader(@"pass.txt");
            string pass = leer.ReadLine();
            String passwo = ConvertHex(pass);

            
            
            MailMessage enviar = new MailMessage("paulwalkerpsr@gmail.com", textBox1.Text);
            MailMessage ee = new MailMessage();
            enviar.Subject = textBox2.Text;
            enviar.Body = textBox3.Text;

            foreach (string nombreArchivo in openFileDialog1.FileNames) 
            {
                if (File.Exists(nombreArchivo)) 
                {
                    string nombreArchivo2 = Path.GetFileName(nombreArchivo);
                    enviar.Attachments.Add(new Attachment(nombreArchivo));
                }
            }
            SmtpClient clienteSmtp = new SmtpClient();
            clienteSmtp.Host = "smtp.gmail.com";
            clienteSmtp.Port = 587;
            clienteSmtp.UseDefaultCredentials = false;
            System.Net.NetworkCredential Credenciales = new NetworkCredential("paulwalkerpsr@gmail.com", passwo);
            clienteSmtp.Credentials = Credenciales;
            clienteSmtp.EnableSsl = true;
            clienteSmtp.Send(enviar);
            label6.Text = "Enviado Exitosanebte";

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            label5.Text = "Archivo Adjuntado Correctamente!";
            
        }
    }
}