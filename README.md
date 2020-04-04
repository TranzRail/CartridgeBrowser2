# CartridgeBrowser2
A GUI tool to explore LTFS schema files generated by the HP LTFS tool (and possibly others).

## How to Use

Build, run, browse to the folder containing the schema files (default is usually C:\LTFS). See "SAMPLE.schema" in case you aren't sure what file you are looking for.

Notes:

* The column titled "barcode" gets this information from the schema filename as the barcode is not stored within the file itself. If a tape does not have a barcode set during formatting, the filename will be the tape UUID and thus will show "NO BARCODE" within the UI.
* The CRC32 file has gets this information from the filename recorded within the schema. The string should look like this "[4D1D5B40]". I personally use rapidcrc to hash my files prior to writing. 

## Screenshot
![Main screen](https://github.com/TranzRail/CartridgeBrowser2/blob/master/sample001.png)

## DISCLAIMER
This program is probably buggy and is a poor example of programming. If you wish to make a fix or a change, submit a pull request.
**USE AT YOUR OWN RISK** 

## Dependencies
Uses ObjectListView, located here http://objectlistview.sourceforge.net/cs/index.html.