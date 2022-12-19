using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace AssemblyLock.PTKCatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fileName = GetDropedFileName(e);
            ShowInfo(fileName);
        }

        private string GetDropedFileName(DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                if(fileNames.Length >0)
                {
                    if(File.Exists(fileNames[0]))
                    {
                        return fileNames[0];
                    }
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowInfo(textBox1.Text);
        }

        private void ShowInfo(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    var asm = Assembly.LoadFrom(fileName);
                    textBox2.Text = asm.FullName;
                }
                catch (Exception ex)
                {
                    textBox2.Text = "Error : " + ex.Message;
                }
            }
        }
    }
}
