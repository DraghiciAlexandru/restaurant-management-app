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
    class ViewArchiveStaff : Panel
    {
        String path = Application.StartupPath;
        private ControlOrders controlOrders;
        private ControlBookings controlBookings;
        private ControlCancel controlCancel;
        private FlowLayoutPanel flowLayout;


        public ViewArchiveStaff()
        {
            controlOrders = new ControlOrders();
            controlBookings = new ControlBookings();
            controlCancel = new ControlCancel();

            layout();
        }

        private void layout()
        {
            this.Size = new Size(834, 464);
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Name = "pnlArchive";
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Font = new Font("Showcard Gothic", 14);
            this.ForeColor = ThemeColor.PrimaryColor;

            setPic();
            setId();
            setName();
            setTabel();
            setDate();
            setFlow();
            setOrders();
        }

        private void setPic()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(40, 40);
            pic.Location = new Point(15, 15);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\search_64px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            pic.Click += Pic_Click;

            this.Controls.Add(pic);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            TextBox txtId = new TextBox();
            TextBox txtName = new TextBox();
            TextBox txtTabel = new TextBox();
            TextBox txtDate = new TextBox();

            foreach(Control x in Controls)
            {
                if (x.Name == "txtId")
                    txtId = x as TextBox;
                if (x.Name == "txtName")
                    txtName = x as TextBox;
                if (x.Name == "txtTabel")
                    txtTabel = x as TextBox;
                if (x.Name == "txtDate")
                    txtDate = x as TextBox;
            }

            controlOrders = new ControlOrders();
            ListaSimpla<Order> list = controlOrders.orders;

            for (int i = 0; i < controlOrders.orders.size(); i++)
            {
                if (txtId.Text != "ID:")
                {
                    if ((controlOrders.orders.getAtPosition(i) != null) && (controlOrders.orders.getAtPosition(i).Id != int.Parse(txtId.Text))) 
                    {
                        list.deletePosition(list.position(controlOrders.orders.getAtPosition(i)));
                        i--;
                    }
                }
                if (txtName.Text != "Name:")
                {
                    if ((controlOrders.orders.getAtPosition(i) != null) && (controlOrders.orders.getAtPosition(i).ClientName != txtName.Text)) 
                    {
                        list.deletePosition(list.position(controlOrders.orders.getAtPosition(i)));
                        i--;
                    }
                }
                if (txtTabel.Text != "Tabel:")
                {
                    if ((controlOrders.orders.getAtPosition(i) != null) && (controlOrders.orders.getAtPosition(i).TabelNumber != int.Parse(txtTabel.Text))) 
                    {
                        list.deletePosition(list.position(controlOrders.orders.getAtPosition(i)));
                        i--;
                    }
                }
                if (txtDate.Text != "Date:")
                {
                    DateTime dateTime = new DateTime();
                    if (DateTime.TryParse(txtTabel.Text, out dateTime))
                    {
                        if ((controlOrders.orders.getAtPosition(i) != null) && (controlBookings.getByOrder(controlOrders.orders.getAtPosition(i).Id).CompareTo(new Booking(0, 0, 0, controlOrders.orders.getAtPosition(i).TabelNumber, dateTime)) != 0)) 
                        {
                            list.deletePosition(list.position(controlOrders.orders.getAtPosition(i)));
                            i--;
                        }
                    }
                }
            }

            flowLayout.Controls.Clear();
            setOrders(list);
        }

        private void setId()
        {
            TextBox txtId = new TextBox();
            txtId.Name = "txtId";

            txtId.AutoSize = false;
            txtId.Size = new Size(50, 24);

            txtId.Location = new Point(60, 25);

            txtId.Text = "ID:";
            txtId.BackColor = Color.FromArgb(40, 40, 40);
            txtId.BorderStyle = BorderStyle.None;
            txtId.ForeColor = ThemeColor.PrimaryColor;

            txtId.Enter += Txt_Enter;
            txtId.Leave += Txt_Leave;

            this.Controls.Add(txtId);
        }

        private void setName()
        {
            TextBox txtName = new TextBox();
            txtName.Name = "txtName";

            txtName.AutoSize = false;
            txtName.Size = new Size(150, 24);

            txtName.Location = new Point(140, 25);

            txtName.Text = "Name:";
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.BorderStyle = BorderStyle.None;
            txtName.ForeColor = ThemeColor.PrimaryColor;

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            this.Controls.Add(txtName);
        }

        private void setTabel()
        {
            TextBox txtTabel = new TextBox();
            txtTabel.Name = "txtTabel";

            txtTabel.AutoSize = false;
            txtTabel.Size = new Size(100, 24);

            txtTabel.Location = new Point(315, 25);

            txtTabel.Text = "Tabel:";
            txtTabel.BackColor = Color.FromArgb(40, 40, 40);
            txtTabel.BorderStyle = BorderStyle.None;
            txtTabel.ForeColor = ThemeColor.PrimaryColor;

            txtTabel.Enter += Txt_Enter;
            txtTabel.Leave += Txt_Leave;

            this.Controls.Add(txtTabel);
        }

        private void setDate()
        {
            TextBox txtDate = new TextBox();
            txtDate.Name = "txtDate";

            txtDate.AutoSize = false;
            txtDate.Size = new Size(150, 24);

            txtDate.Location = new Point(420, 25);

            txtDate.Text = "Date:";
            txtDate.BackColor = Color.FromArgb(40, 40, 40);
            txtDate.BorderStyle = BorderStyle.None;
            txtDate.ForeColor = ThemeColor.PrimaryColor;

            txtDate.Enter += Txt_Enter;
            txtDate.Leave += Txt_Leave;

            this.Controls.Add(txtDate);
        }

        private void setFlow()
        {
            flowLayout = new FlowLayoutPanel();

            flowLayout.Size = new Size(825, 350);
            flowLayout.Location = new Point(10, 80);
            flowLayout.Anchor = AnchorStyles.Top;
            flowLayout.BorderStyle = BorderStyle.FixedSingle;
            flowLayout.WrapContents = true;
            flowLayout.AutoScroll = true;

            this.Controls.Add(flowLayout);
        }

        private void setOrders()
        {
            for (int i = 0; i < controlOrders.orders.size(); i++)
            {
                CardArchiveStaff cardArchive = new CardArchiveStaff(controlOrders.orders.getAtPosition(i));

                cardArchive.dateTime.Value = controlBookings.getByOrder(controlOrders.orders.getAtPosition(i).Id).Date;

                cardArchive.btnDetails.Click += BtnDetails_Click;
                cardArchive.btnEdit.Click += BtnEdit_Click;
                cardArchive.btnCancel.Click += BtnCancel_Click;

                if (cardArchive.dateTime.Value.CompareTo(DateTime.Now) != 1) 
                {
                    cardArchive.setOutDate();
                }
                if(controlCancel.isCancel(controlBookings.getByOrder(cardArchive.Order.Id).Id))
                {
                    cardArchive.setCanceled();
                }

                flowLayout.Controls.Add(cardArchive);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            CardArchiveStaff cardArchive = btn.Parent as CardArchiveStaff;

            controlCancel.add(controlBookings.getByOrder(cardArchive.Order.Id));
            controlCancel.save();

            cardArchive.setCanceled();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            CardArchiveStaff cardArchive = btn.Parent as CardArchiveStaff;

            TextBox txtName = new TextBox();
            TextBox txtTabel = new TextBox();
            DateTimePicker dateTime = new DateTimePicker();

            foreach (Control x in cardArchive.Controls) 
            {
                if (x.Name == "txtName")
                    txtName = x as TextBox;
                if (x.Name == "txtTabel")
                    txtTabel = x as TextBox;
                if (x.Name == "dateTime")
                    dateTime = x as DateTimePicker;
            }

            txtName.ReadOnly = false;
            txtTabel.ReadOnly = false;
            dateTime.Enabled = true;

            txtName.TextChanged += TxtName_TextChanged;
            txtTabel.TextChanged += TxtTabel_TextChanged;
            dateTime.ValueChanged += DateTime_ValueChanged;
        }

        private void DateTime_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker date = sender as DateTimePicker;

            CardArchiveStaff cardArchive = date.Parent as CardArchiveStaff;

            controlBookings.getByOrder(cardArchive.Order.Id).Date = (controlBookings.getClose(new Booking(0, 0, 0, cardArchive.Order.TabelNumber, date.Value))).Date;

            controlBookings.save();
        }

        private void TxtTabel_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            CardArchiveStaff cardArchive = txt.Parent as CardArchiveStaff;

            if (txt.Text.Trim() != "")
            {
                controlOrders.updateTabel(cardArchive.Order.Id, int.Parse(txt.Text));
                controlOrders.save();
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            CardArchiveStaff cardArchive = txt.Parent as CardArchiveStaff;

            if (txt.Text.Trim() != "") 
            {
                controlOrders.updateName(cardArchive.Order.Id, txt.Text);
                controlOrders.save();
            }
        }

        private void setOrders(ListaSimpla<Order> list)
        {
            for (int i = 0; i < list.size(); i++)
            {
                CardArchiveStaff cardArchive = new CardArchiveStaff(list.getAtPosition(i));

                cardArchive.dateTime.Value = controlBookings.getByOrder(list.getAtPosition(i).Id).Date;

                cardArchive.btnDetails.Click += BtnDetails_Click;
                cardArchive.btnEdit.Click += BtnEdit_Click;
                cardArchive.btnCancel.Click += BtnCancel_Click;

                if (cardArchive.dateTime.Value.CompareTo(DateTime.Now) != 1)
                {
                    cardArchive.setOutDate();
                }
                if (controlCancel.isCancel(controlBookings.getByOrder(cardArchive.Order.Id).Id))
                {
                    cardArchive.setCanceled();
                }

                flowLayout.Controls.Add(cardArchive);
            }
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            CardArchiveStaff cardArchive = btn.Parent as CardArchiveStaff;
            CardTabelStaff cardTabel = new CardTabelStaff(controlBookings.getByOrder(cardArchive.Order.Id));

            if (cardArchive.dateTime.Value.CompareTo(DateTime.Now) != 1)
            {
                cardTabel.setOutDate();
            }

            this.Controls.Clear();

            Controls.Add(cardTabel);
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text.Trim(' ') == "")
            {
                if (text.Name == "txtId")
                    text.Text = "ID:";
                else if (text.Name == "txtName")
                    text.Text = "Name:";
                else if (text.Name == "txtDate")
                    text.Text = "Date:";
                else if (text.Name == "txtTabel")
                    text.Text = "Tabel:";
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "ID:" || text.Text == "Date:" || text.Text == "Tabel:")
            {
                text.Text = "";
            }
        }

    }
}
