using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VUT_index
{
    public partial class Credits : Form
    {
        private struct creditNumbers
        {
            public int min { get; set; }
            public int passed { get; set; }
            public int reg { get; set; }

            public creditNumbers(int p1, int p2, int p3)
            {
                min = p1;
                passed = p2;
                reg = p3;
            }
        };

        private creditNumbers compulsory = new creditNumbers(0, 0, 0);
        private creditNumbers specialized = new creditNumbers(0, 0, 0);
        private creditNumbers interdisciplinary = new creditNumbers(0, 0, 0);
        private creditNumbers knowledge = new creditNumbers(0, 0, 0);
        private creditNumbers theoretical = new creditNumbers(0, 0, 0);
        private creditNumbers total = new creditNumbers(0, 0, 0);

        private int endTable = 0;

        private List<Courses> courseList = new List<Courses>();
        private List<bool> readedValue = new List<bool>();
        public Credits()
        {
            InitializeComponent();
            LoadCredits();
            ParseCredit();
        }

        private void ParseCredit()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(Index.creditsDoc);

            var query = from table in doc.DocumentNode.SelectNodes("//table")
                        from row in table.SelectNodes("tr")
                        from cell in row.SelectNodes("th|td")
                        select new { Table = table.Id, CellText = cell.InnerText };

            Regex regexCourse = new Regex("(B|J|K|M|X)[A-Z0-9]{3}");

            int identity = 0, col = 0, line = 0, length = 0;
            string[] courses = new string[8];

            foreach(var cell in query)
            {
                Match match = regexCourse.Match(Convert.ToString(cell.CellText));
                if(match.Success)
                    length++;
            }

            Regex regexCourses = new Regex("(A|Z|N){1}");

            int i = 0;
            int tmp = 0;
            foreach(var cell in query)
            {
                tmp++;
                if(cell.CellText.Contains("Všechny skupiny volitelných předmětů"))
                {
                    endTable = tmp;
                }

                Match match = regexCourses.Match(Convert.ToString(cell.CellText));

                if(match.Success && cell.CellText.Length == 1)
                {
                    col = 0;
                    line = identity++;
                }

                if((identity != 0) && (col < 8) && (line < length))
                {
                    courses[col++] = Convert.ToString(cell.CellText);
                    if(col == 8)
                    {
                        if(courseList.Find(x => x.Acronym.Contains(courses[1])) != null)
                            continue;

                        courseList.Add(new Courses
                        {
                            Status = courses[0],
                            Acronym = courses[1],
                            Name = courses[2],
                            Credits = Regex.Match(courses[3], @"\d+").Value,
                            Semester = courses[4],
                            Compulsory = courses[5],
                            Enroll = courses[0].Contains("A") || courses[0].Contains("Z") || courses[0].Contains("U") //|| courses[5].Contains("P")
                        }
                        );

                        if(chb_readTable.Checked && i < readedValue.Count)
                        {
                            courseList.Last().Enroll = readedValue.ElementAt(i);
                        }
                        i++;

                        if(courseList.Last().Compulsory == "P")
                        {
                            compulsory.min += Convert.ToInt16(courseList.Last().Credits);

                            switch(courseList.Last().Status)
                            {
                                case "A":
                                    compulsory.passed += Convert.ToInt16(courseList.Last().Credits);
                                    break;
                            }
                        }
                    }
                }
            }

            DGV_courses.DataSource = courseList;

            DGV_courses.AutoResizeColumns();
            DGV_courses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DGV_courses.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_courses.Columns[0].HeaderText = "Status";
            DGV_courses.Columns[1].HeaderText = "Acronym";
            DGV_courses.Columns[2].HeaderText = "Name";
            DGV_courses.Columns[3].HeaderText = "Credits";
            DGV_courses.Columns[4].HeaderText = "Semester";
            DGV_courses.Columns[5].HeaderText = "Compulsory";
            DGV_courses.Columns[6].HeaderText = "Enroll";

            foreach(DataGridViewColumn dc in DGV_courses.Columns)
            {
                dc.ReadOnly = !dc.Index.Equals(6);
            }


            foreach(DataGridViewRow row in DGV_courses.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Enroll"];

                chk.TrueValue = true;
                chk.FalseValue = false;

                if(chk.Value == null)
                {
                    chk.Value = chk.FalseValue;
                }

            }


            /*for(int i = 0; i < DGV_courses.Columns.Count - 1; i++)
            {
                DGV_courses.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            DGV_courses.Columns[DGV_courses.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for(int i = 0; i < DGV_courses.Columns.Count; i++)
            {
                int colw = DGV_courses.Columns[i].Width;
                DGV_courses.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                DGV_courses.Columns[i].Width = colw;
            }*/


            DGV_courses.SuspendLayout();
            int controlBorderWidth = (DGV_courses.BorderStyle == BorderStyle.None) ? 0 : 2;
            DGV_courses.Width = DGV_courses.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + DGV_courses.RowHeadersWidth + controlBorderWidth;
            //DGV_courses.Left = (ClientSize.Width - DGV_courses.Width) / 2;
            DGV_courses.ResumeLayout();

            for(int idx = endTable; idx < query.Count(); idx++)
            {
                if(query.ElementAt(idx).CellText.ToString() == "VO" &&
                   query.ElementAt(idx+1).CellText.ToString() == "Volitelný oborový")
                {
                    specialized.min = Convert.ToInt16(query.ElementAt(idx + 2).CellText.ToString());
                    specialized.passed = Convert.ToInt16(query.ElementAt(idx + 3).CellText.ToString());
                    //specialized.reg = Convert.ToInt16(query.ElementAt(idx + 4).CellText.ToString());
                }

                if(query.ElementAt(idx).CellText.ToString() == "VM" &&
                   query.ElementAt(idx + 1).CellText.ToString() == "Volitelný mimooborový")
                {
                    interdisciplinary.min = Convert.ToInt16(query.ElementAt(idx + 2).CellText.ToString());
                    interdisciplinary.passed = Convert.ToInt16(query.ElementAt(idx + 3).CellText.ToString());
                    //interdisciplinary.reg = Convert.ToInt16(query.ElementAt(idx + 4).CellText.ToString());
                }

                if(query.ElementAt(idx).CellText.ToString() == "VV" &&
                   query.ElementAt(idx + 1).CellText.ToString() == "Volitelný všeobecný")
                {
                    knowledge.min = Convert.ToInt16(query.ElementAt(idx + 2).CellText.ToString());
                    knowledge.passed = Convert.ToInt16(query.ElementAt(idx + 3).CellText.ToString());
                    //knowledge.reg = Convert.ToInt16(query.ElementAt(idx + 4).CellText.ToString());
                }

                if(query.ElementAt(idx).CellText.ToString() == "TN" &&
                   query.ElementAt(idx + 1).CellText.ToString() == "Teoretická nadstavba")
                {
                    theoretical.min = Convert.ToInt16(query.ElementAt(idx + 2).CellText.ToString());
                    theoretical.passed = Convert.ToInt16(query.ElementAt(idx + 3).CellText.ToString());
                    //theoretical.reg = Convert.ToInt16(query.ElementAt(idx + 4).CellText.ToString());
                }

                if(query.ElementAt(idx).CellText.ToString() == "Splnění minimálního počtu kreditů")
                {
                    total.min = Convert.ToInt16(query.ElementAt(idx + 1).CellText.ToString());
                    total.passed = Convert.ToInt16(query.ElementAt(idx + 2).CellText.ToString());
                    //total.reg = Convert.ToInt16(query.ElementAt(idx + 3).CellText.ToString());
                }
            }

            CountCredits();
        }

        private void FillCreditNumbers()
        {
            lb_compulsory_min.Text = compulsory.min.ToString();
            lb_compulsory_passed.Text = compulsory.passed.ToString();
            lb_compulsory_reg.Text = compulsory.reg.ToString();

            lb_specialized_min.Text = specialized.min.ToString();
            lb_specialized_passed.Text = specialized.passed.ToString();
            lb_specialized_reg.Text = specialized.reg.ToString();

            lb_interdisciplinary_min.Text = interdisciplinary.min.ToString();
            lb_interdisciplinary_passed.Text = interdisciplinary.passed.ToString();
            lb_interdisciplinary_reg.Text = interdisciplinary.reg.ToString();

            lb_knowledge_min.Text = knowledge.min.ToString();
            lb_knowledge_passed.Text = knowledge.passed.ToString();
            lb_knowledge_reg.Text = knowledge.reg.ToString();

            lb_theoretical_min.Text = theoretical.min.ToString();
            lb_theoretical_passed.Text = theoretical.passed.ToString();
            lb_theoretical_reg.Text = theoretical.reg.ToString();

            lb_all_min.Text = total.min.ToString();
            lb_all_passed.Text = total.passed.ToString();
            lb_all_reg.Text = total.reg.ToString();

        }

        private void CountCredits()
        {
            try
            {
                foreach (DataGridViewRow row in DGV_courses.Rows)
                {
                    string check = row.Cells["Enroll"].Value.ToString();
                    string type = row.Cells["Compulsory"].Value.ToString();
                    string status = row.Cells["Status"].Value.ToString();
                    int credits = Convert.ToInt16(row.Cells["Credits"].Value);

                    if(check == "True")
                    {
                        if(status == "A" || status == "U")
                            continue;

                        total.reg += credits;

                        switch(type)
                        {
                            case "P":
                                compulsory.reg += credits;
                                break;
                            case "VO":
                                specialized.reg += credits;
                                break;
                            case "VM":
                                interdisciplinary.reg += credits;
                                break;
                            case "VV":
                                knowledge.reg += credits;
                                break;
                            case "TN":
                                theoretical.reg += credits;
                                break;
                        }
                    }
                }

                FillCreditNumbers();

            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;

                if(rowIndex == -1 || colIndex != 6) return;

                string check = DGV_courses.Rows[rowIndex].Cells["Enroll"].Value.ToString();
                string type = DGV_courses.Rows[rowIndex].Cells["Compulsory"].Value.ToString();
                int credits = Convert.ToInt16(DGV_courses.Rows[rowIndex].Cells["Credits"].Value);

                if(check == "True")
                {
                    total.reg += credits;

                    switch(type)
                    {
                        case "P":
                            compulsory.reg += credits;
                            break;
                        case "VO":
                            specialized.reg += credits;
                            break;
                        case "VM":
                            interdisciplinary.reg += credits;
                            break;
                        case "VV":
                            knowledge.reg += credits;
                            break;
                        case "TN":
                            theoretical.reg += credits;
                            break;
                    }
                }
                else
                {
                    total.reg -= credits;

                    switch(type)
                    {
                        case "P":
                            compulsory.reg -= credits;
                            break;
                        case "VO":
                            specialized.reg -= credits;
                            break;
                        case "VM":
                            interdisciplinary.reg -= credits;
                            break;
                        case "VV":
                            knowledge.reg -= credits;
                            break;
                        case "TN":
                            theoretical.reg -= credits;
                            break;
                    }
                }

                FillCreditNumbers();
            }
            catch(Exception)
            {

                //throw;
            }
        }

        private void DGV_courses_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(DGV_courses.CurrentCell.ColumnIndex == 6 && DGV_courses.IsCurrentCellDirty)
            {
                DGV_courses.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Credits_FormClosing(object sender, FormClosingEventArgs e)
        {
            using(StreamWriter sw = new StreamWriter("credits.dll"))
            {
                sw.WriteLine(chb_readTable.Checked);
                sw.WriteLine(chb_saveTable.Checked);

                if(!chb_saveTable.Checked)
                {
                    sw.WriteLine("End");
                    return;
                }

                for(int i = 0; i < courseList.Count; i++)
                {
                    sw.WriteLine(courseList.ElementAt(i).Enroll);
                }
                sw.WriteLine("End");
            }
        }

        private void LoadCredits()
        {
            if(File.Exists("credits.dll"))
            {
                try
                {
                    using(StreamReader sr = new StreamReader("credits.dll"))
                    {
                        string line = "";
                        line = sr.ReadLine();
                        if(line == "True")
                        {
                            chb_readTable.Checked = true;
                        }

                        line = sr.ReadLine();
                        if(line == "True")
                        {
                            chb_saveTable.Checked = true;
                        }

                        do
                        {
                            line = sr.ReadLine();
                            if(line == "True")
                            {
                                readedValue.Add(true);
                            }
                            else if(line == "False")
                            {
                                readedValue.Add(false);
                            }
                            else if(line == "End")
                            {
                                break;
                            }
                        } while(true);
                    }
                }
                catch(Exception)
                {

                    //throw;
                }
            }
        }

    }
    public class Courses
    {
        public string Status { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string Credits { get; set; }
        public string Semester { get; set; }
        public string Compulsory { get; set; }
        public bool Enroll { get; set; }
    }
}
