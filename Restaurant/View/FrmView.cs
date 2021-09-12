using Restaurant.Controler;
using Restaurant.Model;
using Restaurant.Servicii;
using Restaurant.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.View
{
    class FrmView : Form
    {
        private Panel Header;
        private Panel Aside;
        private Panel Main;
        private Button currentBtn;
        private ControlCustomers controlCustomers;

        String path = Application.StartupPath;

        public FrmView()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();

            controlCustomers = new ControlCustomers();

            setLogin();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParm, int lParam);

        private void SelectThemeColor()
        {
            Random random = new Random();
            int index =  random.Next(ThemeColor.ColorList.Count);
            string color = ThemeColor.ColorList[index];
            ThemeColor.PrimaryColor = ColorTranslator.FromHtml(color);
            ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, -0.3);
        }

        public void setLogin()
        {
            this.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(300, 200);
            this.ControlBox = false;
            this.Size = new Size(500, 300);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Icon = new Icon(path + @"\resources\restaurant_icon.ico");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            SelectThemeColor();

            setHeader(Header);

            foreach (Control x in Header.Controls)
            {
                if (x.Name == "btnHome") 
                {
                    x.Controls.Clear();
                }
                if(x.Name=="lblPage")
                {
                    x.Text = "Login";
                }
            }

            ViewLogin viewLogin = new ViewLogin();
            Controls.Add(viewLogin);

            Button btnLogin = new Button();
            Button btnRegister = new Button();

            btnLogin = viewLogin.btnLogin;
            btnRegister = viewLogin.btnRegister;

            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            layoutRegister();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ViewLogin viewLogin = new ViewLogin();

            foreach (Control x in Controls)
            {
                if (x.Name == "pnlLogin")
                    viewLogin = x as ViewLogin;
            }

            if (viewLogin.txtName.Text != "Name:" && viewLogin.txtPass.Text != "Password:")
            {
                if (controlCustomers.getClient(viewLogin.txtName.Text) != null)
                {
                    if (controlCustomers.getClient(viewLogin.txtName.Text).Password == viewLogin.txtPass.Text)
                    {
                        ControlCustomers.loged = controlCustomers.getClient(viewLogin.txtName.Text);
                        Controls.Clear();
                        Header.Controls.Clear();

                        if(ControlCustomers.loged is Staff)
                        {
                            layoutStaff();
                        }
                        else
                        {
                            layoutClient();
                        }
                    }
                }
            }

        }

        public void layoutRegister()
        {
            Controls.Clear();
            this.Size = new Size(500, 400);
            this.Location = new Point(400, 150);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            setRegister();
        }

        private void setRegister()
        {
            Controls.Clear();

            Controls.Add(Header);

            foreach (Control x in Header.Controls)
            {
                if (x.Name == "lblPage")
                {
                    x.Text = "Register";
                }
            }

            ViewRegister viewRegister = new ViewRegister();
            Controls.Add(viewRegister);


            Button btnFinal = new Button();
            btnFinal = viewRegister.btnFinal;

            btnFinal.Click += BtnFinal_Click;
        }

        private void BtnFinal_Click(object sender, EventArgs e)
        {
            ViewRegister viewRegister = new ViewRegister();
            foreach (Control x in Controls)
            {
                if (x.Name == "pnlRegister")
                    viewRegister = x as ViewRegister;
            }

            if (viewRegister.txtName.Text != "Name:" && viewRegister.txtPass.Text != "Password:" || viewRegister.txtConfPass.Text != "Confirm password:" || viewRegister.txtEmail.Text != "Email:" || viewRegister.txtTelefon.Text != "Phone:")
            {
                if (viewRegister.txtPass.Text == viewRegister.txtConfPass.Text)
                {
                    if (controlCustomers.getClient(viewRegister.txtName.Text) == null)
                    {
                        Client client = new Client(0, viewRegister.txtName.Text, viewRegister.txtPass.Text, viewRegister.txtEmail.Text, viewRegister.txtTelefon.Text);
                        controlCustomers.add(client);
                        ControlCustomers.loged = client;
                        controlCustomers.save();

                        Header.Controls.Clear();
                        Controls.Clear();
                        layoutStaff();
                    }
                }
            }
        }

        public void layoutStaff()
        {
            this.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(150, 75);
            this.ControlBox = false;
            this.Size = new Size(1000, 550);
            this.MinimumSize = new Size(800, 400);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Icon = new Icon(path + @"\resources\restaurant_icon.ico");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            SelectThemeColor();

            setAside(Aside);
            setHeader(Header);
            setMain(Main);
        }

        public void layoutClient()
        {
            this.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(150, 75);
            this.ControlBox = false;
            this.Size = new Size(1000, 550);
            this.MinimumSize = new Size(800, 400);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Icon = new Icon(path + @"\resources\restaurant_icon.ico");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            SelectThemeColor();

            setAsideClient(Aside);
            setHeader(Header);
            setMain(Main);
        }

        private void setHeader(Panel header)
        {
            header.Size = new Size(1000, 75);
            header.Dock = DockStyle.Top;
            header.BackColor = ThemeColor.PrimaryColor;
            header.BorderStyle = BorderStyle.FixedSingle;
            header.MouseDown += Header_MouseDown;

            setBtnHome(header);

            setLblPage(header);

            setBtnClose(header);
            setBtnMax(header);
            setBtnMin(header);

            Controls.Add(header);
        }

        private void setBtnHome(Panel header)
        {
            Button btnHome = new Button();
            btnHome.Size = new Size(200, 70);
            btnHome.Location = new Point(0, 0);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.Text = "Restaurant";
            btnHome.Name = "btnHome";
            btnHome.Image = Image.FromFile(path + @"\resources\restaurant_64px.png");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.ForeColor = Color.White;
            btnHome.Dock = DockStyle.Left;

            btnHome.Font = new Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnHome.Click += BtnHome_Click;

            header.Controls.Add(btnHome);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
        }

        private void setLblPage(Panel header)
        {
            Label lblPage = new Label();
            lblPage.AutoSize = false;
            lblPage.Size = new Size(150, 40);
            lblPage.Location = new Point(450, 15);
            lblPage.TextAlign = ContentAlignment.MiddleCenter;
            lblPage.Text = "Home";
            lblPage.Name = "lblPage";
            lblPage.Font= new Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPage.ForeColor = Color.White;

            lblPage.Anchor = AnchorStyles.None;

            header.Controls.Add(lblPage);
        }

        private void setBtnClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(965, 5);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Name = "btnClose";
            btnClose.Image = Image.FromFile(path + @"\resources\close_window_26px.png");

            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnClose.Click += BtnClose_Click;

            header.Controls.Add(btnClose);
        }

        private void setBtnMax(Panel header)
        {
            Button btnMax = new Button();
            btnMax.Size = new Size(30, 30);
            btnMax.Location = new Point(935, 5);
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.Name = "btnMax";
            btnMax.Image = Image.FromFile(path + @"\resources\maximize_window_26px.png");

            btnMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnMax.Click += BtnMax_Click;

            header.Controls.Add(btnMax);
        }

        private void setBtnMin(Panel header)
        {
            Button btnMin = new Button();
            btnMin.Size = new Size(30, 30);
            btnMin.Location = new Point(905, 5);
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.Name = "btnMin";
            btnMin.Image = Image.FromFile(path + @"\resources\minimize_window_26px.png");

            btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnMin.Click += BtnMin_Click;

            header.Controls.Add(btnMin);
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void setAside(Panel aside)
        {
            aside.Size = new Size(150, 500);
            aside.Dock = DockStyle.Left;
            aside.BackColor = Color.FromArgb(40, 40, 40);
            aside.BorderStyle = BorderStyle.FixedSingle;
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            aside.ForeColor = Color.FromArgb(32, 178, 170);

            setSettings(aside);
            setMenu(aside);
            setOrders(aside);
            setReserve(aside);
            setTabels(aside);

            Controls.Add(aside);
        }

        private void setAsideClient(Panel aside)
        {
            aside.Size = new Size(150, 500);
            aside.Dock = DockStyle.Left;
            aside.BackColor = Color.FromArgb(40, 40, 40);
            aside.BorderStyle = BorderStyle.FixedSingle;
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            aside.ForeColor = Color.FromArgb(32, 178, 170);
            
            setSettings(aside);
            setMenuClient(aside);
            setOrdersClient(aside);
            setReserveClient(aside);
            setTabelsClient(aside);

            Controls.Add(aside);
        }

        private void setTabels(Panel aside)
        {
            Button btnTabels = new Button();
            btnTabels.Size = new Size(150, 50);
            btnTabels.Location = new Point(0, 0);
            btnTabels.FlatStyle = FlatStyle.Flat;
            btnTabels.FlatAppearance.BorderSize = 0;
            btnTabels.Text = "  Tabels";
            btnTabels.Name = "btnTabels";
            btnTabels.Image = Image.FromFile(path + @"\resources\table_40px.png");
            btnTabels.ImageAlign = ContentAlignment.MiddleCenter;
            btnTabels.TextAlign = ContentAlignment.MiddleLeft;
            btnTabels.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTabels.ForeColor = Color.White;
            btnTabels.Dock = DockStyle.Top;

            btnTabels.Click += BtnTabels_Click;

            aside.Controls.Add(btnTabels);
        }

        private void setTabelsClient(Panel aside)
        {
            Button btnTabels = new Button();
            btnTabels.Size = new Size(150, 50);
            btnTabels.Location = new Point(0, 0);
            btnTabels.FlatStyle = FlatStyle.Flat;
            btnTabels.FlatAppearance.BorderSize = 0;
            btnTabels.Text = "  Tabels";
            btnTabels.Name = "btnTabels";
            btnTabels.Image = Image.FromFile(path + @"\resources\table_40px.png");
            btnTabels.ImageAlign = ContentAlignment.MiddleCenter;
            btnTabels.TextAlign = ContentAlignment.MiddleLeft;
            btnTabels.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTabels.ForeColor = Color.White;
            btnTabels.Dock = DockStyle.Top;

            btnTabels.Click += BtnTabels_Click1;

            aside.Controls.Add(btnTabels);
        }

        private void BtnTabels_Click1(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();
            ViewTabelClient viewTabels = new ViewTabelClient();
            Main.Controls.Add(viewTabels);
        }

        private void BtnTabels_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();
            ViewTabelsStaff viewTabels = new ViewTabelsStaff();
            Main.Controls.Add(viewTabels);
        }

        private void setOrders(Panel aside)
        {
            Button btnOrders = new Button();
            btnOrders.Size = new Size(150, 50);
            btnOrders.Location = new Point(0, 50);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.Text = "   Orders";
            btnOrders.Name = "btnOrders";
            btnOrders.Image = Image.FromFile(path + @"\resources\order_history_30px.png");
            btnOrders.ImageAlign = ContentAlignment.MiddleRight;
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrders.ForeColor = Color.White;
            btnOrders.Dock = DockStyle.Top;

            btnOrders.Click += BtnOrders_Click;

            aside.Controls.Add(btnOrders);
        }

        private void setOrdersClient(Panel aside)
        {
            Button btnOrders = new Button();
            btnOrders.Size = new Size(150, 50);
            btnOrders.Location = new Point(0, 50);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.Text = "   Orders";
            btnOrders.Name = "btnOrders";
            btnOrders.Image = Image.FromFile(path + @"\resources\order_history_30px.png");
            btnOrders.ImageAlign = ContentAlignment.MiddleRight;
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrders.ForeColor = Color.White;
            btnOrders.Dock = DockStyle.Top;

            btnOrders.Click += BtnOrders_Click1;

            aside.Controls.Add(btnOrders);
        }

        private void BtnOrders_Click1(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            ViewArchiveClient viewArchive = new ViewArchiveClient();
            Main.Controls.Clear();
            Main.Controls.Add(viewArchive);
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            ViewArchiveStaff viewArchive = new ViewArchiveStaff();
            Main.Controls.Clear();
            Main.Controls.Add(viewArchive);
        }

        private void setReserve(Panel aside)
        {
            Button btnReserve = new Button();
            btnReserve.Size = new Size(150, 50);
            btnReserve.Location = new Point(0, 100);
            btnReserve.FlatStyle = FlatStyle.Flat;
            btnReserve.FlatAppearance.BorderSize = 0;
            btnReserve.Text = " Reserv";
            btnReserve.Name = "btnReserve";
            btnReserve.Image = Image.FromFile(path + @"\resources\reserve_48px.png");
            btnReserve.ImageAlign = ContentAlignment.MiddleRight;
            btnReserve.TextAlign = ContentAlignment.MiddleLeft;
            btnReserve.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReserve.ForeColor = Color.White;
            btnReserve.Dock = DockStyle.Top;

            btnReserve.Click += BtnReserve_Click;

            aside.Controls.Add(btnReserve);
        }

        private void setReserveClient(Panel aside)
        {
            Button btnReserve = new Button();
            btnReserve.Size = new Size(150, 50);
            btnReserve.Location = new Point(0, 100);
            btnReserve.FlatStyle = FlatStyle.Flat;
            btnReserve.FlatAppearance.BorderSize = 0;
            btnReserve.Text = " Reserv";
            btnReserve.Name = "btnReserve";
            btnReserve.Image = Image.FromFile(path + @"\resources\reserve_48px.png");
            btnReserve.ImageAlign = ContentAlignment.MiddleRight;
            btnReserve.TextAlign = ContentAlignment.MiddleLeft;
            btnReserve.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReserve.ForeColor = Color.White;
            btnReserve.Dock = DockStyle.Top;

            btnReserve.Click += BtnReserve_Click1;

            aside.Controls.Add(btnReserve);
        }

        private void BtnReserve_Click1(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();
            ViewOrderClient viewOrder = new ViewOrderClient();
            Main.Controls.Add(viewOrder);
        }

        private void BtnReserve_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();
            ViewOrderStaff viewOrderStaff = new ViewOrderStaff();
            Main.Controls.Add(viewOrderStaff);

        }

        private void setMenu(Panel aside)
        {
            Button btnMenu = new Button();
            btnMenu.Size = new Size(150, 50);
            btnMenu.Location = new Point(0, 100);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Text = " Menu";
            btnMenu.Name = "btnMenu";
            btnMenu.Image = Image.FromFile(path + @"\resources\waiter_48px.png");
            btnMenu.ImageAlign = ContentAlignment.MiddleCenter;
            btnMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenu.ForeColor = Color.White;
            btnMenu.Dock = DockStyle.Top;

            btnMenu.Click += BtnMenu_Click;

            aside.Controls.Add(btnMenu);
        }

        private void setMenuClient(Panel aside)
        {
            Button btnMenu = new Button();
            btnMenu.Size = new Size(150, 50);
            btnMenu.Location = new Point(0, 100);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Text = " Menu";
            btnMenu.Name = "btnMenu";
            btnMenu.Image = Image.FromFile(path + @"\resources\waiter_48px.png");
            btnMenu.ImageAlign = ContentAlignment.MiddleCenter;
            btnMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenu.ForeColor = Color.White;
            btnMenu.Dock = DockStyle.Top;

            btnMenu.Click += BtnMenu_Click1;

            aside.Controls.Add(btnMenu);
        }

        private void BtnMenu_Click1(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();
            ViewMenuClient viewMenu = new ViewMenuClient();
            Main.Controls.Add(viewMenu);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();
            ViewMenuStaff viewMenu = new ViewMenuStaff();
            Main.Controls.Add(viewMenu);
        }

        private void setSettings(Panel aside)
        {
            Button btnSettings = new Button();
            btnSettings.Size = new Size(150, 50);
            btnSettings.Location = new Point(0, 100);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.Text = " Settings";
            btnSettings.Name = "btnSettings";
            btnSettings.Image = Image.FromFile(path + @"\resources\settings_40px.png");
            btnSettings.ImageAlign = ContentAlignment.MiddleCenter;
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.ForeColor = Color.White;
            btnSettings.Dock = DockStyle.Top;

            btnSettings.Click += BtnSettings_Click;

            aside.Controls.Add(btnSettings);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);
            Main.Controls.Clear();

            CardProfil cardProfil = new CardProfil();

            cardProfil.Location = new Point(130, 100);

            cardProfil.picLogout.Click += PicLogout_Click;

            Main.Controls.Add(cardProfil);
        }

        private void PicLogout_Click(object sender, EventArgs e)
        {
            ControlCustomers.loged = null;

            Header.Controls.Clear();
            Main.Controls.Clear();
            Aside.Controls.Clear();

            this.Controls.Clear();

            setLogin();
        }

        private void setMain(Panel main)
        {
            main.Size = new Size(850, 475);
            main.Location = new Point(150, 75);
            main.BackColor = Color.FromArgb(40, 40, 40);
            main.BorderStyle = BorderStyle.FixedSingle;

            main.Anchor = AnchorStyles.None;

            Controls.Add(main);
        }

        private void ActivateBtn(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentBtn != (Button)btnSender)
                {
                    DisableBtn();
                    currentBtn = (Button)btnSender;
                    currentBtn.BackColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void DisableBtn()
        {
            foreach (Control prevBtn in Aside.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(40, 40, 40);
                }
            }
        }
    }
}
