using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace BaiduTalk
{
    //播放相关功能
    public partial class SndPlayer
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        //private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);


        private const int ERROR_SUCCESS = 0;
        private const string MODE_UNKNOWN = "unknown";

        private static bool mciSendString(string strCommand)
        {
            return mciSendString(strCommand, null, 0, 0) != ERROR_SUCCESS;
        }
    }



    public partial class SndPlayer
    {
        private int m_channels;
        private int m_sample_spersec;
        private string m_format_tag;
        private int m_bits_per_sample;

        public SndPlayer()
        {

        }
 

        /// <summary>
        /// 播放录音
        /// </summary>
        /// <param name="file"></param>
        public static void Play(string file)
        {
            mciSendString("close media", null, 0, 0);//关闭
            mciSendString("open \"" + file + "\" type mpegvideo alias media", null, 0, 0);
            mciSendString("play media notify", null, 0, 0);//播放
        }
        public static double GetWavFileTime(string p_File)
        {
            WInfo.WaveInfo _WaveFileInfo = new WInfo.WaveInfo(p_File);
            return _WaveFileInfo.Second;
        }

        /// <summary>
        /// 获取当前播放位置
        /// </summary>
        /// <param name="file"></param>
        public static void GetPosition(string file)
        {
            //string s;
            //mciSendString("status movie position", s, 0, 0);//关闭
            //mciSendString("open \"" + file + "\" type mpegvideo alias media", null, 0, 0);
            //mciSendString("play media notify", null, 0, 0);//播放
        }
        //        10.获取当前播放位置：
        //Dim ST As String*64
        //mciSendString "status movie position", st, len(st), 0
        //　　11. 获取媒体的总长度：
        //mciSendString "status movie length", st, len(st), 0
        //l=val(st) 'l就是所播放文件的长度

        // 采样位数
        public virtual int BitsPerSample
        {
            set
            {
                if (mciSendString("set wave bitpersample " + value))
                    this.m_bits_per_sample = value;
            }
            get
            {
                return this.m_bits_per_sample;
            }
        }
       
        // 采样频率
        public virtual int SampleSpersec
        {
            get
            {
                return this.m_sample_spersec;
            }
            set
            {
                if (mciSendString("set wave samplespersec " + value))
                    this.m_sample_spersec = value;
            }
        }
    
        // 声道
        public virtual int Channels
        {
            get
            {
                return m_channels;
            }
            set
            {
                if (mciSendString("set wave channels " + value))
                    this.m_channels = value;
            }
        }
       
        // 格式标签
        public virtual string FormatTag
        {
            get
            {
                return this.m_format_tag;
            }
            set
            {
                if (mciSendString("set wave format tag " + value))
                    this.m_format_tag = value;
            }
        }
        

        /// <summary>
        /// 终止录音
        /// </summary>
        public void Stop()
        {
            mciSendString("stop movie");  // 停止录音  
            mciSendString("close movie"); // 关闭录音  
        }

        /// <summary>
        /// 开始录音
        /// </summary>
        public void Start()
        {
            mciSendString("open new type waveaudio alias movie"); // 打开录音  
            mciSendString("record movie");// 开始录音 
        }

        /// <summary>
        /// 暂停录音
        /// </summary>
        public void Pause()
        {
            mciSendString("pause movie");
            //mciSendString("open new type waveaudio alias movie"); // 打开录音  
            //mciSendString("record movie");// 开始录音 
        }

        /// <summary>
        /// 恢复录音
        /// </summary>
        /// <returns></returns>
        public virtual bool Resume()
        {
            return mciSendString("resume movie");
        }

        /// <summary>
        /// 保存录音文件
        /// </summary>
        /// <param name="saveFileName"></param>
        public void SaveToFile(string saveFileName)
        {
            mciSendString("stop movie");  // 停止录音  
            mciSendString("save movie " + saveFileName);// 保存录音  
            mciSendString("close movie"); // 关闭录音  
        }


        public static double GetAudioTime(string fileName)
        {

            string TemStr = "";
            string MP3Name = "";
            TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
            MP3Name = MP3Name.PadLeft(260, Convert.ToChar(" "));
            MP3Name = fileName;
            MP3Name = "Open \"" + MP3Name + "\" type mpegvideo alias mysong";
            int ilong = mciSendString(MP3Name, "", 0, 0);
            string durLength = "";
            durLength = durLength.PadLeft(128, Convert.ToChar(" "));
            ilong = mciSendString("set mysong time format milliseconds", TemStr, TemStr.Length, 0);
            ilong = mciSendString("status mysong length", durLength, durLength.Length, 0);
            durLength = durLength.Trim();
            mciSendString("stop mysong");  // 停止录音  
            mciSendString("close mysong"); // 关闭录音  

            if (durLength == "")
            {
                return 0;

            }
            else
            {
                double s_sum = ((double)(Convert.ToInt32(durLength)) / 1000);
                return s_sum;
            }
        }

        //执行状态
        public virtual string Status
        {
            get
            {
                string strBuffer = new string('\0', 12);
                if (mciSendString("status movie mode", strBuffer, 12, 0) != ERROR_SUCCESS)
                    return MODE_UNKNOWN;
                if ((strBuffer = strBuffer.Remove(strBuffer.IndexOf('\0'))).Length <= 0)
                    return MODE_UNKNOWN;
                return strBuffer;
            }
        }
    }
}

