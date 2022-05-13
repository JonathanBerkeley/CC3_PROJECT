using System.Runtime.InteropServices;
using System.Text;

public class HardwareID
{
    [DllImport("Identify.dll")]
    static extern void GetHWID(StringBuilder message);
    
    public static string GetHardwareID()
    {
        StringBuilder hwid = new StringBuilder(64);
        GetHWID(hwid);
        return hwid.ToString();
    }
}
