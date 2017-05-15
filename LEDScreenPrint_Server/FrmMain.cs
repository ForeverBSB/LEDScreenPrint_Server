using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace LEDScreenPrint_Server
{
    public partial class FrmMain : Form
    {

        private int screenHeight;
        private int screenWidth;
        private String configFilePath;
        private DateTime createDate;
        private DateTime fightDate;
        private TimeSpan DateDiff;
        private System.Windows.Forms.Timer mainTimer;
        private String socketIPAddress;
        private int socketPort;
        private Socket socketServer;
        private static List<Socket> clientSockets = new List<Socket>();

        public FrmMain()
        {
            InitializeComponent();
            //获取Ini配置文件绝对路径
            configFilePath = System.Windows.Forms.Application.StartupPath + "\\Config.ini";
            //获取屏幕高度
            screenHeight = Convert.ToInt32(ConfigHelper.ReadIniData("Screen", "ScreenHeight", "300", configFilePath));
            //获取屏幕宽度
            screenWidth = Convert.ToInt32(ConfigHelper.ReadIniData("Screen", "ScreenWidth", Screen.PrimaryScreen.Bounds.Width.ToString(), configFilePath));
            //设定窗体宽度为设置宽度
            this.Width = screenWidth;
            //设定窗体高度为设置高度
            this.Height = screenHeight;
            //设定窗体位置为屏幕顶部
            this.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Screen", "LocationX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Screen", "LocationY", "0", configFilePath)));
            //获取Server服务IP地址
            socketIPAddress = ConfigHelper.ReadIniData("Setting", "ServerIP", "127.0.0.1", configFilePath);
            //获取Server服务端口号
            socketPort = Convert.ToInt32(ConfigHelper.ReadIniData("Setting", "ServerPort", "8888", configFilePath));
            //获取程序生成时间
            createDate = new FileInfo(System.Windows.Forms.Application.ExecutablePath).CreationTime;
            //获取并计算作战时间
            DateTime setNowDate = Convert.ToDateTime(ConfigHelper.ReadIniData("FightTimeSetting", "SettingNowDate", DateTime.Now.ToString(), configFilePath));
            DateDiff = DateTime.Now.Subtract(setNowDate);
            fightDate = new DateTime(Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightYear", DateTime.Now.ToString("yyyy"), configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightMonth", DateTime.Now.ToString("MM"), configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightDay", DateTime.Now.ToString("dd"), configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightHour", DateTime.Now.ToString("HH"), configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightMinute", DateTime.Now.ToString("mm"), configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightSecond", DateTime.Now.ToString("ss"), configFilePath)));
            fightDate = fightDate.Add(DateDiff);
            //初始化Timer
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 1000;
            mainTimer.Start();
            mainTimer.Tick += MainTimer_Tick; ;
            Control.CheckForIllegalCrossThreadCalls = false;
            //初始化服务器
            initSocket();
            //初始化各控件位置
            getLocationSetting();
            //初始化各空间字号
            getFrontSizeSetting();
            //初始化标题文字
            getTitleSetting();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Compare(DateTime.Now, createDate.AddDays(30)) > 0)
            {
                mainTimer.Stop();
                MessageBox.Show("试用到期");
                Application.Exit();
            }
            labelNowDate.Text = DateTime.Now.ToString("yyyy") + "年" + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日";
            labelNowWeek.Text = DateTime.Now.ToString("dddd");
            labelNowTime.Text = DateTime.Now.ToString("HH") + "时" + DateTime.Now.ToString("mm") + "分" + DateTime.Now.ToString("ss") + "秒";
            fightDate = fightDate.AddSeconds(1);
            labelFightDate.Text = fightDate.ToString("yyyy") + "年" + fightDate.ToString("MM") + "月" + fightDate.ToString("dd") + "日";
            labelFightWeek.Text = fightDate.ToString("dddd");
            labelFightTime.Text = fightDate.ToString("HH") + "时" + fightDate.ToString("mm") + "分" + fightDate.ToString("ss") + "秒";

        }

        private void getLocationSetting()
        {
            //获取并设置天文时间文字位置
            labelNow.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowY", "0", configFilePath)));
            //获取并设置天文时间日期文字位置
            labelNowDate.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowDateX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowDateY", "0", configFilePath)));
            //获取并设置天文时间星期文字位置
            labelNowWeek.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowWeekX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowWeekY", "0", configFilePath)));
            //获取并设置天文时间时间文字位置
            labelNowTime.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowTimeX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "NowTimeY", "0", configFilePath)));
            //获取并设置标题文字位置
            labelTitle.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "TitleX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "TitleY", "0", configFilePath)));
            //获取并设置作战时间文字位置
            labelFight.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightY", "0", configFilePath)));
            //获取并设置作战时间日期文字位置
            labelFightDate.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightDateX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightDateY", "0", configFilePath)));
            //获取并设置作战时间星期文字位置
            labelFightWeek.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightWeekX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightWeekY", "0", configFilePath)));
            //获取并设置作战时间时间文字位置
            labelFightTime.Location = new Point(Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightTimeX", "0", configFilePath)),
                Convert.ToInt32(ConfigHelper.ReadIniData("Location", "FightTimeY", "0", configFilePath)));
        }

        private void getFrontSizeSetting()
        {
            //获取并设置天文时间字号
            labelNow.Font = new Font(new FontFamily(this.labelNow.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "NowSize", "9", configFilePath)));
            labelNowDate.Font = new Font(new FontFamily(this.labelNowDate.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "NowDateSize", "9", configFilePath)));
            labelNowWeek.Font = new Font(new FontFamily(this.labelNowWeek.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "NowWeekSize", "9", configFilePath)));
            labelNowTime.Font = new Font(new FontFamily(this.labelNowTime.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "NowTimeSize", "9", configFilePath)));
            labelFight.Font = new Font(new FontFamily(this.labelFight.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "FightSize", "9", configFilePath)));
            labelFightDate.Font = new Font(new FontFamily(this.labelFightDate.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "FightDateSize", "9", configFilePath)));
            labelFightWeek.Font = new Font(new FontFamily(this.labelFightWeek.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "FightWeekSize", "9", configFilePath)));
            labelFightTime.Font = new Font(new FontFamily(this.labelFightTime.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "FightTimeSize", "9", configFilePath)));
            labelTitle.Font = new Font(new FontFamily(this.labelTitle.Font.Name),
                float.Parse(ConfigHelper.ReadIniData("FrontSize", "TitleSize", "9", configFilePath)));
        }

        private void getTitleSetting()
        {
            labelTitle.Text = ConfigHelper.ReadIniData("Title", "Title", "", configFilePath);
        }
        private void initSocket()
        {
            try
            {
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketServer.Bind(new IPEndPoint(IPAddress.Parse(socketIPAddress), socketPort));
                socketServer.Listen(0);
                Thread socketThread = new Thread(ListenClientConnect);
                socketThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = socketServer.Accept();
                if (clientSocket.Connected)
                {

                    Thread receiveThread = new Thread(ReceiveMessage);
                    receiveThread.Start(clientSocket);
                }
            }
        }

        private void ReceiveMessage(object clientSocket)
        {
            Socket client = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    byte[] socketResult = new byte[1024];
                    //通过ClientSocket接收数据
                    int receiveNumber = client.Receive(socketResult);
                    string result = Encoding.UTF8.GetString(socketResult, 0, receiveNumber);
                    
                    if (result != null && result.Length > 0)
                    {
                        String[] setting = result.Split('|');
                        switch (setting[0])
                        {
                            case "NowX":
                                ConfigHelper.WriteIniData("Location", "NowX", setting[1], configFilePath);
                                labelNow.Location = new Point(Convert.ToInt32(setting[1]), labelNow.Location.Y);
                                break;
                            case "NowDateX":
                                ConfigHelper.WriteIniData("Location", "NowDateX", setting[1], configFilePath);
                                labelNowDate.Location = new Point(Convert.ToInt32(setting[1]), labelNowDate.Location.Y);
                                break;
                            case "NowWeekX":
                                ConfigHelper.WriteIniData("Location", "NowWeekX", setting[1], configFilePath);
                                labelNowWeek.Location = new Point(Convert.ToInt32(setting[1]), labelNowWeek.Location.Y);
                                break;
                            case "NowTimeX":
                                ConfigHelper.WriteIniData("Location", "NowTimeX", setting[1], configFilePath);
                                labelNowTime.Location = new Point(Convert.ToInt32(setting[1]), labelNowTime.Location.Y);
                                break;
                            case "FightX":
                                ConfigHelper.WriteIniData("Location", "FightX", setting[1], configFilePath);
                                labelFight.Location = new Point(Convert.ToInt32(setting[1]), labelFight.Location.Y);
                                break;
                            case "FightDateX":
                                ConfigHelper.WriteIniData("Location", "FightDateX", setting[1], configFilePath);
                                labelFightDate.Location = new Point(Convert.ToInt32(setting[1]), labelFightDate.Location.Y);
                                break;
                            case "FightWeekX":
                                ConfigHelper.WriteIniData("Location", "FightWeekX", setting[1], configFilePath);
                                labelFightWeek.Location = new Point(Convert.ToInt32(setting[1]), labelFightWeek.Location.Y);
                                break;
                            case "FightTimeX":
                                ConfigHelper.WriteIniData("Location", "FightTimeX", setting[1], configFilePath);
                                labelFightTime.Location = new Point(Convert.ToInt32(setting[1]), labelFightTime.Location.Y);
                                break;
                            case "TitleX":
                                ConfigHelper.WriteIniData("Location", "TitleX", setting[1], configFilePath);
                                labelTitle.Location = new Point(Convert.ToInt32(setting[1]), labelTitle.Location.Y);
                                break;
                            case "NowY":
                                ConfigHelper.WriteIniData("Location", "NowY", setting[1], configFilePath);
                                labelNow.Location = new Point(labelNow.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "NowDateY":
                                ConfigHelper.WriteIniData("Location", "NowDateY", setting[1], configFilePath);
                                labelNowDate.Location = new Point(labelNowDate.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "NowWeekY":
                                ConfigHelper.WriteIniData("Location", "NowWeekY", setting[1], configFilePath);
                                labelNowWeek.Location = new Point(labelNowWeek.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "NowTimeY":
                                ConfigHelper.WriteIniData("Location", "NowTimeY", setting[1], configFilePath);
                                labelNowTime.Location = new Point(labelNowTime.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "FightY":
                                ConfigHelper.WriteIniData("Location", "FightY", setting[1], configFilePath);
                                labelFight.Location = new Point(labelFight.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "FightDateY":
                                ConfigHelper.WriteIniData("Location", "FightDateY", setting[1], configFilePath);
                                labelFightDate.Location = new Point(labelFightDate.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "FightWeekY":
                                ConfigHelper.WriteIniData("Location", "FightWeekY", setting[1], configFilePath);
                                labelFightWeek.Location = new Point(labelFightWeek.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "FightTimeY":
                                ConfigHelper.WriteIniData("Location", "FightTimeY", setting[1], configFilePath);
                                labelFightTime.Location = new Point(labelFightTime.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "TitleY":
                                ConfigHelper.WriteIniData("Location", "TitleY", setting[1], configFilePath);
                                labelTitle.Location = new Point(labelTitle.Location.X, Convert.ToInt32(setting[1]));
                                break;
                            case "NowSize":
                                ConfigHelper.WriteIniData("FrontSize", "NowSize", setting[1], configFilePath);
                                labelNow.Font = new Font(new FontFamily(this.labelNow.Font.Name), float.Parse(setting[1]));
                                break;
                            case "NowDateSize":
                                ConfigHelper.WriteIniData("FrontSize", "NowDateSize", setting[1], configFilePath);
                                labelNowDate.Font = new Font(new FontFamily(this.labelNowDate.Font.Name), float.Parse(setting[1]));
                                break;
                            case "NowWeekSize":
                                ConfigHelper.WriteIniData("FrontSize", "NowWeekSize", setting[1], configFilePath);
                                labelNowWeek.Font = new Font(new FontFamily(this.labelNowWeek.Font.Name), float.Parse(setting[1]));
                                break;
                            case "NowTimeSize":
                                ConfigHelper.WriteIniData("FrontSize", "NowTimeSize", setting[1], configFilePath);
                                labelNowTime.Font = new Font(new FontFamily(this.labelNowTime.Font.Name), float.Parse(setting[1]));
                                break;
                            case "FightSize":
                                ConfigHelper.WriteIniData("FrontSize", "FightSize", setting[1], configFilePath);
                                labelFight.Font = new Font(new FontFamily(this.labelFight.Font.Name), float.Parse(setting[1]));
                                break;
                            case "FightDateSize":
                                ConfigHelper.WriteIniData("FrontSize", "FightDateSize", setting[1], configFilePath);
                                labelFightDate.Font = new Font(new FontFamily(this.labelFightDate.Font.Name), float.Parse(setting[1]));
                                break;
                            case "FightWeekSize":
                                ConfigHelper.WriteIniData("FrontSize", "FightWeekSize", setting[1], configFilePath);
                                labelFightWeek.Font = new Font(new FontFamily(this.labelFightWeek.Font.Name), float.Parse(setting[1]));
                                break;
                            case "FightTimeSize":
                                ConfigHelper.WriteIniData("FrontSize", "FightTimeSize", setting[1], configFilePath);
                                labelFightTime.Font = new Font(new FontFamily(this.labelFightTime.Font.Name), float.Parse(setting[1]));
                                break;
                            case "TitleSize":
                                ConfigHelper.WriteIniData("FrontSize", "TitleSize", setting[1], configFilePath);
                                labelTitle.Font = new Font(new FontFamily(this.labelTitle.Font.Name), float.Parse(setting[1]));
                                break;
                            case "Title":
                                ConfigHelper.WriteIniData("Title", "Title", setting[1], configFilePath);
                                labelTitle.Text = setting[1];
                                break;
                            case "ScreenHeight":
                                ConfigHelper.WriteIniData("Screen", "ScreenHeight", setting[1], configFilePath);
                                this.Height = int.Parse(setting[1]);
                                break;
                            case "FightTimeYear":
                                ConfigHelper.WriteIniData("FightTimeSetting", "FightTimeYear", setting[1], configFilePath);
                                break;
                            case "FightTimeMonth":
                                ConfigHelper.WriteIniData("FightTimeSetting", "FightTimeMonth", setting[1], configFilePath);
                                break;
                            case "FightTimeDay":
                                ConfigHelper.WriteIniData("FightTimeSetting", "FightTimeDay", setting[1], configFilePath);
                                break;
                            case "FightTimeHour":
                                ConfigHelper.WriteIniData("FightTimeSetting", "FightTimeHour", setting[1], configFilePath);
                                break;
                            case "FightTimeMinute":
                                ConfigHelper.WriteIniData("FightTimeSetting", "FightTimeMinute", setting[1], configFilePath);
                                break;
                            case "FightTimeSecond":
                                ConfigHelper.WriteIniData("FightTimeSetting", "FightTimeSecond", setting[1], configFilePath);
                                break;
                            case "SyncFightTime":
                                String nowDate = setting[1];
                                ConfigHelper.WriteIniData("FightTimeSetting", "SettingNowDate", nowDate, configFilePath);
                                DateDiff = DateTime.Now.Subtract(Convert.ToDateTime(nowDate));
                                fightDate = new DateTime(Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightTimeYear", DateTime.Now.ToString("yyyy"), configFilePath)),
                                    Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightTimeMonth", DateTime.Now.ToString("MM"), configFilePath)),
                                    Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightTimeDay", DateTime.Now.ToString("dd"), configFilePath)),
                                    Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightTimeHour", DateTime.Now.ToString("HH"), configFilePath)),
                                    Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightTimeMinute", DateTime.Now.ToString("mm"), configFilePath)),
                                    Convert.ToInt32(ConfigHelper.ReadIniData("FightTimeSetting", "FightTimeSecond", DateTime.Now.ToString("ss"), configFilePath)));
                                fightDate = fightDate.Add(DateDiff);
                                break;
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    break;
                }
            }
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出软件?", "提示信息",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
