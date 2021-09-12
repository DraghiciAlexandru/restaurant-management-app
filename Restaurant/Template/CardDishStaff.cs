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
    class CardDishStaff : Panel
    {
        public AbstractDish AbstractDish;
        String path = Application.StartupPath;
        public TextBox txtName;
        public TextBox txtPrice;
        public Button btnEdit;
        public Button btnDel;

        public CardDishStaff(AbstractDish AbstractDish)
        {
            this.AbstractDish = AbstractDish;

            layout();
        }

        private void layout()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = ThemeColor.SecondaryColor;
            this.Font = new Font("Showcard Gothic", 14);
            this.ForeColor = Color.White;
            this.Size = new Size(300, 150);

            setPic();
            setName();
            setPrice();
            setEdit();
            setDelete();
        }

        private void setPic()
        {
            PictureBox pic = new PictureBox();
            pic.Name = "pic";

            pic.Size = new Size(120, 120);
            pic.Location = new Point(15, 15);

            pic.BackgroundImage = AbstractDish.Picture;
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setName()
        {
            txtName = new TextBox();
            txtName.Name = "txtName";

            txtName.AutoSize = false;
            txtName.ReadOnly = true;
            txtName.Size = new Size(150, 50);

            txtName.Location = new Point(145, 15);

            txtName.Text = AbstractDish.Name;

            this.Controls.Add(txtName);
        }

        private void setPrice()
        {
            txtPrice = new TextBox();
            txtPrice.Name = "txtPrice";

            txtPrice.AutoSize = false;
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(70, 30);

            txtPrice.Location = new Point(145, 75);

            txtPrice.Text = AbstractDish.Price + "$";

            this.Controls.Add(txtPrice);
        }

        private void setEdit()
        {
            btnEdit = new Button();
            btnEdit.Size = new Size(25, 25);
            btnEdit.Location = new Point(240, 120);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Name = "btnEdit";
            btnEdit.Image = Image.FromFile(path + @"\resources\edit_24px.png");

            this.Controls.Add(btnEdit);
        }

        private void setDelete()
        {
            btnDel = new Button();
            btnDel.Size = new Size(25, 25);
            btnDel.Location = new Point(270, 120);
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.Name = "btnDel";
            btnDel.Image = Image.FromFile(path + @"\resources\delete_document_24px.png");

            this.Controls.Add(btnDel);
        }

        public void setEditMode()
        {
            txtName.ReadOnly = false;
            txtPrice.ReadOnly = false;
            txtPrice.Text = AbstractDish.Price.ToString();
        }
    }
}
