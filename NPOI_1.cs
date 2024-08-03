#region Help:  Introduction to the script task
/* The Script Task allows you to perform virtually any operation that can be accomplished in
 * a .Net application within the context of an Integration Services control flow. 
 * 
 * Expand the other regions which have "Help" prefixes for examples of specific ways to use
 * Integration Services features within this script task. */
#endregion


#region Namespaces
using System;
using System.Data;
using Microsoft.SqlServer.Dts.Runtime;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;
using System.IO;
#endregion

namespace ST_8a95b7992e92411eb9cf3365cdeb04e3
{
    /// <summary>
    /// ScriptMain is the entry point class of the script.  Do not change the name, attributes,
    /// or parent of this class.
    /// </summary>
	[Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
	public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
	{
        #region Help:  Using Integration Services variables and parameters in a script
        /* To use a variable in this script, first ensure that the variable has been added to 
         * either the list contained in the ReadOnlyVariables property or the list contained in 
         * the ReadWriteVariables property of this script task, according to whether or not your
         * code needs to write to the variable.  To add the variable, save this script, close this instance of
         * Visual Studio, and update the ReadOnlyVariables and 
         * ReadWriteVariables properties in the Script Transformation Editor window.
         * To use a parameter in this script, follow the same steps. Parameters are always read-only.
         * 
         * Example of reading from a variable:
         *  DateTime startTime = (DateTime) Dts.Variables["System::StartTime"].Value;
         * 
         * Example of writing to a variable:
         *  Dts.Variables["User::myStringVariable"].Value = "new value";
         * 
         * Example of reading from a package parameter:
         *  int batchId = (int) Dts.Variables["$Package::batchId"].Value;
         *  
         * Example of reading from a project parameter:
         *  int batchId = (int) Dts.Variables["$Project::batchId"].Value;
         * 
         * Example of reading from a sensitive project parameter:
         *  int batchId = (int) Dts.Variables["$Project::batchId"].GetSensitiveValue();
         * */

        #endregion

        #region Help:  Firing Integration Services events from a script
        /* This script task can fire events for logging purposes.
         * 
         * Example of firing an error event:
         *  Dts.Events.FireError(18, "Process Values", "Bad value", "", 0);
         * 
         * Example of firing an information event:
         *  Dts.Events.FireInformation(3, "Process Values", "Processing has started", "", 0, ref fireAgain)
         * 
         * Example of firing a warning event:
         *  Dts.Events.FireWarning(14, "Process Values", "No values received for input", "", 0);
         * */
        #endregion

        #region Help:  Using Integration Services connection managers in a script
        /* Some types of connection managers can be used in this script task.  See the topic 
         * "Working with Connection Managers Programatically" for details.
         * 
         * Example of using an ADO.Net connection manager:
         *  object rawConnection = Dts.Connections["Sales DB"].AcquireConnection(Dts.Transaction);
         *  SqlConnection myADONETConnection = (SqlConnection)rawConnection;
         *  //Use the connection in some code here, then release the connection
         *  Dts.Connections["Sales DB"].ReleaseConnection(rawConnection);
         *
         * Example of using a File connection manager
         *  object rawConnection = Dts.Connections["Prices.zip"].AcquireConnection(Dts.Transaction);
         *  string filePath = (string)rawConnection;
         *  //Use the connection in some code here, then release the connection
         *  Dts.Connections["Prices.zip"].ReleaseConnection(rawConnection);
         * */
        #endregion


		/// <summary>
        /// This method is called when this script task executes in the control flow.
        /// Before returning from this method, set the value of Dts.TaskResult to indicate success or failure.
        /// To open Help, press F1.
        /// </summary>
		public void Main()
		{
            // Excel file path and name
            var filename = @"C:\Users\Dell-PC\Desktop\Shubham\NPOI testing\NPOI Sheet Rename Test File.xlsx";
            //Load file
            IWorkbook book = WorkbookFactory.Create(filename);
            //Iterate through sheets and show name
            for(var i=0; i<book.NumberOfSheets;i++)
            {
                Console.WriteLine("Sheet " + i.ToString() + " --> " + book.GetSheetName(i));
            }
            //Change Sheet Name
            book.SetSheetName(0, "SkOne");
            book.SetSheetName(1, "SkTwo");
            book.SetSheetName(2, "SkThree");
            //Iterate again
            for (var i = 0; i < book.NumberOfSheets; i++)
            {
                Console.WriteLine("Sheet " + i.ToString() + " --> " + book.GetSheetName(i));
            }
            //Save File
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                book.Write(fs);
            }

            book.Close();

            Dts.TaskResult = (int)ScriptResults.Success;
		}

        #region ScriptResults declaration
        /// <summary>
        /// This enum provides a convenient shorthand within the scope of this class for setting the
        /// result of the script.
        /// 
        /// This code was generated automatically.
        /// </summary>
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
        #endregion

	}
}


-------------------------------------------------------------------------------------------------------------------------

@"C:\Users\Dell-PC\Desktop\Shubham\NPOI testing\MOCK_DATA.xlsx

Keep the .NET Framework to latest version (ex.4.7)

install-package NPOI
install-package NPOI -version 2.5.6


Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\net45\NPOI.OOXML.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\net45\NPOI.OpenXml4Net.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\net45\NPOI.OpenXmlFormats.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.1\NPOI.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.1\NPOI.OOXML.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.1\NPOI.OpenXml4Net.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.1\NPOI.OpenXmlFormats.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.0\NPOI.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.0\NPOI.OOXML.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.0\NPOI.OpenXml4Net.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\netstandard2.0\NPOI.OpenXmlFormats.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\npoi\2.5.6\lib\net45\NPOI.dll"


Gacutil /I "C:\Users\Dell-PC\.nuget\packages\portable.bouncycastle\1.8.9\lib\net40\BouncyCastle.Crypto.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\portable.bouncycastle\1.8.9\lib\netstandard2.0\BouncyCastle.Crypto.dll"

Gacutil /I "C:\Users\Dell-PC\.nuget\packages\sharpziplib\1.3.3\lib\net45\ICSharpCode.SharpZipLib.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\sharpziplib\1.3.3\lib\netstandard2.1\ICSharpCode.SharpZipLib.dll"
Gacutil /I "C:\Users\Dell-PC\.nuget\packages\sharpziplib\1.3.3\lib\netstandard2.0\ICSharpCode.SharpZipLib.dll"