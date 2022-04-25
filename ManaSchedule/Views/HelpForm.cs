using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManaSchedule.Views
{
    public partial class HelpForm : Form
    {
       
        public HelpForm()
        {
            InitializeComponent();
        }

        
        public static string GetHelpFilePath(object article)
        {
            return string.Format(@"{0}\{1}.rtf", App.HelpPath, article);
        }

        public HelpForm(string article) : this()
        {
            var list = Directory.GetFiles(App.HelpPath, "*.rtf").Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
            if (!list.Contains(article))
            {
                richTextBox1.SaveFile(GetHelpFilePath(article), RichTextBoxStreamType.RichText);
                list.Add(article);
            }
            boxArticles.Items.AddRange(list.OrderBy(f => f).ToArray());
            boxArticles.SelectedItem = article;
        }

        private string _currentFile;
        private bool _currentFileChanged;

        private void boxArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveChanges();
            var filename =GetHelpFilePath(boxArticles.SelectedItem);
            uiPanel1.Text = filename;
            richTextBox1.LoadFile(filename);
            _currentFile = filename;
            _currentFileChanged = false;
        }

        private void SaveChanges()
        {
            if (!_currentFileChanged) return;

            try
            {
                  if (!string.IsNullOrEmpty(_currentFile) 
                      && DialogResult.Yes == MessageBox.Show(this,"Сохранить изменения в " + Path.GetFileNameWithoutExtension(_currentFile) + "?" ,"Сохранить", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                richTextBox1.SaveFile(_currentFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveChanges();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            _currentFileChanged = true;
        }
        
    }
}
