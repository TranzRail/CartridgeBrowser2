using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CartridgeBrowser2.Schema
{
    class Cartridge
    {
        // Name of the program that created the file (string)
        // E.g. "HPE LTFS 3.4.2 - Windows - ltfs - Unmount"
        string _creator;

        // Unique identifier for the volume (string)
        // E.g. "8a4eac79-f871-4835-94f3-0a18479b45f3"
        string _volumeuuid;

        // Generation number (string)
        // E.g. "47"
        // Note: could be a counter for the number of times the tape has been formatted.
        string _generationnumber;

        // The time that the file was updated (string)
        // E.g. "2019-05-18T18:15:55.000976000Z"
        string _updatetime;

        // Location (string)
        // E.g. ""
        // Notes: See sample XML file.
        List<Location> _location;

        // Previous Generation Location (string)
        // E.g. ""
        // Notes: see sample XML file.
        List<PreviousGenerationLocation> _previousgenerationlocation;

        // Policy update flag (bool)
        // E.g. "true"
        string _allowpolicyupdate;

        // Volume lock state (string)
        // E.g. "unlocked"
        // Notes: Determined by the physical switch on the cartridge.
        string _volumelockstate;

        // Highest File UID (string)
        // E.g. "15"
        // Notes: UID for the last file or folder written.
        string _highestfileuid;

        // The root directory of the cartridge
        // E.g. "LTFS Volume" or "ASG110L5"
        CartridgeDirectory _rootDirectory;

        // The cartridge barcode.
        // E.g. ASG110
        // Notes: the volume UUID will be here if the cardridge does not have a barcode defined when formatted.
        string _barcode;

        // Stores the total number of directories on the cartridge.
        int _totalNumberOfDirectories = 0;

        // Stores the total number of files on the cartridge.
        int _totalNumberOfFiles = 0;

        // Stores the total space used by all files (in bytes).
        ulong _totalSpaceUsed = 0;

        // Stores all the files found.
        List<CartridgeFile> _allFiles;

        public string Creator
        {
            get { return _creator; }
            private set { _creator = value; }
        }

        public string VolumeUUID
        {
            get { return _volumeuuid; }
            private set { _volumeuuid = value; }
        }

        public string GenerationNumber
        {
            get { return _generationnumber; }
            private set { _generationnumber = value; }
        }

        public string UpdateTime
        {
            get { return _updatetime; }
            private set { _updatetime = value; }
        }

        public List<Location> Location
        {
            get { return _location; }
            private set { _location = value; }
        }

        public List<PreviousGenerationLocation> PreviousGenerationLocation
        {
            get { return _previousgenerationlocation; }
            private set { _previousgenerationlocation = value; }
        }

        public string AllowPolicyUpdate
        {
            get { return _allowpolicyupdate; }
            private set { _allowpolicyupdate = value; }
        }

        public string VolumeLockState
        {
            get { return _volumelockstate; }
            private set { _volumelockstate = value; }
        }

        public string HighestFileUID
        {
            get { return _highestfileuid; }
            private set { _highestfileuid = value; }
        }

        public CartridgeDirectory RootDirectory
        {
            get { return _rootDirectory; }
            private set { _rootDirectory = value; }
        }

        public string GetVolumeName()
        {
            return RootDirectory.Name;
        }
        public string Barcode
        {
            get { return _barcode; }
            private set { _barcode = value; }
        }

        public int GetTotalNumberOfDirectories
        {
            get { return _totalNumberOfDirectories; }
            private set { _totalNumberOfDirectories = value; }
        }

        public int GetTotalNumberOfFiles
        {
            get { return _totalNumberOfFiles; }
            private set { _totalNumberOfFiles = value; }
        }
        

        public ulong GetTotalSpaceUsed
        {
            get { return _totalSpaceUsed; }
            private set { _totalSpaceUsed = value; }
        }

        public List<CartridgeFile> AllFiles
        {
            get { return _allFiles; }
            private set { _allFiles = value; }
        }

        public Cartridge(XmlDocument documentRoot, string filename)
        {
            // Get our field data from the XML document.
            Creator = documentRoot.SelectSingleNode("descendant::creator").InnerText.ToString();
            VolumeUUID = documentRoot.SelectSingleNode("descendant::volumeuuid").InnerText.ToString();
            GenerationNumber = documentRoot.SelectSingleNode("descendant::generationnumber").InnerText.ToString();
            UpdateTime = documentRoot.SelectSingleNode("descendant::updatetime").InnerText.ToString();

            // !! IMPORTANT !! replace these two lines to add the contents of location and previous generation location
            //ModifyTime = directoryNode.SelectSingleNode("descendant::modifytime").InnerText.ToString();
            //AccessTime = directoryNode.SelectSingleNode("descendant::accesstime").InnerText.ToString();

            AllowPolicyUpdate = documentRoot.SelectSingleNode("descendant::allowpolicyupdate").InnerText.ToString();
            VolumeLockState = documentRoot.SelectSingleNode("descendant::volumelockstate").InnerText.ToString();
            HighestFileUID = documentRoot.SelectSingleNode("descendant::highestfileuid").InnerText.ToString();

            // Get the XmlNode for our cartridge data.
            XmlNode root = documentRoot.SelectSingleNode("//ltfsindex");

            // Initialize the RootDirectory object.
            RootDirectory = new CartridgeDirectory(root.SelectSingleNode("//directory"), null);

            // Store the cartridge barcode, which is sourced from the filename (unfortunately).
            if (!string.IsNullOrEmpty(filename) && filename.Length <= 6)
            {
                Barcode = filename;
            }
            else
            {
                Barcode = "NO BARCODE";
            }

            // Count the number of files, directories and get total size used.
            gatherStatistics(RootDirectory);

            // Initalize our all files list.
            AllFiles = new List<CartridgeFile>();

            // Add the files from the root to the list of all files.
            // Move this below the recursive list if you want the root files at the end
            // of the list.
            AllFiles.AddRange(RootDirectory.Files);

            // Get all the files on the cartridge.
            indexAllFilesInSubdirectories(RootDirectory);
        }

        private void gatherStatistics(CartridgeDirectory directory)
        {
            // Add the total number of files within the directory to the count. 
            GetTotalNumberOfFiles += directory.Files.Count;

            // Add up the total file size used by this directory.
            foreach (CartridgeFile file in directory.Files)
            {
                GetTotalSpaceUsed += Convert.ToUInt64(file.Length);
            }

            foreach (CartridgeDirectory subdirectory in directory.Subdirectories)
            {
                // Count the directories as we traverse them.
                GetTotalNumberOfDirectories++;

                // Continue our search for directories and files.
                gatherStatistics(subdirectory);
            }
        }

        private void indexAllFilesInSubdirectories(CartridgeDirectory directory)
        {
            // Start searching subdirectories for files.
            foreach (CartridgeDirectory subdirectory in directory.Subdirectories)
            {
                AllFiles.AddRange(subdirectory.Files);
                indexAllFilesInSubdirectories(subdirectory);
            }
        }

    }
}
