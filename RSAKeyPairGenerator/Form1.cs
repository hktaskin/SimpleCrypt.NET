using System;
using System.Windows.Forms;

namespace RSAKeyPairGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const string PUBLIC = "PUBLIC";
        const string PRIVATE = "PRIVATE";

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCopyPublic.Tag = PUBLIC;
            btnCopyPrivate.Tag = PRIVATE;
        }
        private void btnGeneratePair_Click(object sender, EventArgs e)
        {
            txtPublic.Clear();
            txtPrivate.Clear();
            Application.DoEvents();

            string[] p = LibSimpleCrypt.HybridCrypto.GenerateKeyPair().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            txtPublic.Text = p[3];
            txtPrivate.Text = p[1];
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Tag.Equals(PUBLIC))
            {
                Clipboard.SetText(txtPublic.Text);
            }
            else if (b.Tag.Equals(PRIVATE))
            {
                Clipboard.SetText(txtPrivate.Text);
            }
        }
    }
}
