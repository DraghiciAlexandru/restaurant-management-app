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
    class ViewTabelClient : Panel
    {
        String path = Application.StartupPath;
        public ListaSimpla<Button> tabels;
        private ControlTabels controlTabels;
        private ControlBookings controlBookings;
        private ControlCancel controlCancel;

        public ViewTabelClient()
        {
            tabels = new ListaSimpla<Button>();
            controlTabels = new ControlTabels();
            controlBookings = new ControlBookings();
            controlCancel = new ControlCancel();
            layout();
        }

        public void layout()
        {
            this.Size = new Size(850, 365);
            this.Location = new Point(0, 50);

            this.BackColor = Color.FromArgb(40, 40, 40);

            this.BackgroundImage = Image.FromFile(path + @"\resources\RestaurantFloor2.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.Font = new Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.ForeColor = Color.Black;

            //this.Anchor= AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Anchor = AnchorStyles.None;

            setTabels();
            setControl();
        }

        public void tabelBtn(Button btnTabel)
        {
            btnTabel.FlatStyle = FlatStyle.Flat;
            btnTabel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTabel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnTabel.FlatAppearance.BorderSize = 0;
            btnTabel.BackColor = Color.Transparent;
            btnTabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnTabel.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void setTabels()
        {
            Button btnTab1 = new Button();
            btnTab1.Name = "btnTab1";
            btnTab1.Text = "1";
            btnTab1.Location = new Point(35, 70);
            btnTab1.Size = new Size(45, 70);
            tabelBtn(btnTab1);

            Button btnTab2 = new Button();
            btnTab2.Name = "btnTab2";
            btnTab2.Text = "2";
            btnTab2.Location = new Point(35, 216);
            btnTab2.Size = new Size(45, 70);
            tabelBtn(btnTab2);

            Button btnTab3 = new Button();
            btnTab3.Name = "btnTab3";
            btnTab3.Text = "3";
            btnTab3.Location = new Point(180, 5);
            btnTab3.Size = new Size(50, 55);
            tabelBtn(btnTab3);

            Button btnTab4 = new Button();
            btnTab4.Name = "btnTab4";
            btnTab4.Text = "4";
            btnTab4.Location = new Point(255, 5);
            btnTab4.Size = new Size(50, 55);
            tabelBtn(btnTab4);

            Button btnTab5 = new Button();
            btnTab5.Name = "btnTab5";
            btnTab5.Text = "5";
            btnTab5.Location = new Point(332, 5);
            btnTab5.Size = new Size(50, 55);
            tabelBtn(btnTab5);

            Button btnTab6 = new Button();
            btnTab6.Name = "btnTab6";
            btnTab6.Text = "6";
            btnTab6.Location = new Point(180, 300);
            btnTab6.Size = new Size(50, 55);
            tabelBtn(btnTab6);

            Button btnTab7 = new Button();
            btnTab7.Name = "btnTab7";
            btnTab7.Text = "7";
            btnTab7.Location = new Point(255, 300);
            btnTab7.Size = new Size(50, 55);
            tabelBtn(btnTab7);

            Button btnTab8 = new Button();
            btnTab8.Name = "btnTab8";
            btnTab8.Text = "8";
            btnTab8.Location = new Point(332, 300);
            btnTab8.Size = new Size(50, 55);
            tabelBtn(btnTab8);

            Button btnTab9 = new Button();
            btnTab9.Name = "btnTab9";
            btnTab9.Text = "9";
            btnTab9.Location = new Point(613, 300);
            btnTab9.Size = new Size(50, 55);
            tabelBtn(btnTab9);

            Button btnTab10 = new Button();
            btnTab10.Name = "btnTab10";
            btnTab10.Text = "10";
            btnTab10.Location = new Point(688, 300);
            btnTab10.Size = new Size(55, 55);
            tabelBtn(btnTab10);

            Button btnTab11 = new Button();
            btnTab11.Name = "btnTab11";
            btnTab11.Text = "11";
            btnTab11.Location = new Point(178, 120);
            btnTab11.Size = new Size(55, 55);
            tabelBtn(btnTab11);

            Button btnTab12 = new Button();
            btnTab12.Name = "btnTab12";
            btnTab12.Text = "12";
            btnTab12.Location = new Point(259, 190);
            btnTab12.Size = new Size(55, 55);
            tabelBtn(btnTab12);

            Button btnTab13 = new Button();
            btnTab13.Name = "btnTab13";
            btnTab13.Text = "13";
            btnTab13.Location = new Point(340, 120);
            btnTab13.Size = new Size(55, 55);
            tabelBtn(btnTab13);

            Button btnTab14 = new Button();
            btnTab14.Name = "btnTab14";
            btnTab14.Text = "14";
            btnTab14.Location = new Point(425, 190);
            btnTab14.Size = new Size(55, 55);
            tabelBtn(btnTab14);

            Button btnTab15 = new Button();
            btnTab15.Name = "btnTab15";
            btnTab15.Text = "15";
            btnTab15.Location = new Point(506, 120);
            btnTab15.Size = new Size(55, 55);
            tabelBtn(btnTab15);

            Button btnTab16 = new Button();
            btnTab16.Name = "btnTab16";
            btnTab16.Text = "16";
            btnTab16.Location = new Point(593, 190);
            btnTab16.Size = new Size(55, 55);
            tabelBtn(btnTab16);

            Button btnTab17 = new Button();
            btnTab17.Name = "btnTab17";
            btnTab17.Text = "17";
            btnTab17.Location = new Point(673, 120);
            btnTab17.Size = new Size(55, 55);
            tabelBtn(btnTab17);

            Button btnTab18 = new Button();
            btnTab18.Name = "btnTab18";
            btnTab18.Text = "18";
            btnTab18.Location = new Point(443, 22);
            btnTab18.Size = new Size(45, 40);
            btnTab18.Font = new Font("Showcard Gothic", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabelBtn(btnTab18);

            Button btnTab19 = new Button();
            btnTab19.Name = "btnTab19";
            btnTab19.Text = "19";
            btnTab19.Location = new Point(549, 22);
            btnTab19.Size = new Size(45, 40);
            btnTab19.Font = new Font("Showcard Gothic", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabelBtn(btnTab19);

            Button btnTab20 = new Button();
            btnTab20.Name = "btnTab20";
            btnTab20.Text = "20";
            btnTab20.Location = new Point(659, 22);
            btnTab20.Size = new Size(45, 40);
            btnTab20.Font = new Font("Showcard Gothic", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabelBtn(btnTab20);

            tabels.addFinish(btnTab1);
            tabels.addFinish(btnTab2);
            tabels.addFinish(btnTab3);
            tabels.addFinish(btnTab4);
            tabels.addFinish(btnTab5);
            tabels.addFinish(btnTab6);
            tabels.addFinish(btnTab7);
            tabels.addFinish(btnTab8);
            tabels.addFinish(btnTab9);
            tabels.addFinish(btnTab10);
            tabels.addFinish(btnTab11);
            tabels.addFinish(btnTab12);
            tabels.addFinish(btnTab13);
            tabels.addFinish(btnTab14);
            tabels.addFinish(btnTab15);
            tabels.addFinish(btnTab16);
            tabels.addFinish(btnTab17);
            tabels.addFinish(btnTab18);
            tabels.addFinish(btnTab19);
            tabels.addFinish(btnTab20);

            Controls.Add(btnTab1);
            Controls.Add(btnTab2);
            Controls.Add(btnTab3);
            Controls.Add(btnTab4);
            Controls.Add(btnTab5);
            Controls.Add(btnTab6);
            Controls.Add(btnTab7);
            Controls.Add(btnTab8);
            Controls.Add(btnTab9);
            Controls.Add(btnTab10);
            Controls.Add(btnTab11);
            Controls.Add(btnTab12);
            Controls.Add(btnTab13);
            Controls.Add(btnTab14);
            Controls.Add(btnTab15);
            Controls.Add(btnTab16);
            Controls.Add(btnTab17);
            Controls.Add(btnTab18);
            Controls.Add(btnTab19);
            Controls.Add(btnTab20);
        }

        private void setControl()
        {
            for (int i = 0; i < tabels.size(); i++)
            {
                Booking booking = new Booking(0, 0, 0, (i + 1), DateTime.Now);

                if ((controlBookings.isRezerved(booking) == true) && (controlCancel.isCancel(booking) == false))
                {
                    tabels.getAtPosition(i).ForeColor = Color.Red;

                    controlTabels.updateState(i + 1, true);
                }
                else
                {
                    tabels.getAtPosition(i).ForeColor = Color.Green;
                }
            }
        }

    }
}
