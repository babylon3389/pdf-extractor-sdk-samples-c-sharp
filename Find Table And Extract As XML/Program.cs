//****************************************************************************//
//                                                                            //
// Download evaluation version: https://bytescout.com/download/web-installer  //
//                                                                            //
// Signup Cloud API free trial: https://secure.bytescout.com/users/sign_up    //
//                                                                            //
// Copyright © 2017 ByteScout Inc. All rights reserved.                       //
// http://www.bytescout.com                                                   //
//                                                                            //
//****************************************************************************//


using Bytescout.PDFExtractor;

namespace FindTableAndExtractAsXml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Bytescout.PDFExtractor.XMLExtractor instance
            XMLExtractor xmlExtractor = new XMLExtractor();
            xmlExtractor.RegistrationName = "demo";
            xmlExtractor.RegistrationKey = "demo";

            // Create Bytescout.PDFExtractor.TableDetector instance
            TableDetector tableDetector = new TableDetector();
            tableDetector.RegistrationKey = "demo";
            tableDetector.RegistrationName = "demo";

            // We should define what kind of tables we should detect.
            // So we set min required number of columns to 3 ...
            tableDetector.DetectionMinNumberOfColumns = 3;
            // ... and we set min required number of columns to 3
            tableDetector.DetectionMinNumberOfRows = 3;

            // Load sample PDF document
            xmlExtractor.LoadDocumentFromFile(@".\sample3.pdf");
            tableDetector.LoadDocumentFromFile(@".\sample3.pdf");

            // Get page count
            int pageCount = tableDetector.GetPageCount();

            for (int i = 0; i < pageCount; i++)
            {
                int t = 1;
                // Find first table and continue if found
                if (tableDetector.FindTable(i))
                {
                    do
                    {
                        // Set extraction area for XML extractor to rectangle received from the table detector
                        xmlExtractor.SetExtractionArea(tableDetector.FoundTableLocation);
                        // Export the table to XML file
                        xmlExtractor.SavePageXMLToFile(i, "page-" + i + "-table-" + t + ".xml");
                        t++;
                    } 
                    while (tableDetector.FindNextTable()); // search next table
                }
            }

            xmlExtractor.Dispose();
            tableDetector.Dispose();

            // Open first output file in default associated application (for demo purposes)
            System.Diagnostics.Process.Start("page-0-table-1.xml");
        }
    }
}
