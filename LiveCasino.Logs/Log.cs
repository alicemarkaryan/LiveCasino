namespace LiveCasino.Logs
{
    public class Log
    {
        private string logFilePath = "C:\\Alisa\\Logs\\CasinoLive.log";

        public string LogMessage(string message)
        {
            try
            {
                // Create or open the log file for appending
                using (StreamWriter writer = File.AppendText(logFilePath))
                {

                    string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                    writer.WriteLine(logEntry);
                    return logEntry;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"Error logging message: {ex.Message}";
                return errorMsg;
            }
        }

        public void ExampleUsage()
        {
            Log logger = new Log();
            string result = logger.LogMessage("This is a log message for casino live");
        }
    }


}
