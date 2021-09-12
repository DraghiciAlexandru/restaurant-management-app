using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Restaurant.Servicii;
using Restaurant.Controler;

namespace Restaurant.Template
{
    class CardProfil : Panel
    {
        String path = Application.StartupPath;
        public TextBox txtName;
        public TextBox txtTelefon;
        public TextBox txtEmail;
        public TextBox txtPassWord;
        public PictureBox picLogout;
        private ControlCustomers controlCustomers;

        public CardProfil()
        {
            controlCustomers = new ControlCustomers();

            layout();
        }

        private void layout()
        {
            this.Size = new Size(600, 200);
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Name = "pnlProfil";
            this.Anchor = AnchorStyles.None;
            this.Font = new Font("Showcard Gothic", 14);



            setPicProfil();
            setPicEdit();
            setLogout();
            setTxtName();
            setTxtTelefon();
            setTxtEmail();
            setTxtPassword();
        }

        private void setPicProfil()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(20, 50);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\profile_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setPicEdit()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(350, 50);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\edit_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BackColor = ThemeColor.PrimaryColor;

            pic.BorderStyle = BorderStyle.FixedSingle;

            pic.Anchor = AnchorStyles.Top;

            pic.Click += Pic_Click;

            this.Controls.Add(pic);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtTelefon.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPassWord.ReadOnly = false;

            PictureBox pic = sender as PictureBox;

            setPicSave();
            Controls.Remove(pic);

        }

        private void setLogout()
        {
            picLogout = new PictureBox();
            picLogout.Size = new Size(100, 100);
            picLogout.Location = new Point(475, 50);
            picLogout.BackgroundImage = Image.FromFile(path + @"\resources\export_100px.png");
            picLogout.BackgroundImageLayout = ImageLayout.Stretch;
            picLogout.BackColor = ThemeColor.PrimaryColor;

            picLogout.BorderStyle = BorderStyle.FixedSingle;

            picLogout.Name = "picLogout";

            picLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Controls.Add(picLogout);
        }

        private void setPicSave()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(350, 50);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\ok_48px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            pic.BorderStyle = BorderStyle.FixedSingle;

            pic.Click += Pic_Click1;

            this.Controls.Add(pic);
        }

        private void Pic_Click1(object sender, EventArgs e)
        {
            ControlCustomers.loged = controlCustomers.getClient(ControlCustomers.loged.ID);

            controlCustomers.save();

            txtName.ReadOnly = true;
            txtTelefon.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPassWord.ReadOnly = true;

            PictureBox pic = sender as PictureBox;

            setPicEdit();
            Controls.Remove(pic);
        }

        private void setTxtName()
        {
            txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(150, 20);
            txtName.Location = new Point(130, 30);
            txtName.Name = "txtName";
            txtName.Text = ControlCustomers.loged.Nume;
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.ForeColor = ThemeColor.PrimaryColor;

            txtName.ReadOnly = true;

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            txtName.TextChanged += TxtName_TextChanged;

            this.Controls.Add(txtName);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Trim() != "") 
            {
                controlCustomers.updateName(ControlCustomers.loged.ID, txt.Text.Trim());
            }
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text.Trim(' ') == "")
            {
                if (text.Name == "txtName")
                    text.Text = "Name:";
                else if (text.Name == "txtTelefon")
                    text.Text = "Phone number:";
                else if (text.Name == "txtEmail")
                    text.Text = "Email:";
                else if (text.Name == "txtTabel")
                    text.Text = "Tabel:";
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "Phone number:" || text.Text == "Email:" || text.Text == "Tabel:")
            {
                text.Text = "";
            }
        }

        private void setTxtTelefon()
        {
            txtTelefon = new TextBox();
            txtTelefon.AutoSize = false;
            txtTelefon.Size = new Size(150, 20);
            txtTelefon.Location = new Point(130, 70);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = ControlCustomers.loged.Telefon;
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.BackColor = Color.FromArgb(40, 40, 40);
            txtTelefon.ForeColor = ThemeColor.PrimaryColor;

            txtTelefon.ReadOnly = true;

            txtTelefon.Enter += Txt_Enter;
            txtTelefon.Leave += Txt_Leave;

            txtTelefon.TextChanged += TxtTelefon_TextChanged;

            this.Controls.Add(txtTelefon);
        }

        private void TxtTelefon_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Trim() != "")
            {
                controlCustomers.updatePhone(ControlCustomers.loged.ID, txt.Text.Trim());
            }
        }

        private void setTxtEmail()
        {
            txtEmail = new TextBox();
            txtEmail.AutoSize = false;
            txtEmail.Size = new Size(170, 20);
            txtEmail.Location = new Point(130, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Text = ControlCustomers.loged.Email;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);
            txtEmail.ForeColor = ThemeColor.PrimaryColor;

            txtEmail.ReadOnly = true;

            txtEmail.Enter += Txt_Enter;
            txtEmail.Leave += Txt_Leave;

            txtEmail.TextChanged += TxtEmail_TextChanged;

            this.Controls.Add(txtEmail);
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Trim() != "")
            {
                controlCustomers.updateEmail(ControlCustomers.loged.ID, txt.Text.Trim());
            }
        }

        private void setTxtPassword()
        {
            txtPassWord = new TextBox();
            txtPassWord.AutoSize = false;
            txtPassWord.Size = new Size(60, 20);
            txtPassWord.Location = new Point(130, 150);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.PasswordChar = '●';
            txtPassWord.Text = ControlCustomers.loged.Password;
            txtPassWord.BorderStyle = BorderStyle.None;
            txtPassWord.BackColor = Color.FromArgb(40, 40, 40);
            txtPassWord.ForeColor = ThemeColor.PrimaryColor;

            txtPassWord.Anchor = AnchorStyles.Top;

            txtPassWord.Enter += Txt_Enter;
            txtPassWord.Leave += Txt_Leave;

            txtPassWord.TextChanged += TxtPassWord_TextChanged;

            this.Controls.Add(txtPassWord);
        }

        private void TxtPassWord_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Trim() != "")
            {
                controlCustomers.updatePassword(ControlCustomers.loged.ID, txt.Text.Trim());
            }
        }
    }
}
