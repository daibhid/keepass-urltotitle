using KeePassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URLInName
{
    public partial class CheckboxTableForm : Form
    {
        private List<SuggestedModification> suggestedModifications;

        public CheckboxTableForm()
        {
            InitializeComponent();
        }

        public void AddData(List<SuggestedModification> data)
        {
            dataGridView1.Rows.Clear();

            suggestedModifications = data;

            foreach (var item in data)
            {
                int index = dataGridView1.Rows.Add(new object[] { true, item.OldTitle, item.NewTitle, item.OldUrl, item.suggestedUrl, item.Uuid });
                
                if (item.OldTitle != item.NewTitle)
                {
                    dataGridView1.Rows[index].Cells[2].Style.Font =
                        dataGridView1.Rows[index].Cells[2].InheritedStyle.Font.SetBold();
                }

                if (item.OldUrl != item.suggestedUrl)
                {
                    dataGridView1.Rows[index].Cells[4].Style.Font =
                        dataGridView1.Rows[index].Cells[4].InheritedStyle.Font.SetBold();
                }
            }
        }

        public List<SuggestedModification> GetSuggestedModications()
        {
            return suggestedModifications;
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void unSelectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            suggestedModifications.Clear();

            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!(bool)row.Cells[0].Value)
                {
                    suggestedModifications.RemoveAll(item => ((PwUuid)row.Cells[5].Value).CompareTo(item.Uuid) == 0);
                }
            }

            this.Close();
        }
    }
}
