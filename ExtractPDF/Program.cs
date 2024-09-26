using System;
using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace Ler_PDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = @"C:\New-C#-Projects\extract-text-of-pdf\cert-simple.pdf";
            string text = ExtractTextFromPdf(pdfPath);
            Console.WriteLine(text);
            Console.ReadLine();
        }

        static string ExtractTextFromPdf(string pdfPath)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader pdfReader = new PdfReader(pdfPath))
            using (PdfDocument pdfDoc = new PdfDocument(pdfReader))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
                }
            }
            return text.ToString();
        }
    }
}