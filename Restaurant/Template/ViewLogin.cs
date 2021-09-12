﻿using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Template
{
    class ViewLogin : Panel
    {
        String path = Application.StartupPath;
        public TextBox txtName;
        public TextBox txtPass;
        public Button btnLogin;
        public Button btnRegister;

        public ViewLogin()
        {
            layout();
        }
        
        public void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(500, 300);
            this.ForeColor = Color.FromArgb(32, 178, 170);
            this.Location = new Point(0, 0);
            this.Name = "pnlLogin";
            this.Font = new Font("Showcard Gothic", 12F);

            this.Anchor = AnchorStyles.None;

            setTxtName();
            setTxtPassword();
            setBtnLogin();
            setBtnRegister();
        }

        private void setTxtName()
        {
            txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(150, 25);
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
            txtPass.Size = new Size(150, 25);
            txtPass.Location = new Point(160, 140);
            txtPass.Name = "txtPassword";
            txtPass.Text = "Password:";
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.BackColor = Color.FromArgb(40, 40, 40);
            txtPass.ForeColor = Color.FromArgb(32, 178, 170);

            txtPass.BackColor = ThemeColor.PrimaryColor;
            txtPass.ForeColor = Color.White;

            txtPass.Enter += Txt_Enter;
            txtPass.Leave += Txt_Leave;

            this.Controls.Add(txtPass);
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
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "Password:")
            {
                if(text.Text == "Password:")
                {
                    text.PasswordChar = '●';
                }
                text.Text = "";
            }
        }

        private void setBtnLogin()
        {
            btnLogin = new Button();
            btnLogin.Size = new Size(150, 50);
            btnLogin.Location = new Point(75, 200);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Text = "   Login";
            btnLogin.Name = "btnLogin";
            
            btnLogin.Image = Image.FromFile(path + @"\resources\user_48px.png");
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.TextAlign = ContentAlignment.MiddleLeft;
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnLogin.BackColor = ThemeColor.PrimaryColor;
            btnLogin.ForeColor = Color.White;

            this.Controls.Add(btnLogin);

        }

        private void setBtnRegister()
        {
            btnRegister = new Button();
            btnRegister.Size = new Size(150, 50);
            btnRegister.Location = new Point(270, 200);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Text = "  Register";
            btnRegister.Name = "btnRegister";
            btnRegister.Image = Image.FromFile(path + @"\resources\add_user_male_40px.png");
            btnRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnRegister.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRegister.BackColor = ThemeColor.PrimaryColor;
            btnRegister.ForeColor = Color.White;

            this.Controls.Add(btnRegister);
        }
    }
}
