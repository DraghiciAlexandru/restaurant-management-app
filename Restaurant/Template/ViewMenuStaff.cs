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
    class ViewMenuStaff : Panel
    {
        String path = Application.StartupPath;
        private FlowLayoutPanel flowMenu;
        private ControlMenu controlMenu;

        public ViewMenuStaff()
        {
            controlMenu = new ControlMenu();
            layout();
        }

        private void layout()
        {
            this.Size = new Size(834, 464);

            setMain();
            setSoup();
            setDesert();
            setFlowMenu();
        }

        private void setMain()
        {
            Button btnMain = new Button();
            btnMain.Name = "btnMain";

            btnMain.FlatStyle = FlatStyle.Flat;
            btnMain.FlatAppearance.MouseOverBackColor = ThemeColor.PrimaryColor;
            btnMain.FlatAppearance.MouseDownBackColor = ThemeColor.PrimaryColor;
            btnMain.FlatAppearance.BorderSize = 0;
            btnMain.BackColor = ThemeColor.PrimaryColor;
            btnMain.Anchor = AnchorStyles.Top;

            btnMain.Size = new Size(100, 100);
            btnMain.BackgroundImage = Image.FromFile(path + @"\resources\food_100px.png");
            btnMain.Location = new Point(100, 25);

            btnMain.Click += BtnMain_Click;

            this.Controls.Add(btnMain);
        }

        private void BtnMain_Click(object sender, EventArgs e)
        {
            setItem("main");
        }

        private void setSoup()
        {
            Button btnSoup = new Button();
            btnSoup.Name = "btnSoup";

            btnSoup.FlatStyle = FlatStyle.Flat;
            btnSoup.FlatAppearance.MouseOverBackColor = ThemeColor.PrimaryColor;
            btnSoup.FlatAppearance.MouseDownBackColor = ThemeColor.PrimaryColor;
            btnSoup.FlatAppearance.BorderSize = 0;
            btnSoup.BackColor = ThemeColor.PrimaryColor;
            btnSoup.Anchor = AnchorStyles.Top;

            btnSoup.Image = Image.FromFile(path + @"\resources\soup_plate_96px.png");
            btnSoup.Size = new Size(100, 100);
            btnSoup.Location = new Point(360, 25);

            btnSoup.Click += BtnSoup_Click;

            this.Controls.Add(btnSoup);
        }

        private void BtnSoup_Click(object sender, EventArgs e)
        {
            setItem("soup");
        }

        private void setDesert()
        {
            Button btnDesert = new Button();
            btnDesert.Name = "btnDesert";

            btnDesert.FlatStyle = FlatStyle.Flat;
            btnDesert.FlatAppearance.MouseOverBackColor = ThemeColor.PrimaryColor;
            btnDesert.FlatAppearance.MouseDownBackColor = ThemeColor.PrimaryColor;
            btnDesert.FlatAppearance.BorderSize = 0;
            btnDesert.BackColor = ThemeColor.PrimaryColor;
            btnDesert.Anchor = AnchorStyles.Top;
            btnDesert.TextAlign = ContentAlignment.MiddleCenter;

            btnDesert.Image = Image.FromFile(path + @"\resources\croissant_100px.png");
            btnDesert.Size = new Size(100, 100);
            btnDesert.Location = new Point(615, 25);

            btnDesert.Click += BtnDesert_Click;

            this.Controls.Add(btnDesert);
        }

        private void BtnDesert_Click(object sender, EventArgs e)
        {
            setItem("desert");
        }

        private void setFlowMenu()
        {
            flowMenu = new FlowLayoutPanel();

            flowMenu.Size = new Size(750, 280);
            flowMenu.Location = new Point(40, 150);
            flowMenu.Anchor = AnchorStyles.Top;
            flowMenu.BorderStyle = BorderStyle.FixedSingle;
            flowMenu.WrapContents = true;
            flowMenu.AutoScroll = true;

            this.Controls.Add(flowMenu);
        }

        private void setItem(String type)
        {
            flowMenu.Controls.Clear();

            ListaSimpla<AbstractDish> dishList = new ListaSimpla<AbstractDish>();

            if (type == "main")
            {
                dishList = controlMenu.getMain();
            }
            else if (type == "soup")
            {
                dishList = controlMenu.getSoup();
            }
            else
            {
                dishList = controlMenu.getDesert();
            }

            for (int i = 0; i < dishList.size(); i++)
            {
                CardDishStaff cardDish = new CardDishStaff(dishList.getAtPosition(i));

                cardDish.Margin = new Padding(50, 10, 0, 10);

                cardDish.btnEdit.Click += BtnEdit_Click;
                cardDish.btnDel.Click += BtnDel_Click;
                cardDish.txtName.TextChanged += TxtName_TextChanged;
                cardDish.txtPrice.TextChanged += TxtPrice_TextChanged;

                flowMenu.Controls.Add(cardDish);
            }

        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            CardDishStaff cardDish = txt.Parent as CardDishStaff;

            double price;

            if (txt.Text.Trim() != "" && double.TryParse(txt.Text.Trim(), out price))
            {
                controlMenu.updatePrice(cardDish.AbstractDish.Id, price);
                controlMenu.save();
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            CardDishStaff cardDish = txt.Parent as CardDishStaff;

            if (txt.Text.Trim() != "") 
            {
                controlMenu.updateName(cardDish.AbstractDish.Id, txt.Text.Trim());
                controlMenu.save();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            CardDishStaff cardDish = btn.Parent as CardDishStaff;

            controlMenu.remove(cardDish.AbstractDish);
            controlMenu.save();

            flowMenu.Controls.Remove(cardDish);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            CardDishStaff cardDish = btn.Parent as CardDishStaff;

            cardDish.setEditMode();
        }
    }
}
