using System.Globalization;

namespace amzsaletxt
{
    
    public partial class Form1 : Form
    {
        private CultureInfo kulturayarlari = new CultureInfo("en-EN");
        public Form1()
        {
            InitializeComponent();
        }

        static int nCount = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            ValueModel addItem = new ValueModel();
            addItem.Kod = "1";
            addItem.Value = "Yes";
            comSecim.Items.Add(addItem);
            addItem = new ValueModel();
            addItem.Kod = "2";
            addItem.Value = "No";
            comSecim.Items.Add(addItem);
            CountFileRead();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValueModel oSecim;

            int nRank = Convert.ToInt32(textRank.Text);
            //int nRankSmall = Convert.ToInt32(textRankSmall.Text); 
            int nQty = Convert.ToInt32(textQuantity.Text);
            //int lastRank = 999;

            double n3MC = Convert.ToDouble(text3MC.Text, kulturayarlari);
            double nNet = Convert.ToDouble(textNet.Text, kulturayarlari);

            string sFBA = textFBA.Text;
            string sSKU = textSKU.Text;
            //string placeK = "K";


            double price = (n3MC * (1.1)) + 0.3;


            double marj = (nNet / price) * 100;
            //int iMarj = Convert.ToInt32(marj);



            int MOQ = Convert.ToInt32(500 / price);

            if (MOQ%nQty!=0) 
            {
                for (int i = MOQ; i < MOQ+nQty; i++)
                {
                    if (i%nQty==0) { MOQ = i; }
                }
            }

            if (sFBA=="0") { sFBA = "No"; }


            oSecim = comSecim.SelectedItem as ValueModel;

            string ssecim = oSecim.Kod == "1" ? "" : "No AMZ";

            //if (nRank == 0)
            //{
            //    placeK = "";
            //    lastRank = nRankSmall;
            //}
            //else if (nRankSmall == 0) 
            //{
            //    placeK = "K";
            //    lastRank = nRank;
            //}


            string fnsku = "(0.20$ FNSKU labelling fee will be applied, if received. Instead you can choose manufacturer barcode option which is free of charge.)";

                if (price<4) 
            { }
            else { fnsku = ""; }


            string sMetin = $@"
RANK {nRank}K %{marj.ToString("0.#")} ROI {ssecim} {sFBA} FBA Sellers

Price: ${price.ToString("0.##")}
MOQ: {MOQ} units
QTY: {2*MOQ} units
Lead Time: 12-15 business days
SKU: MMM-{nQty}-{sSKU}

{fnsku}
";
            richtxtSunum.Text = sMetin;
            textFinalCost.Text = Convert.ToString(price.ToString("0.##"), kulturayarlari);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double n3MC = Convert.ToDouble(text3MC.Text, kulturayarlari);
            double price = (n3MC * (1.1)) + 0.3 ;
            

             textFinalCost.Text = Convert.ToString(price.ToString("0.##"), kulturayarlari);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            text3MC.Text = "";
            textRank.Text = "";
            textNet.Text = "";
            textFBA.Text = "";
            textSKU.Text = "";
            textQuantity.Text = "";
            textFinalCost.Text = "";
            richtxtSunum.Text = "";
            textKar.Text = "";
            //textRankSmall.Text = "";
            comSecim.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            double n3MC = Convert.ToDouble(text3MC.Text, kulturayarlari);
            double nNet = Convert.ToDouble(textNet.Text, kulturayarlari);

            double price = (n3MC * (1.1)) + 0.3;


            double marj = (nNet / price) * 100;
            //int iMarj = Convert.ToInt32(marj);

            textKar.Text= Convert.ToString(marj.ToString("0.#"), kulturayarlari);
        }

        private void textKar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richtxtSunum.Text);
        }

        private void comSecim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUP_Click(object sender, EventArgs e)
        {
            nCount = Convert.ToInt32(textCount.Text);
            nCount++;
            textCount.Text=Convert.ToString(nCount);
            CountFileWrite();
        }

        private void buttonDOWN_Click(object sender, EventArgs e)
        {
            nCount = Convert.ToInt32(textCount.Text);
            nCount--;
            textCount.Text = Convert.ToString(nCount);
            CountFileWrite();
        }

        private void CountFileRead()
        {
            
            string spath = Application.StartupPath + @"\count.txt";
            string readText = "0";
            try
            {
                readText = File.ReadAllText(spath);
            }
            catch (Exception ex)
            {
                File.WriteAllText(spath, "0");
            }
            finally
            {
                textCount.Text = readText;
            }
            

        }
        private void CountFileWrite()
        {
            
            string spath = Application.StartupPath + @"\count.txt";
            string readText = "0";
            try
            {
                readText = textCount.Text;
                File.WriteAllText(spath, readText);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }
            

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textFBA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

        
    