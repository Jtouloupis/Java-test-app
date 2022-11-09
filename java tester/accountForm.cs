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
    public partial class accountForm : Form
    {

        private NpgsqlConnection cnn;
        private List<int> finChapters;
        private List<int> finQuiz;
        public accountForm()
        {
            InitializeComponent();
            finChapters = new List<int>();
            finQuiz = new List<int>();
        }

        private void accountForm_Load(object sender, EventArgs e)
        {
            uncompletedQuizTXT.Clear();
            uncompletedChapterTXT.Clear();
            repeatChapterTXT.Clear();
            repeatQuizTXT.Clear();

            firstnameLBL.Text = HomeForm.user.getFirstname();
            lastnameLBL.Text = HomeForm.user.geLastname();
            usernameLBL.Text = HomeForm.user.getUsername();
            cnn = Program.GetConnection();

            List<int> repCha = new List<int>();
            List<int> repQuiz = new List<int>();

            cnn.Open();

            NpgsqlCommand command;
            NpgsqlDataReader dataReader;
            String sql;

            sql = "Select * from account_lesson where accountid = @user;";

            command = new NpgsqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (dataReader.GetBoolean(3))
                {
                    finChapters.Add(dataReader.GetInt32(1));
                }
            }

            command.Dispose();
            dataReader.Close();

            chapterCompLBL.Text = finChapters.Count + " / 4";

            sql = "Select * from account_quiz where account_id = @user;";

            command = new NpgsqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.GetInt32(3) > 60) //success rate > 60
                {
                    finQuiz.Add(dataReader.GetInt32(2));
                }
                else
                {
                    repCha.Add(dataReader.GetInt32(2));
                    repQuiz.Add(dataReader.GetInt32(2));
                }
            }

            command.Dispose();
            dataReader.Close();
            cnn.Close();
            quizCompLBL.Text = finQuiz.Count + " / 4";



            for (int i = 1; i <= 4; i++)
            {
                if (!finChapters.Contains(i))
                {
                    uncompletedChapterTXT.Text += "Chapter " + i + "\n";
                }
                if (!finQuiz.Contains(i) && !repQuiz.Contains(i))
                {
                    uncompletedQuizTXT.Text += "Chapter " + i + " Quiz\n";

                }
            }

            foreach (int i in repCha)
            {
                repeatChapterTXT.Text += "Chapter" + i + "\n";
            }

            foreach (int i in repQuiz)
            {
                repeatQuizTXT.Text += "Chapter " + i + " Quiz\n";
            }
        }
    }
}
