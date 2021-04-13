using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryCalculator
{
    public partial class frmHistory : Form
    {
        //calculator instance
        //and variable list that will store list with all calulations
        private Calculator c = null;
        private List<string> calculations;
        public frmHistory(List<string> listCalculations)
        {
            InitializeComponent();

            //takes incoming list with all calculations performed.
            this.calculations = listCalculations;
        }
        private void frmHistory_Load(object sender, EventArgs e)
        {
            FillItemListBox();
        }


        //method to display the history form
        public Calculator GetNewItem()
        {
            this.ShowDialog();
            return c;

        }
        private void FillItemListBox()
        {
            //method to display all the calculations that were performed
            foreach (string item in calculations)
            {
                lstCalculations.Items.Add(item+"\n");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //close history form
            this.Close();
        }

        
    }
}
