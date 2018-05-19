using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_quiz
{
    public partial class Form2 : Form
    {
        question[] questions = new question[1];
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Form2()
        {
            InitializeComponent();
        }

        private void GenerateQuiz()
        {
            var query =
                from question in db.questions
                where question.Id == 1
                select question;
            questions[0] = query.First();
        }

        private void NextQuestion()
        {
            label1.Text = questions[0].questtext;
            radioButton1.Text = questions[0].correct_ans;
            radioButton2.Text = questions[0].ans1;
            radioButton3.Text = questions[0].ans2;
            radioButton4.Text = questions[0].ans3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateQuiz();
            NextQuestion();

            groupBox1.Visible = true;
            button1.Text = "Submit";
        }
    }
}
