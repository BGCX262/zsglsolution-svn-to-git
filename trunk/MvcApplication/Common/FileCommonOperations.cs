using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using PPT = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Data.OleDb;
using System.Data;

namespace MvcApplication
{
    public class FileCommonOperations
    {
        static object path;
        static object saveFileName;
        #region 转换PDF
        /// <summary>
        /// word转换成pdf
        /// </summary>
        /// <param name="filePath"></param>
        public static void Word2Pdf(string filePath)
        {
            path = filePath;
            saveFileName = filePath + ".pdf";
            var word = new Word.Application();
            Type wordType = word.GetType();
            Word.Documents docs = word.Documents;
            var docsType = docs.GetType();
            var doc = (Word.Document)docsType.InvokeMember("Open", BindingFlags.InvokeMethod, null, docs,
                new Object[] { path, true, true });
            Type docType = doc.GetType();
            docType.InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, doc,
                new object[] { saveFileName, Word.WdSaveFormat.wdFormatPDF });
            wordType.InvokeMember("Quit", BindingFlags.InvokeMethod, null, word, null);
        }

        /// <summary>
        /// excel转换成pdf
        /// </summary>
        /// <param name="filePath"></param>
        public static void Excel2Pdf(string filePath)
        {
            path = filePath;
            saveFileName = filePath + ".pdf";
            var xlsx = new Excel.Application();
            Excel.Workbook wb = xlsx.Workbooks.Open(path.ToString(),
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, saveFileName, Excel.XlFixedFormatQuality.xlQualityStandard,
                true, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.Close(false, Type.Missing, Type.Missing);
            wb = null;
            xlsx.Quit();
            xlsx = null;
        }

        /// <summary>
        /// ppt转换成pdf
        /// </summary>
        /// <param name="filePath"></param>
        public static void PPT2Pdf(string filePath)
        {
            path = filePath;
            saveFileName = filePath + ".pdf";
            var ppt = new PPT.Application();
            var doc = ppt.Presentations.Open(path.ToString(),
                       Microsoft.Office.Core.MsoTriState.msoFalse,
                       Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse);
            doc.SaveAs(saveFileName.ToString(), PPT.PpSaveAsFileType.ppSaveAsPDF, MsoTriState.msoTrue);
            doc.Close();
            doc = null;
            ppt.Quit();
            ppt = null;
        }
        #endregion

        #region 获取内容

        public static List<string> GetWordContent(string filePath)
        {
            try
            {
                List<string> allContent = new List<string>();
                string content = string.Empty;
                path = filePath;
                var word = new Word.Application();
                Type wordType = word.GetType();
                Word.Documents docs = word.Documents;
                var docsType = docs.GetType();
                var doc = (Word.Document)docsType.InvokeMember("Open", BindingFlags.InvokeMethod, null, docs,
                    new Object[] { path, true, true });
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    if (content.Length <= 300)
                        content += doc.Paragraphs[i+1].Range.Text;
                    else
                    {
                        allContent.Add(content);
                        content = "";
                        content += doc.Paragraphs[i+1].Range.Text;
                    }
                }
                if (allContent.Count == 0)
                    allContent.Add(content);
                Type docType = doc.GetType();
                docType.InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, doc,
                    new object[] { saveFileName, Word.WdSaveFormat.wdFormatPDF });
                wordType.InvokeMember("Quit", BindingFlags.InvokeMethod, null, word, null);
                return allContent;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取Excel内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> GetExcelContent(string filePath)
        {
            path = filePath;
            List<string> allContent = new List<string>();
            string content = string.Empty;
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbs = app.Workbooks;
            Excel.Workbook wb =
            wbs.Open(path.ToString(), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            string sss = string.Empty;
            for (int i = 0; i < wb.Worksheets.Count; i++)
            {
                Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets[i + 1];
                for (int j = 0; j < s.UsedRange.Cells.Rows.Count; j++)
                {
                    for (int k = 0; k < s.UsedRange.Cells.Columns.Count; k++)
                    {
                        if (content.Length <= 300)
                            content += ((Excel.Range)s.Cells[j + 1, k + 1]).Text.ToString();
                        else
                        {
                            allContent.Add(content);
                            content = "";
                            content += ((Excel.Range)s.Cells[j + 1, k + 1]).Text.ToString();
                        }
                    }
                }
                if (allContent.Count == 0)
                    allContent.Add(content);
            }
            wb.Close(false, Type.Missing, Type.Missing);
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            return allContent;
        }

        /// <summary>
        /// 获取PPT内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> GetPPTContent(string filePath)
        {
            path = filePath;
            List<string> allContent = new List<string>();
            string content = string.Empty;
            var ppt = new PPT.Application();
            var doc = ppt.Presentations.Open(path.ToString(),
                       Microsoft.Office.Core.MsoTriState.msoCTrue,
                       Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse);
            int Slides = doc.Slides.Count;
            foreach (PPT.Slide slide in doc.Slides)
            {
                foreach (PPT.Shape shape in slide.Shapes)
                {
                    if (content.Length <= 300)
                        content += shape.TextFrame.TextRange.Text;
                    else
                    {
                        allContent.Add(content);
                        content = "";
                        content += shape.TextFrame.TextRange.Text;
                    }
                }
                if (allContent.Count == 0)
                    allContent.Add(content);
            }
            ppt.Quit();
            return allContent;
        }

        #endregion
    }
}
