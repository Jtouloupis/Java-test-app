using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EkpaideytikoLogismiko
{
    public partial class ResultsForm : Form
    {
        private List<Quiz> quizQuestions;
        private List<int> UserAnswers;
        private int chapterId;
        private int correctCounter;
        private List<Quiz> wrongQuest;
        private int index = 0;
        private NpgsqlConnection cnn;

        public ResultsForm(int chapter,List<Quiz> quizQuestions, List<int> UserAnswers)
        {
            InitializeComponent();
            this.quizQuestions = quizQuestions;
            this.UserAnswers = UserAnswers;
            chapterId = chapter;
            wrongQuest = new List<Quiz>();
            cnn = Program.GetConnection();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {

            saveProgress();
            resultTitle.Text = "Results:";

            for(int i = 0; i < quizQuestions.Count; i++)
            {
                if(quizQuestions[i].getAnswer() == UserAnswers[i])
                {
                    correctCounter++;
                }
                else
                {
                    wrongQuest.Add(quizQuestions[i]);
                }
            }

            correctLBL.Text = "Correct: " + correctCounter + " / " + quizQuestions.Count;

            backBTN.Visible = false;

            loadExplanations();
            
        }

        private void loadExplanations()
        {
            if(wrongQuest.Count > 0)
            {
                if(index > wrongQuest.Count - 1)
                {
                    HomeForm hm = this.ParentForm as HomeForm;
                    hm.showStartingPNL();
                    this.Close();
                }
                else
                {
                    questionTXT.Text = wrongQuest[index].getQuestion();
                    explanationTXT.Text = wrongQuest[index].getExplanation();
                }

                if (index > 0)
                    backBTN.Visible = true;
                else
                    backBTN.Visible = false;

                if (index+1 == wrongQuest.Count)
                {
                    nextBTN.Visible = false;
                }
                else
                {
                    nextBTN.Image = Properties.Resources.next_arrow;
                }
            }
            else
            {
                nextBTN.Visible = false;

                questionTXT.Text = "Congratulation you answered all questions correctly!!";
                explanationTXT.Text = "Congratulation you answered all questions correctly!!";
            }
        }

        private void saveProgress()
        {
            if (chapterId == -1)
            {
                int[,] chapter_pers = new int[4, 2]; //[x,0] -> number of question of chapter x | [x,1] -> number of wrong answers 
                for (int i=0; i < quizQuestions.Count; i++)
                {
                    chapter_pers[quizQuestions[i].getChapter()-1, 0]++;
                    if(quizQuestions[i].getAnswer() != UserAnswers[i])
                        chapter_pers[quizQuestions[i].getChapter()-1, 1]++;

                }

                for(int i = 0; i< 4; i++)
                {
                    if (chapter_pers[i, 0] > 0)
                    {
                        if (((chapter_pers[i, 0] - chapter_pers[i, 1]) / chapter_pers[i, 0]) *100 < 60)
                        {
                            cnn.Open();

                            NpgsqlCommand command;
                            NpgsqlDataReader dataReader;
                            String sql;

                            sql = "Select * from account_quiz where account_id = @user and quiz_chapter_id = @chapter;";

                            command = new NpgsqlCommand(sql, cnn);
                            command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
                            command.Parameters.AddWithValue("@chapter", i+1);

                            dataReader = command.ExecuteReader();

                            bool alreadyExists;
                            if (dataReader.Read())
                            {
                                alreadyExists = true;
                            }
                            else
                            {
                                alreadyExists = false;
                            }

                            dataReader.Close();
                            command.Dispose();

                            if (alreadyExists)
                            {
                                sql = "update account_quiz set success_per = @percent where account_id = @user and quiz_chapter_id = @chapter;";
                                command = new NpgsqlCommand(sql, cnn);
                                command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
                                command.Parameters.AddWithValue("@chapter", i+1);
                                command.Parameters.AddWithValue("@percent", ((chapter_pers[i, 0] - chapter_pers[i, 1]) / chapter_pers[i, 0]) * 100);

                                command.ExecuteNonQuery();

                                command.Dispose();
                            }
                            else if (!alreadyExists)
                            {

                                sql = "INSERT INTO public.account_quiz (account_id, quiz_chapter_id, success_per) VALUES(@account, @chapter,@percent);";

                                command = new NpgsqlCommand(sql, cnn);
                                command.Parameters.AddWithValue("@account", HomeForm.user.getUserId());
                                command.Parameters.AddWithValue("@chapter", i+1);
                                command.Parameters.AddWithValue("@percent", ((chapter_pers[i, 0] - chapter_pers[i, 1])/ chapter_pers[i, 0]) * 100);


                                command.ExecuteNonQuery();

                                command.Dispose();
                            }

                            cnn.Close();
                        }
                    }
                }
            }
            else
            {
                cnn.Open();

                NpgsqlCommand command;
                NpgsqlDataReader dataReader;
                String sql;

                sql = "Select * from account_quiz where account_id = @user and quiz_chapter_id = @chapter;";

                command = new NpgsqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
                command.Parameters.AddWithValue("@chapter", chapterId);

                dataReader = command.ExecuteReader();

                bool alreadyExists;
                if (dataReader.Read())
                {
                    alreadyExists = true;
                }
                else
                {
                    alreadyExists = false;
                }

                dataReader.Close();
                command.Dispose();

                if (alreadyExists)
                {
                    sql = "update account_quiz set success_per = @percent where account_id = @user and quiz_chapter_id = @chapter;";
                    command = new NpgsqlCommand(sql, cnn);
                    command.Parameters.AddWithValue("@user", HomeForm.user.getUserId());
                    command.Parameters.AddWithValue("@chapter", chapterId);
                    command.Parameters.AddWithValue("@percent", ((quizQuestions.Count - wrongQuest.Count) / quizQuestions.Count) * 100);

                    command.ExecuteNonQuery();

                    command.Dispose();
                }
                else if (!alreadyExists)
                {

                    sql = "INSERT INTO public.account_quiz (account_id, quiz_chapter_id, success_per) VALUES(@account, @chapter,@percent);";

                    command = new NpgsqlCommand(sql, cnn);
                    command.Parameters.AddWithValue("@account", HomeForm.user.getUserId());
                    command.Parameters.AddWithValue("@chapter", chapterId);
                    command.Parameters.AddWithValue("@percent", ((quizQuestions.Count - wrongQuest.Count) / quizQuestions.Count) * 100);


                    command.ExecuteNonQuery();

                    command.Dispose();
                }

                cnn.Close();
            }
        }

        private void nextBTN_Click(object sender, EventArgs e)
        {
            index++;
            loadExplanations();
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            index--;
            loadExplanations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeForm hm = this.ParentForm as HomeForm;
            hm.showStartingPNL();
            Close();
        }
    }
}
