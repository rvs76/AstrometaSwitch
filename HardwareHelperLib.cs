using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AstrometaForm
{
    #region Unmanaged

    public class Native
    {

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, UInt32 iEnumerator, IntPtr hParent, UInt32 nFlags);

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiEnumDeviceInfo(IntPtr lpInfoSet, UInt32 dwIndex, SP_DEVINFO_DATA devInfoData);

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetDeviceRegistryProperty(IntPtr lpInfoSet, SP_DEVINFO_DATA DeviceInfoData, UInt32 Property, UInt32 PropertyRegDataType, StringBuilder PropertyBuffer, UInt32 PropertyBufferSize, IntPtr RequiredSize);

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiSetClassInstallParams(IntPtr DeviceInfoSet, IntPtr DeviceInfoData, IntPtr ClassInstallParams, int ClassInstallParamsSize);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        public static extern Boolean SetupDiCallClassInstaller(UInt32 InstallFunction,IntPtr DeviceInfoSet, IntPtr DeviceInfoData);
        

        [StructLayout(LayoutKind.Sequential)]
        public class SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid classGuid;
            public int devInst;
			public UIntPtr reserved;
        };

        [StructLayout(LayoutKind.Sequential)]
        public class SP_PROPCHANGE_PARAMS 
        {
            public SP_CLASSINSTALL_HEADER ClassInstallHeader=new SP_CLASSINSTALL_HEADER();
            public int StateChange;
            public int Scope;
            public int HwProfile;
        };

        [StructLayout(LayoutKind.Sequential)]
        public class SP_CLASSINSTALL_HEADER
        {
            public int cbSize;
            public int InstallFunction;
        }; 

        public const int DIGCF_ALLCLASSES = (0x00000004);
        public const int DIGCF_PRESENT = (0x00000002);
        public const int INVALID_HANDLE_VALUE = -1;
        public const int SPDRP_DEVICEDESC = (0x00000000);
        public const int MAX_DEV_LEN = 1000;
        public const int DEVICE_NOTIFY_WINDOW_HANDLE = (0x00000000);
        public const int DEVICE_NOTIFY_SERVICE_HANDLE = (0x00000001);
        public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = (0x00000004);
        public const int DBT_DEVTYP_DEVICEINTERFACE = (0x00000005);
        public const int DBT_DEVNODES_CHANGED = (0x0007);
        public const int WM_DEVICECHANGE = (0x0219);
        public const int DIF_PROPERTYCHANGE = (0x00000012);
        public const int DICS_FLAG_CONFIGSPECIFIC = (0x00000002);
		public const int DICS_PROPCHANGE = ((0x00000003));  
    }

    #endregion

    public class HH_Lib
    {

        #region Public Methods

		public bool ResetDevice(string match)
		{
		    bool retour = false;
			try
			{
				Guid myGUID = Guid.Empty;
				IntPtr hDevInfo = Native.SetupDiGetClassDevs(ref myGUID, 0, IntPtr.Zero, Native.DIGCF_ALLCLASSES | Native.DIGCF_PRESENT);
				if (hDevInfo.ToInt32() == Native.INVALID_HANDLE_VALUE)
				{
					return false;
				}
			    Native.SP_DEVINFO_DATA DeviceInfoData = new Native.SP_DEVINFO_DATA();
				DeviceInfoData.cbSize = Marshal.SizeOf(DeviceInfoData);
				//is devices exist for class
				DeviceInfoData.devInst = 0;
				DeviceInfoData.classGuid = Guid.Empty;
				DeviceInfoData.reserved = UIntPtr.Zero;
				UInt32 i;
				StringBuilder deviceName = new StringBuilder("") {Capacity = Native.MAX_DEV_LEN};
			    for (i = 0; Native.SetupDiEnumDeviceInfo(hDevInfo, i, DeviceInfoData); i++)
				{
				    Native.SetupDiGetDeviceRegistryProperty(hDevInfo,
				        DeviceInfoData,
				        Native.SPDRP_DEVICEDESC,
				        0,
				        deviceName,
				        Native.MAX_DEV_LEN,
				        IntPtr.Zero);

					if (deviceName.ToString().Trim().ToLower().Equals(match.Trim().ToLower()))
					{
						retour= ResetDevice(hDevInfo, DeviceInfoData);
						break;
					}
						
				}
				Native.SetupDiDestroyDeviceInfoList(hDevInfo);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to enumerate device tree!", ex);
			}
			return retour;
		}

        #endregion

        #region Private Methods

        private bool ResetDevice(IntPtr hDevInfo, Native.SP_DEVINFO_DATA devInfoData)
        {
            Native.SP_PROPCHANGE_PARAMS pcp = new Native.SP_PROPCHANGE_PARAMS
            {
                ClassInstallHeader =
                {
                    cbSize = Marshal.SizeOf(typeof (Native.SP_CLASSINSTALL_HEADER)),
                    InstallFunction = Native.DIF_PROPERTYCHANGE
                },
                StateChange = Native.DICS_PROPCHANGE,
                Scope = Native.DICS_FLAG_CONFIGSPECIFIC,
                HwProfile = 0
            };

            int szOfPcp = Marshal.SizeOf(pcp);
            IntPtr ptrToPcp = Marshal.AllocHGlobal(szOfPcp);
            Marshal.StructureToPtr(pcp, ptrToPcp, true);
            int szDevInfoData = Marshal.SizeOf(devInfoData);
            IntPtr ptrToDevInfoData = Marshal.AllocHGlobal(szDevInfoData);
            Marshal.StructureToPtr(devInfoData, ptrToDevInfoData, true);

            bool rslt1 = Native.SetupDiSetClassInstallParams(hDevInfo, ptrToDevInfoData, ptrToPcp, Marshal.SizeOf(typeof(Native.SP_PROPCHANGE_PARAMS)));
            bool rstl2 = Native.SetupDiCallClassInstaller(Native.DIF_PROPERTYCHANGE, hDevInfo, ptrToDevInfoData);

            if (rslt1 && rstl2)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
