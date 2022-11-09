using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideytikoLogismiko
{
    public class Lessons
    {
        private int id;
        private int chapter;
        private int page;
        private string code;
        private string explanation;
        private string result;

        public Lessons(int id,int chapter, int page, string code,string explanation, string result)
        {
            this.id = id;
            this.chapter = chapter;
            this.page = page;
            this.code = code;
            this.explanation = explanation;
            this.result = result;
        }

        public int getId()
        {
            return id;
        }

        public int getChapter()
        {
            return chapter;
        } 
        
        public int getPage()
        {
            return page;
        }

        public string getCode()
        {
            return code;
        }

        public string getExplanation()
        {
            return explanation;
        }

        public string getResult()
        {
            return result;
        }


        public void setId(int id)
        {
            this.id = id;
        }

        public void setChapter(int chapter)
        {
            this.chapter = chapter;
        } 
        public void setPage(int page)
        {
            this.page = page;
        }

        public void setCode(string code)
        {
            this.code = code;
        }

        public void setExplanation(string explanation)
        {
            this.explanation = explanation;
        }

        public void setResult(string result)
        {
            this.result = result;
        }
    }


}
