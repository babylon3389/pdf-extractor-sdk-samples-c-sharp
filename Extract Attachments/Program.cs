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


using System;
using Bytescout.PDFExtractor;

namespace ExtractAttachments
{
    class Program
    {
        static void Main()
        {
            // Create Bytescout.PDFExtractor.AttachmentExtractor instance
            AttachmentExtractor extractor = new AttachmentExtractor();
            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";

            // Load sample PDF document
            extractor.LoadDocumentFromFile(@".\attachments.pdf");

            for (int i = 0; i < extractor.Count; i++)
            {
                Console.WriteLine("Saving attachment: " + extractor.GetFileName(i));
                // Save attachment to file
                extractor.Save(i, extractor.GetFileName(i));
                Console.WriteLine("File size: " + extractor.GetSize(i));
            }

            extractor.Dispose();
        }
    }
}
