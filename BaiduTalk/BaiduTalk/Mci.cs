using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BaiduTalk
{
    public partial class Mci
    {
        //检测声源信号

        [DllImport("WinMm.dll")]
        //private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);


        private const int ERROR_SUCCESS = 0;
        private const string MODE_UNKNOWN = "unknown";

        private static bool mciSendString(string strCommand)
        {
            return mciSendString(strCommand, null, 0, IntPtr.Zero) != ERROR_SUCCESS;
        }
    }

    public partial class Mci
    {

        public Mci()
        {

        }
        public static void StartLevelMeter()
        {
            mciSendString("open new type waveaudio alias soundLevelMeterDevice", null, 0, IntPtr.Zero);
        } //StartLevelMeter

        public const double MaximumLevel = 128;
        public static double GetLevel(int count, out double maxLevel, int delayMs)
        {
            double buf = 0;
            maxLevel = double.NegativeInfinity;
            for (int index = 0; index < count; ++index)
            {
                StringBuilder sb = new StringBuilder();
                mciSendString("status soundLevelMeterDevice level", sb, 0x10, IntPtr.Zero);
                double value;
                if (!double.TryParse(sb.ToString(), out value))
                    return 0;
                buf += value;
                if (value > maxLevel) maxLevel = value;
                System.Threading.Thread.Sleep(delayMs);
            } //loop
            return buf / count;
        } //GetLevel

        public static double GetLevel()
        {
            double dummyMax;
            return GetLevel(1, out dummyMax, 0);
        } //GetLevel

        public static void CloseLevelMeter()
        {
            mciSendString("close soundLevelMeterDevice", null, 0, IntPtr.Zero);
        } //CloseLevelMeter

    }
}
