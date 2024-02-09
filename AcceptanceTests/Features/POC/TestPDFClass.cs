using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Features.POC
{
    class TestPDFClass
    {

        [Test]
        public void TestPDF()
        {
            //Get data file dir + PDF filename
            //var runDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var runDir = Directory.GetCurrentDirectory();
            var dir1 = Directory.GetParent(runDir).FullName.ToString();
            var dir2 = Directory.GetParent(dir1).FullName.ToString();
            var projectDir = Directory.GetParent(dir2).FullName.ToString();

            var dataFileDir = projectDir + @"\AcceptanceTests\DataFiles\";

            //Select the filename
            var pdfPath1 = dataFileDir + "sample-pdf-file1.pdf";
            //var pdfPath1 = dataFileDir + "T38_TEST_PAGES1.pdf";
            //var pdfPath1 = dataFileDir + "AARPMedicareAdvantagePlan5.1.pdf";

            var pdfPath2 = dataFileDir + "sample-pdf-file2.pdf";
            //var pdfPath2 = dataFileDir + "T38_TEST_PAGES2.pdf";
            //var pdfPath2 = dataFileDir + "AARPMedicareAdvantagePlan5.2.pdf";

            //Create PdfMethods object
            PdfMethods pdfMethods = new PdfMethods();
            string result = pdfMethods.iText7ReadPdf1(pdfPath1);
            result = pdfMethods.iText7ReadPdf2(pdfPath1);
            pdfMethods.PdfPigReadPdf(pdfPath1);

            result = pdfMethods.ComparePdfFiles(pdfPath1, pdfPath2);


        }




    }
}
