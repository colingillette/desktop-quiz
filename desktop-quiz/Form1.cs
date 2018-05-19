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
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Form1()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            user user1 = verifyLogin();

            if (user1 != null)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
        }

        private user verifyLogin()
        {
            string usernm = usernameTextBox.Text;
            string userpw = passwordTextBox.Text;

            var query =
                from user in db.users
                where user.username == usernm
                select user;

            int result = query.Count<user>();

            if (result >= 1)
            {
                user user1 = query.First<user>();
                if (user1.password == userpw)
                {
                    return user1;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
