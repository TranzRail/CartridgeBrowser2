using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CartridgeBrowser2.Schema
{
    class CartridgeFile
    {
        // Name of the file (string)
        // E.g. "My File.txt"
        string _name;

        // Length (ulong)
        // E.g. "48171122688"
        string _length;

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

        // Extent info (XML node)
        XmlNode _extentinfo;

        // CRC32 hash from filename 
        string _crc32hash;

        // Filesize, derived from length.
        string _filesize;

        // Stores a reference to the parent directory.
        CartridgeDirectory _parentdirectory;

        // Current filepath.
        // E.g. \\ASG103\\Test Folder
        string _path;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Length
        {
            get { return _length; }
            private set { _length = value; }
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

        public XmlNode ExtentInfo
        {
            get { return _extentinfo; }
            private set { _extentinfo = value; }
        }

        public string CRC32Hash
        {
            get { return _crc32hash; }
            private set { _crc32hash = value; }
        }

        public string FileSize
        {
            get { return _filesize; }
            private set { _filesize = value; }
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

        public CartridgeFile(XmlNode fileNode, CartridgeDirectory parentDirectory)
        {
            try
            {
                Name = fileNode.SelectSingleNode("descendant::name").InnerText.ToString();
                Length = fileNode.SelectSingleNode("descendant::length").InnerText.ToString();
                ReadOnly = fileNode.SelectSingleNode("descendant::readonly").InnerText.ToString();
                CreationTime = fileNode.SelectSingleNode("descendant::creationtime").InnerText.ToString();
                ChangeTime = fileNode.SelectSingleNode("descendant::changetime").InnerText.ToString();
                ModifyTime = fileNode.SelectSingleNode("descendant::modifytime").InnerText.ToString();
                AccessTime = fileNode.SelectSingleNode("descendant::accesstime").InnerText.ToString();
                BackupTime = fileNode.SelectSingleNode("descendant::backuptime").InnerText.ToString();
                FileUID = fileNode.SelectSingleNode("descendant::fileuid").InnerText.ToString();
                ExtentInfo = fileNode.SelectSingleNode("descendant::extentinfo");

                // Get CRC32 hash from filename
                Regex r = new Regex(@"\[(.*?)\]"); // returns first captured group.
                Match hash = r.Match(Name);
                if (hash.Success && hash.Length == 10)
                {
                    CRC32Hash = hash.Value.Substring(1, 8);
                }
                else
                {
                    Console.WriteLine("[{0}] Invalid or missing hash within filename.", this.GetType().ToString());
                }

                // Calculate filesize
                FileSize = StaticMethods.FormatBytes(Convert.ToUInt64(Length));

                // Store the parent directory.
                ParentDirectory = parentDirectory;

                // Store our current filepath.
                if (ParentDirectory != null)
                {
                    Path = parentDirectory.Path + @"\" + Name;
                }
                else
                {
                    Path = Name;
                }

            }
            catch (NullReferenceException nullReferenceException)
            {
                Console.WriteLine("[{0}] Invalid or missing node.", this.GetType().ToString());
                Console.WriteLine(nullReferenceException);
            }
            
        }
    }
}
