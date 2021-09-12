using Restaurant.Model;
using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Restaurant.Template
{
    class CardDetails : Panel
    {
        public AbstractDish AbstractDish;
        public int Quantity = 1;
        String path = Application.StartupPath;
        public Label lblPrice;
        public Button btnCancel;
        public TextBox txtQuantity;

        public CardDetails(AbstractDish AbstractDish)
        {
            this.AbstractDish = AbstractDish;
            layout();
        }

        private void layout()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = ThemeColor.SecondaryColor;
            this.Font = new Font("Showcard Gothic", 10);
            this.ForeColor = Color.White;
            this.Size = new Size(250, 50);

            setPic();
            setName();
            setPrice();
            setQuantity();
            setDelete();
        }

        private void setPic()
        {
            PictureBox pic = new PictureBox();
            pic.Name = "pic";

            pic.Size = new Size(40, 40);
            pic.Location = new Point(5, 5);

            pic.BackgroundImage = AbstractDish.Picture;
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setName()
        {
            Label lblName = new Label();
            lblName.Name = "lblName";

            lblName.Location = new Point(50, 17);

            lblName.Text = AbstractDish.Name;

            this.Controls.Add(lblName);
        }

        private void setPrice()
        {
            lblPrice = new Label();
            lblPrice.Name = "lblPrice";

            lblPrice.AutoSize = false;
            lblPrice.Size = new Size(40, 20);
            lblPrice.Location = new Point(180, 17);

            lblPrice.Text = AbstractDish.Price + "$";

            this.Controls.Add(lblPrice);
        }

        private void setQuantity()
        {
            txtQuantity = new TextBox();
            txtQuantity.AutoSize = false;
            txtQuantity.Size = new Size(20, 20);
            txtQuantity.Location = new Point(155, 15);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Text = "1";
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.BorderStyle = BorderStyle.None;
            txtQuantity.BackColor = ThemeColor.PrimaryColor;
            txtQuantity.ForeColor = Color.FromArgb(40, 40, 40);

            txtQuantity.TextChanged += TxtQuantity_TextChanged;

            this.Controls.Add(txtQuantity);
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            int nr = 0;

            if (txt.Text != "")
            {
                if (int.TryParse(txt.Text, out nr))
                {
                    Quantity = nr;
                    lblPrice.Text = AbstractDish.Price * nr + "$";
                }
            }
        }

        private void setDelete()
        {
            btnCancel = new Button();
            btnCancel.Size = new Size(25, 25);
            btnCancel.Location = new Point(220, 12);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Name = "btnCancel";
            btnCancel.Image = Image.FromFile(path + @"\resources\delete_document_24px.png");

            this.Controls.Add(btnCancel);
        }
    }
}
