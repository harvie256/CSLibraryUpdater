using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OpenMcdf;
using System.Diagnostics;

namespace CSLibraryUpdater
{
    public partial class MainForm : Form
    {
        string _currentFile = null;
        CompoundFile _schCompoundFile;
        List<SchLibComponent> _componentsList;
        SchLibComponent _currentSelectedComponent;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenSchLib_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _currentFile = openDialog.FileName;
                loadSchFile();
            }
        }

        private void loadSchFile()
        {
            List<string> schLibEntries = new List<string>();

            _schCompoundFile = new CompoundFile(_currentFile, CFSUpdateMode.Update, CFSConfiguration.Default);
            _componentsList = new List<SchLibComponent>();

            Action<CFItem> va = delegate (CFItem item)
            {
                schLibEntries.Add(item.Name);
            };

            _schCompoundFile.RootStorage.VisitEntries(va, false);

            foreach (var entry in schLibEntries)
            {
                var storage = _schCompoundFile.RootStorage.TryGetStorage(entry);
                if (storage == null) continue;

                var stream = storage.GetStream("Data");
                byte[] buffer = new byte[stream.Size];

                stream.Read(buffer, 0, (int)stream.Size);

                _componentsList.Add(new SchLibComponent(entry, buffer));
            }

            PopulateComponentListBox();
        }

        private void PopulateComponentListBox()
        {
            lbxComponents.Items.Clear();

            foreach(var component in _componentsList)
            {
                lbxComponents.Items.Add(component.Name);
            }
        }

        private void lbxComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = lbxComponents.SelectedItem.ToString();
            gVparameters.Rows.Clear();

            _currentSelectedComponent = null;


            foreach (var component in _componentsList)
            {
                if(component.Name == name)
                {
                    _currentSelectedComponent = component;
                    break;
                }
            }

            if (_currentSelectedComponent == null)
                return;

            foreach (var param in _currentSelectedComponent.Parameters)
            {
                if (!param.IsParameterRecord) continue;
                string value = "";
                if(param.RecordProperties.ContainsKey("TEXT"))
                {
                    value = param.RecordProperties["TEXT"];
                }

                gVparameters.Rows.Add(param.RecordProperties["NAME"], value, param.RecordProperties["UNIQUEID"]);

            }
            gVparameters.Sort(gVparameters.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            if(_currentSelectedComponent.FindParameter("Supplier 1") != null
                && _currentSelectedComponent.FindParameter("Supplier Part Number 1") != null)
            {
                btnLoadSupplierData.Enabled = true;
            } else
            {
                btnLoadSupplierData.Enabled = false;
            }
        }

        private void btnLoadSupplierData_Click(object sender, EventArgs e)
        {
            string supplier = _currentSelectedComponent.FindParameter("Supplier 1").RecordProperties["TEXT"];
            string supplierPartNo = _currentSelectedComponent.FindParameter("Supplier Part Number 1").RecordProperties["TEXT"];
            if(supplier.Contains("Farnell"))
            {
                _currentSelectedComponent.AddParameters(WebDataLoader.LoadFromFarnell(supplierPartNo));
                lbxComponents_SelectedIndexChanged(null, null);

            } else
            {
                MessageBox.Show("Supplier not supported yet.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            List<string> UpdateList = new List<string>();
            // Clear all storage items
            Action<CFItem> va = delegate (CFItem item)
            {
                if(item.IsStorage)
                {
                    UpdateList.Add(item.Name);
                }
            };

            _schCompoundFile.RootStorage.VisitEntries(va, false);

            foreach(var name in UpdateList)
            {
                var storage = _schCompoundFile.RootStorage.GetStorage(name);
                var stream = storage.GetStream("Data");

                // Find the component
                SchLibComponent matchedComponent = null;
                foreach(var component in _componentsList)
                {
                    if(component.Name == name)
                    {
                        matchedComponent = component;
                        break;
                    }
                }

                stream.SetData(matchedComponent.GetBinary());

            }


            _schCompoundFile.Commit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_schCompoundFile != null)
            {
                _schCompoundFile.Close();
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            var supDialog = new SupplierDialog();
            supDialog.ShowDialog();

            if(supDialog.result == SupplierDialog.Result.Ok)
            {

            }
        }

        private void btnClearAllParameters_Click(object sender, EventArgs e)
        {

        }
    }
}
