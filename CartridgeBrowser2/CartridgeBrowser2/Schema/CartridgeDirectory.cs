using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CartridgeBrowser2.Schema
{
    class CartridgeDirectory
    {
        // Name of the directory (string)
        // E.g. "MyDirectory"
        string _name;

        // Read-only state (bool)
        // E.g. "false"
        string _readonly;

        // Creation time (string)
        // E.g. "2019-05-04T06:06:01.000289000Z"
        string _creationtime;

        // Change time (string)
        // E.g. "2019-05-16T16:06:33.000839000Z"
        string _changetime;

        // Modify time (string)
        // E.g. "2019-05-16T16:06:33.000839000Z"
        string _modifytime;

        // Access time (string)
        // E.g. "2019-05-16T17:04:45.000785000Z"
        string _accesstime;

        // Backup time (string)
        // E.g. "2019-05-04T06:06:01.000289000Z"
        string _backuptime;

        // File UID (ulong)
        // E.g. "1"
        string _fileuid;

        // Sub directories
        List<CartridgeDirectory> _subdirectories;

        // Files array (XML node)
        List<CartridgeFile> _files;

        // Parent directory
        CartridgeDirectory _parentdirectory;

        // Current filepath.
        // E.g. \\ASG103\\Test Folder
        string _path;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string ReadOnly
        {
            get { return _readonly; }
            private set { _readonly = value; }
        }

        public string CreationTime
        {
            get { return _creationtime; }
            private set { _creationtime = value; }
        }

        public string ChangeTime
        {
            get { return _changetime; }
            private set { _changetime = value; }
        }

        public string ModifyTime
        {
            get { return _modifytime; }
            private set { _modifytime = value; }
        }

        public string AccessTime
        {
            get { return _accesstime; }
            private set { _accesstime = value; }
        }

        public string BackupTime
        {
            get { return _backuptime; }
            private set { _backuptime = value; }
        }

        public string FileUID
        {
            get { return _fileuid; }
            private set { _fileuid = value; }
        }

        public List<CartridgeDirectory> Subdirectories
        {
            get { return _subdirectories; }
            private set { _subdirectories = value; }
        }

        public List<CartridgeFile> Files
        {
            get { return _files; }
            private set { _files = value; }
        }

        public CartridgeDirectory ParentDirectory
        {
            get { return _parentdirectory; }
            private set { _parentdirectory = value; }
        }
        public string Path
        {
            get { return _path; }
            private set { _path = value; }
        }

        public int GetTotalNumOfSubDirectories()
        {
            return Subdirectories.Count();
        }

        


        public CartridgeDirectory(XmlNode directoryNode, CartridgeDirectory parentDirectory)
        {
            Name = directoryNode.SelectSingleNode("descendant::name").InnerText.ToString(); 
            ReadOnly = directoryNode.SelectSingleNode("descendant::readonly").InnerText.ToString();
            CreationTime = directoryNode.SelectSingleNode("descendant::creationtime").InnerText.ToString();
            ChangeTime = directoryNode.SelectSingleNode("descendant::changetime").InnerText.ToString();
            ModifyTime = directoryNode.SelectSingleNode("descendant::modifytime").InnerText.ToString();
            AccessTime = directoryNode.SelectSingleNode("descendant::accesstime").InnerText.ToString();
            BackupTime = directoryNode.SelectSingleNode("descendant::backuptime").InnerText.ToString();
            FileUID = directoryNode.SelectSingleNode("descendant::fileuid").InnerText.ToString();

            // Store a reference to the parent directory.
            ParentDirectory = parentDirectory;
            
            // Set our current path.
            if (ParentDirectory != null)
            {
                Path = parentDirectory.Path + @"\" + Name;
            }
            else
            {
                //Path = @"\";
                Path = "";
            }

            // Initalize our Lists.
            Subdirectories = new List<CartridgeDirectory>();
            Files = new List<CartridgeFile>();

            foreach (XmlNode node in directoryNode.SelectSingleNode("descendant::contents"))
            {
                if (node.Name == "directory")
                {
                    CartridgeDirectory directory = new CartridgeDirectory(node, this);
                    Subdirectories.Add(directory);
                }
                if (node.Name == "file")
                {
                    CartridgeFile file = new CartridgeFile(node, this);
                    Files.Add(file);
                }
            }

            
        }

    }
}
