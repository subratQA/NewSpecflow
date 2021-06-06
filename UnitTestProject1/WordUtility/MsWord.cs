using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Word = Microsoft.Office.Interop.Word;

namespace Specflow.WordUtility
{
    public class MsWord
    {
        public void CreateOELogFromTemplate(String docName, String saveLocation, String applicationName, String version, String environment)
        {
            String newFile = CreateFile(docName, saveLocation);
            
            AddEnvironmentDetails(newFile, applicationName, version, environment);
            AddOELogTable(newFile);
        }

        public void CreateScreenshotLogFromTemplate(String docName, String saveLocation, String applicationName, String version, String environment)
        {
            String newFile = CreateFile(docName, saveLocation);
            AddEnvironmentDetails(newFile, applicationName, version, environment);
            AddScreenshotLogTable(newFile);
        }

        void AddScreenshotLogTable(string newFile)
        {
            try
            {
                Word.Application Wapp = new Word.Application();
                Wapp.Visible = false;
                Word.Document doc = Wapp.Documents.Open(newFile);

                object Missing = System.Reflection.Missing.Value;
                object EndOfDoc = "\\endofdoc";
                Word.Table TableObj;
                Word.Range Range = doc.Bookmarks.get_Item(ref EndOfDoc).Range;
                TableObj = doc.Tables.Add(Range, 1, 1, Missing, Missing);
                TableObj.Rows[1].Range.Bold = 1;
                TableObj.Borders.Enable = 1;

                doc.Close();
                Wapp.Quit();
            }
            catch (Exception e)
            {

            }
        }

        void AddOELogTable(string newFile)
        {
            try
            {
                Word.Application Wapp = new Word.Application();
                Wapp.Visible = false;
                Word.Document doc = Wapp.Documents.Open(newFile);


                //AddPersonnelAndInitiationTable();
                //AddEnvironmentAndAssumptionsTable();
                //AddStepsTable();
                //AddScreenshotsTable();


                object Missing = System.Reflection.Missing.Value;
                object EndOfDoc = "\\endofdoc";
                Word.Range Range = doc.Bookmarks.get_Item(ref EndOfDoc).Range;
                object objBreak = Word.WdBreakType.wdPageBreak;
                object objUnit = Word.WdUnits.wdStory;
                Wapp.Selection.EndKey(ref objUnit, ref Missing);
                Wapp.Selection.InsertBreak(ref objBreak);
                Word.Paragraph objP = doc.Paragraphs.Add();
                objP.Range.Bold = 1;

                doc.Tables.Add(Range, 1, 6, Missing, Missing);
                Word.Table stepTable = doc.Tables[1];
                stepTable.Borders.Enable = 1;
                stepTable.Range.Font.Size = 11;
                stepTable.Range.Font.Name = "Times New Roman";

                stepTable.Rows[1].Range.Bold = 1;
                stepTable.Cell(1, 1).Range.Text = "Step #";
                stepTable.Cell(1, 2).Range.Text = "Req ID";
                stepTable.Cell(1, 3).Range.Text = "Action(s)";
                stepTable.Cell(1, 4).Range.Text = "Expected Result(s)";
                stepTable.Cell(1, 5).Range.Text = "Actual Result";
                stepTable.Cell(1, 6).Range.Text = "Comments";

                Range = null;
                Range = doc.Bookmarks.get_Item(EndOfDoc).Range;
                Word.Paragraph objPara2 = doc.Content.Paragraphs.Add(Range);
                objPara2.Range.InsertParagraphBefore();

                doc.Tables.Add(Range, 1, 1, Missing, Missing);
                Word.Table screenshotTable = doc.Tables[2];

                doc.Close();
                Wapp.Quit();
            }
            catch (Exception e)
            {

            }
        }

        void AddEnvironmentDetails(String newFilePath, String applicationName, String version, String environment)
        {
            try
            {
                Word.Application Wapp = new Word.Application();
                Wapp.Visible = false;
                Word.Document doc = Wapp.Documents.Open(newFilePath);
                Word.Paragraph Para = doc.Paragraphs.Add();
                Para.Range.Bold = 1;
                Para.Range.Text = "Test Script:     " + FeatureContext.Current.FeatureInfo.Title + "    Run #1 \n";
                Para.Range.Bold = 0;
                Para.Range.Text = "Description:     " + FeatureContext.Current.FeatureInfo.Description + " \n";
                Para.Range.Text = "Application Name: " + applicationName + "\n";
                Para.Range.Text = "Version: " + version + "\n";
                Para.Range.Text = "Environment: " + environment + "\n\n";
                doc.Save();
                doc.Close();
                Wapp.Quit();
            }
            catch (Exception e)
            {

            }
        }

        String CreateFile(String docName, String location)
        {
            try
            {
                string TemplatePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
                TemplatePath = TemplatePath.Replace("file:\\", "");
                Word.Application Wapp = new Word.Application();
                Wapp.Visible = false;
                Word.Document doc = Wapp.Documents.Open(TemplatePath + @"\Reporting\OELogTemplate.docx");
                String newFileName = location + docName + ".docx";
                doc.SaveAs2(newFileName);
                doc.Close();
                Wapp.Quit();
                return newFileName;
            }
            catch (Exception e)
            {

            }
            return String.Empty;
        }
    }
}
