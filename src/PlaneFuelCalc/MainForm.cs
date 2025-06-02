using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlaneFuelCalc
{
    public partial class MainForm : Form
    {
        int _tankContents = 3900;
        double _totalCapacity = double.MinValue;
        double _readingLeft = double.MinValue;
        double _readingRight = double.MinValue;
        double _density = double.MinValue;


        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if (c.BackColor == SystemColors.ControlLight)
                {
                    ((TextBox)c).ReadOnly = true; 
                }
            }

            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.BackColor == SystemColors.ControlLight)
                {
                    ((TextBox)c).ReadOnly = true;
                }
            }
        }

        private void tbGageReadingLeftTank_TextChanged(object sender, EventArgs e)
        {
            ReadUserValues();

            Calculate();
        }

        private void Calculate()
        {
            tbGageReadingCentralTank.Text = "0";

            if ((_totalCapacity == double.MinValue) || 
                (_readingLeft == double.MinValue) || 
                (_readingRight == double.MinValue) || 
                (_density == double.MinValue))
            {
                return;
            }

            tbFuelRequiredLeftTank.Text = _tankContents.ToString();
            tbFuelRequiredRightTank.Text = _tankContents.ToString();

            double fuelRequiredCentralTank = _totalCapacity - _tankContents - _tankContents;
            tbFuelRequiredCentralTank.Text = fuelRequiredCentralTank.ToString();

            double totalGageReading = _readingLeft + _readingRight;
            tbGageReadingTotal.Text = totalGageReading.ToString();

            double TBALeftTankKgs = _tankContents - _readingLeft;
            tbTBALeftTankKgs.Text = TBALeftTankKgs.ToString();

            double TBALeftTankLtr = TBALeftTankKgs / _density;
            tbTBALeftTankLtr.Text = TBALeftTankLtr.ToString("0.00");

            double TBACentralTankKgs = fuelRequiredCentralTank;
            tbTBACentralTankKgs.Text = TBACentralTankKgs.ToString();

            double TBACentralTankLtr = TBACentralTankKgs / _density;
            tbTBACentralTankLtr.Text = TBACentralTankLtr.ToString("0.00");

            double TBARightTankKgs = _tankContents - _readingRight;
            tbTBARightTankKgs.Text = TBARightTankKgs.ToString();

            double TBARightTankLtr = TBARightTankKgs / _density;
            tbTBARightTankLtr.Text = TBARightTankLtr.ToString("0.00");

            double TBATotalKgs = _totalCapacity - totalGageReading;
            tbTBATotalKgs.Text = TBATotalKgs.ToString();

            double TBATotalLtr = TBATotalKgs / _density;
            tbTBATotalLtr.Text = TBATotalLtr.ToString("0.00");

            tbResultTotalFuelKgs.Text = TBATotalKgs.ToString();

            double resultTotalFuelLtf = TBATotalKgs / _density;
            tbResultTotalFuelLtf.Text = resultTotalFuelLtf.ToString("0.00");
                 
        }

        private void ReadUserValues()
        {
            if (double.TryParse(tbFuelRequiredTotal.Text, out _totalCapacity))
            {
                tbFuelRequiredTotal.BackColor = SystemColors.ControlLightLight;
            }
            else if (string.IsNullOrEmpty(tbFuelRequiredTotal.Text))
            {
                tbFuelRequiredTotal.BackColor = SystemColors.ControlLightLight;
                _totalCapacity = double.MinValue;
            }
            else
            {
                tbFuelRequiredTotal.BackColor = Color.LightSalmon;
                _totalCapacity = double.MinValue;
            }

            if (double.TryParse(tbGageReadingLeftTank.Text, out _readingLeft))
            {
                tbGageReadingLeftTank.BackColor = SystemColors.ControlLightLight;
            }
            else if (string.IsNullOrEmpty(tbGageReadingLeftTank.Text))
            {
                tbGageReadingLeftTank.BackColor = SystemColors.ControlLightLight;
                _readingLeft = double.MinValue;
            }
            else
            {
                tbGageReadingLeftTank.BackColor = Color.LightSalmon;
                _readingLeft = double.MinValue;
            }

            if (double.TryParse(tbGageReadingRightTank.Text, out _readingRight))
            {
                tbGageReadingRightTank.BackColor = SystemColors.ControlLightLight;
            }
            else if (string.IsNullOrEmpty(tbGageReadingRightTank.Text))
            {
                tbGageReadingRightTank.BackColor = SystemColors.ControlLightLight;
                _readingRight = double.MinValue;
            }
            else
            {
                tbGageReadingRightTank.BackColor = Color.LightSalmon;
                _readingRight = double.MinValue;
            }

            if (double.TryParse(tbDensity.Text, out _density))
            {
                tbDensity.BackColor = SystemColors.ControlLightLight;
            }
            else if (string.IsNullOrEmpty(tbDensity.Text))
            {
                tbDensity.BackColor = SystemColors.ControlLightLight;
                _readingRight = double.MinValue;
            }
            else
            {
                tbDensity.BackColor = Color.LightSalmon;
                _readingRight = double.MinValue;
            }
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();

        }
    }
}
