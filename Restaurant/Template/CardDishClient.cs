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
    class CardDishClient : Panel
    {
        public AbstractDish AbstractDish;
        String path = Application.StartupPath;

        public CardDishClient(AbstractDish AbstractDish)
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

            this.MouseDown += CardDishClient_MouseDown;

            setPic();
            setName();
            setPrice();

            foreach(Control x in Controls)
            {
                x.MouseDown += CardDishClient_MouseDown;
            }
        }

        private void CardDishClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Copy);
            }
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
            Label lblName = new Label();
            lblName.Name = "lblName";

            lblName.AutoSize = false;
            lblName.Size = new Size(150, 50);

            lblName.Location = new Point(145, 15);

            lblName.Text = AbstractDish.Name;

            this.Controls.Add(lblName);
        }

        private void setPrice()
        {
            Label lblPrice = new Label();
            lblPrice.Name = "lblPrice";

            lblPrice.AutoSize = false;
            lblPrice.Size = new Size(90, 75);

            lblPrice.Location = new Point(145, 75);

            lblPrice.Text = AbstractDish.Price + "$";

            this.Controls.Add(lblPrice);
        }
    }
}
