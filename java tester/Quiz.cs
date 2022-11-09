using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideytikoLogismiko
{
    public class Quiz
    {
        private int id;
        private int chapter;
        private int question_number;
        private string question;
        private string choice1;
        private string choice2;
        private string choice3;
        private string choice4;
        private int answer;
        private string explanation;

        public Quiz(int id, int chapter, int question_number, string question, string choice1, string choice2, string choice3, string choice4, int answer, string explanation)
        {
            this.id = id;
            this.chapter = chapter;
            this.question_number = question_number;
            this.question = question;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
            this.choice4 = choice4;
            this.answer = answer;
            this.explanation = explanation;
        }

        public int getId()
        {
            return id;
        }

        public int getChapter()
        {
            return chapter;
        }

        public int getQuestion_number()
        {
            return question_number;
        }

        public string getQuestion()
        {
            return question;
        }

        public string getChoice1()
        {
            return choice1;
        }

        public string getChoice2()
        {
            return choice2;
        }
        public string getChoice3()
        {
            return choice3;
        }

        public string getChoice4()
        {
            return choice4;
        }
        public int getAnswer()
        {
            return answer;
        }

        public string getExplanation()
        {
            return explanation;
        }


        public void setId(int id)
        {
            this.id = id;
        }

        public void setChapter(int chapter) {

            this.chapter = chapter;
        }



        public void setQuestion_number(int question_number) {

            this.question_number = question_number;

        }

        public void setChoice1(string choice1)
        {

            this.choice1 = choice1;

        }

        public void setChoice2(string choice2)
        {

            this.choice2 = choice2;

        }
        public void setChoice3(string choice3)
        {

            this.choice3 = choice3;

        }
        public void setChoice4(string choice4)
        {

            this.choice4 = choice4;

        }
        public void setAnswer(int answer)
        {

            this.answer = answer;

        }
        public void setExplanation(string explanation)
        {

            this.explanation = explanation;

        }



    }


}
