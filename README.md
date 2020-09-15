# Logger
Logging Code Challenge

Logger 
The logging process is used to log to the file system the different log levels as determined by user.
DEBUG, INFORMATION, WARNING and ERROR logs are currently available.

Usage:
Add the LoggerDemo file to the application using the logger.

Either pass the logger as a parameter or use globally.  

Files:
Ilogger 
	Sets up an interface with the log parameters. 
	logType: The type of logging message
	message: The logging message 

FileLogger
	Inherits the logging interface
	Log Method - takes log type and message as parameters
	Sets the environment where the log files are written
	Sets file location and name of the log file
	Uses StreamWriter to write files
	Case statement is used to determine type of log and where the message is written
	By default all the messages are written to the log.txt file
	Additional logs are written to specific files for segmentation 
	LogMessage Method - takes logtype, message and filePath as parameters
		Writes message to the appropriate file location

App.Config
	Defines the Environment the files are written to.
	Each filePath needs to be set up prior to running app. ex. 'C:\temp\PROD' 'C:\temp\DEVL'
