using System;

public class Class1
{
	public Class1()
	{
        
	}
    public int[] breakip(string _ip)
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
    public void breakip()
    {

    }
}
