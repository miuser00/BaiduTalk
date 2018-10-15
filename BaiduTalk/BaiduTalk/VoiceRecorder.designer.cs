namespace BaiduTalk
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.tmr_recorder = new System.Windows.Forms.Timer(this.components);
            this.txt_VoiceLevel = new System.Windows.Forms.TextBox();
            this.tmr_talk = new System.Windows.Forms.Timer(this.components);
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.lab_status = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_AudioFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Recognize = new System.Windows.Forms.Button();
            this.rtb_textOut = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Send = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_SendMsg = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecMsg = new System.Windows.Forms.RichTextBox();
            this.rtb_replyMSG = new System.Windows.Forms.RichTextBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_play = new System.Windows.Forms.Button();
            this.txt_VoicePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_combine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_VoiceCombine = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Liten = new System.Windows.Forms.Button();
            this.message_bar = new System.Windows.Forms.Label();
            this.panel_sample = new System.Windows.Forms.Panel();
            this.pan_chanel2 = new System.Windows.Forms.Panel();
            this.pan_chanel1 = new System.Windows.Forms.Panel();
            this.btn_Report = new System.Windows.Forms.Button();
            this.btn_GetCmd = new System.Windows.Forms.Button();
            this.prb_volume = new System.Windows.Forms.ProgressBar();
            this.tmr_Cmd = new System.Windows.Forms.Timer(this.components);
            this.tmr_Report = new System.Windows.Forms.Timer(this.components);
            this.tmr_listen = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_sample.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_recorder
            // 
            this.tmr_recorder.Interval = 10;
            this.tmr_recorder.Tick += new System.EventHandler(this.tmr_recorder_Tick);
            // 
            // txt_VoiceLevel
            // 
            this.txt_VoiceLevel.BackColor = System.Drawing.Color.DimGray;
            this.txt_VoiceLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_VoiceLevel.ForeColor = System.Drawing.Color.White;
            this.txt_VoiceLevel.Location = new System.Drawing.Point(9, 8);
            this.txt_VoiceLevel.Name = "txt_VoiceLevel";
            this.txt_VoiceLevel.Size = new System.Drawing.Size(176, 14);
            this.txt_VoiceLevel.TabIndex = 1;
            // 
            // tmr_talk
            // 
            this.tmr_talk.Tick += new System.EventHandler(this.tmr_talk_Tick);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_Start.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Start.Location = new System.Drawing.Point(413, 6);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(72, 21);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_Stop.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Stop.Location = new System.Drawing.Point(491, 6);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(72, 21);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // lab_status
            // 
            this.lab_status.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_status.Location = new System.Drawing.Point(23, 79);
            this.lab_status.Name = "lab_status";
            this.lab_status.Size = new System.Drawing.Size(529, 47);
            this.lab_status.TabIndex = 4;
            this.lab_status.Text = "等待";
            this.lab_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_AudioFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_Recognize);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1382, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 365);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文字识别：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(131, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "label9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "识别出的文本：";
            // 
            // txt_AudioFile
            // 
            this.txt_AudioFile.BackColor = System.Drawing.Color.DimGray;
            this.txt_AudioFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_AudioFile.Location = new System.Drawing.Point(21, 60);
            this.txt_AudioFile.Multiline = true;
            this.txt_AudioFile.Name = "txt_AudioFile";
            this.txt_AudioFile.Size = new System.Drawing.Size(301, 60);
            this.txt_AudioFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "待识别音频：";
            // 
            // btn_Recognize
            // 
            this.btn_Recognize.Location = new System.Drawing.Point(203, 142);
            this.btn_Recognize.Name = "btn_Recognize";
            this.btn_Recognize.Size = new System.Drawing.Size(119, 26);
            this.btn_Recognize.TabIndex = 1;
            this.btn_Recognize.Text = "识别";
            this.btn_Recognize.UseVisualStyleBackColor = true;
            this.btn_Recognize.Click += new System.EventHandler(this.btn_Recognize_Click);
            // 
            // rtb_textOut
            // 
            this.rtb_textOut.BackColor = System.Drawing.Color.DimGray;
            this.rtb_textOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_textOut.Font = new System.Drawing.Font("宋体", 9F);
            this.rtb_textOut.ForeColor = System.Drawing.Color.Black;
            this.rtb_textOut.Location = new System.Drawing.Point(35, 165);
            this.rtb_textOut.Name = "rtb_textOut";
            this.rtb_textOut.Size = new System.Drawing.Size(283, 45);
            this.rtb_textOut.TabIndex = 0;
            this.rtb_textOut.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btn_Send);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.rtb_SendMsg);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(1024, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 269);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "对话引擎：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "对话：";
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(204, 133);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(119, 26);
            this.btn_Send.TabIndex = 8;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "回应：";
            // 
            // rtb_SendMsg
            // 
            this.rtb_SendMsg.BackColor = System.Drawing.Color.DimGray;
            this.rtb_SendMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_SendMsg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_SendMsg.ForeColor = System.Drawing.Color.White;
            this.rtb_SendMsg.Location = new System.Drawing.Point(33, 40);
            this.rtb_SendMsg.Name = "rtb_SendMsg";
            this.rtb_SendMsg.Size = new System.Drawing.Size(288, 87);
            this.rtb_SendMsg.TabIndex = 0;
            this.rtb_SendMsg.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "输入：";
            // 
            // txtRecMsg
            // 
            this.txtRecMsg.BackColor = System.Drawing.Color.DimGray;
            this.txtRecMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecMsg.Location = new System.Drawing.Point(35, 216);
            this.txtRecMsg.Name = "txtRecMsg";
            this.txtRecMsg.Size = new System.Drawing.Size(580, 100);
            this.txtRecMsg.TabIndex = 9;
            this.txtRecMsg.Text = "";
            this.txtRecMsg.TextChanged += new System.EventHandler(this.txtRecMsg_TextChanged);
            // 
            // rtb_replyMSG
            // 
            this.rtb_replyMSG.BackColor = System.Drawing.Color.DimGray;
            this.rtb_replyMSG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_replyMSG.Font = new System.Drawing.Font("宋体", 9F);
            this.rtb_replyMSG.ForeColor = System.Drawing.Color.Black;
            this.rtb_replyMSG.Location = new System.Drawing.Point(324, 165);
            this.rtb_replyMSG.Name = "rtb_replyMSG";
            this.rtb_replyMSG.Size = new System.Drawing.Size(291, 45);
            this.rtb_replyMSG.TabIndex = 3;
            this.rtb_replyMSG.Text = "";
            this.rtb_replyMSG.TextChanged += new System.EventHandler(this.rtb_replyMSG_TextChanged);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.btn_play);
            this.groupBox4.Controls.Add(this.txt_VoicePath);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txt_combine);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btn_VoiceCombine);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(662, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(345, 466);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "语音合成：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(69, 340);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(187, 385);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(119, 26);
            this.btn_play.TabIndex = 23;
            this.btn_play.Text = "播放";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // txt_VoicePath
            // 
            this.txt_VoicePath.Location = new System.Drawing.Point(21, 247);
            this.txt_VoicePath.Multiline = true;
            this.txt_VoicePath.Name = "txt_VoicePath";
            this.txt_VoicePath.Size = new System.Drawing.Size(301, 76);
            this.txt_VoicePath.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "被合成的音频：";
            // 
            // txt_combine
            // 
            this.txt_combine.Location = new System.Drawing.Point(21, 43);
            this.txt_combine.Multiline = true;
            this.txt_combine.Name = "txt_combine";
            this.txt_combine.Size = new System.Drawing.Size(301, 139);
            this.txt_combine.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "待合成文本：";
            // 
            // btn_VoiceCombine
            // 
            this.btn_VoiceCombine.Location = new System.Drawing.Point(203, 204);
            this.btn_VoiceCombine.Name = "btn_VoiceCombine";
            this.btn_VoiceCombine.Size = new System.Drawing.Size(119, 26);
            this.btn_VoiceCombine.TabIndex = 1;
            this.btn_VoiceCombine.Text = "合成";
            this.btn_VoiceCombine.UseVisualStyleBackColor = true;
            this.btn_VoiceCombine.Click += new System.EventHandler(this.btn_VoiceCombine_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(734, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Black;
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.txtRecMsg);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.panel2);
            this.groupBox5.Controls.Add(this.panel_sample);
            this.groupBox5.Controls.Add(this.rtb_replyMSG);
            this.groupBox5.Controls.Add(this.rtb_textOut);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(6, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(650, 473);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "智能语音模块：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 32);
            this.button3.TabIndex = 28;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 32);
            this.button2.TabIndex = 27;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rtb_output);
            this.groupBox9.ForeColor = System.Drawing.Color.White;
            this.groupBox9.Location = new System.Drawing.Point(38, 322);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(577, 102);
            this.groupBox9.TabIndex = 26;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "输出：";
            // 
            // rtb_output
            // 
            this.rtb_output.BackColor = System.Drawing.Color.DarkGray;
            this.rtb_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_output.Location = new System.Drawing.Point(6, 15);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.Size = new System.Drawing.Size(565, 81);
            this.rtb_output.TabIndex = 0;
            this.rtb_output.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.btn_Liten);
            this.panel2.Controls.Add(this.txt_VoiceLevel);
            this.panel2.Controls.Add(this.btn_Start);
            this.panel2.Controls.Add(this.message_bar);
            this.panel2.Controls.Add(this.btn_Stop);
            this.panel2.Location = new System.Drawing.Point(35, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 33);
            this.panel2.TabIndex = 25;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btn_Liten
            // 
            this.btn_Liten.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_Liten.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Liten.Location = new System.Drawing.Point(335, 6);
            this.btn_Liten.Name = "btn_Liten";
            this.btn_Liten.Size = new System.Drawing.Size(72, 21);
            this.btn_Liten.TabIndex = 4;
            this.btn_Liten.Text = "倾听";
            this.btn_Liten.UseVisualStyleBackColor = true;
            this.btn_Liten.Click += new System.EventHandler(this.btn_Listen_Click);
            // 
            // message_bar
            // 
            this.message_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.message_bar.AutoSize = true;
            this.message_bar.Location = new System.Drawing.Point(220, 15);
            this.message_bar.Name = "message_bar";
            this.message_bar.Size = new System.Drawing.Size(53, 12);
            this.message_bar.TabIndex = 1;
            this.message_bar.Text = "Message:";
            // 
            // panel_sample
            // 
            this.panel_sample.BackColor = System.Drawing.Color.DimGray;
            this.panel_sample.Controls.Add(this.pan_chanel2);
            this.panel_sample.Controls.Add(this.pan_chanel1);
            this.panel_sample.Controls.Add(this.btn_Report);
            this.panel_sample.Controls.Add(this.btn_GetCmd);
            this.panel_sample.Controls.Add(this.lab_status);
            this.panel_sample.Controls.Add(this.prb_volume);
            this.panel_sample.Location = new System.Drawing.Point(35, 20);
            this.panel_sample.Name = "panel_sample";
            this.panel_sample.Size = new System.Drawing.Size(580, 139);
            this.panel_sample.TabIndex = 21;
            // 
            // pan_chanel2
            // 
            this.pan_chanel2.BackColor = System.Drawing.Color.Chocolate;
            this.pan_chanel2.Location = new System.Drawing.Point(83, 89);
            this.pan_chanel2.Name = "pan_chanel2";
            this.pan_chanel2.Size = new System.Drawing.Size(45, 24);
            this.pan_chanel2.TabIndex = 27;
            // 
            // pan_chanel1
            // 
            this.pan_chanel1.BackColor = System.Drawing.Color.Chocolate;
            this.pan_chanel1.Location = new System.Drawing.Point(32, 89);
            this.pan_chanel1.Name = "pan_chanel1";
            this.pan_chanel1.Size = new System.Drawing.Size(45, 24);
            this.pan_chanel1.TabIndex = 26;
            // 
            // btn_Report
            // 
            this.btn_Report.Location = new System.Drawing.Point(491, 94);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(83, 29);
            this.btn_Report.TabIndex = 25;
            this.btn_Report.Text = "Report";
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Visible = false;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // btn_GetCmd
            // 
            this.btn_GetCmd.Location = new System.Drawing.Point(402, 94);
            this.btn_GetCmd.Name = "btn_GetCmd";
            this.btn_GetCmd.Size = new System.Drawing.Size(83, 29);
            this.btn_GetCmd.TabIndex = 24;
            this.btn_GetCmd.Text = "GetCMD";
            this.btn_GetCmd.UseVisualStyleBackColor = true;
            this.btn_GetCmd.Visible = false;
            this.btn_GetCmd.Click += new System.EventHandler(this.btn_GetCmd_Click);
            // 
            // prb_volume
            // 
            this.prb_volume.BackColor = System.Drawing.Color.DarkGray;
            this.prb_volume.ForeColor = System.Drawing.Color.Orange;
            this.prb_volume.Location = new System.Drawing.Point(23, 17);
            this.prb_volume.Maximum = 128;
            this.prb_volume.Name = "prb_volume";
            this.prb_volume.Size = new System.Drawing.Size(529, 59);
            this.prb_volume.TabIndex = 22;
            // 
            // tmr_Cmd
            // 
            this.tmr_Cmd.Enabled = true;
            this.tmr_Cmd.Interval = 500;
            this.tmr_Cmd.Tick += new System.EventHandler(this.tmr_Cmd_Tick);
            // 
            // tmr_Report
            // 
            this.tmr_Report.Enabled = true;
            this.tmr_Report.Interval = 500;
            this.tmr_Report.Tick += new System.EventHandler(this.tmr_Report_Tick);
            // 
            // tmr_listen
            // 
            this.tmr_listen.Tick += new System.EventHandler(this.tmr_listen_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "声音强度：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1024, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "声音采样：";
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1022, 488);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form1";
            this.ShowIcon = false;
            this.Text = "花小曰 V0.11";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form1_FormClosed);
            this.Load += new System.EventHandler(this.VoiceRecorder_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_sample.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr_recorder;
        private System.Windows.Forms.TextBox txt_VoiceLevel;
        private System.Windows.Forms.Timer tmr_talk;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label lab_status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_AudioFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Recognize;
        private System.Windows.Forms.RichTextBox rtb_textOut;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.RichTextBox rtb_replyMSG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_SendMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtRecMsg;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_VoicePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_combine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_VoiceCombine;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel_sample;
        private System.Windows.Forms.ProgressBar prb_volume;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label message_bar;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.Timer tmr_Cmd;
        private System.Windows.Forms.Timer tmr_Report;
        private System.Windows.Forms.Button btn_Report;
        private System.Windows.Forms.Button btn_GetCmd;
        private System.Windows.Forms.Timer tmr_listen;
        private System.Windows.Forms.Button btn_Liten;
        private System.Windows.Forms.Panel pan_chanel2;
        private System.Windows.Forms.Panel pan_chanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}