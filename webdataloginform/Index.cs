using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VUT_index
{
    public partial class Index : Form
    {
        int numRows = 0;
        bool status;
        bool partition;
        string[,] pole = new string[99, 12];
        string[,] temp = new string[99, 12];
        string[] change = new string[12];
        private string[] years = new String[9];
        private string lastYear = "";
        public static string creditsDoc = "";

        public Index()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;

            webBrowser.ScriptErrorsSuppressed = true;
            btn_login.Enabled = true;
            btn_logout.Enabled = false;
            btn_refresh.Enabled = false;
            btn_credits.Enabled = false;
            partition = false;
            status = false;

            ObjectCenter();

            cb_refresh.SelectedItem = "1min";
            cb_Year.SelectedItem = "2015/2016";
            timer.Stop();

            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            notifyIcon.ContextMenuStrip = contextMenuStrip1;

            chb_mailRemember.Checked = false;
            chb_loginRemember.Checked = false;

            if(File.Exists("data.dll"))
            {
                try
                {
                    using(StreamReader sr = new StreamReader("data.dll"))
                    {
                        string line = "";
                        line = sr.ReadLine();
                        tb_login.Text = line;
                        line = sr.ReadLine();
                        tb_password.Text = line;
                        line = sr.ReadLine();
                        if(line == "True")
                        {
                            chb_loginRemember.Checked = true;
                        }

                        line = sr.ReadLine();
                        tb_mail.Text = line;

                        line = sr.ReadLine();
                        if (line == "True")
                        {
                            chb_mail.Checked = true;
                            chb_mailRemember.Checked = true;
                        }
                    }
                }
                catch(Exception)
                {

                    //throw;
                }
            }
        }

        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

       
        private void Navigate(string url)
        {
            webBrowser.Navigate(url);
            while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Zmaze udaje z tabulky (DGV)
        /// </summary>
        private void EraseArray()
        {
            for(int n = numRows - 1; n >= 0; n--)
            {
                DGV_index.Rows.RemoveAt(n);
            }
            numRows = 0;
        }

        /// <summary>
        /// Naplni tabulku (DGV)
        /// </summary>
        /// <param name="pole">Obsah tabulky</param>
        /// <param name="length">Pocet riadkov</param>
        private void FillArray(string[,] pole, int length)
        {
            if(numRows != 0)
            {
                EraseArray();
            }

            //Naplni DGV
            for(int i = 0; i < length; i++)
            {
                string[] rowCont = { pole[i, 0], pole[i, 1], pole[i, 2], pole[i, 3], pole[i, 4], pole[i, 5], pole[i, 7].Length > 3 ? pole[i, 7].Substring(0, 3):pole[i,7], pole[i, 8], pole[i, 9].Length > 1 ? pole[i, 9].Substring(0, 1):pole[i, 9], pole[i, 11] };
                DGV_index.Rows.Add(rowCont);
                numRows++;
            }

            ObjectCenter();
        }

        /// <summary>
        /// Parsuje HTML kód a ukladá do pola
        /// </summary>
        private void ParseData(string year)
        {
            int tmp = 0;

            string browserContents = webBrowser.DocumentText;
            if(browserContents == "") return;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            //Parsovanie tabulky indexu do query
            doc.LoadHtml(browserContents);

            var query = from table in doc.DocumentNode.SelectNodes("//table")
                        from row in table.SelectNodes("tr")
                        from cell in row.SelectNodes("th|td")
                        select new { Table = table.Id, CellText = cell.InnerText };

            Regex regex = new Regex("(B|J|K|M|X)[A-Z0-9]{3}");

            int length = 0;

            foreach(var cell in query)
            {
                Match match = regex.Match(Convert.ToString(cell.CellText));
                if(match.Success)
                {
                    length++;
                }

                if(cell.CellText == "Akademický rok: " + year)
                {
                    break;
                }
            }


            int line = 0;
            int col = 0;
            int identity = -1;

            foreach(var cell in query)
            {
                Match match = regex.Match(Convert.ToString(cell.CellText));
                if(match.Success)
                {
                    identity++;
                    col = 0;
                    line = identity;
                }

                if((identity != -1) && (col <= 11) && (line < length))
                {
                    temp[line, col] = Convert.ToString(cell.CellText);

                    if(temp[line, col].Contains("&nbsp;"))
                    {
                        temp[line, col] = temp[line, col].Replace("&nbsp;", "");
                    }
                    col++;
                }

            }


            if(!partition || !lastYear.Equals(year))
            {
                for(int m = 0; m < length; m++)
                {
                    for(int n = 0; n <= 11; n++)
                    {
                        pole[m, n] = temp[m, n];
                    }
                }
                partition = true;
            }
            else
            {
                var equal =
                    pole.Rank == temp.Rank &&
                        Enumerable.Range(0, pole.Rank).All(dimension => pole.GetLength(dimension) == temp.GetLength(dimension)) &&
                        pole.Cast<string>().SequenceEqual(temp.Cast<string>());
                if(!equal)
                {
                    for(int m = 0; m < length; m++)
                    {
                        for(int n = 0; n <= 11; n++)
                        {
                            if(string.CompareOrdinal(pole[m, n], temp[m, n]) != 0)
                            {
                                tmp = m;
                                for(int k = 0; k <= 11; k++)
                                {
                                    change[k] = temp[m, k];
                                }

                                break;
                            }
                        }
                    }

                    string msg = null;

                    if(change[7].Contains("ano") && (pole[tmp, 7].Contains("ne") || pole[tmp, 7].Contains("nie")) && (string.CompareOrdinal(change[8], pole[tmp, 8]) != 0))
                    {
                        msg = $"Získal si zápočet z {change[0]} - {change[8]}";
                    }
                    else if(change[7].Contains("ano") && (pole[tmp, 7].Contains("ne") || pole[tmp, 7].Contains("nie")))
                    {
                        msg = $"Získal si zápočet z {change[0]}";
                    }
                    else
                    {
                        change[9] = change[9].Length > 1 ? change[9].Substring(0, 1) : change[9];
                        msg = $"Update: {change[0]} - {change[8]} - {change[9]}";
                    }

                    for(int m = 0; m < length; m++)
                    {
                        for(int n = 0; n <= 11; n++)
                        {
                            pole[m, n] = temp[m, n];
                        }
                    }


                    if(WindowState == FormWindowState.Minimized)
                    {
                        notifyIcon.BalloonTipText = msg;
                        notifyIcon.ShowBalloonTip(3000);
                    }


                    if(chb_mail.Checked)
                    {
                        SendMail(msg);
                    }
                    MessageBox.Show(msg);

                }
            }

            FillArray(pole, length);
        }


        private void button_login(object sender, EventArgs e)
        {
            SendMail("Test");
            if ((tb_login.Text.Length <= 0) || (tb_password.Text.Length <= 0))
            {
                MessageBox.Show(@"Ty nevidíš?!, nevyplnil si meno alebo heslo!");
            }
            else
            {
                Navigate("https://www.vutbr.cz/login/");


                if (webBrowser.Document == null) return;
                webBrowser.Document.GetElementById("LDAPlogin").InnerText = tb_login.Text;
                webBrowser.Document.GetElementById("LDAPpasswd").InnerText = tb_password.Text;
                webBrowser.Document.GetElementById("login").InvokeMember("click");

                Thread.Sleep(500);
                //Wait();
                
                Navigate("https://www.vutbr.cz/studis/student.phtml?sn=kontrola_predmetu");
                creditsDoc = webBrowser.DocumentText;
                Wait();

                Navigate("https://www.vutbr.cz/studis/student.phtml?sn=el_index");

                //Thread.Sleep(500);
                Wait();

                // Kontrola či prihlásenie prebehlo úspešne
                HtmlElementCollection elems = webBrowser.Document.GetElementsByTagName("title");
                foreach (HtmlElement elem in elems)
                {
                    if (elem.OuterText != "Elektronický index")
                    {
                        MessageBox.Show(@"Niečo si posral, asi zlé meno alebo heslo!");
                    }
                    else
                    {
                        //if((chb_loginRemember.Checked && tb_login.Text != "" && tb_password.Text != "") || (chb_mailRemember.Checked && tb_mail.Text != "" && MailValid(tb_mail.Text)))
                        //{
                            if(!File.Exists("data.dll"))
                            {
                                var fileCreateHandler = File.Create("data.dll");
                                fileCreateHandler.Close();
                            }
                            try
                            {
                                using(StreamWriter sw = new StreamWriter("data.dll"))
                                {
                                    if(chb_loginRemember.Checked)
                                    {
                                        sw.WriteLine(tb_login.Text);
                                        sw.WriteLine(tb_password.Text);
                                    }
                                    else
                                    {
                                        sw.WriteLine("");
                                        sw.WriteLine("");
                                    }
                                    sw.WriteLine(chb_loginRemember.Checked);

                                    if(chb_mailRemember.Checked)
                                    {
                                        sw.WriteLine(tb_mail.Text);
                                    }
                                    else
                                    {
                                        sw.WriteLine("");
                                    }
                                    sw.WriteLine(chb_mailRemember.Checked);
                                }
                            }
                            catch(Exception)
                            {
                                //throw;
                            }
                        //}

                        // Naplnenie comboboxu pre vyplnenie zmeny roku
                        int i = 0;               
                        HtmlElementCollection links = webBrowser.Document.GetElementsByTagName("td");
                        foreach(HtmlElement curElement in links)
                        {
                            if(curElement.GetAttribute("InnerText").Contains("Akademický rok:"))
                            {
                                years[i++] =
                                    curElement.GetAttribute("InnerText").Substring("Akademický rok: ".Length, 9);
                            }
                        }
                        for (i = 0; i < years.Length; i++)
                        {
                            if(years[i] != null)
                            {
                                cb_Year.Items.Add(years[i]);
                            }
                        }
                        cb_Year.SelectedIndex = 0;

                        status = true;
                        btn_login.Enabled = false;
                        btn_logout.Enabled = true;
                        btn_refresh.Enabled = true;
                        btn_credits.Enabled = true;
                        timer.Start();
                        lb_status.Text = @"Online";
                        string item = cb_Year.GetItemText(cb_Year.SelectedItem);
                        lastYear = yearFix(item);
                        ParseData(yearFix(item));
                    }
                }
            }
        }

        private void button_refresh(object sender, EventArgs e)
        {
            if (!status || !CheckForInternetConnection()) return;
            Navigate("https://www.vutbr.cz/studis/student.phtml?sn=el_index");
            string item = cb_Year.GetItemText(cb_Year.SelectedItem);
            lastYear = yearFix(item);
            ParseData(yearFix(item));
        }


        private void button_logout(object sender, EventArgs e)
        {
            Navigate("https://www.vutbr.cz/login/out");
            EraseArray();
            btn_login.Enabled = true;
            btn_logout.Enabled = false;
            btn_refresh.Enabled = false;
            timer.Stop();
            status = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!CheckForInternetConnection())
            {
                status = false;
                lb_status.Text = @"Offline";
            }

            if (!status && CheckForInternetConnection())
            {
                status = true;
                lb_status.Text = @"Online";
            }

            if (status && CheckForInternetConnection())
            {
                Navigate("https://www.vutbr.cz/studis/student.phtml?sn=el_index");
                string item = cb_Year.GetItemText(cb_Year.SelectedItem);
                lastYear = yearFix(item);
                ParseData(yearFix(item));
            }
    
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            if(WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Activate();

            notifyIcon.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }

            ObjectCenter();

        }

        private void cb_Year_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string item = cb_Year.GetItemText(cb_Year.SelectedItem);
            ParseData(yearFix(item));
        }

        private void cb_refresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cb_refresh.GetItemText(cb_refresh.SelectedItem);

            switch (item)
            {
                case "30sec":
                    timer.Interval = 30000;
                    break;
                case "1min":
                    timer.Interval = 60000;
                    break;
                case "5min":
                    timer.Interval = 300000;
                    break;
                case "10min":
                    timer.Interval = 600000;
                    break;
                case "30min":
                    timer.Interval = 1800000;
                    break;
                case "59min":
                    timer.Interval = 3540000;
                    break;
                default:
                    timer.Interval = 60000;
                    break;
            }
        }

        private string yearFix(string item)
        {
            string message = "";
            switch(item)
            {
                case "2017/2018":
                    message = "2016/2017";
                    break;
                case "2016/2017":
                    message = "2015/2016";
                    break;
                case "2015/2016":
                    message = "2014/2015";
                    break;
                case "2014/2015":
                    message = "2013/2014";
                    break;
                case "2013/2014":
                    message = "2012/2013";
                    break;
                case "2012/2013":
                    message = "2011/2012";
                    break;
                case "2011/2012":
                    message = "2010/2011";
                    break;
                default:
                    message = "2015/2016";
                    break;
            }
            return message;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            HtmlElementCollection elems = webBrowser.Document.GetElementsByTagName("title");
            foreach (HtmlElement elem in elems)
            {
                if ((elem.OuterText != "Vysoké učení technické v Brně") || !status) continue;
                EraseArray();
                btn_login.Enabled = true;
                btn_logout.Enabled = false;
                btn_refresh.Enabled = false;
                timer.Stop();
                status = false;
            }
        }


        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Suspend:
                    timer.Stop();
                    status = false;
                    break;
                case PowerModes.Resume:
                    btn_refresh.PerformClick();
                    Wait();
                    HtmlElementCollection elems = webBrowser.Document.GetElementsByTagName("title");
                    foreach (HtmlElement elem in elems)
                    {
                        if (elem.OuterText != "Elektronický index")
                        {
                            btn_logout.PerformClick();
                            Wait();
                            btn_login.PerformClick();
                        }
                        else
                        {
                            timer.Start();
                            status = true;
                        }
                    }

                    break;
                case PowerModes.StatusChange:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ObjectCenter()
        {
            DGV_index.SuspendLayout();
            int controlBorderWidth = (DGV_index.BorderStyle == BorderStyle.None) ? 0 : 2;
            DGV_index.Width = DGV_index.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + DGV_index.RowHeadersWidth + controlBorderWidth;
            DGV_index.Left = (ClientSize.Width - DGV_index.Width)/2;
            DGV_index.ResumeLayout();

            webBrowser.SuspendLayout();
            webBrowser.Left = (ClientSize.Width - webBrowser.Width)/2; 
            webBrowser.ResumeLayout();

            gb_menu.SuspendLayout();
            gb_menu.Left = (ClientSize.Width - gb_menu.Width) / 2;
            gb_menu.ResumeLayout();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == Convert.ToString("Show"))
            {
                Show();
                if (WindowState == FormWindowState.Minimized)
                    WindowState = FormWindowState.Normal;
                Activate();

                notifyIcon.Visible = false;
            }
            else if (e.ClickedItem.Text == Convert.ToString("Logout"))
            {
                Navigate("https://www.vutbr.cz/login/out");
                EraseArray();
                btn_login.Enabled = true;
                btn_logout.Enabled = false;
                btn_refresh.Enabled = false;
                timer.Stop();
                status = false;
            }
            else if (e.ClickedItem.Text == Convert.ToString("Exit"))
            {
                Application.Exit();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!status)
            {
                contextMenuStrip1.Items[1].Visible = false;
            }
            else
            {
                contextMenuStrip1.Items[1].Visible = true;
            }
        }

        private void SendMail(string message)
        {
            /*MailMessage msg = new MailMessage();
            msg.From = new MailAddress("donotreply@gmail.com");
            if (tb_mail.Text == "" || !MailValid(tb_mail.Text)) return;
            msg.To.Add(tb_mail.Text);
            msg.Subject = "VUT Index";
            msg.Body = message + "\n" + DateTime.Now;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("mail", "pass");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                //MessageBox.Show("Mail has been successfully sent!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"Fail Has error: " + ex.Message);
            }
            finally
            {
                msg.Dispose();
            }*/
        }

        private bool MailValid(string emailaddress)
        {
            try
            {
                new MailAddress(emailaddress);

                return true;
            }
            catch(FormatException)
            {
                return false;
            }
        }

        private void Wait()
        {
            while(webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }

        private void btn_credits_Click(object sender, EventArgs e)
        {
            new Thread(() => new Credits().ShowDialog()).Start();
            //Credits credis = new Credits();
            //credis.ShowDialog();
        }
    }
}
