namespace EnocdeDecode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] stringArrayFiles = null;
            stringArrayFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            MessageBox.Show(stringArrayFiles[1]);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}