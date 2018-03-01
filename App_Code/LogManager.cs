using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LogManager
/// </summary>
public static class LogManager
{
    const string logFilePath = "";
   public  static void Logerror1(string _class,string method,  string message)
    {
        string res = "Date: " + DateTime.Now + "\n";
        res += "Class: " + _class + "\r\n";
        res += "Method: " + method+ "\r\n";
       // res += "Exeption Type: " + _type+ "\r\n";
        res += "Message: " + message+ "\r\n";
        res += "*********************************************************************************\r\n";
        res += "*********************************************************************************\r\n";
        File.AppendAllText(logFilePath, res);
    }
}