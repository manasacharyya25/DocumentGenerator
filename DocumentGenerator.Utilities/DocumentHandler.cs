using DocumentGenerator.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gherkin.Ast;
using Xceed.Words.NET;

namespace DocumentGenerator.Utilities
{
    public class DocumentHandler
    { 
        public static void GenerateFeatureSpecDocument(Feature feature,DocX doc)
        {
            string title = feature.Name;

            Formatting titleFormat = new Formatting();
            titleFormat.FontFamily = new Xceed.Words.NET.Font("Arial");
            titleFormat.Size = 13D;
            titleFormat.Position = 10;
            titleFormat.FontColor = System.Drawing.Color.Black;
            titleFormat.Bold = true;

            doc.InsertParagraph(title, false, titleFormat);

            int rows = GetNumberOfRows(feature);

            Xceed.Words.NET.Table t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].Paragraphs.First().Append("FS_Id");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Requirement");
            
            t.Rows[0].Cells[0].Paragraphs.First().Bold();
            t.Rows[0].Cells[1].Paragraphs.First().Bold();

            int InsertDataToThisRowNext = 1;

            foreach (var child in feature.Children)
            {
                string FS_ID;
                string Requirement;

                if (child.Keyword.ToString().Equals("Scenario"))
                {
                    var scenario = (Scenario)child;

                    FS_ID = scenario.Tags.ElementAt(0).Name.ToString().Substring(7);
                    Requirement = scenario.Name;
                }
                else if (child.Keyword.ToString().Equals("Scenario Outline"))
                {
                    var scenario = (ScenarioOutline)child;

                    FS_ID = scenario.Tags.ElementAt(0).Name.ToString().Substring(7);
                    Requirement = scenario.Name;
                }
                else
                {
                    continue;
                }

                t.Rows[InsertDataToThisRowNext].Cells[0].Paragraphs.First().Append(FS_ID);

                t.Rows[InsertDataToThisRowNext].Cells[1].Paragraphs.First().Append(Requirement);

                InsertDataToThisRowNext++;
            }

            doc.InsertTable(t);

            string FooterWhiteSpace = "\n\n\n\n";
            doc.InsertParagraph(FooterWhiteSpace);

            doc.Save();
        }

        private static int GetNumberOfRows(Feature feature)
        {
            if (feature.Children.ElementAt(0).Keyword.ToString().Equals("Background"))
            {
                return feature.Children.Count();
            }
            else
            {
                return feature.Children.Count() + 1;
            }
        }
    }
}

