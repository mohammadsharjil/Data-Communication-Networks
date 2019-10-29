using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipCalculator
{
    class ipCalculator
    {
         int[] breakeip(string _ip)
        {
            string[] words = _ip.Split('.');
            int[] ipbroken = new int[4];
            int ipoctetnumb = 0;
            foreach (var item in words)
            {
                ipbroken[ipoctetnumb] = Convert.ToInt32(item);
                ipoctetnumb++;
            }
            return ipbroken;
        }
        public string[] convertInToBinary()
        {
            int[] ipbroke = breakeip(Program.ip);
            string[] binaryip = new string[4];
            for (int j = 0; j < 4; j++)
            {
                int quot;
                string rem = "";
                while (ipbroke[j] >= 1)
                {
                    quot = ipbroke[j] / 2;
                    rem += (ipbroke[j] % 2).ToString();
                    ipbroke[j] = quot;
                }
                string bin = "";
                for (int i = rem.Length - 1; i >= 0; i--)
                {
                    bin = bin + rem[i];
                }
                int binIp;
                if (bin.Length < 8)
                {
                    binIp = 8 - bin.Length;
                    for (int i = 0; i < binIp; i++)
                    {
                        bin = "0" + bin;
                    }
                }
                binaryip[j] = bin;
            }
            return binaryip;
        }
        public string[] convertInToHexa()
        {
            int[] ipbroke = breakeip(Program.ip);
            string[] Hexaip = new string[4];
            int quotient;
            int m = 1, temp = 0;
            for (int k = 0; k < 4; k++)
            {
                quotient = ipbroke[k];
                char[] hexadecimalNumber = new char[100];
                char temp1;
                while (quotient != 0)
                {
                    temp = quotient % 16;
                    if (temp < 10)
                        temp = temp + 48;
                    else
                        temp = temp + 55;
                    temp1 = Convert.ToChar(temp);
                    hexadecimalNumber[m++] = temp1;
                    quotient = quotient / 16;
                }
                string hexanumb = "";
                for (int j = m - 1; j > 0; j--)
                {
                    if (hexadecimalNumber[j] != '\0')
                    {
                        hexanumb = hexanumb + hexadecimalNumber[j];
                    }
                }
                Hexaip[k] = hexanumb;
            }
            return Hexaip;
        }
        
        public string addressAndClassInfo()
        {
            string address = "";
            string clasinfo = "";
            int[] intIpArr = breakeip(Program.ip);
            if (intIpArr[0]>=0 && intIpArr[0]<128)
            {
                address = "Class A address (1.0.0.0 - 127.255.255.255)\n";
                clasinfo = "0nnnnnnn.hhhhhhhh.hhhhhhhh.hhhhhhhh";
            }
            if (intIpArr[0] >= 128 && intIpArr[0] < 192)
            {
                address = "Class B address (128.0.0.0 - 191.255.255.255)\n";
                clasinfo = "10nnnnnn.nnnnnnnn.hhhhhhhh.hhhhhhhh";
            }
            if (intIpArr[0] >= 192 && intIpArr[0] < 224)
            {
                address = "Class C address (192.0.0.0 - 223.255.255.255)\n";
                clasinfo = "110nnnnn.nnnnnnnn.nnnnnnnn.hhhhhhhh";
            }
            if (intIpArr[0] >= 224 && intIpArr[0] < 240)
            {
                address = "Class D address (224.0.0.0 - 239.255.255.255)\n";
                clasinfo = "1110nnnn.nnnnnnnn.hhhhhhhh.hhhhhhhh";
            }
            if (intIpArr[0] >= 240 && intIpArr[0] < 256)
            {
                address = "Reserved address class";
            }
            return address + clasinfo;
        }
    }
}
