using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetailPlan.POS.NETS
{
    public partial class Nets2NetworkPayment : Form
    {
        private bool mbTransactionSuccess = false;
        private const int ImageCreditCard = 0, ImageNets = 1, ImageFlashPay = 2, ImageQRCode = 3;

        Thread netsThread;

        private string msNetsPayMode;
        private decimal mdAmount = 0;
        Nets2Network clsNetsNetwork = new Nets2Network();

        Dictionary<string, string> responseData;

        public Dictionary<string, string> EDCResponseData
        {
            get { return responseData; }
            set { responseData = value; }
        }

        public Nets2NetworkPayment(string sNetsPayMode, decimal dAmount)
        {
            InitializeComponent();
            msNetsPayMode = sNetsPayMode;
            mdAmount = dAmount;
            picNets.SizeMode = PictureBoxSizeMode.StretchImage;
            PaymentType(sNetsPayMode);
            lblAmountToPay.Text = mdAmount.ToString();
            base.CenterToScreen();
            this.Focus();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            if (clsNetsNetwork.TransactionStatus.Length == 0) return;
            mbTransactionSuccess = clsNetsNetwork.TransactionSuccess;
            responseData = clsNetsNetwork.EDCResponseData;
            tmrStatus.Enabled = false;
            if (!mbTransactionSuccess)
            {
                lblStatus.Text = clsNetsNetwork.TransactionStatus;
                picNets.Visible = false;
                butCancel.Visible = true;
            }
            else
            {
                this.Close();
            }

        }

        public bool TransactionSuccess
        {
            get { return mbTransactionSuccess; }
        }

        private void PaymentType(string sNetsPaymode)
        {
            string sPaymentType = "NETS";
            picNets.Image = Image.FromFile(Application.StartupPath + @"\images\Nets\Nets.gif");
            switch (sNetsPaymode)
            {
                case "NETSFP":
                    sPaymentType = "FLASHPAY";
                    picNets.Image = Image.FromFile(Application.StartupPath + @"\images\Nets\NetsFlashPay.gif");
                    break;
                case "NETSQR":
                    sPaymentType = "QR Code";
                    picNets.Image = Image.FromFile(Application.StartupPath + @"\images\Nets\NetsQR.gif");
                    break;
                case "NETSCC":
                    sPaymentType = "CASHCARD";
                    break;
                case "CREDITCARD":
                    sPaymentType = "CREDITCARD";
                    picNets.Image = Image.FromFile(Application.StartupPath + @"\images\Nets\CreditCard.gif");
                    break;
            }
            lblPayBy.Text = sPaymentType;
        }


        private void NetsPayment_Load(object sender, EventArgs e)
        {

            netsThread = new Thread(x => clsNetsNetwork.ProcessNetsNetwork(msNetsPayMode, mdAmount));
            netsThread.IsBackground = true;
            netsThread.Start();
            tmrStatus.Enabled = true;

            //clsNetsNetwork.ProcessNetsNetwork(msNetsPayMode, mdAmount);
        }


    }
}