namespace WInfo
{
    public class WaveInfo
    {
        /// <summary>
        /// 数据流
        /// </summary>
        private FileStream m_WaveData;

        private bool m_WaveBool = false;

        private RIFF_WAVE_Chunk _Header = new RIFF_WAVE_Chunk();
        private Format_Chunk _Format = new Format_Chunk();
        private Fact_Chunk _Fact = new Fact_Chunk();
        private Data_Chunk _Data = new Data_Chunk();
        public WaveInfo(string WaveFileName)
        {
            m_WaveData = new FileStream(WaveFileName, FileMode.Open);
            try
            {
                LoadWave();
                m_WaveData.Close();
            }
            catch
            {
                m_WaveData.Close();
            }
        }
        private void LoadWave()
        {
            #region RIFF_WAVE_Chunk
            byte[] _Temp4 = new byte[4];
            byte[] _Temp2 = new byte[2];
            m_WaveData.Read(_Temp4, 0, 4);
            if (_Temp4[0] != _Header.szRiffID[0] || _Temp4[1] != _Header.szRiffID[1] || _Temp4[2] != _Header.szRiffID[2] || _Temp4[3] != _Header.szRiffID[3]) return;
            m_WaveData.Read(_Temp4, 0, 4);
            _Header.dwRiffSize = BitConverter.ToUInt32(_Temp4, 0);
            m_WaveData.Read(_Temp4, 0, 4);
            if (_Temp4[0] != _Header.szRiffFormat[0] || _Temp4[1] != _Header.szRiffFormat[1] || _Temp4[2] != _Header.szRiffFormat[2] || _Temp4[3] != _Header.szRiffFormat[3]) return;

            #endregion
            #region Format_Chunk
            m_WaveData.Read(_Temp4, 0, 4);
            if (_Temp4[0] != _Format.ID[0] || _Temp4[1] != _Format.ID[1] || _Temp4[2] != _Format.ID[2]) return;
            m_WaveData.Read(_Temp4, 0, 4);
            _Format.Size = BitConverter.ToUInt32(_Temp4, 0);
            long _EndWave = _Format.Size + m_WaveData.Position;
            m_WaveData.Read(_Temp2, 0, 2);
            _Format.FormatTag = BitConverter.ToUInt16(_Temp2, 0);
            m_WaveData.Read(_Temp2, 0, 2);
            _Format.Channels = BitConverter.ToUInt16(_Temp2, 0);
            m_WaveData.Read(_Temp4, 0, 4);
            _Format.SamlesPerSec = BitConverter.ToUInt32(_Temp4, 0);
            m_WaveData.Read(_Temp4, 0, 4);
            _Format.AvgBytesPerSec = BitConverter.ToUInt32(_Temp4, 0);
            m_WaveData.Read(_Temp2, 0, 2);
            _Format.BlockAlign = BitConverter.ToUInt16(_Temp2, 0);
            m_WaveData.Read(_Temp2, 0, 2);
            _Format.BitsPerSample = BitConverter.ToUInt16(_Temp2, 0);
            m_WaveData.Position += _EndWave - m_WaveData.Position;
            #endregion
            m_WaveData.Read(_Temp4, 0, 4);
            if (_Temp4[0] == _Fact.ID[0] && _Temp4[1] == _Fact.ID[1] && _Temp4[2] == _Fact.ID[2] && _Temp4[3] == _Fact.ID[3])
            {
                #region  Fact_Chunk
                m_WaveData.Read(_Temp4, 0, 4);
                _Fact.Size = BitConverter.ToUInt32(_Temp4, 0);
                m_WaveData.Position += _Fact.Size;
                #endregion
                m_WaveData.Read(_Temp4, 0, 4);
            }
            if (_Temp4[0] == _Data.ID[0] && _Temp4[1] == _Data.ID[1] && _Temp4[2] == _Data.ID[2] && _Temp4[3] == _Data.ID[3])
            {
                #region Data_Chunk
                m_WaveData.Read(_Temp4, 0, 4);
                _Data.Size = BitConverter.ToUInt32(_Temp4, 0);
                _Data.FileBeginIndex = m_WaveData.Position;
                _Data.FileOverIndex = m_WaveData.Position + _Data.Size;
                m_Second = (double)_Data.Size / (double)_Format.AvgBytesPerSec;
                #endregion
            }

            m_WaveBool = true;
        }
        #region 文件定义
        /// <summary>
        /// 文件头
        /// </summary>
        private class RIFF_WAVE_Chunk
        {
            /// <summary>
            /// 文件前四个字节 为RIFF
            /// </summary>
            public byte[] szRiffID = new byte[] { 0x52, 0x49, 0x46, 0x46 };   // 'R','I','F','F'
            /// <summary>
            /// 数据大小 这个数字等于+8 =文件大小
            /// </summary>
            public uint dwRiffSize = 0;
            /// <summary>
            ///WAVE文件定义 为WAVE
            /// </summary>
            public byte[] szRiffFormat = new byte[] { 0x57, 0x41, 0x56, 0x45 }; // 'W','A','V','E'         
        }
        /// <summary>
        /// 声音内容定义
        /// </summary>
        private class Format_Chunk
        {
            /// <summary>
            /// 固定为  是"fmt "字后一位为0x20
            /// </summary>
            public byte[] ID = new byte[] { 0x66, 0x6D, 0x74, 0x20 };
            /// <summary>
            /// 区域大小
            /// </summary>
            public uint Size = 0;
            /// <summary>
            /// 记录着此声音的格式代号，例如1-WAVE_FORMAT_PCM， 2-WAVE_F0RAM_ADPCM等等。 
            /// </summary>
            public ushort FormatTag = 1;
            /// <summary>
            /// 声道数目，1--单声道；2--双声道
            /// </summary>
            public ushort Channels = 2;
            /// <summary>
            /// 采样频率  一般有11025Hz（11kHz）、22050Hz（22kHz）和44100Hz（44kHz）三种
            /// </summary>
            public uint SamlesPerSec = 0;
            /// <summary>
            /// 每秒所需字节数
            /// </summary>
            public uint AvgBytesPerSec = 0;
            /// <summary>
            /// 数据块对齐单位(每个采样需要的字节数)
            /// </summary>
            public ushort BlockAlign = 0;
            /// <summary>
            /// 音频采样大小 
            /// </summary>
            public ushort BitsPerSample = 0;
            /// <summary>
            /// ???
            /// </summary>
            public byte[] Temp = new byte[2];
        }
        /// <summary>
        /// FACT
        /// </summary>
        private class Fact_Chunk
        {
            /// <summary>
            /// 文件前四个字节 为fact
            /// </summary>
            public byte[] ID = new byte[] { 0x66, 0x61, 0x63, 0x74 };   // 'f','a','c','t'
            /// <summary>
            /// 数据大小
            /// </summary>
            public uint Size = 0;
            /// <summary>
            /// 临时数据
            /// </summary>
            public byte[] Temp;
        }
        /// <summary>
        /// 数据区
        /// </summary>
        private class Data_Chunk
        {
            /// <summary>
            /// 文件前四个字节 为RIFF
            /// </summary>
            public byte[] ID = new byte[] { 0x64, 0x61, 0x74, 0x61 };   // 'd','a','t','a'
            /// <summary>
            /// 大小
            /// </summary>
            public uint Size = 0;
            /// <summary>
            /// 开始播放的位置
            /// </summary>
            public long FileBeginIndex = 0;
            /// <summary>
            /// 结束播放的位置
            /// </summary>
            public long FileOverIndex = 0;
        }
        #endregion
        #region 属性
        /// <summary>
        /// 是否成功打开文件
        /// </summary>
        public bool WaveBool { get { return m_WaveBool; } }
        private double m_Second = 0;
        /// <summary>
        /// 秒单位
        /// </summary>
        public double Second { get { return m_Second; } }
        /// <summary>
        /// 格式
        /// </summary>
        public string FormatTag
        {
            get
            {
                switch (_Format.FormatTag)
                {
                    case 1:
                        return "PCM";
                    case 2:
                        return "Microsoft ADPCM";
                    default:
                        return "Un";
                }
            }
        }
        /// <summary>
        /// 频道
        /// </summary>
        public ushort Channels { get { return _Format.Channels; } }
        /// <summary>
        /// 采样级别
        /// </summary>
        public string SamlesPerSec
        {
            get
            {
                switch (_Format.SamlesPerSec)
                {
                    case 11025:
                        return "11kHz";
                    case 22050:
                        return "22kHz";
                    case 44100:
                        return "44kHz";
                    default:
                        return _Format.SamlesPerSec.ToString() + "Hz";
                }
            }
        }
        /// <summary>
        /// 采样大小
        /// </summary>
        public ushort BitsPerSample { get { return _Format.BitsPerSample; } }
        #endregion
    }
}