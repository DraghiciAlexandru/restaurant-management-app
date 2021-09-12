using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Template
{
    class ViewRegister : Panel
    {
        String path = Application.StartupPath;
        public TextBox txtName;
        public TextBox txtPass;
        public TextBox txtConfPass;
        public TextBox txtEmail;
        public TextBox txtTelefon;
        public Button btnFinal;

        public ViewRegister()
        {
            layout();
        }

        public void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(500, 400);
            this.ForeColor = Color.FromArgb(32, 178, 170); 
            this.Font = new Font("Showcard Gothic", 12F);
            this.Location = new Point(0, 0);
            this.Name = "pnlRegister";
            this.Anchor = AnchorStyles.None;

            setTxtName();
            setTxtPassword();
            setTxtConfPassword();
            setTxtEmail();
            setTxtTelefon();
            setBtnFinal();
        }

        private void setTxtName()
        {
            txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(180, 25);
            txtName.Location = new Point(160, 100);
            txtName.Name = "txtName";
            txtName.Text = "Name:";
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = ThemeColor.PrimaryColor;
            txtName.ForeColor = Color.White;

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            this.Controls.Add(txtName);
        }

        private void setTxtPassword()
        {
            txtPass = new TextBox();
            txtPass.AutoSize = false;
            txtPass.Size = new Size(180, 25);
            txtPass.Location = new Point(160, 140);
            txtPass.Name = "txtPassword";
            txtPass.Text = "Password:";
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.BackColor = ThemeColor.PrimaryColor;
            txtPass.ForeColor = Color.White;

            txtPass.Enter += Txt_Enter;
            txtPass.Leave += Txt_Leave;

            this.Controls.Add(txtPass);
        }

        private void setTxtConfPassword()
        {
            txtConfPass = new TextBox();
            txtConfPass.AutoSize = false;
            txtConfPass.Size = new Size(180, 25);
            txtConfPass.Location = new Point(160, 180);
            txtConfPass.Name = "txtConfPass";
            txtConfPass.Text = "Confirm password:";
            txtConfPass.BorderStyle = BorderStyle.None;
            txtConfPass.BackColor = ThemeColor.PrimaryColor;
            txtConfPass.ForeColor = Color.White;

            txtConfPass.Enter += Txt_Enter;
            txtConfPass.Leave += Txt_Leave;

            this.Controls.Add(txtConfPass);
        }

        private void setTxtEmail()
        {
            txtEmail = new TextBox();
            txtEmail.AutoSize = false;
            txtEmail.Size = new Size(180, 25);
            txtEmail.Location = new Point(160, 220);
            txtEmail.Name = "txtEmail";
            txtEmail.Text = "Email:";
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.BackColor = ThemeColor.PrimaryColor;
            txtEmail.ForeColor = Color.White;

            txtEmail.Enter += Txt_Enter;
            txtEmail.Leave += Txt_Leave;

            this.Controls.Add(txtEmail);
        }

        private void setTxtTelefon()
        {
            txtTelefon = new TextBox();
            txtTelefon.AutoSize = false;
            txtTelefon.Size = new Size(180, 25);
            txtTelefon.Location = new Point(160, 260);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = "Phone:";
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.BackColor = ThemeColor.PrimaryColor;
            txtTelefon.ForeColor = Color.White;

            txtTelefon.Enter += Txt_Enter;
            txtTelefon.Leave += Txt_Leave;

            this.Controls.Add(txtTelefon);
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text.Trim(' ') == "")
            {
                if (text.Name == "txtName")
                    text.Text = "Name:";
                else if (text.Name == "txtPassword")
                {
                    text.Text = "Password:";
                    text.PasswordChar = default;
                }
                else if (text.Name == "txtConfPass")
                {
                    text.Text = "Confirm password:";
                    text.PasswordChar = default;
                }
                else if (text.Name == "txtEmail")
                {
                    text.Text = "Email:";
                }
                else if (text.Name == "txtTelefon")
                {
                    text.Text = "Phone:";
                }
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "Password:" || text.Text == "Confirm password:" || text.Text == "Email:" || text.Text == "Phone:") 
            {
                if (text.Text == "Password:" || text.Text == "Confirm password:") 
                {
                    text.PasswordChar = '●';
                }
                text.Text = "";
            }
        }

        private void setBtnFinal()
        {
            btnFinal = new Button();
            btnFinal.Size = new Size(150, 50);
            btnFinal.Location = new Point(175, 315);
            btnFinal.FlatStyle = FlatStyle.Flat;
            btnFinal.Text = "  Finalize";
            btnFinal.Name = "btnFinal";
            btnFinal.Image = Image.FromFile(path + @"\resources\ok_48px.png");
            btnFinal.ImageAlign = ContentAlignment.MiddleLeft;
            btnFinal.TextAlign = ContentAlignment.MiddleLeft;
            btnFinal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinal.BackColor = ThemeColor.PrimaryColor;
            btnFinal.ForeColor = Color.White;

            this.Controls.Add(btnFinal);
        }
    }
}
