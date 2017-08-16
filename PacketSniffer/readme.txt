Brad Howard's Packet Sniffer

To run go to ./PacketSniffer/PacketSniffer/bin/Debug

run PacketSniffer.exe

The GUI will run;
	Buttons:
		Start Sniff - Sniff the device number 0
		Stop Sniff - Stops the Sniff
		Clear Log - Clears the log, if the log hasn't been save will popup a window asking if the user wants to clear with out saving
	Scan Mode:
		Normal Mode - Sniff only packet for your computer
		Promiscuous Mode - Sniffs all packet running on the network
	File Writing:
		Write to File - is a ckeck box to write all log entry to a file, users enters a file name
	Filter Setting:
		Set Filter - any checked items in the list of protocol with be set
		Clear Filter - clears the filter
Menus
	File:
		Save Log - saves the log to a file
		Load Log - loads a file and places all entries into the viewer
		Exit - Quits the program
	Setting:
		Set Normal Mode - set the sniffer to normal scan
		Set Promiscuous Mode - Set the sniffer to promiscuous scan
		Write to File - Set the write to file mode, if no name is given in the file name box, its write the log to log.txt
	View:
		Clear Log - clears the log
		Set Filter - set the filter
	Info:
		Info - Displays the Info on the Program
		Help - Gives a limited help info
		

for the Code all sorce files are in PacketSniffer/PacketSniffer

open PacketSniffer.sln in Visual Studio to compilation instructions.