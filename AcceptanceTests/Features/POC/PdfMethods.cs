using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.IO;
using System.Reflection;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using DiffMatchPatch;


namespace AcceptanceTests.Features.POC
{
    class PdfMethods
    {


        public void PdfPigReadPdf(string pdfPath)
        {
            using (UglyToad.PdfPig.PdfDocument document = UglyToad.PdfPig.PdfDocument.Open(pdfPath))
            {
                foreach (Page page in document.GetPages())
                {
                    IReadOnlyList<Letter> letters = page.Letters;
                    string example = string.Join(string.Empty, letters.Select(x => x.Value));

                    IEnumerable<Word> words = page.GetWords();

                    IEnumerable<IPdfImage> images = page.GetImages();
                }
            }
        }


        public string iText7ReadPdf1(string pdfPath)
        {
            //var pageText = new StringBuilder();
            var pageText = "";
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(new PdfReader(pdfPath)))
            {
                var pageNumbers = pdfDocument.GetNumberOfPages();

                for (int i = 1; i <= pageNumbers; i++)
                {
                    LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                    PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                    parser.ProcessPageContent(pdfDocument.GetFirstPage());
                    //pageText.Append(strategy.GetResultantText());
                    pageText += strategy.GetResultantText();
                }
            }
            return pageText.ToString();
        }

        public string iText7ReadPdf2(string pdfPath)
        {
            var pageText = "";
            PdfReader pdfReader = new PdfReader(pdfPath);

            iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(pdfReader);
            var numberOfPages = pdfDoc.GetNumberOfPages();

            for (int page = 1; page <= numberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                pageText += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
            }
            pdfDoc.Close();
            pdfReader.Close();

            return pageText;
        }

        /// <summary>
        /// Originally built in 2006 to power Google Docs, this library is now available in C++, C#, Dart, Java, 
        /// JavaScript, Lua, Objective C, and Python.
        /// 
        /// Use this method and return True/False
        /// Re-run the failed compares and save the HTML format to display in the browser
        /// </summary>
        /// <param name="pdfPath1"></param>
        /// <param name="pdfPath2"></param>
        /// <returns></returns>
        public string ComparePdfFiles(string pdfPath1, string pdfPath2)
        {
            StringBuilder compareResult = new StringBuilder();

            //1.Read the PDF text from both PDF files
            var text1 = iText7ReadPdf1(pdfPath1);
            var text2 = iText7ReadPdf1(pdfPath2);

            //2. Create a diff_match_patch object
            diff_match_patch dmp = new diff_match_patch();

            //3. Call the diff method
            var diff = dmp.diff_main(text1, text2);
            var html = dmp.diff_prettyHtml(diff);

            var diffCount = diff.Count;  //Total #differences

            foreach (var d in diff)
            {
                compareResult.Append(d + "\n");
            }
            return compareResult.ToString();
        }





    }

}
