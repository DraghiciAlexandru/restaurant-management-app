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
    class CardArchiveStaff : Panel
    {
        public Order Order;
        String path = Application.StartupPath;
        public DateTimePicker dateTime;
        public Button btnDetails;
        public Button btnEdit;
        public Button btnCancel;

        public CardArchiveStaff(Order Order)
        {
            this.Order = Order;

            layout();
        }

        private void layout()
        {
            this.Size = new Size(800, 50);
            this.AutoScroll = true;
            this.BackColor = ThemeColor.PrimaryColor;
            this.Name = "pnlArchiveStaff";
            this.Font = new Font("Showcard Gothic", 14);
            this.ForeColor = Color.White;

            setId();
            setName();
            setTabel();
            setPrice();
            setCancel();
            setDetails();
            setEdit();
            setDate();
        }

        private void setId()
        {
            Label lblId = new Label();
            lblId.Name = "lblId";

            lblId.AutoSize = false;
            lblId.Size = new Size(50, 24);

            lblId.Location = new Point(10, 10);

            lblId.Text = Order.Id.ToString();

            this.Controls.Add(lblId);
        }

        private void setName()
        {
            TextBox txtName = new TextBox();
            txtName.Name = "txtName";

            txtName.AutoSize = false;
            txtName.Size = new Size(150, 24);
            txtName.ReadOnly = true;

            txtName.Location = new Point(125, 10);

            txtName.Text = Order.ClientName;

            this.Controls.Add(txtName);
        }

        private void setTabel()
        {
            TextBox txtTabel = new TextBox();
            txtTabel.Name = "txtTabel";

            txtTabel.AutoSize = false;
            txtTabel.Size = new Size(80, 24);
            txtTabel.ReadOnly = true;

            txtTabel.Location = new Point(300, 10);

            txtTabel.Text = Order.TabelNumber.ToString();

            this.Controls.Add(txtTabel);
        }

        public void setDate()
        {
            dateTime = new DateTimePicker();
            dateTime.Name = "dateTime";
            dateTime.Location = new Point(410, 10);
            dateTime.Format = DateTimePickerFormat.Time;
            dateTime.Size = new Size(140, 31);
            dateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTime.CalendarTitleBackColor = ThemeColor.PrimaryColor;
            dateTime.CalendarTitleForeColor = Color.White;
            
            dateTime.Enabled = false;

            Controls.Add(dateTime);
        }

        private void setPrice()
        {
            TextBox txtPrice = new TextBox();
            txtPrice.Name = "txtPrice";

            txtPrice.AutoSize = false;
            txtPrice.Size = new Size(130, 24);
            txtPrice.ReadOnly = true;

            txtPrice.Location = new Point(560, 10);

            txtPrice.Text = Order.TotalPrice + "$";

            this.Controls.Add(txtPrice);
        }

        private void setDetails()
        {
            btnDetails = new Button();
            btnDetails.Size = new Size(25, 25);
            btnDetails.Location = new Point(700, 10);
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Name = "btnDetails";
            btnDetails.Image = Image.FromFile(path + @"\resources\info_24px.png");

            this.Controls.Add(btnDetails);
        }

        private void setEdit()
        {
            btnEdit = new Button();
            btnEdit.Size = new Size(25, 25);
            btnEdit.Location = new Point(730, 10);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Name = "btnEdit";
            btnEdit.Image = Image.FromFile(path + @"\resources\edit_24px.png");

            this.Controls.Add(btnEdit);
        }

        private void setCancel()
        {
            btnCancel = new Button();
            btnCancel.Size = new Size(25, 25);
            btnCancel.Location = new Point(760, 10);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Name = "btnCancel";
            btnCancel.Image = Image.FromFile(path + @"\resources\delete_document_24px.png");

            this.Controls.Add(btnCancel);
        }

        public void setOutDate()
        {
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
        }

        public void setCanceled()
        {
            btnCancel.BackColor = Color.Black;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
        }
    }
}
