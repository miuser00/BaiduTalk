using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BaiduTalk
{
    //录音相关功能
    public partial class SndRecord
    {
        [DllImport("WinMm.dll")]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        //private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);


        private const int ERROR_SUCCESS = 0;
        private const string MODE_UNKNOWN = "unknown";

        private static bool mciSendString(string strCommand)
        {
            return mciSendString(strCommand, null, 0, 0) != ERROR_SUCCESS;
        }
    }



    public partial class SndRecord
    {
        private int m_channels;
        private int m_sample_spersec;
        private string m_format_tag;
        private int m_bits_per_sample;
        string audioname;
        public bool b_Recording = false;


        public SndRecord(string name)
        {
            this.Channels = 1;
            this.FormatTag = "pcm";
            this.BitsPerSample = 16;
            this.SampleSpersec = 8000;
            this.audioname = name;
        }
 


        public static void Play(string file)
        {
            mciSendString("close media", null, 0, 0);//关闭
            mciSendString("open \"" + file + "\" type mpegvideo alias media", null, 0, 0);

            //打开  file 这个路径的歌曲 " ，type mpegvideo是文件类型  ，    alias 是将文件别名为media 
            mciSendString("play media notify", null, 0, 0);//播放
        }

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
            mciSendString("stop "+audioname+"");  // 停止录音  
            mciSendString("close "+audioname+""); // 关闭录音  
            b_Recording = false;
        }

        /// <summary>
        /// 开始录音
        /// </summary>
        public void Start()
        {

            mciSendString("open new type waveaudio alias "+audioname+""); // 打开录音 

            mciSendString("record "+audioname+"");// 开始录音 
            b_Recording = true;
        }

        /// <summary>
        /// 暂停录音
        /// </summary>
        public void Pause()
        {
            mciSendString("pause "+audioname+"");
            //mciSendString("open new type waveaudio alias "+audioname+""); // 打开录音  
            //mciSendString("record "+audioname+"");// 开始录音 
        }

        /// <summary>
        /// 恢复录音
        /// </summary>
        /// <returns></returns>
        public virtual bool Resume()
        {
            return mciSendString("resume "+audioname+"");
        }

        /// <summary>
        /// 保存录音文件
        /// </summary>
        /// <param name="saveFileName"></param>
        public void SaveToFile(string saveFileName)
        {
            mciSendString("stop "+audioname+"");  // 停止录音  
            mciSendString("save "+audioname+" " + saveFileName);// 保存录音  
            mciSendString("close "+audioname+""); // 关闭录音  
            b_Recording = false;
        }




        //执行状态
        public virtual string Status
        {
            get
            {
                string strBuffer = new string('\0', 12);
                if (mciSendString("status "+audioname+" mode", strBuffer, 12, 0) != ERROR_SUCCESS)
                    return MODE_UNKNOWN;
                if ((strBuffer = strBuffer.Remove(strBuffer.IndexOf('\0'))).Length <= 0)
                    return MODE_UNKNOWN;
                return strBuffer;
            }
        }
    }
}
