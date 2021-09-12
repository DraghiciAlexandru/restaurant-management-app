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
    class ViewOrderStaff : Panel
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

        private DateTimePicker dateTime;

        public ViewOrderStaff()
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

            dateTime = new DateTimePicker();

            layout();
        }

        private void layout()
        {
            this.Size = new Size(850, 475);
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Name = "pnlOrderS";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            setBtnComplete();
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
            txtName.Text = "Name:";
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.ForeColor = ThemeColor.PrimaryColor;

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            this.Controls.Add(txtName);
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
            TextBox txtTelefon = new TextBox();
            txtTelefon.AutoSize = false;
            txtTelefon.Size = new Size(150, 20);
            txtTelefon.Location = new Point(130, 70);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = "Phone number:";
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.BackColor = Color.FromArgb(40, 40, 40);
            txtTelefon.ForeColor = ThemeColor.PrimaryColor;

            txtTelefon.Enter += Txt_Enter;
            txtTelefon.Leave += Txt_Leave;

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

            txtEmail.Enter += Txt_Enter;
            txtEmail.Leave += Txt_Leave;

            this.Controls.Add(txtEmail);
        }

        private void setTxtTabel()
        {
            TextBox txtTabel = new TextBox();
            txtTabel.AutoSize = false;
            txtTabel.Size = new Size(60, 20);
            txtTabel.Location = new Point(430, 70);
            txtTabel.Name = "txtTabel";
            txtTabel.Text = "Tabel:";
            txtTabel.BorderStyle = BorderStyle.None;
            txtTabel.BackColor = Color.FromArgb(40, 40, 40);
            txtTabel.ForeColor = ThemeColor.PrimaryColor;

            txtTabel.Anchor = AnchorStyles.Top;

            txtTabel.Enter += Txt_Enter;
            txtTabel.Leave += Txt_Leave;

            this.Controls.Add(txtTabel);
        }

        private void setBtnComplete()
        {
            Button btnComplete = new Button();
            btnComplete.Size = new Size(170, 50);
            btnComplete.Location = new Point(360, 850);
            btnComplete.Margin = new Padding(20);
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Text = "Complete";
            btnComplete.Name = "btnComplete";
            btnComplete.Image = Image.FromFile(path + @"\resources\checklist_48px.png");
            btnComplete.ImageAlign = ContentAlignment.MiddleLeft;
            btnComplete.TextAlign = ContentAlignment.MiddleLeft;
            btnComplete.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnComplete.BackColor = ThemeColor.PrimaryColor;
            btnComplete.ForeColor = Color.White;

            btnComplete.Anchor = AnchorStyles.Top;

            btnComplete.Click += BtnComplete_Click;

            this.Controls.Add(btnComplete);
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            TextBox txtName = new TextBox();
            TextBox txtEmail = new TextBox();
            TextBox txtTelefon = new TextBox();
            TextBox txtTabel = new TextBox();

            FlowLayoutPanel flowMain = new FlowLayoutPanel();
            FlowLayoutPanel flowSoup = new FlowLayoutPanel();
            FlowLayoutPanel flowDesert = new FlowLayoutPanel();

            foreach (Control x in Controls)
            {
                if (x.Name == "txtName")
                    txtName = x as TextBox;
                if (x.Name == "txtEmail")
                    txtEmail = x as TextBox;
                if (x.Name == "txtTelefon")
                    txtTelefon = x as TextBox;
                if (x.Name == "txtTabel")
                    txtTabel = x as TextBox;
                if (x.Name == "flowDMain")
                    flowMain = x as FlowLayoutPanel;
                if (x.Name == "flowDSoup")
                    flowSoup = x as FlowLayoutPanel;
                if (x.Name == "flowDDesert")
                    flowDesert = x as FlowLayoutPanel;
            }


            Person client = controlCustomers.getClient(txtName.Text);

            int cID = 0;

            if (client != null) 
            {
                cID = client.ID;
            }

            Order order = new Order(1, cID, txtName.Text, int.Parse(txtTabel.Text), 0);

            controlOrders.add(order);

            

            Booking booking = new Booking(1, cID, order.Id, int.Parse(txtTabel.Text), new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, 0));
            
            controlBookings.add(booking);

            ListaSimpla<CardDetails> listaDetails = new ListaSimpla<CardDetails>();

            foreach (Control x in flowMain.Controls)
            {
                if (x is CardDetails) 
                {
                    CardDetails card = x as CardDetails;
                    listaDetails.addFinish(card);
                }
            }
            foreach (Control x in flowSoup.Controls)
            {
                if (x is CardDetails)
                {
                    CardDetails card = x as CardDetails;
                    listaDetails.addFinish(card);
                }
            }
            foreach (Control x in flowDesert.Controls)
            {
                if (x is CardDetails)
                {
                    CardDetails card = x as CardDetails;
                    listaDetails.addFinish(card);
                }
            }

            double total = 0;
            for (int i = 0; i < listaDetails.size(); i++) 
            {
                OrderDetails orderDetails = new OrderDetails(1, order.Id, listaDetails.getAtPosition(i).AbstractDish.Id, listaDetails.getAtPosition(i).Quantity, double.Parse(listaDetails.getAtPosition(i).lblPrice.Text.Replace("$", null)));
                total += double.Parse(listaDetails.getAtPosition(i).lblPrice.Text.Replace("$", null));
                cOrderDetails.add(orderDetails);
            }

            controlOrders.updateTotal(controlOrders.lastId() - 1, total);


            controlBookings.save();
            cOrderDetails.save();
            controlOrders.save();
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

            FlowLayoutPanel flowLayout = sender as FlowLayoutPanel;

            flowLayout.Controls.Add(cardDetails);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            FlowLayoutPanel flowLayout = new FlowLayoutPanel();

            foreach(Control x in Controls)
            {
                if (x.Name == "flowDMain")
                    flowLayout = x as FlowLayoutPanel;
            }

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

            FlowLayoutPanel flowLayout = sender as FlowLayoutPanel;

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

            FlowLayoutPanel flowLayout = sender as FlowLayoutPanel;

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
            if(btn.Size==new Size(410, 50))
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
    }
}
