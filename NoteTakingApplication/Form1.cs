using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApplication
{
    public partial class Form1 : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[previewNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previewNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previewNotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid note");
                throw;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previewNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[previewNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void previewNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[previewNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previewNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previewNotes.DataSource = notes;
        }
    }
}
