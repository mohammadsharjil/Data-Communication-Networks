﻿    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace ipCalculator
    {
    public partial class Form1 : Form
    {
        
        string hostName = "";
        public Form1()
        {
            this.ActiveControl = ip_textBox;
            InitializeComponent();
        }
        //tab1
        private void button2_Click(object sender, EventArgs e)
        {
            Program.ip = ip_textBox.Text;
            ipCalculator ipclass = new ipCalculator();
            string[] ipbin=ipclass.convertInToBinary();
            textBox5.Text = ipbin[0] + "." + ipbin[1] + "." + ipbin[2] + "." + ipbin[3];
            string[] ipHex = ipclass.convertInToHexa();
            textBox1.Text = ipHex[0] + "." + ipHex[1] + "." + ipHex[2] + "." + ipHex[3];
            address_classinfo_textbox.Text = ipclass.addressAndClassInfo();
        }
        string[] cidrmask = new[] { "128.0.0.0", "192.0.0.0", "224.0.0.0", "240.0.0.0", "248.0.0.0", "252.0.0.0", "254.0.0.0", "255.0.0.0", "255.128.0.0", "255.192.0.0", "255.224.0.0", "255.240.0.0", "255.248.0.0", "255.252.0.0", "255.254.0.0", "255.255.0.0", "255.255.128.0", "255.255.192.0", "255.255.224.0", "255.255.240.0", "255.255.248.0", "255.255.252.0", "255.255.254.0", "255.255.255.0", "255.255.255.128", "255.255.255.192", "255.255.255.224", "255.255.255.240", "255.255.255.248", "255.255.255.252", "255.255.255.254", "255.255.255.255" };
        string[] cidrbit = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" };
        private void Form1_Load(object sender, EventArgs e)
        {
            hostName = Dns.GetHostName();
            ip_textBox.Text = Dns.GetHostByName(hostName).AddressList[0].ToString();

            //CIDR Tab calculating
            CIDR_Mask.DataSource = cidrmask.ToArray();
            Bit.DataSource = cidrbit.ToArray();
            
        }
        //tab2
        char classname = ' ';
        int subnetbits = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ip_textBox.Text!="")
            {
                hostName_textbox.Text = hostName;
            }
            else
            {
                MessageBox.Show("No Ip Address", "Warning");
            }
            
        }
        int[] classAMaskbits = new int[] {8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32};
        int[] classBMaskbits = new int[] { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
        int[] classCMaskbits = new int[] { 24, 25, 26, 27, 28, 29, 30, 31, 32 };
        int[] classAHostbits = new int[] { 0,1,2,3,4,5,6,7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        int[] classBHostbits = new int[] { 0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        int[] classCHostbits = new int[] { 0,1, 2, 3, 4, 5, 6, 7, 8 };
        int[] specialSubnets = new int[] { 0,128, 192, 224, 240, 248, 252, 254, 255 };
        int[] numOfSubnetsClassA = new int[] {1,2,4,8,16,32,64,128,256,512,1024,2048,4096,8192,16384,32768,65536,131072,262144,524288,1048576,2097152,4194304,8388608,16777216 };
        int[] numOfSubnetsClassB = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 };
        int[] numOfSubnetsClassC = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
        int[] numOfHostClassA = new int[] { 1, 2, 2, 6, 14, 30, 62, 126, 254, 510, 1022, 2046, 4094, 8190, 16382, 32766, 65534, 131070, 262142, 524286, 1048574, 2097150, 4194302, 8388606, 16777214};
        int[] numOfHostClassB = new int[] { 1, 2, 2, 6, 14, 30, 62, 126, 254, 510, 1022, 2046, 4094, 8190, 16382, 32766, 65534 };
        int[] numOfHostClassC = new int[] { 1, 2, 2, 6, 14, 30, 62, 126, 254 };
        string[] classASubnets = new string[] {"255.0.0.0","255.128.0.0","255.192.0.0","255.224.0.0","255.240.0.0","255.248.0.0","255.252.0.0","255.254.0.0","255.255.0.0"
        ,"255.255.128.0","255.255.192.0","255.255.224.0","255.255.240.0","255.255.248.0","255.255.252.0","255.255.254.0","255.255.255.0","255.255.255.128","255.255.255.192"
            ,"255.255.255.224","255.255.255.240","255.255.255.248","255.255.255.252","255.255.255.254","255.255.255.255"};
        string[] classBSubnets = new string[] {"255.255.0.0","255.255.128.0","255.255.192.0","255.255.224.0","255.255.240.0","255.255.248.0","255.255.252.0","255.255.254.0","255.255.255.0","255.255.255.128","255.255.255.192"
            ,"255.255.255.224","255.255.255.240","255.255.255.248","255.255.255.252","255.255.255.254","255.255.255.255"};
        string[] classCSubnet = new string[] {"255.255.255.0","255.255.255.128","255.255.255.192"
            ,"255.255.255.224","255.255.255.240","255.255.255.248","255.255.255.252","255.255.255.254","255.255.255.255"};
        private void ipTextbox_TextChanged(object sender, EventArgs e)
        {
            string[] ip=subnetIp_Textbox.Text.Split('.');
            if (ip.Length==4 && ip[3]!="")
            {
                int[] intip = new int[4];
                int ipOctNum = 0;
                foreach (var item in ip)
                {
                    intip[ipOctNum] = Convert.ToInt32(item);
                    ipOctNum++;
                }


                if ((intip[0] > 0 && intip[0] < 240) && (intip[1] >= 0 && intip[1] < 256) && (intip[2] >= 0 && intip[2] < 256) && (intip[3] >= 0 && intip[3] < 256))
                {
                    if (intip[0] > 0 && intip[0] < 128)
                    {
                        classname = 'A';
                        MaskBit_Combobox.DataSource = classAMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classAHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[24];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassA.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassA.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[24];
                        classInfo_textbox.Text = "0nnnnnnn.hhhhhhhh.hhhhhhhh.hhhhhhhh";
                        Subnet_ComboBox.DataSource = classASubnets.ToArray();
                    }
                    if (intip[0] >= 128 && intip[0] < 192)
                    {
                        classname = 'B';
                        MaskBit_Combobox.DataSource = classBMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classBHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[16];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassB.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassB.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[16];
                        Subnet_ComboBox.DataSource = classBSubnets.ToArray();
                        classInfo_textbox.Text = "10nnnnnn.nnnnnnnn.hhhhhhhh.hhhhhhhh";
                    }
                    if (intip[0] >= 192 && intip[0] < 224)
                    {
                        classname = 'C';
                        MaskBit_Combobox.DataSource = classCMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classCHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[8];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassC.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassC.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[8];
                        Subnet_ComboBox.DataSource = classCSubnet.ToArray();
                        classInfo_textbox.Text = "110nnnnn.nnnnnnnn.nnnnnnnn.hhhhhhhh";
                    }
                    if (intip[0] >= 224 && intip[0] < 240)
                    {
                        if (!MaskBit_Combobox.Items.Contains("32"))
                        {
                            MaskBit_Combobox.Items.Add(32);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("wrong...!");
                }
            }

            
        }
        int k = 0;
        private void Subnet_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int maskbit = 0;
            string[] subnetbroken = Subnet_ComboBox.SelectedItem.ToString().Split('.');
            
            if (k!=0)
            {
                if (classname=='A')
                {
                    int i = 0;
                    foreach (var item in specialSubnets)
                    {
                        if (item == Convert.ToInt32(subnetbroken[1]))
                        {
                            break;
                        }
                        i++;
                    }
                    int a = 0;
                    foreach (var item in specialSubnets)
                    {
                        if (item == Convert.ToInt32(subnetbroken[2]))
                        {
                            break;
                        }
                        a++;
                    }
                    int b = 0;
                    foreach (var item in specialSubnets)
                    {
                        if (item == Convert.ToInt32(subnetbroken[3]))
                        {
                            break;
                        }
                        b++;
                    }
                    maskbit = 8 + i + a + b;
                }
                if (classname=='B')
                {
                    int i = 0;
                    foreach (var item in specialSubnets)
                    {
                        if (item == Convert.ToInt32(subnetbroken[2]))
                        {
                            break;
                        }
                        i++;
                    }
                    int a = 0;
                    foreach (var item in specialSubnets)
                    {
                        if (item == Convert.ToInt32(subnetbroken[3]))
                        {
                            break;
                        }
                        a++;
                    }
                    maskbit = 16 + i+a;
                }
                if (classname=='C')
                {
                    int i = 0;
                    foreach (var item in specialSubnets)
                    {
                        if (item == Convert.ToInt32(subnetbroken[3]))
                        {
                            break;
                        }
                        i++;
                    }
                    maskbit = 24 + i;
                }
                double numofsubnets = 0.0;
                double hostpersubnets = 0.0;
                var Index = MaskBit_Combobox.FindStringExact(maskbit.ToString());
                if (!(Index == -1))
                {
                    MaskBit_Combobox.SelectedItem = MaskBit_Combobox.Items[Index];
                }
                if (classname=='A')
                {
                    subnetbits = Convert.ToInt32(MaskBit_Combobox.SelectedItem) - 8;
                    numofsubnets = Math.Pow(2, Convert.ToDouble(subnetbits));
                    hostpersubnets = (16777216 / numofsubnets)-2;
                }
                if (classname == 'B')
                {
                    subnetbits = Convert.ToInt32(MaskBit_Combobox.SelectedItem) - 16;
                    numofsubnets = Math.Pow(2, Convert.ToDouble(subnetbits));
                    hostpersubnets = (65536 / numofsubnets)-2;
                }
                if (classname == 'C')
                {
                    subnetbits = Convert.ToInt32(MaskBit_Combobox.SelectedItem) - 24;
                    numofsubnets = Math.Pow(2, Convert.ToDouble(subnetbits));
                    
                    hostpersubnets = (256 / numofsubnets)-2;
                }
                
                var subindex = numOfSubnetCombobox.FindStringExact(numofsubnets.ToString());
                numOfSubnetCombobox.SelectedItem = numOfSubnetCombobox.Items[subindex];
                var hostindex = NumOfHostComboBox.FindStringExact(hostpersubnets.ToString());
                NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[hostindex];
            }
            k++;
        }
        string making_subnet="";
        private void MaskBit_Combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            int hostbit=32-(int)MaskBit_Combobox.SelectedValue;
            var Index=hostBit_ComboBox.FindStringExact(hostbit.ToString());
            if (!(Index==-1))
            {
                hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[Index];
            }
            int sub = (int)MaskBit_Combobox.SelectedItem / 8;
            if (sub==1)
            {
                
                int val = (int)MaskBit_Combobox.SelectedItem - 8;
                making_subnet = "255."+specialSubnets[val]+".0.0";
            }
            if (sub == 2)
            {

                int val = (int)MaskBit_Combobox.SelectedItem - 16;
                making_subnet = "255.255." + specialSubnets[val] + ".0";
            }
            if (sub == 3)
            {

                int val = (int)MaskBit_Combobox.SelectedItem - 24;
                making_subnet = "255.255.255." + specialSubnets[val];
            }
            var thisindex = Subnet_ComboBox.FindStringExact(making_subnet);
            if (thisindex!=-1)
            {
                Subnet_ComboBox.SelectedItem = Subnet_ComboBox.Items[thisindex];
            }
            
        }
       

        private void hostBit_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int valmask = 32 - (int)hostBit_ComboBox.SelectedItem;
            var valindex = MaskBit_Combobox.FindStringExact(valmask.ToString());
            MaskBit_Combobox.SelectedItem = MaskBit_Combobox.Items[valindex];
        }

        private void numOfSubnetCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            int changednumofsubnet = (int)numOfSubnetCombobox.SelectedItem;
            int i = 0;
            int newmaskbits = 0;
            foreach (var item in numOfSubnetsClassA)
            {
                if (changednumofsubnet==item)
                {
                    break;
                }
                i++;
            }
            if (classname=='A')
            {
                newmaskbits = 8 + i;
            }
            if (classname == 'B')
            {
                newmaskbits = 16 + i;
            }
            if (classname == 'C')
            {
                newmaskbits = 24 + i;
            }
            var valindex = MaskBit_Combobox.FindStringExact(newmaskbits.ToString());
            MaskBit_Combobox.SelectedItem = MaskBit_Combobox.Items[valindex];
        }
        int j = 0;
        private void NumOfHostComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (j > 1)
            {
                int someval = (int)NumOfHostComboBox.SelectedItem;
                int index = 0;
                foreach (var item in numOfHostClassA)
                {
                    if (item == someval)
                    {
                        break;
                    }
                    index++;
                }
                int someindex = 24 - index;
                int someint = numOfSubnetsClassA[someindex];
                var thisindex = numOfSubnetCombobox.FindStringExact(someint.ToString());
                numOfSubnetCombobox.SelectedItem = numOfSubnetCombobox.Items[thisindex];
            }
            j++;
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            string[] ip = subnetIp_Textbox.Text.Split('.');
            if (ip.Length == 4 && ip[3] != "")
            {
                int[] intip = new int[4];
                int ipOctNum = 0;
                foreach (var item in ip)
                {
                    intip[ipOctNum] = Convert.ToInt32(item);
                    ipOctNum++;
                }


                if ((intip[0] > 0 && intip[0] < 240) && (intip[1] >= 0 && intip[1] < 256) && (intip[2] >= 0 && intip[2] < 256) && (intip[3] >= 0 && intip[3] < 256))
                {
                    if (intip[0] > 0 && intip[0] < 128)
                    {
                        classname = 'A';
                        MaskBit_Combobox.DataSource = classAMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classAHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[24];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassA.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassA.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[24];
                        classInfo_textbox.Text = "0nnnnnnn.hhhhhhhh.hhhhhhhh.hhhhhhhh";
                        Subnet_ComboBox.DataSource = classASubnets.ToArray();
                    }
                    if (intip[0] >= 128 && intip[0] < 192)
                    {
                        classname = 'B';
                        MaskBit_Combobox.DataSource = classBMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classBHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[16];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassB.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassB.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[16];
                        Subnet_ComboBox.DataSource = classBSubnets.ToArray();
                        classInfo_textbox.Text = "10nnnnnn.nnnnnnnn.hhhhhhhh.hhhhhhhh";
                    }
                    if (intip[0] >= 192 && intip[0] < 224)
                    {
                        classname = 'C';
                        MaskBit_Combobox.DataSource = classCMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classCHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[8];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassC.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassC.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[8];
                        Subnet_ComboBox.DataSource = classCSubnet.ToArray();
                        classInfo_textbox.Text = "110nnnnn.nnnnnnnn.nnnnnnnn.hhhhhhhh";
                    }
                    if (intip[0] >= 224 && intip[0] < 240)
                    {
                        if (!MaskBit_Combobox.Items.Contains("32"))
                        {
                            MaskBit_Combobox.Items.Add(32);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("wrong...!");
                }
            }
        }
        private void IP_Address_TextChanged(object sender, EventArgs e)
        {
            string[] ip = subnetIp_Textbox.Text.Split('.');
            if (ip.Length == 4 && ip[3] != "")
            {
                int[] intip = new int[4];
                int ipOctNum = 0;
                foreach (var item in ip)
                {
                    intip[ipOctNum] = Convert.ToInt32(item);
                    ipOctNum++;
                }


                if ((intip[0] > 0 && intip[0] < 240) && (intip[1] >= 0 && intip[1] < 256) && (intip[2] >= 0 && intip[2] < 256) && (intip[3] >= 0 && intip[3] < 256))
                {
                    if (intip[0] > 0 && intip[0] < 128)
                    {
                        classname = 'A';
                        MaskBit_Combobox.DataSource = classAMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classAHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[24];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassA.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassA.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[24];
                        classInfo_textbox.Text = "0nnnnnnn.hhhhhhhh.hhhhhhhh.hhhhhhhh";
                        Subnet_ComboBox.DataSource = classASubnets.ToArray();
                    }
                    if (intip[0] >= 128 && intip[0] < 192)
                    {
                        classname = 'B';
                        MaskBit_Combobox.DataSource = classBMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classBHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[16];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassB.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassB.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[16];
                        Subnet_ComboBox.DataSource = classBSubnets.ToArray();
                        classInfo_textbox.Text = "10nnnnnn.nnnnnnnn.hhhhhhhh.hhhhhhhh";
                    }
                    if (intip[0] >= 192 && intip[0] < 224)
                    {
                        classname = 'C';
                        MaskBit_Combobox.DataSource = classCMaskbits.ToArray();
                        hostBit_ComboBox.DataSource = classCHostbits.ToArray();
                        hostBit_ComboBox.SelectedItem = hostBit_ComboBox.Items[8];
                        numOfSubnetCombobox.DataSource = numOfSubnetsClassC.ToArray();
                        NumOfHostComboBox.DataSource = numOfHostClassC.ToArray();
                        NumOfHostComboBox.SelectedItem = NumOfHostComboBox.Items[8];
                        Subnet_ComboBox.DataSource = classCSubnet.ToArray();
                        classInfo_textbox.Text = "110nnnnn.nnnnnnnn.nnnnnnnn.hhhhhhhh";
                    }
                    if (intip[0] >= 224 && intip[0] < 240)
                    {
                        if (!MaskBit_Combobox.Items.Contains("32"))
                        {
                            MaskBit_Combobox.Items.Add(32);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("wrong...!");
                }
            }
        }

        //CIDR Tab

        private void Bit_SelectedValueChanged(object sender, EventArgs e)
        {
            string someval = Bit.SelectedItem.ToString();
            int index = 0;
            foreach (var item in cidrbit)
            {
                if (item == someval)
                {
                    break;
                }
                index++;
            }
            if (index != 0)
            {
                CIDR_Mask.SelectedItem =CIDR_Mask.Items[index];
            }
        }
        
        private void CIDR_Mask_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = 0;
            int someindex = 0;
            string someval = CIDR_Mask.SelectedItem.ToString();
            
            foreach (var item in cidrmask)
            {
                if (item == someval)
                {
                    break;
                }
                index++;
            }
            if (index != 0)
            {
                Bit.SelectedItem = Bit.Items[index];
            }

            //subnet mask change
            if (index != 0)
            {
                someindex = 32 - (index + 1);
                string[] subnetmask = new string[someindex];
                for (int i = 0; i < subnetmask.Length; i++)
                {
                    subnetmask[i] = cidrmask[index + i];

                }
                
                Subnet_Mask.DataSource = subnetmask.ToArray();
            }

        }
        int v = 0;
        int[] noof_subnet = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 6710888, 134217728, 268435456, 536870912, 1073741824, 214783648};
        int[] host_persubnet = new int[] { 1, 2, 2, 6, 14, 30, 62, 126, 254, 510, 1022, 2046, 4094, 8190, 16382, 32766, 65534, 131070, 262142, 524286, 1048574, 2097150, 4194302, 8388606, 16777214, 33554430, 6710886, 134217726, 268435454, 536870910, 1073741822, 2147483646};
        int[] mask_bitcombo = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
        int[] host_bitcombo = new int[] { 0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31};
       
        
        
        
        private void Subnet_Mask_SelectedValueChanged(object sender, EventArgs e)
        {
            int maskbit = 0;
            string[] subnetbroken = Subnet_Mask.SelectedItem.ToString().Split('.');
            int[] words=new int[4];
            for (int i = 0; i < 4; i++)
		    {
			    words[i]=Convert.ToInt32(subnetbroken[i]);
		    }
            
            foreach (var item in words)
            {
                int index=0;
                foreach (var someitem in specialSubnets)
                {
		            if (item==someitem)
                    {   
		                 break;
                    }
                    index++;
                }
                maskbit+=index;
            }
            maskbitcombo.DataSource = mask_bitcombo.ToArray();
                int numbofsubnets = 0;
                int hostspersubnets = 0;
                var Index = maskbitcombo.FindStringExact(maskbit.ToString());
                if (Index != -1)
                {
                    maskbitcombo.SelectedItem = maskbitcombo.Items[Index];
                }

                noofsubnetcombo.DataSource = noof_subnet.ToArray();
                
                hostbitcombo.DataSource = host_bitcombo.ToArray();
                hostpersubnetcombo.DataSource = host_persubnet.ToArray();
                
                
                var subindex = noofsubnetcombo.FindStringExact(numbofsubnets.ToString());
                if (subindex!=-1)
                {
                    noofsubnetcombo.SelectedItem = noofsubnetcombo.Items[subindex];
                }
                
                var hostindex = hostpersubnetcombo.FindStringExact(hostspersubnets.ToString());
                if (subindex!=-1)
                {
                    hostpersubnetcombo.SelectedItem = hostpersubnetcombo.Items[hostindex];
                }
                
            }

        private void maskbitcombo_ValueMemberChanged(object sender, EventArgs e)
        {

        }

       

       

       

       
            
        }
    }