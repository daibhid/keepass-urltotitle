namespace URLInName
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using KeePassLib;

    public partial class CheckboxTableForm : Form
    {
        private List<SuggestedModification> suggestedModifications;

        public CheckboxTableForm()
        {
            this.InitializeComponent();
        }

        public void AddData(List<SuggestedModification> data)
        {
            this.dataGridView1.Rows.Clear();

            this.suggestedModifications = data;

            foreach (SuggestedModification item in data)
            {
                int index = this.dataGridView1.Rows.Add(new object[] { true, item.OldTitle, item.NewTitle, item.OldUrl, item.suggestedUrl, item.Uuid });

                if (item.OldTitle != item.NewTitle)
                {
                    this.dataGridView1.Rows[index].Cells[2].Style.Font =
                        this.dataGridView1.Rows[index].Cells[2].InheritedStyle.Font.SetBold();
                }

                if (item.OldUrl != item.suggestedUrl)
                {
                    this.dataGridView1.Rows[index].Cells[4].Style.Font =
                        this.dataGridView1.Rows[index].Cells[4].InheritedStyle.Font.SetBold();
                }
            }
        }

        public List<SuggestedModification> GetSuggestedModications()
        {
            return this.suggestedModifications;
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void unSelectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.suggestedModifications.Clear();

            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!(bool)row.Cells[0].Value)
                {
                    this.suggestedModifications.RemoveAll(item => ((PwUuid)row.Cells[5].Value).CompareTo(item.Uuid) == 0);
                }
            }

            this.Close();
        }
    }
}
