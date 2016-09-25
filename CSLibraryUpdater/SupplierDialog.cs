using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSLibraryUpdater
{
    public partial class SupplierDialog : Form
    {
        public enum Result
        {
            Ok,
            Cancel
        }

        public Result result { get; private set; }
        public string supplier { get; private set; }
        public string sku { get; private set; }


        public SupplierDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result = Result.Ok;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = Result.Cancel;
            this.Close();
        }

        private void SupplierDialog_Load(object sender, EventArgs e)
        {
            cbxSupplier.Items.Add("Farnell");
            cbxSupplier.Items.Add("Digi-key");
            cbxSupplier.Items.Add("RS Components");
            cbxSupplier.Items.Add("Mouser");
        }
    }
}
