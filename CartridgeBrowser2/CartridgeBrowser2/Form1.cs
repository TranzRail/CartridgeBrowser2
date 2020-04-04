using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CartridgeBrowser2.Schema;

namespace CartridgeBrowser2
{
    public partial class Form1 : Form
    {
        // our main test class
        Database database;

        public Form1()
        {
            // add event to detect when the window is shown.
            InitializeComponent();

            //olv.UseFiltering = true;
            //olv.ShowFilterMenuOnRightClick = true;
            //olv.ItemsChanged += ObjectListView1_ItemsChanged;
            //olv.GetColumn(2).AspectToStringConverter = delegate (object x) { return StaticMethods.FormatBytes(Convert.ToUInt64(x.ToString())); };
            fastObjectListView1.UseFiltering = true;
            fastObjectListView1.ShowCommandMenuOnRightClick = true;
            fastObjectListView1.ShowFilterMenuOnRightClick = true;
            fastObjectListView1.ItemsChanged += ObjectListView1_ItemsChanged;
            //fastObjectListView1.GetColumn(7).IsVisible = false;
            //fastObjectListView1.GetColumn(8).IsVisible = false;

        }

        private void Olv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Console.WriteLine("[{0}] ItemSelectionChanged event for objectListView1.", this.GetType().ToString());
        }

        private void ObjectListView1_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            updateTotalSizeText();
            Console.WriteLine("[{0}] ItemsChanged event for objectListView1.", this.GetType().ToString());
        }

        private void SearchTextbox_TextChanged(object sender, EventArgs e)
        {
            TextMatchFilter filter = TextMatchFilter.Contains(this.fastObjectListView1, searchTextbox.Text);
            //olv.ModelFilter = filter;
            fastObjectListView1.AdditionalFilter = filter;

            //HighlightTextRenderer r = new HighlightTextRenderer();
            //olv.DefaultRenderer = r;

            updateTotalSizeText();
        }

        private async void SelectFolderButton_Click(object sender, EventArgs e)
        {
            await selectFolderAndLoad();
        }
        private void updateTotalSizeText()
        {
            // !!!
            // check if files loaded before trying to update text
            // !!!
            ulong totalSize = 0;

            if (fastObjectListView1.GetItemCount() > 0)
            {
                if (fastObjectListView1.FilteredObjects != null)
                {
                    foreach (FileListItem item in fastObjectListView1.FilteredObjects)
                    {
                        totalSize += Convert.ToUInt64(item.CartridgeFileInfo.Length);
                    }

                    totalSizeText.Text = StaticMethods.FormatBytes(totalSize);
                    numCartridgesText.Text = database.GetNumCartridges().ToString();
                }
            }
            
        }

        private async Task selectFolderAndLoad()
        {
            initalizeDatabase();

            // update our dataset.
            //olv.SetObjects(database.GetFileList());
            await Task.Run(() => fastObjectListView1.SetObjects(database.GetFileList()));
        }

        private void initalizeDatabase()
        {
            // Initalize our main class.
            database = new Database();
        }

    }
}
