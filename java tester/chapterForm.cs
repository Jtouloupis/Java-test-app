using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkpaideytikoLogismiko
{
    public partial class chapterForm : Form
    {
        private int page;
        private int chapterID;
        private NpgsqlConnection cnn;

        private List<Lessons> lessons;
        private Lessons lesson;

        private bool finish = false;

        public chapterForm(int chapter)
        {
            InitializeComponent();
            chapterID = chapter;
        }

        private void chapterForm_Load(object sender, EventArgs e)
        {
            lessons = new List<Lessons>();
            page = 1;
            cnn = Program.GetConnection();


            cnn.Open();

            NpgsqlCommand command;
            NpgsqlDataReader dataReader;
            String sql;

            sql = "Select * from lessons where chapter = @chapter;";

            command = new NpgsqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@chapter", chapterID);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                lesson = new Lessons(dataReader.GetInt32(0), dataReader.GetInt32(1),dataReader.GetInt32(5), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));

                lessons.Add(lesson);
            }

            command.Dispose();
            dataReader.Close();

            sql = "Select * from account_lesson where accountid = @user and chapterid = @chapter;";

            command = new NpgsqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
            command.Parameters.AddWithValue("@chapter", chapterID);

            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                page = dataReader.GetInt32(2);
            }

            cnn.Close();
            command.Dispose();
            dataReader.Close();

            backBTN.Visible = false;
            loadLesson();
        }

        private void loadLesson()
        {
            if (lessons.Count > 0)
            {
                if (!finish)
                {
                    codeTXT.Text = lessons[page - 1].getCode();
                    expTXT.Text = lessons[page - 1].getExplanation();
                    resultTXT.Text = lessons[page - 1].getResult();

                    numberLBL.Text = page + " / " + lessons.Count.ToString();


                    if (page > 1)
                        backBTN.Visible = true;
                    else
                        backBTN.Visible = false;

                    if (page == lessons.Count)
                    {
                        nextBTN.Image = Properties.Resources.checkmark;
                        finish = true;
                    }
                    else
                    {
                        nextBTN.Image = Properties.Resources.next_arrow;
                    }
                }
                else
                {
                    page--;
                    MessageBox.Show("You have completed this chapter! Well done!\n" +
                        "You can now continue to the next chapter of try the quiz of this one to test yourself!");
                    HomeForm hm = this.ParentForm as HomeForm;
                    hm.showStartingPNL();
                    this.Close();
                }
            }
            else
                numberLBL.Text = "0 / 0";
        }

        private void nextBTN_Click(object sender, EventArgs e)
        {
            page++;
            loadLesson();
            saveProgress();
        }

        private void saveProgress()
        {
            bool biggerProg = false;

            cnn.Open();

            NpgsqlCommand command;
            NpgsqlDataReader dataReader;
            String sql;

            sql = "Select * from account_lesson where accountid = @user and chapterid = @chapter;";

            command = new NpgsqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
            command.Parameters.AddWithValue("@chapter", chapterID);

            dataReader = command.ExecuteReader();



            bool alreadyExists;
            if (dataReader.Read())
            {
                alreadyExists = true;

                if (dataReader.GetInt32(2) < page)
                {

                    biggerProg = true;

                }
            }
            else
            {
                alreadyExists = false;
            }

            dataReader.Close();
            command.Dispose();

            if (alreadyExists && biggerProg)
            {
                sql = "update account_lesson set lessonid = @page,finished = @finish where accountid = @user and chapterid = @chapter;";
                command = new NpgsqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
                command.Parameters.AddWithValue("@chapter", chapterID);
                command.Parameters.AddWithValue("@page", page);
                command.Parameters.AddWithValue("@finish", finish);

                command.ExecuteNonQuery();

                command.Dispose();
            }
            else if(!alreadyExists){
                sql = "INSERT INTO public.account_lesson (accountid, chapterid, lessonid,finished) VALUES(@account, @chapter,@page,@finish);";

                command = new NpgsqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@account", HomeForm.user.getUserId());
                command.Parameters.AddWithValue("@chapter", chapterID);
                command.Parameters.AddWithValue("@page", page);
                command.Parameters.AddWithValue("@finish", finish);


                command.ExecuteNonQuery();

                command.Dispose();
            }

            cnn.Close();
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            page--;
            finish = false;

            loadLesson();
        }
    }
}
