using System.Windows.Forms;

namespace GlobalBarcodeHook
{
    public partial class Form1 : Form
    {
        BarCodeHook BarCode = new BarCodeHook();

        public Form1()
        {
            InitializeComponent();
            BarCode.BarCodeEvent += new BarCodeHook.BarCodeDelegate(BarCode_BarCodeEvent);
        }

        private delegate void ShowInfoDelegate(BarCodeHook.BarCodes barCode);
        private void ShowInfo(BarCodeHook.BarCodes barCode)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ShowInfoDelegate(ShowInfo), new object[] { barCode });
            }
            else
            {
                textBox1.Text = barCode.KeyName;
            }
        }

        void BarCode_BarCodeEvent(BarCodeHook.BarCodes barCode)
        {
            ShowInfo(barCode);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            BarCode.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            BarCode.Stop();
        }
    }
}