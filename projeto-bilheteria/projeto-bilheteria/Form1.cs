using System;
using System.Windows.Forms;

namespace projeto_bilheteria
{
    public partial class Form1 : Form
    {
        private CheckBox halfPriceCheckBox = new CheckBox();
        private Label billingLabel = new Label();
        private Button billingButton = new Button();
        private int reservedSeats = 0;
        private double billing;
        public Form1()
        {
            InitializeComponent();
            InitializeHalfPriceCheckBox();
            InitializeSeatButtons();
            InitializeBillingButton();
            InitializeBillingLabel();
            this.Height = 425;
            this.Width = 840;
            this.BackColor = System.Drawing.Color.DimGray;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
        private void InitializeHalfPriceCheckBox()
        {
            halfPriceCheckBox.Parent = this;
            halfPriceCheckBox.AutoSize = true;
            halfPriceCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            halfPriceCheckBox.Location = new System.Drawing.Point(10, 10);
            halfPriceCheckBox.Size = new System.Drawing.Size(112, 22);
            halfPriceCheckBox.TabIndex = 0;
            halfPriceCheckBox.Text = "Meia entrada";
            halfPriceCheckBox.UseVisualStyleBackColor = true;
        }
        private void InitializeSeatButtons()
        {
            int x = 10;
            int y = 40;
            for (int ii = 0; ii < 15; ii++)
            {
                for(int jj = 0; jj < 40;  jj++)
                {
                    var seatButton = new System.Windows.Forms.Button();
                    seatButton.Name = "SeatR" + (ii+1).ToString("00") + "S" + (jj + 1).ToString("00");
                    seatButton.Click += ReserveSeat;
                    seatButton.Parent = this;
                    seatButton.Height = 20;
                    seatButton.Width = 20;
                    seatButton.BackColor = System.Drawing.Color.Green;
                    seatButton.Location = new System.Drawing.Point(x, y);
                    x += seatButton.Width;
                }
                x = 10;
                y += 20;
            }
        }
        private void InitializeBillingButton()
        {
            billingButton.Parent = this;
            billingButton.Location = new System.Drawing.Point(10, 350);
            billingButton.Text = "Ver faturamento";
            billingButton.Width = 110;
            billingButton.Height = 25;
            billingButton.BackColor = System.Drawing.Color.White;
            billingButton.Click += ShowBillingLabel;
        }
        private void InitializeBillingLabel()
        {
            billingLabel.Parent = this;
            billingLabel.Location = new System.Drawing.Point(110, 350);
            billingLabel.Width = 300;
            billingLabel.Height = 25;
            billingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            billingLabel.Visible = false;
        }

        private void ShowBillingLabel(object sender, EventArgs e)
        {
            billingLabel.Visible = true;
            UpdateBillingLabel(sender, e);
        }

        private void UpdateBillingLabel(object sender, EventArgs e)
        {
            billingLabel.Text = "Lugares reservados: " + reservedSeats + " | Valor da bilheteria: " +
                billing.ToString("C", new System.Globalization.CultureInfo("pt-BR"));
        }

        private void ReserveSeat(object sender, EventArgs e)
        {
            if(((Control)sender).BackColor == System.Drawing.Color.Green)
            {
                reservedSeats++;
                ((Control)sender).BackColor = System.Drawing.Color.Red;

                string seatName = ((Control)sender).Name;
                int seatRow = int.Parse(seatName.Substring(5, 2));

                int toPay;
                if (seatRow < 6) { toPay = 50; }
                else if (seatRow < 11) { toPay = 30; }
                else { toPay = 15; }
                billing += halfPriceCheckBox.Checked ? toPay / 2 : toPay;
                UpdateBillingLabel(sender, e);
            }
            else
            {
                MessageBox.Show("Lugar ocupado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
