using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSI
{
    public partial class DatePicker : Form
    {
        private int[] iids;
        public DateTime selDate;
        public DatePicker()
        {
            InitializeComponent();
        }

        public DatePicker(int[] iIds, DateTime s)
        {
            InitializeComponent();

            iids = iIds;
            monthCalendar1.SelectionStart = s;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(monthCalendar1.SelectionStart != null)
            {
                
                selDate = monthCalendar1.SelectionStart.AddDays(-(int)monthCalendar1.SelectionStart.DayOfWeek + (int)DayOfWeek.Monday);
                MovementDialog md = new MovementDialog(iids, selDate);
                md.ShowDialog();
                this.Close();
            }
        }
    }
}
