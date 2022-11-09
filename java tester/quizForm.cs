using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EkpaideytikoLogismiko
{
    public partial class quizForm : Form
    {
        private int chapterID;
        private NpgsqlConnection cnn;

        private List<Quiz> quizzes;
        private Quiz quiz;

        private bool finish = false;

        public List<int> userAnswers;

        public int questionCounter = 1;

        public quizForm(int chapter)
        {
            InitializeComponent();
            chapterID = chapter;

            userAnswers = new List<int>();
        }

      
        //save the answer of the user in an array
        private int radioButtonChecker()
        {
            int answer = 0;
            if (answer1BTN.Checked == true)
            {
                answer = 1;
            }
            else if (answer2BTN.Checked == true)
            {
                answer = 2;

            }
            else if (answer3BTN.Checked == true)
            {
                answer = 3;
                    
            }
            else if (answer4BTN.Checked == true)
            {
                answer = 4;
            }

            return answer;
        }


        private void nextBTN_Click(object sender, EventArgs e)
        {
            if (userAnswers.Count < questionCounter)
            {
                userAnswers.Add(radioButtonChecker());
            }
            else
            {
                userAnswers[questionCounter-1] = radioButtonChecker();
            }
            questionCounter++;

            loadQuiz();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (userAnswers.Count < questionCounter)
            {
                userAnswers.Add(radioButtonChecker());
            }
            else
            {
                userAnswers[questionCounter-1] = radioButtonChecker();
            }
            questionCounter--;

            finish = false;

            loadQuiz();
        }

        private void quizForm_Load(object sender, EventArgs e)
        {
            quizzes = new List<Quiz>();
            cnn = Program.GetConnection();

            if (chapterID == -1)
            {
                Random r = new Random();
                cnn.Open();

                NpgsqlCommand command;
                NpgsqlDataReader dataReader;
                String sql;

                sql = "Select * from quiz";

                command = new NpgsqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    quiz = new Quiz(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetInt32(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetInt32(8), dataReader.GetString(9));

                    quizzes.Add(quiz);
                }

                while(quizzes.Count > 20)
                {
                    int i = r.Next(0, quizzes.Count);
                    quizzes.RemoveAt(i);
                }

                command.Dispose();
                dataReader.Close();

                loadQuiz();
            }
            else
            {
                questionCounter = 1;


                cnn.Open();

                NpgsqlCommand command;
                NpgsqlDataReader dataReader;
                String sql;

                sql = "Select * from quiz where chapter = @chapter;";

                command = new NpgsqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@chapter", chapterID);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    quiz = new Quiz(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetInt32(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetInt32(8), dataReader.GetString(9));

                    quizzes.Add(quiz);
                }

                command.Dispose();
                dataReader.Close();

                loadQuiz();
            }
        }

        private void loadQuiz()
        {
            if (quizzes.Count > 0)
            {
                if (!finish)
                {
                    answer1BTN.Checked = false;
                    answer2BTN.Checked = false;
                    answer3BTN.Checked = false;
                    answer4BTN.Checked = false;

                    richTextBox1.Text = quizzes[questionCounter - 1].getQuestion();

                    //load choices
                    answer1BTN.Text = quizzes[questionCounter - 1].getChoice1();
                    answer2BTN.Text = quizzes[questionCounter - 1].getChoice2();
                    answer3BTN.Text = quizzes[questionCounter - 1].getChoice3();
                    answer4BTN.Text = quizzes[questionCounter - 1].getChoice4();



                    numberLBL.Text = questionCounter + " / " + quizzes.Count.ToString();

                    if(userAnswers.Count >= questionCounter)
                    {
                        switch (userAnswers[questionCounter-1])
                        {
                            case 1:
                                answer1BTN.Checked = true;
                                break;
                            case 2:
                                answer2BTN.Checked = true;
                                break;
                            case 3:
                                answer3BTN.Checked = true;
                                break;
                            case 4:
                                answer4BTN.Checked = true;
                                break;
                        }
                    }

                    if (questionCounter > 1)
                        backBTN.Visible = true;
                    else
                        backBTN.Visible = false;

                    if (questionCounter == quizzes.Count)
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
                    questionCounter--;
                    MessageBox.Show("You have completed this chapter's quiz! Well done!\n" +
                       "In the next form you will see the results and the explanation for the questions you answered wrong.");
                    showResult();
                }
            }
            else
                numberLBL.Text = "0 / 0";
        }

        

        private void showResult()
        {
            HomeForm hm = this.ParentForm as HomeForm;
            hm.showResultForm(chapterID,quizzes,userAnswers);
        }
    }
}
