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
    public partial class AppForm : Form
    {
        private Form activeForm;

        public AppForm()
        {
            InitializeComponent();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new SignUpForm(this));
        }

        private void OpenChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.AppPanel.Controls.Add(childForm);
            this.AppPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void AppPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public void userLoggedIn(User user)
        {
            OpenChildForm(new HomeForm(this,user));

        }

        public void userLoggedOut()
        {
            OpenChildForm(new SignUpForm(this));

        }
    }
}
