using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HotelReservation.Logger
{
    public class Log
    {
        public static void ExceptionLogger(Exception ex)
        {
            string message = string.Format("==>>  Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------**START**-------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "===================================**END**==============================";
            message += Environment.NewLine;
            using (StreamWriter writer = new StreamWriter("C:/Users/Deependra Tripathi/Desktop/Log.txt", true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static string  StatusLogger(string vendorConfirmationNumber)
        {
            string guidID = Guid.NewGuid().ToString();
            string status = string.Format("==>>  Time :{0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            status += Environment.NewLine;
            status += "---------------------------------------------------------------------------**START**---------------------------------------------------------------------------------------------";
            status += Environment.NewLine;
            status += string.Format("ConformationNumber :{0}", guidID);
            status += Environment.NewLine;
            status += string.Format("VendorConfirmationNo :{0}",vendorConfirmationNumber);
            status += Environment.NewLine;
            status += "=============================================================================**END**==============================================================================================";
            using (StreamWriter writer = new StreamWriter("C:/Users/Deependra Tripathi/Desktop/Status.txt", true))
            {
                writer.WriteLine(status);
                writer.Close();
            }
            return guidID;
        }
    }
}
