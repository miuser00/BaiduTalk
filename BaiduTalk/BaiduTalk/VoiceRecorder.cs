using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Baidu.Aip.Speech;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Net;


namespace BaiduTalk
{
    public partial class form1 : Form
    {
        [DllImport("WinMm.dll")]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        //private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);



        private readonly Asr _asrClient;
        private readonly Tts _ttsClient;

        SndRecord recorderA = new SndRecord("recorder1");
        SndRecord recorderB = new SndRecord("recorder2");
        int silencetime = 0; //无声时间
        bool b_Read = false;
        int i;
        private string code = "";
        private string text = "";
        private string url = "";
        private string list = "";

        private FileWR file = new FileWR();

        BassPlayer bs;

        public form1()
        {
            InitializeComponent();
            _asrClient = new Asr("7bZfvZvN3WpShcHwoT1hTpz1", "5b6a4e7316289ac109d6558848678991");
            _ttsClient = new Tts("7bZfvZvN3WpShcHwoT1hTpz1", "5b6a4e7316289ac109d6558848678991");

            bs = new BaiduTalk.BassPlayer(this.Handle, "EZCast Headphone");

            try
            {
                List<string> cmd = new List<string>();
                cmd = file.ReadToList("VoiceCmd.ini");
                l_lastCmdSEQ = long.Parse(cmd[2].ToString());
            }catch
                { }

           

        }
        private ToJoson DoAPI(string Msg)
        {
            INFO = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(Msg));
            getURl = "http://www.tuling123.com/openapi/api?key=" + APIKEY + "&info=" + INFO;
            Uri uri = new Uri(getURl);
            HttpWebRequest getUrl = WebRequest.Create(uri) as HttpWebRequest;
            getUrl.Method = "GET";
            HttpWebResponse response = getUrl.GetResponse() as HttpWebResponse;
            Stream respStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(respStream, Encoding.UTF8);
            string respStr = stream.ReadToEnd();
            stream.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            ToJoson joson = js.Deserialize<ToJoson>(respStr);
            code = joson.code;
            text = joson.text;
            url = joson.url;
            List<list> list = joson.list;
            return joson;
        }
        private void Clear()
        {
            //rtb_SendMsg.Text = "";
        }


