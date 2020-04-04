using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CartridgeBrowser2.Schema;

namespace CartridgeBrowser2
{
    class Database
    {
        // Stores a list of filepaths to xml files.
        List<Cartridge> cartridges;
        List<FileListItem> files;

        public List<FileListItem> GetFileList()
        {
            return files;
        }

        public int GetNumCartridges()
        {
            return cartridges.Count;
        }

        public Database()
        {
            scanDirectory();
            buildFileList();
        }

        private void scanDirectory()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                // dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                //dialog.RootFolder = Environment.CurrentDirectory;
                dialog.SelectedPath = Environment.CurrentDirectory;

                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    // Initalize our list of cartridges.
                    cartridges = new List<Cartridge>();

                    // Iterate over the files found within the selected directory.
                    foreach (string path in Directory.GetFiles(dialog.SelectedPath))
                    {
                        // Get file info. Probably not needed at this stage.
                        FileInfo fileInfo = new FileInfo(path);

                        // Only add files to our list if they have the right file extension, case insensitive.
                        if (path.IndexOf(".schema", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(path);

                            XmlNode node = xmlDocument.SelectSingleNode("//ltfsindex");

                            // Check to see if the XML document loaded has what we're looking for.
                            if (node != null)
                            {
                                cartridges.Add(new Cartridge(xmlDocument, Path.GetFileNameWithoutExtension(path)));
                            }
                        }
                        
                    }
                    // Just some debug info on how many valid xml files were found.
                    Console.WriteLine("[{0}] Found {1} files.", this.GetType().ToString(), cartridges.Count);
                }
                else if (result == DialogResult.Cancel)
                {
                    // no folder was selected
                }
                
            }
        }

        private List<FileListItem> buildFileList()
        {
            // Initialize our file list.
            files = new List<FileListItem>();

            if (cartridges != null && cartridges.Count >= 1)
            {
                // Iterate over our cartridges
                foreach (Cartridge cart in cartridges)
                {
                    // Iterate over the files stored on the root of cartridge.
                    foreach (CartridgeFile file in cart.AllFiles)
                    {
                        FileListItem item = new FileListItem(file, cart);
                        files.Add(item);
                    }
                }
                Console.WriteLine("[{0}] Finished building file list.", this.GetType().ToString());
            }

            return files;
        }

    }
}
