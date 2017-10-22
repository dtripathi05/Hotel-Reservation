using System;
using System.IO;

namespace HotelReservation.Logger
{
    public class Log
    {
        public static void ExcpLogger(Exception ex)
        {
            string message = string.Format("==>>  Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "=================================================================";
            message += Environment.NewLine;
            using (StreamWriter writer = new StreamWriter("C:/Users/Deependra Tripathi/Desktop/Log.txt", true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
