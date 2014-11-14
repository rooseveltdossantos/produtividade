using System;
using System.Windows.Forms;

namespace QuickPack
{
    public partial class Form1 : Form
    {
        private readonly AjustadorOutputCSProj ajustadorOutputCSProj = new AjustadorOutputCSProj();

        public Form1()
        {
            InitializeComponent();
            ajustadorOutputCSProj.OnOutputCSProjProcessado += (sender, processado) => status.AppendText(string.Format("Alterado o arquivo '{0}': Saída Original: '{1}' - Saída Nova: '{2}'{3}", processado.ProjectFileName, processado.OriginalValue, processado.NewValue, Environment.NewLine));
        }

        private void ajustarOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    ajustadorOutputCSProj.Ajustar(openFileDialog.FileName, folderBrowserDialog.SelectedPath);
                }
            }
        }
    }
}
