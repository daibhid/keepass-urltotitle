// <copyright file="CheckboxTableForm.cs" company="daibhid">
// Copyright (c) daibhid. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace URLInName
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using KeePassLib;

    /// <summary>
    /// Form holding the UI of the plugin.
    /// </summary>
    public partial class CheckboxTableForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckboxTableForm"/> class.
        /// </summary>
        public CheckboxTableForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the list of potential modifications.
        /// </summary>
        public List<SuggestedModification> SuggestedModifications { get; set; }

        /// <summary>
        /// Method to populate some suggestions in the UI.
        /// </summary>
        /// <param name="data">The new suggestions to show.</param>
        public void AddData(List<SuggestedModification> data)
        {
            this.dataGridView1.Rows.Clear();

            this.SuggestedModifications = data;

            foreach (SuggestedModification item in data)
            {
                int index = this.dataGridView1.Rows.Add(new object[] { false, item.OldTitle, item.NewTitle, item.OldUrl, item.SuggestedUrl, item.Uuid });

                if (item.OldTitle != item.NewTitle)
                {
                    this.dataGridView1.Rows[index].Cells[2].Style.Font =
                        this.dataGridView1.Rows[index].Cells[2].InheritedStyle.Font.SetBold();
                }

                if (item.OldUrl != item.SuggestedUrl)
                {
                    this.dataGridView1.Rows[index].Cells[4].Style.Font =
                        this.dataGridView1.Rows[index].Cells[4].InheritedStyle.Font.SetBold();
                }
            }
        }

        /// <summary>
        /// Callback when the "Select All" button is pressed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/>.</param>
        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        /// <summary>
        /// Callback when the "Unselect All" button is pressed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/>.</param>
        private void unSelectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        /// <summary>
        /// Callback when the "Cancel" button is pressed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/>.</param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.SuggestedModifications.Clear();

            this.Close();
        }

        /// <summary>
        /// Callback when the "OK" button is pressed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/>.</param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClosedEvent(object sender, FormClosedEventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!(bool)row.Cells[0].Value)
                {
                    this.SuggestedModifications.RemoveAll(item => ((PwUuid)row.Cells[5].Value).CompareTo(item.Uuid) == 0);
                }
            }
        }
    }
}
