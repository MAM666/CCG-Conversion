# CCG-Conversion
A simple console conversion tool.
There are currently 4 params:
F\<filename> - the extension is the important part see below. 
O\<output> - the extension is the important part see below. If no filename then will use the input filename. All output filename will be overwritten if they exist.
P\<pattern> - currently only '_' and 'people' are supported.
-wait - the console will stay open till the user presses a key.

extensions: 
csv - its a csv file. First line must be the headers.
xml - its an xml file.
json - its a json file.
db - its a database file:
First line is the connection string.
Second line is the SQL to execute.

either a copletion message will be printed to the console or a problem message.