        //图灵机
        private static string APIKEY = "a4655b5ca5864520a02efee935d3556b";
        private static string INFO = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("你好"));
        private static string getURl = "http://www.tuling123.com/openapi/api?key=" + APIKEY + "&info=" + INFO;


        int i_AchanncelRecordingCount = 0;
        int i_BchanncelRecordingCount = 0;
        int i_ABchanncelOverlapCount = 0;

        private void tmr_recorder_Tick(object sender, EventArgs e)
        {

            //轮询录音
            if (recorderA.b_Recording == true)
            {
                pan_chanel1.BackColor = Color.Green;
                i_AchanncelRecordingCount++;
            }
            else
            {
                pan_chanel1.BackColor = Color.Gray;
                i_AchanncelRecordingCount = 0;
            }
            if (recorderB.b_Recording == true)
            {
                pan_chanel2.BackColor = Color.Green;
                i_BchanncelRecordingCount++;
            }
            else
            {
                pan_chanel2.BackColor = Color.Gray;
                i_BchanncelRecordingCount = 0;
            }
            if ((recorderA.b_Recording == true) && (recorderB.b_Recording == true))
            {
                i_ABchanncelOverlapCount++;
            }
            else
            {
                i_ABchanncelOverlapCount = 0;
            }

            //情况一 A信道没在录音，B信道也没在录音
            if ((i_AchanncelRecordingCount==0)&& (i_BchanncelRecordingCount == 0))
            {
                //A信道开始录音
                recorderA.Start();

            }

            //情况二 A信道录过1分钟，B还没录
            if ((i_AchanncelRecordingCount >50)  && (i_BchanncelRecordingCount ==0))
            {
                //交叠<0.2s
                if (i_ABchanncelOverlapCount < 20)
                {

                    //B信道开始录音
                    recorderB.Start();
                    pan_chanel2.BackColor = Color.Green;
                    pan_chanel1.BackColor = Color.Gray;
                }
            }

            //情况三 B信道录过1分钟，A还没录
            if ((i_BchanncelRecordingCount > 50) && (i_AchanncelRecordingCount == 0))
            {
                //交叠<0.2s
                if (i_ABchanncelOverlapCount < 20)
                {

                    //B信道开始录音
                    recorderA.Start();
                    pan_chanel1.BackColor = Color.Green;
                    pan_chanel2.BackColor = Color.Gray;
                }
            }

            //情况四 AB交叠超过0.2s
            if (i_ABchanncelOverlapCount > 20)
            {
                if (i_AchanncelRecordingCount > i_BchanncelRecordingCount)
                {
                    //A信道停 B信道继续录
                    recorderA.Stop();
                    pan_chanel2.BackColor = Color.Green;
                    pan_chanel1.BackColor = Color.Gray;
                }else
                {
                    //B信道停 A信道继续录
                    recorderB.Stop();
                    pan_chanel1.BackColor = Color.Green;
                    pan_chanel2.BackColor = Color.Gray;

                }
                
            }


        }

        private void VoiceRecorder_Load(object sender, EventArgs e)
        {
            Mci.StartLevelMeter();
            lab_status.Text = "无声";

        }

        private void tmr_talk_Tick(object sender, EventArgs e)
        {
           
            double inputValue;
            double level = Mci.GetLevel(10, out inputValue, 1);
            txt_VoiceLevel.Text = "Sample strength = "+((int)level).ToString();
            prb_volume.Value = Convert.ToInt32(level);


            //计算安静的时间
            if (inputValue<=5)
            {

                silencetime++;
            }else
            {
                silencetime = 0;
            }
            if ((b_Read==true) && (inputValue<=10))
            {
                lab_status.Text = "正在聆听";
                Log("正在聆听");
                lab_status.Refresh();
                rtb_output.Refresh();
                btn_Report_Click(sender, e);
                panel_sample.BackColor = Color.DarkGreen;
                panel_sample.Refresh();
            }

            //判断是否正式录音
            if (inputValue>5)
            {
                if (i_AchanncelRecordingCount>i_BchanncelRecordingCount)
                {
                    tmr_recorder.Enabled = false;
                    lab_status.Text = "信道1正在拾取";
                    Log("信道1正在拾取");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    b_Read = false;
                    panel_sample.BackColor = Color.Gold;
                    panel_sample.Refresh();

                }
                if (i_BchanncelRecordingCount > i_AchanncelRecordingCount)
                {
                    tmr_recorder.Enabled = false;
                    lab_status.Text = "信道2正在拾取";
                    Log("信道2正在拾取");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    b_Read = false;
                    panel_sample.BackColor = Color.Gold;
                    panel_sample.Refresh();
                }
            }

            //判断是否记录 静默1s开始存储
            if ((silencetime>20)&&(b_Read==false))
            {
                if (i_AchanncelRecordingCount > i_BchanncelRecordingCount)
                {
                    Random a = new Random();
                    string aa = "AA" + a.Next();
                    string path = Application.StartupPath + "\\wav\\" + aa + "r1.wav";
                    recorderA.SaveToFile(path);
                    recorderB.Stop();
                    System.Threading.Thread.Sleep(100);
                    int i_sleeptime = (int)(SndPlayer.GetWavFileTime(path) * 1000);
                    txt_AudioFile.Text = path;
                    lab_status.Text = "信道1正在识别";
                    Log("信道1正在识别");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    panel_sample.BackColor = Color.Blue;
                    panel_sample.Refresh();



                }
                if (i_BchanncelRecordingCount > i_AchanncelRecordingCount)
                {
                    Random a = new Random();
                    string aa = "AA" + a.Next();
                    string path = Application.StartupPath + "\\wav\\" + aa + "r2.wav";
                    recorderB.SaveToFile(path);
                    recorderA.Stop();
                    System.Threading.Thread.Sleep(100);
                    int i_sleeptime = (int)(SndPlayer.GetWavFileTime(path) * 1000);
                    txt_AudioFile.Text = path;
                    lab_status.Text = "信道2正在识别";
                    Log("信道2正在识别");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    panel_sample.BackColor = Color.Blue;
                    panel_sample.Refresh();

                }
                b_Read = true;
                //SndPlayer.Play(path);
                //System.Threading.Thread.Sleep(i_sleeptime);

                tmr_talk.Enabled = false;
               
                btn_Recognize_Click(sender, e);
                Application.DoEvents();
                rtb_SendMsg.Refresh();
                if (message_bar.Text == "识别成功")
                {
                    Log("识别成功");
                    lab_status.Text = "正在合成语音";
                    Log("正在合成语音");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    panel_sample.BackColor = Color.Gold;
                    lab_status.Refresh();

                    btn_send_Click(sender, e);
                    Application.DoEvents();
                    btn_VoiceCombine_Click(sender, e);
                    Application.DoEvents();

                    lab_status.Text = "正在发声";
                    Log("正在发声");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    panel_sample.BackColor = Color.Navy;
                    lab_status.Refresh();

                    btn_play_Click(sender, e);
                    Application.DoEvents();
                }
                //txt_VoicePath.Text = txt_AudioFile.Text;
                //btn_play_Click(sender, e);
                tmr_recorder.Enabled = true;
                tmr_talk.Enabled = true;
            }
            


        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            btn_Stop_Click(sender, e);
            Log("开始自动运行");
            tmr_talk.Enabled = true;
            tmr_recorder.Enabled = true;
            lab_status.Text = "正在聆听";
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            Log("停止自动运行");
            tmr_talk.Enabled = false;
            tmr_recorder.Enabled = false;
            tmr_listen.Enabled = false;
            lab_status.Text = "停止聆听";
        }

        private void btn_Recognize_Click(object sender, EventArgs e)
        {
            string fileName = "ffmpeg.exe";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = fileName;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "-i " + txt_AudioFile.Text + " -y -ar 16000 -ac 1 -acodec pcm_s16le input.wav";//参数以空格分隔，如果某个参数为空，可以传入””
            p.Start();
            p.WaitForExit();
            var data = File.ReadAllBytes("input.wav");
            File.Delete("input.wav");
            var result = _asrClient.Recognize(data, "pcm", 16000);
            Console.Write(result);
            if (result["err_msg"].ToString() == "success.")
            {
                rtb_textOut.Text = result["result"].ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Trim();
                rtb_SendMsg.Text = rtb_textOut.Text;
                message_bar.Text = "识别成功";
            }else
            {
                message_bar.Text = "识别失败";
                panel_sample.BackColor = Color.Red;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            mciSendString("set wave bitpersample 8", "", 0, 0);

            mciSendString("set wave samplespersec 20000", "", 0, 0);
            mciSendString("set wave channels 2", "", 0, 0);
            mciSendString("set wave format tag pcm", "", 0, 0);
            mciSendString("open new type WAVEAudio alias movie", "", 0, 0);

            mciSendString("record movie", "", 0, 0);
            System.Threading.Thread.Sleep(1000);
            mciSendString("stop movie", "", 0, 0);
            mciSendString("save movie 1.wav", "", 0, 0);
            mciSendString("close movie", "", 0, 0);

            SndPlayer.GetWavFileTime("1.wav");


        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            StringBuilder receiveMsg = new StringBuilder();
            string msg = rtb_SendMsg.Text.Trim();
            txtRecMsg.AppendText("我：" + DateTime.Now + Environment.NewLine);
            txtRecMsg.AppendText(msg + "\r\n");
            ToJoson joson = DoAPI(msg);
            List<list> list = joson.list;
            switch (joson.code)
            {
                //文本类
                case "100000":
                    receiveMsg.Append(joson.text + Environment.NewLine);
                    break;
                    //列车
                //网址类数据 
                case "200000":
                    receiveMsg.Append(joson.text + Environment.NewLine)
                               .Append(joson.url);
                    break;
                //新闻 
                case "302000":
                    receiveMsg.Append(joson.text + Environment.NewLine)
                              .Append(joson.url);
                    foreach (list listDetail in list)
                    {
                        receiveMsg.Append(listDetail.source + "   " + listDetail.article + Environment.NewLine)
                            .Append(listDetail.detailurl + Environment.NewLine);
                    }
                    break;
                //菜谱、视频、小说 
                case "308000":
                    receiveMsg.Append(joson.text + Environment.NewLine)
                             .Append(joson.url);
                    foreach (list listDetail in list)
                    {
                        receiveMsg.Append(listDetail.name + "   " + listDetail.info + Environment.NewLine)
                            .Append(listDetail.detailurl + Environment.NewLine);
                    }
                    break;
                //key的长度错误（32位）
                case "40001":
                    receiveMsg.Append("key的长度错误（32位）" + Environment.NewLine);
                    break;
                //请求内容为空
                case "40002":
                    receiveMsg.Append("请求内容为空" + Environment.NewLine);
                    break;
                //Key错误或帐号未激活
                case "40003":
                    receiveMsg.Append("Key错误或帐号未激活" + Environment.NewLine);
                    break;
                //当天请求次数已用完
                case "40004":
                    receiveMsg.Append("当天请求次数已用完" + Environment.NewLine);
                    break;
                //暂不支持该功能
                case "40005":
                    receiveMsg.Append("暂不支持该功能" + Environment.NewLine);
                    break;
                //服务器升级中
                case "40006":
                    receiveMsg.Append("服务器升级中" + Environment.NewLine);
                    break;
                //服务器数据格式异常
                case "40007":
                    receiveMsg.Append("服务器数据格式异常" + Environment.NewLine);
                    break;
                default:
                    break;
            }
            rtb_replyMSG.Text = receiveMsg.ToString();
            txt_combine.Text = rtb_replyMSG.Text;
            txtRecMsg.AppendText("机器人：" + DateTime.Now + Environment.NewLine);
            txtRecMsg.AppendText(receiveMsg.ToString() + "\r\n");
            txtRecMsg.Select(txtRecMsg.TextLength, 0);
            Clear();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void btn_VoiceCombine_Click(object sender, EventArgs e)
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                //{"spd", 3}, // 语速
                                {"spd", 3}, // 语速
                {"vol", 7}, // 音量
                {"per", 4}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis(txt_combine.Text, option);

            Random a = new Random();
            string aa = "AA" + a.Next();
            string path = Application.StartupPath + "\\wav\\" + aa + "voice.mp3";


            if (result.ErrorCode == 0)  // 或 result.Success
            {
                File.WriteAllBytes(path, result.Data);
            }
            txt_VoicePath.Text = path;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            string fileName = "ffmpeg.exe";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = fileName;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "-i " + txt_VoicePath.Text + " -y -ar 11025 -ac 1 -acodec pcm_u8 output.wav";//参数以空格分隔，如果某个参数为空，可以传入””
            p.Start();
            p.WaitForExit();

            int i_sleeptime = (int)(SndPlayer.GetAudioTime(txt_VoicePath.Text) * 1000);

            bs.SetFilePath(txt_VoicePath.Text);
            bs.Play();
            
            //SndPlayer.Play(txt_VoicePath.Text);
            System.Threading.Thread.Sleep(i_sleeptime+200);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtRecMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtb_replyMSG_TextChanged(object sender, EventArgs e)
        {

        }

        long l_lastCmdSEQ = 0;

        long reportno = 0;
        private void btn_Report_Click(object sender,EventArgs e)
        {
            //命令 1
            //参数 2
            //序号 3
            tmr_Report.Enabled = false;
            try
            {
                List<string> report = new List<string>();
                report.Add("");
                report.Add("");
                report.Add("");
                if ((lab_status.Text=="无声")||(lab_status.Text=="停止聆听"))
                {
                    report[0]="停止";
                    report[1] = rtb_textOut.Text;
                }
                else if (lab_status.Text == "正在聆听")
                {
                    report[0] = "空闲";
                    report[1] = rtb_textOut.Text;
                }
                else if (lab_status.Text .Contains ("识别"))
                {
                    report[0] = "识别";
                    report[1] = rtb_textOut.Text;
                }
                else if (lab_status.Text.Contains("发声"))
                {
                    report[0] = "发声";
                    report[1] = rtb_textOut.Text;
                }
                else if (lab_status.Text.Contains("识别成功"))
                {
                    report[0] = "识别到";
                    report[1] = rtb_textOut.Text;
                }
                else
                {
                    report[0] = ("忙");
                    report[1] = rtb_textOut.Text;
                }
                report[2] = reportno.ToString();
                reportno++;
                file.WriteToFile(report,"VoiceReport.ini");
            }
            catch { }
            tmr_Report.Enabled = true;
        }
        private void btn_GetCmd_Click(object sender, EventArgs e)
        {
            //////////////数据格式
            // 指令 0  SAYTOUSER SAYTOROBOT RUN STOP LISTEN
            // 参数 1
            // 序列号 2


            try
            {
                List<string> cmd = new List<string>();
                cmd = file.ReadToList("VoiceCmd.ini");
                long l_currCmdSEQ = long.Parse(cmd[2].ToString());

                //接收到新指令
                if (l_lastCmdSEQ != l_currCmdSEQ)
                {
                    Log("发现新指令");

                    if (cmd[0]=="SAYTOUSER")
                    {

                        //停止自动化
                        btn_Stop_Click(sender, e);
                        //处理当前指令
                        lab_status.Text = "正在合成语音";
                        Log("正在合成语音");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);
                        txt_combine.Text = cmd[1].ToString();
                        btn_VoiceCombine_Click(sender, e);
                        lab_status.Text = "正在发声";
                        Log("正在发声");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);
                        btn_play_Click(sender, e);
                        lab_status.Text = "无声";
                        Log("无声");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);

                    }

                    if (cmd[0] == "SAYTOROBOT")
                    {
                        //停止自动化
                        btn_Stop_Click(sender, e);
                        //处理当前指令
                        rtb_SendMsg.Text = cmd[1].ToString();
                        lab_status.Text = "正在分析语言";
                        Log("正在分析语言");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);
                        btn_send_Click(sender, e);
                        lab_status.Text = "正在合成语音";
                        Log("正在合成语音");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);
                        btn_VoiceCombine_Click(sender, e);
                        lab_status.Text = "正在发声";
                        Log("正在发声");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);
                        btn_play_Click(sender, e);
                        lab_status.Text = "无声";
                        Log("无声");
                        lab_status.Refresh();
                        rtb_output.Refresh();
                        btn_Report_Click(sender, e);

                    }
                    if (cmd[0]=="RUN")
                    {
                        btn_Start_Click(sender, e);
                    }
                    if (cmd[0] == "LISTEN")
                    {
                        btn_Listen_Click(sender, e);
                    }
                    if (cmd[0] == "STOP")
                    {
                        btn_Stop_Click(sender, e);
                    }
                    l_lastCmdSEQ = l_currCmdSEQ;
                }

            }
            catch
            { }
        }
        string s_lastLog = "";
        private void Log(string txt)
        {
            if (txt != s_lastLog)
            {
                rtb_output.Text = rtb_output.Text + txt + "\n";
                rtb_output.SelectionStart = rtb_output.Text.Length;
                rtb_output.ScrollToCaret();
                s_lastLog = txt;
                if (rtb_output.Text.Length > 500)
                {
                    rtb_output.Text = rtb_output.Text.Substring(rtb_output.Text.Length - 500, 500);
                }
            }
        }

        private void tmr_Cmd_Tick(object sender, EventArgs e)
        {
            btn_GetCmd_Click(sender, e);
        }

        private void tmr_Report_Tick(object sender, EventArgs e)
        {
            btn_Report_Click(sender, e);
        }

        private void tmr_listen_Tick(object sender, EventArgs e)
        {

            double inputValue;
            double level = Mci.GetLevel(10, out inputValue, 1);
            txt_VoiceLevel.Text = "Sample strength = " + ((int)level).ToString();
            prb_volume.Value = Convert.ToInt32(level);


            //计算安静的时间
            if (inputValue <= 5)
            {

                silencetime++;
            }
            else
            {
                silencetime = 0;
            }
            if ((b_Read == true) && (inputValue <= 10))
            {
                lab_status.Text = "正在聆听";
                Log("正在聆听");
                lab_status.Refresh();
                rtb_output.Refresh();
                btn_Report_Click(sender, e);
                panel_sample.BackColor = Color.DarkGreen;
                panel_sample.Refresh();
            }

            //判断是否正式录音
            if (inputValue > 5)
            {
                if (recorderA.b_Recording == true)
                {
                    tmr_recorder.Enabled = false;
                    lab_status.Text = "信道1正在拾取";
                    Log("信道1正在拾取");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    b_Read = false;
                    panel_sample.BackColor = Color.Gold;
                    panel_sample.Refresh();

                }
                if (recorderB.b_Recording == true)
                {
                    tmr_recorder.Enabled = false;
                    lab_status.Text = "信道2正在拾取";
                    Log("信道2正在拾取");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    b_Read = false;
                    panel_sample.BackColor = Color.Gold;
                    panel_sample.Refresh();
                }
            }

            //判断是否记录 静默1s开始存储
            if ((silencetime > 10) && (b_Read == false))
            {
                if (recorderA.b_Recording == true)
                {
                    Random a = new Random();
                    string aa = "AA" + a.Next();
                    string path = Application.StartupPath + "\\wav\\" + aa + "r1.wav";
                    recorderA.SaveToFile(path);
                    System.Threading.Thread.Sleep(100);
                    int i_sleeptime = (int)(SndPlayer.GetWavFileTime(path) * 1000);
                    txt_AudioFile.Text = path;
                    lab_status.Text = "信道1正在识别";
                    Log("信道1正在识别");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    panel_sample.BackColor = Color.Blue;
                    panel_sample.Refresh();



                }
                if (recorderB.b_Recording == true)
                {
                    Random a = new Random();
                    string aa = "AA" + a.Next();
                    string path = Application.StartupPath + "\\wav\\" + aa + "r2.wav";
                    recorderB.SaveToFile(path);
                    System.Threading.Thread.Sleep(100);
                    int i_sleeptime = (int)(SndPlayer.GetWavFileTime(path) * 1000);
                    txt_AudioFile.Text = path;
                    lab_status.Text = "信道2正在识别";
                    Log("信道2正在识别");
                    lab_status.Refresh();
                    rtb_output.Refresh();
                    btn_Report_Click(sender, e);
                    panel_sample.BackColor = Color.Blue;
                    panel_sample.Refresh();

                }
                b_Read = true;


                tmr_listen.Enabled = false;

                btn_Recognize_Click(sender, e);
                rtb_SendMsg.Refresh();
                if (message_bar.Text == "识别成功")
                {
                    Log("识别成功");
                    lab_status.Text = "语音识别完成";
                    Log("语音识别完成");
                }
                System.Threading.Thread.Sleep(1000);
                tmr_recorder.Enabled = true;
                tmr_listen.Enabled = true;
            }


        }

        private void btn_Listen_Click(object sender, EventArgs e)
        {
            btn_Stop_Click(sender, e);
            Log("开始识别语音");
            tmr_recorder.Enabled = true;
            tmr_listen.Enabled = true;

        }
        SndRecord recorder3 = new SndRecord("test1");
        SndRecord recorder4 = new SndRecord("test2");
        private void button2_Click(object sender, EventArgs e)
        {
            SndRecord recorder3 = new SndRecord("test1");
            SndRecord recorder4 = new SndRecord("test2");
            recorder3.Start();
            System.Threading.Thread.Sleep(1000);
            recorder4.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            recorder3.SaveToFile("test3.wav");
            recorder4.SaveToFile("test4.wav");
        }

        private void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
