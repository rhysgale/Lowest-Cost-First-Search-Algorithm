using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lowest_Cost_First_Search
{
    public partial class ChooseNodeName : Form
    {
        public string _NodeName;
        public int _Distance;
        bool _DistanceNeeded;

        public ChooseNodeName(bool distance)
        {
            InitializeComponent();
            this._DistanceNeeded = distance;
            InstructionLabel.Text = (distance ? "Please Enter Distance" : "Please Enter Name of Place");
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!_DistanceNeeded)
            {
                _NodeName = NodeNameTextBox.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                _Distance = int.Parse(NodeNameTextBox.Text);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
