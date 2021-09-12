using Restaurant.Controler;
using Restaurant.Model;
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
    class CardTabelStaff : Panel
    {
        String path = Application.StartupPath;
        private Timer timer1;
        private Timer timer2;
        private Timer timer3;
        private bool collapsed1;
        private bool collapsed2;
        private bool collapsed3;
        private FlowLayoutPanel flowMain;
        private FlowLayoutPanel flowSoup;
        private FlowLayoutPanel flowDesert;
        private ControlMenu controlMenu;
        private ControlOrderDetails cOrderDetails;
        private ControlBookings controlBookings;
        private ControlCustomers controlCustomers;
        private ControlOrders controlOrders;
        private ControlCancel controlCancel;

        private DateTimePicker dateTime;
        private Booking booking;

        public CardTabelStaff(Booking booking)
        {
            collapsed1 = true;
            collapsed2 = true;
            collapsed3 = true;
            timer1 = new Timer();
            timer2 = new Timer();
            timer3 = new Timer();
            controlMenu = new ControlMenu();
            cOrderDetails = new ControlOrderDetails();
            controlCustomers = new ControlCustomers();
            controlOrders = new ControlOrders();
            controlBookings = new ControlBookings();
            controlCancel = new ControlCancel();

            dateTime = new DateTimePicker();
            this.booking = booking;

            layout();
        }

        private void layout()
        {
            this.Size = new Size(850, 475);
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Name = "pnlOrderS";
            this.Anchor = AnchorStyles.None;
            this.Font = new Font("Showcard Gothic", 14);



            setPicProfil();
            setPicTabel();
            setPicTime();
            setPicMain();
            setPicSoup();
            setPicDesert();
            setTxtName();
            setTxtTelefon();
            setTxtEmail();
            setTxtTabel();
            setBtnSave();
            setBtnCancel();
            setOrderDetailsMain();
            setOrderDetailsSoup();
            setOrderDetailsDesert();
            setMenuMain();
            setMenuSoup();
            setMenuDesert();
            setTimer1();
            setTimer2();
            setTimer3();
            setDate();
            setDetails();
        }

        private void setPicProfil()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(15, 30);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\profile_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setPicTabel()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(315, 30);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\tableR_80px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            pic.Anchor = AnchorStyles.Top;

            this.Controls.Add(pic);
        }

        private void setPicTime()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(540, 30);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\clock_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            pic.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Controls.Add(pic);
        }

        private void setPicMain()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(15, 185);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\food_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setPicSoup()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(15, 415);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\soup_plate_96px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setPicDesert()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(15, 645);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\croissant_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setTxtName()
        {
            TextBox txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(150, 20);
            txtName.Location = new Point(130, 30);
            txtName.Name = "txtName";
            txtName.Text = controlCustomers.getClient(booking.ClientId).Nume;
            txtName.ReadOnly = true;
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.ForeColor = ThemeColor.PrimaryColor;

            this.Controls.Add(txtName);
        }

        private void setTxtTelefon()
        {
            TextBox txtTelefon = new TextBox();
            txtTelefon.AutoSize = false;
            txtTelefon.Size = new Size(150, 20);
            txtTelefon.Location = new Point(130, 70);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = "Phone number:";
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.BackColor = Color.FromArgb(40, 40, 40);
            txtTelefon.ForeColor = ThemeColor.PrimaryColor;

            txtTelefon.Text = controlCustomers.getClient(booking.ClientId).Telefon;
            txtTelefon.ReadOnly = true;

            this.Controls.Add(txtTelefon);
        }

        private void setTxtEmail()
        {
            TextBox txtEmail = new TextBox();
            txtEmail.AutoSize = false;
            txtEmail.Size = new Size(150, 20);
            txtEmail.Location = new Point(130, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Text = "Email:";
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);
            txtEmail.ForeColor = ThemeColor.PrimaryColor;

            txtEmail.Text = controlCustomers.getClient(booking.ClientId).Email;
            txtEmail.ReadOnly = true;

            this.Controls.Add(txtEmail);
        }

        private void setTxtTabel()
        {
            TextBox txtTabel = new TextBox();
            txtTabel.AutoSize = false;
            txtTabel.Size = new Size(60, 20);
            txtTabel.Location = new Point(430, 70);
            txtTabel.Name = "txtTabel";
            txtTabel.Text = booking.TabelNr.ToString();
            txtTabel.BorderStyle = BorderStyle.None;
            txtTabel.BackColor = Color.FromArgb(40, 40, 40);
            txtTabel.ForeColor = ThemeColor.PrimaryColor;

            txtTabel.Anchor = AnchorStyles.Top;
            txtTabel.ReadOnly = true;

            this.Controls.Add(txtTabel);
        }

        private void setBtnSave()
        {
            Button btnSave = new Button();
            btnSave.Size = new Size(150, 50);
            btnSave.Location = new Point(235, 850);
            btnSave.Margin = new Padding(20);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Text = "Save";
            btnSave.Name = "btnSave";
            btnSave.Image = Image.FromFile(path + @"\resources\ok_48px.png");
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.BackColor = ThemeColor.PrimaryColor;
            btnSave.ForeColor = Color.White;

            btnSave.Anchor = AnchorStyles.Top;

            btnSave.Click += BtnSave_Click;

            this.Controls.Add(btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            cOrderDetails.save();
        }

        private void setBtnCancel()
        {
            Button btnCancel = new Button();
            btnCancel.Size = new Size(150, 50);
            btnCancel.Location = new Point(420, 850);
            btnCancel.Margin = new Padding(20);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Text = "Cancel";
            btnCancel.Name = "btnCancel";
            btnCancel.Image = Image.FromFile(path + @"\resources\cancel_48px.png");
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.BackColor = ThemeColor.PrimaryColor;
            btnCancel.ForeColor = Color.White;

            btnCancel.Anchor = AnchorStyles.Top;

            btnCancel.Click += BtnCancel_Click3;

            this.Controls.Add(btnCancel);
        }

        private void BtnCancel_Click3(object sender, EventArgs e)
        {
            controlCancel.add(this.booking);
            controlCancel.save();

            Button btnS = new Button();
            Button btnC = new Button();

            foreach (Control x in Controls)
            {
                if(x.Name=="btnSave")
                    btnS = x as Button;
                if (x.Name == "btnCancel")
                    btnC = x as Button;
            }

            btnS.Enabled = false;
            btnC.Enabled = false;

        }

        public void setDate()
        {
            dateTime = new DateTimePicker();
            dateTime.Name = "dateTime";
            dateTime.Location = new Point(640, 70);
            dateTime.Format = DateTimePickerFormat.Time;
            dateTime.Size = new Size(140, 31);
            dateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTime.CalendarTitleBackColor = ThemeColor.PrimaryColor;
            dateTime.CalendarTitleForeColor = Color.White;

            dateTime.Value = booking.Date;

            dateTime.Enabled = false;

            Controls.Add(dateTime);
        }

        private void setOrderDetailsMain()
        {
            FlowLayoutPanel flowDMain = new FlowLayoutPanel();

            flowDMain.Name = "flowDMain";
            flowDMain.Size = new Size(275, 140);
            flowDMain.Location = new Point(115, 185);
            flowDMain.BorderStyle = BorderStyle.Fixed3D;
            flowDMain.AutoScroll = true;
            flowDMain.AllowDrop = true;

            flowDMain.DragEnter += FlowDMain_DragEnter;
            flowDMain.DragDrop += FlowDMain_DragDrop;

            this.Controls.Add(flowDMain);
        }

        private void FlowDMain_DragDrop(object sender, DragEventArgs e)
        {
            CardDishClient pnlDrag = (CardDishClient)e.Data.GetData(typeof(CardDishClient));
            CardDetails cardDetails = new CardDetails(pnlDrag.AbstractDish);

            cardDetails.Margin = new Padding(0, 5, 0, 5);

            cardDetails.btnCancel.Click += BtnCancel_Click;
            cardDetails.txtQuantity.TextChanged += TxtQuantity_TextChanged;

            FlowLayoutPanel flowLayout = sender as FlowLayoutPanel;

            cOrderDetails.add(new OrderDetails(0, booking.OrderId, pnlDrag.AbstractDish.Id, 1, pnlDrag.AbstractDish.Price));

            flowLayout.Controls.Add(cardDetails);
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            int nr = 0;

            if (txt.Text != "")
            {
                if (int.TryParse(txt.Text, out nr))
                {
                    cOrderDetails.updateQuantity(cOrderDetails.getDetails(booking.OrderId, ((CardDetails)txt.Parent).AbstractDish.Id).Id, nr);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            FlowLayoutPanel flowLayout = new FlowLayoutPanel();

            foreach (Control x in Controls)
            {
                if (x.Name == "flowDMain")
                    flowLayout = x as FlowLayoutPanel;
            }

            MessageBox.Show(((CardDetails)btn.Parent).AbstractDish.Id.ToString());

            cOrderDetails.remove(((CardDetails)btn.Parent).AbstractDish.Id);
            flowLayout.Controls.Remove(btn.Parent);

        }

        private void FlowDMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardDishClient)))
            {
                CardDishClient pnlEnter = (CardDishClient)e.Data.GetData(typeof(CardDishClient));
                if (pnlEnter.AbstractDish is MainDish)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void setOrderDetailsSoup()
        {
            FlowLayoutPanel flowDSoup = new FlowLayoutPanel();

            flowDSoup.Name = "flowDSoup";
            flowDSoup.Size = new Size(275, 140);
            flowDSoup.Location = new Point(115, 415);
            flowDSoup.BorderStyle = BorderStyle.Fixed3D;
            flowDSoup.AutoScroll = true;
            flowDSoup.AllowDrop = true;

            flowDSoup.DragEnter += FlowDSoup_DragEnter;
            flowDSoup.DragDrop += FlowDSoup_DragDrop;

            this.Controls.Add(flowDSoup);
        }

        private void FlowDSoup_DragDrop(object sender, DragEventArgs e)
        {
            CardDishClient pnlDrag = (CardDishClient)e.Data.GetData(typeof(CardDishClient));
            CardDetails cardDetails = new CardDetails(pnlDrag.AbstractDish);

            cardDetails.Margin = new Padding(0, 5, 0, 5);

            cardDetails.btnCancel.Click += BtnCancel_Click1;
            cardDetails.txtQuantity.TextChanged += TxtQuantity_TextChanged;

            FlowLayoutPanel flowLayout = sender as FlowLayoutPanel;

            cOrderDetails.add(new OrderDetails(0, booking.OrderId, pnlDrag.AbstractDish.Id, 1, pnlDrag.AbstractDish.Price));

            flowLayout.Controls.Add(cardDetails);
        }

        private void BtnCancel_Click1(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            FlowLayoutPanel flowLayout = new FlowLayoutPanel();

            foreach (Control x in Controls)
            {
                if (x.Name == "flowDSoup")
                    flowLayout = x as FlowLayoutPanel;
            }

            cOrderDetails.remove(((CardDetails)btn.Parent).AbstractDish.Id);
            flowLayout.Controls.Remove(btn.Parent);
        }

        private void FlowDSoup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardDishClient)))
            {
                CardDishClient pnlEnter = (CardDishClient)e.Data.GetData(typeof(CardDishClient));
                if (pnlEnter.AbstractDish is SoupDish)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void setOrderDetailsDesert()
        {
            FlowLayoutPanel flowDDesert = new FlowLayoutPanel();

            flowDDesert.Name = "flowDDesert";
            flowDDesert.Size = new Size(275, 140);
            flowDDesert.Location = new Point(115, 645);
            flowDDesert.BorderStyle = BorderStyle.Fixed3D;
            flowDDesert.AutoScroll = true;
            flowDDesert.AllowDrop = true;

            flowDDesert.DragEnter += FlowDDesert_DragEnter;
            flowDDesert.DragDrop += FlowDDesert_DragDrop;


            this.Controls.Add(flowDDesert);
        }

        private void FlowDDesert_DragDrop(object sender, DragEventArgs e)
        {
            CardDishClient pnlDrag = (CardDishClient)e.Data.GetData(typeof(CardDishClient));
            CardDetails cardDetails = new CardDetails(pnlDrag.AbstractDish);

            cardDetails.Margin = new Padding(0, 5, 0, 5);

            cardDetails.btnCancel.Click += BtnCancel_Click2;
            cardDetails.txtQuantity.TextChanged += TxtQuantity_TextChanged;

            FlowLayoutPanel flowLayout = sender as FlowLayoutPanel;

            cOrderDetails.add(new OrderDetails(0, booking.OrderId, pnlDrag.AbstractDish.Id, 1, pnlDrag.AbstractDish.Price));

            flowLayout.Controls.Add(cardDetails);
        }

        private void BtnCancel_Click2(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            FlowLayoutPanel flowLayout = new FlowLayoutPanel();

            foreach (Control x in Controls)
            {
                if (x.Name == "flowDDesert")
                    flowLayout = x as FlowLayoutPanel;
            }

            cOrderDetails.remove(((CardDetails)btn.Parent).AbstractDish.Id);
            flowLayout.Controls.Remove(btn.Parent);
        }

        private void FlowDDesert_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardDishClient)))
            {
                CardDishClient pnlEnter = (CardDishClient)e.Data.GetData(typeof(CardDishClient));
                if (pnlEnter.AbstractDish is DesertDish)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void setMenuMain()
        {
            flowMain = new FlowLayoutPanel();

            flowMain.Name = "flowMain";
            flowMain.Size = new Size(420, 60);
            flowMain.Location = new Point(390, 185);
            flowMain.BorderStyle = BorderStyle.Fixed3D;
            flowMain.AutoScroll = true;
            flowMain.MaximumSize = new Size(420, 250);
            flowMain.MinimumSize = new Size(420, 60);

            setMainDrop(flowMain);

            this.Controls.Add(flowMain);
        }

        private void setMainDrop(FlowLayoutPanel flowMain)
        {
            Button btnDropMain = new Button();
            btnDropMain.Size = new Size(390, 50);
            btnDropMain.Location = new Point(0, 0);
            btnDropMain.FlatStyle = FlatStyle.Flat;
            btnDropMain.Text = "Main";
            btnDropMain.Name = "btnDropMain";
            btnDropMain.Image = Image.FromFile(path + @"\resources\dropdown_field_48px.png");
            btnDropMain.ImageAlign = ContentAlignment.MiddleRight;
            btnDropMain.TextAlign = ContentAlignment.MiddleCenter;
            btnDropMain.BackColor = ThemeColor.PrimaryColor;
            btnDropMain.ForeColor = Color.White;

            btnDropMain.Click += BtnDropMain_Click;

            flowMain.Controls.Add(btnDropMain);
        }

        private void BtnDropMain_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Size == new Size(410, 50))
            {
                btn.Size = new Size(390, 50);
            }
            else
            {
                btn.Size = new Size(410, 50);
            }

            timer1.Start();
            setItem("main");
        }

        private void setMenuSoup()
        {
            flowSoup = new FlowLayoutPanel();

            flowSoup.Name = "flowSoup";
            flowSoup.Size = new Size(420, 60);
            flowSoup.Location = new Point(390, 415);
            flowSoup.BorderStyle = BorderStyle.Fixed3D;
            flowSoup.AutoScroll = true;
            flowSoup.MaximumSize = new Size(420, 250);
            flowSoup.MinimumSize = new Size(420, 60);

            setSoupDrop(flowSoup);

            this.Controls.Add(flowSoup);
        }

        private void setSoupDrop(FlowLayoutPanel flowMain)
        {
            Button btnDropSoup = new Button();
            btnDropSoup.Size = new Size(390, 50);
            btnDropSoup.Location = new Point(0, 0);
            btnDropSoup.FlatStyle = FlatStyle.Flat;
            btnDropSoup.Text = "Soup";
            btnDropSoup.Name = "btnDropSoup";
            btnDropSoup.Image = Image.FromFile(path + @"\resources\dropdown_field_48px.png");
            btnDropSoup.ImageAlign = ContentAlignment.MiddleRight;
            btnDropSoup.TextAlign = ContentAlignment.MiddleCenter;
            btnDropSoup.BackColor = ThemeColor.PrimaryColor;
            btnDropSoup.ForeColor = Color.White;

            btnDropSoup.Click += BtnDropSoup_Click;

            flowMain.Controls.Add(btnDropSoup);
        }

        private void BtnDropSoup_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Size == new Size(410, 50))
            {
                btn.Size = new Size(390, 50);
            }
            else
            {
                btn.Size = new Size(410, 50);
            }

            timer2.Start();
            setItem("soup");
        }

        private void setMenuDesert()
        {
            flowDesert = new FlowLayoutPanel();

            flowDesert.Name = "flowDesert";
            flowDesert.Size = new Size(420, 60);
            flowDesert.Location = new Point(390, 645);
            flowDesert.BorderStyle = BorderStyle.Fixed3D;
            flowDesert.AutoScroll = true;
            flowDesert.MaximumSize = new Size(420, 250);
            flowDesert.MinimumSize = new Size(420, 60);

            setDesertDrop(flowDesert);

            this.Controls.Add(flowDesert);
        }

        private void setDesertDrop(FlowLayoutPanel flowMain)
        {
            Button btnDropDesert = new Button();
            btnDropDesert.Size = new Size(390, 50);
            btnDropDesert.Location = new Point(0, 0);
            btnDropDesert.FlatStyle = FlatStyle.Flat;
            btnDropDesert.Text = "Desert";
            btnDropDesert.Name = "btnDropDesert";
            btnDropDesert.Image = Image.FromFile(path + @"\resources\dropdown_field_48px.png");
            btnDropDesert.ImageAlign = ContentAlignment.MiddleRight;
            btnDropDesert.TextAlign = ContentAlignment.MiddleCenter;
            btnDropDesert.BackColor = ThemeColor.PrimaryColor;
            btnDropDesert.ForeColor = Color.White;

            btnDropDesert.Click += BtnDropDesert_Click;

            flowMain.Controls.Add(btnDropDesert);
        }

        private void BtnDropDesert_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Size == new Size(410, 50))
            {
                btn.Size = new Size(390, 50);
            }
            else
            {
                btn.Size = new Size(410, 50);
            }

            timer3.Start();
            setItem("desert");
        }

        private void setTimer1()
        {
            timer1.Interval = 15;

            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (collapsed1 == true)
            {
                flowMain.Height += 10;
                if (flowMain.Size == flowMain.MaximumSize)
                {
                    timer1.Stop();
                    collapsed1 = false;
                    flowMain.AutoScroll = true;
                }
            }
            else
            {
                flowMain.Height -= 10;
                if (flowMain.Size == flowMain.MinimumSize)
                {
                    timer1.Stop();
                    collapsed1 = true;
                    flowMain.AutoScroll = false;
                }
            }
        }

        private void setTimer2()
        {
            timer2.Interval = 15;

            timer2.Tick += Timer2_Tick;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (collapsed2 == true)
            {
                flowSoup.Height += 10;
                if (flowSoup.Size == flowSoup.MaximumSize)
                {
                    timer2.Stop();
                    collapsed2 = false;
                    flowSoup.AutoScroll = true;
                }
            }
            else
            {
                flowSoup.Height -= 10;
                if (flowSoup.Size == flowSoup.MinimumSize)
                {
                    timer2.Stop();
                    collapsed2 = true;
                    flowSoup.AutoScroll = false;
                }
            }
        }

        private void setTimer3()
        {
            timer3.Interval = 15;

            timer3.Tick += Timer3_Tick;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (collapsed3 == true)
            {
                flowDesert.Height += 10;
                if (flowDesert.Size == flowDesert.MaximumSize)
                {
                    timer3.Stop();
                    collapsed3 = false;
                    flowDesert.AutoScroll = true;
                }
            }
            else
            {
                flowDesert.Height -= 10;
                if (flowDesert.Size == flowDesert.MinimumSize)
                {
                    timer3.Stop();
                    collapsed3 = true;
                    flowDesert.AutoScroll = false;
                }
            }
        }

        private void setItem(String type)
        {
            ListaSimpla<AbstractDish> dishList = new ListaSimpla<AbstractDish>();

            if (type == "main")
            {
                flowMain.Controls.Clear();
                setMainDrop(flowMain);
                dishList = controlMenu.getMain();
            }
            else if (type == "soup")
            {
                flowSoup.Controls.Clear();
                setSoupDrop(flowSoup);
                dishList = controlMenu.getSoup();
            }
            else
            {
                flowDesert.Controls.Clear();
                setDesertDrop(flowDesert);
                dishList = controlMenu.getDesert();
            }

            for (int i = 0; i < dishList.size(); i++)
            {
                CardDishClient cardDish = new CardDishClient(dishList.getAtPosition(i));

                cardDish.Margin = new Padding(50, 10, 0, 10);

                if (type == "main")
                    flowMain.Controls.Add(cardDish);
                else if (type == "soup")
                    flowSoup.Controls.Add(cardDish);
                else
                    flowDesert.Controls.Add(cardDish);
            }

        }

        private void setDetails()
        {
            FlowLayoutPanel flowMain = new FlowLayoutPanel();
            FlowLayoutPanel flowSoup = new FlowLayoutPanel();
            FlowLayoutPanel flowDesert = new FlowLayoutPanel();

            foreach (Control x in Controls)
            {
                if (x.Name == "flowDMain")
                    flowMain = x as FlowLayoutPanel;
                if (x.Name == "flowDSoup")
                    flowSoup = x as FlowLayoutPanel;
                if (x.Name == "flowDDesert")
                    flowDesert = x as FlowLayoutPanel;
            }

            ListaSimpla<OrderDetails> listaDetails = cOrderDetails.getOrderDetails(booking.OrderId);

            for (int i = 0; i < listaDetails.size(); i++)
            {
                if (controlMenu.getTip(listaDetails.getAtPosition(i).DishId) == "Main")
                {
                    CardDetails card = new CardDetails(controlMenu.getDish(listaDetails.getAtPosition(i).DishId));
                    card.txtQuantity.Text = listaDetails.getAtPosition(i).Quantity.ToString();

                    card.btnCancel.Click += BtnCancel_Click;
                    card.txtQuantity.TextChanged += TxtQuantity_TextChanged;

                    flowMain.Controls.Add(card);
                }
                else if (controlMenu.getTip(listaDetails.getAtPosition(i).DishId) == "Soup")
                {
                    CardDetails card = new CardDetails(controlMenu.getDish(listaDetails.getAtPosition(i).DishId));
                    card.txtQuantity.Text = listaDetails.getAtPosition(i).Quantity.ToString();

                    card.btnCancel.Click += BtnCancel_Click;
                    card.txtQuantity.TextChanged += TxtQuantity_TextChanged;

                    flowSoup.Controls.Add(card);
                }
                else
                {
                    CardDetails card = new CardDetails(controlMenu.getDish(listaDetails.getAtPosition(i).DishId));
                    card.txtQuantity.Text = listaDetails.getAtPosition(i).Quantity.ToString();

                    card.btnCancel.Click += BtnCancel_Click;
                    card.txtQuantity.TextChanged += TxtQuantity_TextChanged;

                    flowDesert.Controls.Add(card);
                }
            }
        }

        public void setOutDate()
        {
            Button btnSave = new Button();
            Button btnCancel = new Button();

            foreach (Control x in Controls)
            {
                if (x.Name == "btnSave")
                    btnSave = x as Button;
                if (x.Name == "btnCancel")
                    btnCancel = x as Button;
            }

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
    }
}
