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
    public partial class HomeForm : Form
    {
        private AppForm appForm;
        public static User user;
        public HomeForm(AppForm app, User u)
        {
            InitializeComponent();
            appForm = app;
            user = u;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            load_SubForm(new chapterForm(2));
            hideStartingPNL();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chapterPNL.Visible)
                chapterPNL.Visible = false;
            else
                chapterPNL.Visible = true;

        }

        private void chapQuizBTN_Click(object sender, EventArgs e)
        {
            if (quizPNL.Visible)
                quizPNL.Visible = false;
            else
                quizPNL.Visible = true;
        }

        private void quizPNL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            load_SubForm(new chapterForm(1));
            hideStartingPNL();
        }


        private Form activeForm;

        private void load_SubForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.homeChildPNL.Controls.Add(childForm);
            this.homeChildPNL.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void changeTitle(object sender)
        {
            titleLBL.Text = ((Button)sender).Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            load_SubForm(new chapterForm(3));
            hideStartingPNL();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            load_SubForm(new chapterForm(4));
            hideStartingPNL();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            hideStartingPNL();
            load_SubForm(new quizForm(1));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            hideStartingPNL();
            load_SubForm(new quizForm(2));

        }

        private void button8_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            hideStartingPNL();
            load_SubForm(new quizForm(3));

        }

        private void button7_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            hideStartingPNL();
            load_SubForm(new quizForm(4));

        }

        private void testBTN_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            closeAllSubMenus();
            hideStartingPNL();
            load_SubForm(new quizForm(-1));

        }

        private void manualBTN_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            closeAllSubMenus();
            hideStartingPNL();

        }

        private void accountBTN_Click(object sender, EventArgs e)
        {
            changeTitle(sender);
            closeAllSubMenus();
            hideStartingPNL();
            load_SubForm(new accountForm());


        }

        private void closeAllSubMenus()
        {
            quizPNL.Visible = false;
            chapterPNL.Visible = false;

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            showStartingPNL();
        }

        private void helpBTN_Click(object sender, EventArgs e)
        {
            switch (titleLBL.Text)
            {
                case "Home":
                    MessageBox.Show("Press one of the options at the side menu.\n\n" +
                        "-> Chapters: Opens a submenu with all the available chapters of lessons.\n\n" +
                        "-> Quizes: Opens a submenu with all the quizes for every available chapter.\n\n" +
                        "-> Repetitive Test: Quiz with randomized questions from every chapter.\n\n" +
                        "-> Manual: Opens the user manual that describes the whole application\n\n" +
                        "-> Account: Opens the form that with the user's information, progress etc.\n\n" +
                        "-> Log out: Disconnect.");
                    break;
                case "Chapter 1: Getting Started":
                    MessageBox.Show("");
                    break;
                case "Chapter 2:":
                    MessageBox.Show("");

                    break;
                case "Chapter 3:":
                    MessageBox.Show("");

                    break;
                case "Chapter 4:":
                    MessageBox.Show("");

                    break;
                case "Chapter 1 Quiz":
                    MessageBox.Show("");

                    break;
                case "Chapter 2 Quiz":
                    MessageBox.Show("");

                    break;
                case "Chapter 3 Quiz":
                    MessageBox.Show("");

                    break;
                case "Chapter 4 Quiz":
                    MessageBox.Show("");

                    break;
                case "Repetitive Test":
                    MessageBox.Show("");

                    break;
                case "Account":
                    MessageBox.Show("");

                    break;
            }
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            Close();
            appForm.userLoggedOut();
        }

        public void showResultForm(int chapter, List<Quiz> quizQuestions,List<int> UserAnswers)
        {
            load_SubForm(new ResultsForm(chapter,quizQuestions, UserAnswers));
        }

        public void showStartingPNL()
        {
            titleLBL.Text = "Home";
            startingPNL.Visible = true;

        }

        public void hideStartingPNL()
        {
            startingPNL.Visible = false;

        }
    }

}
