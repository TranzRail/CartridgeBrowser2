using CartridgeBrowser2.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartridgeBrowser2
{
    class FileListItem
    {
        string _filename;
        string _file_extension;
        string _filesize;
        string _crc32hash;
        string _barcode;
        string _volume_name;
        string _volume_uuid;
        string _creation_time;
        string _filepath;
        CartridgeFile _cartridge_fileinfo;
        Cartridge _cartridgeinfo;

        public string Filename
        {
            get { return _filename; }
            private set { _filename = value; }
        }

        public string FileExtension
        {
            get { return _file_extension; }
            private set { _file_extension = value; }
        }

        public string FileSize
        {
            get { return _filesize; }
            private set { _filesize = value; }
        }

        public string CRC32Hash
        {
            get { return _crc32hash; }
            private set { _crc32hash = value; }
        }

        public string Barcode
        {
            get { return _barcode; }
            private set { _barcode = value; }
        }

        public string VolumeName
        {
            get { return _volume_name; }
            private set { _volume_name = value; }
        }

        public string VolumeUUID
        {
            get { return _volume_uuid; }
            private set { _volume_uuid = value; }
        }

        public string CreationTime
        {
            get { return _creation_time; }
            private set { _creation_time = value; }
        }

        public string Filepath
        {
            get { return _filepath; }
            private set { _filepath = value; }
        }

        public CartridgeFile CartridgeFileInfo
        {
            get { return _cartridge_fileinfo; }
            set { _cartridge_fileinfo = value; }
        }

        public Cartridge CartridgeInfo
        {
            get { return _cartridgeinfo; }
            set { _cartridgeinfo = value; }
        }

        public FileListItem(CartridgeFile file, Cartridge cart)
        {
            // Store our references to the schema data.
            CartridgeFileInfo = file;
            CartridgeInfo = cart;

            // Populate our fields.
            if (file.Name.Length >=1 && file.Name.Contains("."))
            {
                Filename = file.Name.Substring(0, file.Name.LastIndexOf('.'));
            }
            else
            {
                // Dump the raw value from the XML if we can't substring it properly.
                Filename = file.Name;
            }

            if (file.Name.Length >= 1 && file.Name.Contains("."))
            {
                Filename = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                FileExtension = file.Name.Substring(file.Name.LastIndexOf('.'));
            }
            else
            {
                // Dump the raw value from the XML if we can't substring it properly.
                Filename = file.Name;
                FileExtension = "";
            }

            FileSize = file.FileSize;
            //FileSize = file.Length; use this if we want to fix the sort by filesize issue.
            CRC32Hash = file.CRC32Hash;
            Barcode = cart.Barcode;
            VolumeName = cart.GetVolumeName(); ;
            VolumeUUID = cart.VolumeUUID;

            // Format our date for readability.
            DateTime datetime = DateTime.Parse(file.CreationTime);
            string format = "dd MMMM yyyy HH:mm: ss";

            CreationTime = datetime.ToString(format);

            Filepath = file.Path;
        }


    }
}
