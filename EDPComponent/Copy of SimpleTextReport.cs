using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO;
using System.Drawing.Printing;

namespace EDPComponent
{
    [ToolboxBitmap("stxt.png")]
    public partial class SimpleTextReport : UserControl
    {
        public enum PutTextAlign{Left, Right, Center};
        public enum Position{AtBeginningofReport, AtEndofReport, AtBeginningofPage, AtEndofPage, AfterPageHeading, BeforePageFooter};
        public enum STSysDataType {Time, Date, DateTime, PageNumber, NextPageNumber, None};
        public enum PrntDriverType {Esc_P,HPDJ500_600,HPDJ_5L,HPDJ_710,HPLJ_6L};
        public enum PrinterOrientation { Portrait, Landscape };
        private ArrayList FFinalList;
        private ArrayList slOutput;
        private DataSet RptDataSet;
        private int FCharactersToALine;
        private int FLinesToAPage;
        private string FPrinterPath ;
        private bool FPrintingInProgress;
        private bool FBuildingInProgress ;
        private bool FActiveDataSet;
        private TReportColumns FReportColumns;
        private TMainPageHeaders FMainPageHeaders;
        private TSubPageHeaders FSubPageHeaders;
        private TPageFooters FPageFooters;
        private int FCurrentPage;
        private int FCurrentLine;
        private int FLinesRemaining;
        private bool FShowSubPageHeaders;
        private bool FDrawLineAtBeginingofPage;
        private bool FDrawLineBeforePageFooter;
        private bool FDrawLineAtEndofPage;
        private bool FDrawLineAtEndofReport;
        private bool FEjectAfterPrint;
        private bool FContinuesReport;
        private TCustomisedSections FCustomisedSection;
        private PrntDriverType fPrinterDriverType;
        private PrinterOrientation fPrinterOrientation;
        private const int PRNTR_IBMPROPRINTER = 0;
        private const int PRNTR_HPDJ500       = 1;
        private const int PRNTR_HPDJ600       = 1;
        private const int PRNTR_EPSON_IJ      = 0;
        private const int PRNTR_EPSON_DMP     = 0;
        private const int PRNTR_HPDJ200_400   = 1;
        private const int PRNTR_HPDJ_5L       = 2;
        private const int PRNTR_HPDJ710       = 3;
        private const int PRNTR_HPLJ6L        = 4;

        private const int BOLD_ON             = 0;
        private const int BOLD_OFF            = 1;
        private const int CONDENSED_ON        = 2;
        private const int CONDENSED_OFF       = 3;
        private const int EXPANDED_ON         = 4;
        private const int EXPANDED_OFF        = 5;
        private const int ITALICS_ON          = 6;
        private const int ITALICS_OFF         = 7;
        private const int UNDERLINE_ON        = 8;
        private const int UNDERLINE_OFF       = 9;

        private const int P_RESET             = 10;
        private const int P_BIDIRECTIONAL     = 11;
        private const int P_PORTRAIT          = 12;
        private const int P_LANDSCAPE         = 13;
        private const int P_PAGESIZE          = 14;
        private const int P_LINESPERINCH      = 15;
        private const int P_PAGELENGTH        = 16;
        private const int P_TOPMARGIN         = 17;
        private const int P_TEXTLENGTHINLINE  = 18;
        private const int P_LEFTMARGIN        = 19;
        private const int P_RIGHTMARGIN       = 20;
        private const int P_CHARACTERSET      = 21;
        private const int P_SPACEBETWEENLINE  = 22;
        private const int P_STANDARDPRINTING  = 23;
        private const int P_NORMALSTYLE = 24;
        private string[,] PrntCodeAry = new string[,]
                               { // IBM_PROPRINTER Begin
                                 { Strings.ChrW(27).ToString()+Strings.ChrW(69).ToString(),              // 00
                                 Strings.ChrW(27).ToString()+Strings.ChrW(70).ToString(),              // 01
                                 Strings.ChrW(15).ToString(),                      // 02
                                 Strings.ChrW(18).ToString(),                      // 03
                                 Strings.ChrW(27).ToString()+Strings.ChrW(87).ToString()+Strings.ChrW(1).ToString(),       // 04
                                 Strings.ChrW(27).ToString()+Strings.ChrW(87).ToString()+Strings.ChrW(0).ToString(),       // 05
                                 Strings.ChrW(27).ToString()+Strings.ChrW(52).ToString(),              // 06
                                 Strings.ChrW(27).ToString()+Strings.ChrW(53).ToString(),              // 07
                                 Strings.ChrW(27).ToString()+Strings.ChrW(45).ToString()+ "1",         // 08
                                 Strings.ChrW(27).ToString()+Strings.ChrW(45).ToString()+ "0",         // 09
                                 " ",                          // 10
                                 " ",                          // 11
                                 " ",                          // 12
                                 " ",                          // 13
                                 " ",                          // 14
                                 " ",                          // 15
                                 " ",                          // 16
                                 " ",                          // 17
                                 " ",                          // 18
                                 " ",                          // 19
                                 " ",                          // 20
                                 " ",                          // 21
                                 " ",                          // 22
                                 " ",                          // 23
                                 " "                           // 24
                                 },// IBM_PROPRINTER END
                                 // HPDJ500_600 Begin
                                 {Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(51).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"17"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"12"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"6"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"12"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(83).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(68).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(69).ToString(),                                   // 10
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(107).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(87).ToString(),          // 11
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(79).ToString(),          // 12
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(79).ToString(),          // 13
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(50).ToString()+Strings.ChrW(54).ToString()+Strings.ChrW(65).ToString(),  // 14
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"6"+Strings.ChrW(68).ToString(),              // 15
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"88"+Strings.ChrW(80).ToString(),             // 16
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"1"+Strings.ChrW(69).ToString(),              // 17
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"80"+Strings.ChrW(70).ToString(),             // 18
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"8"+Strings.ChrW(76).ToString(),               // 19
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"4"+Strings.ChrW(77).ToString(),               // 20
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(85).ToString(),                   // 21
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(80).ToString(),          // 22
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"12"+Strings.ChrW(72).ToString(),             // 23
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString()           // 24
                                }, // HPDJ500_600 End
                                  // HPDJ_5L Begin
                                { Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(51).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(51).ToString()+Strings.ChrW(98).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(107).ToString()+Strings.ChrW(50).ToString()+Strings.ChrW(83).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(107).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(83).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"6"+Strings.ChrW(67).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"12"+Strings.ChrW(99).ToString(),
                                 " ",
                                 " ",
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(100).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(68).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(100).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(100).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(69).ToString(),                                   // 10
                                 " ",                                               // 11
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(79).ToString(),          // 12
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(79).ToString(),          // 13
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(50).ToString()+Strings.ChrW(54).ToString()+Strings.ChrW(65).ToString(),  // 14
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(54).ToString()+Strings.ChrW(68).ToString(),          // 15
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"88"+Strings.ChrW(80).ToString(),             // 16
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"1"+Strings.ChrW(69).ToString(),              // 17
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"80"+Strings.ChrW(70).ToString(),             // 18
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"8"+Strings.ChrW(76).ToString(),               // 19
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"4"+Strings.ChrW(77).ToString(),               // 20
                                 " ",                                               // 21
                                 " ",                                               // 22
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(107).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(83).ToString(),          // 23
                                 " "                                                // 24
                                 }, // HPDJ_5L End
                                  // HPDJ_710 Begin
                                 {Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(55).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"17"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"12"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"6"+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"12"+Strings.ChrW(72).ToString(),
                                 " ",
                                 " ",
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(100).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(68).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(100).ToString()+Strings.ChrW(64).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(69).ToString(),                                   // 10
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(107).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(87).ToString(),          // 11
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(79).ToString(),          // 12
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(79).ToString(),          // 13
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(50).ToString()+Strings.ChrW(54).ToString()+Strings.ChrW(65).ToString(),  // 14
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"6"+Strings.ChrW(68).ToString(),              // 15
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"88"+Strings.ChrW(80).ToString(),             // 16
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"1"+Strings.ChrW(69).ToString(),              // 17
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"80"+Strings.ChrW(70).ToString(),             // 18
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"8"+Strings.ChrW(77).ToString(),               // 19
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+"4"+Strings.ChrW(77).ToString(),               // 20
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(85).ToString(),                   // 21
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(80).ToString(),          // 22
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+"12"+Strings.ChrW(72).ToString(),             // 23
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString()           // 24
                                 }, // HPDJ_710 End
                                  // HPLJ_6L Begin
                                 {Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(52).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(55).ToString()+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(56).ToString()+Strings.ChrW(72).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(72).ToString(),
                                 " ",
                                 " ",
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(100).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(68).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(100).ToString()+Strings.ChrW(64).ToString(),
                                 Strings.ChrW(27).ToString()+Strings.ChrW(69).ToString(),                                   // 10
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(83).ToString(),          // 11
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(79).ToString(),          // 12
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(79).ToString(),          // 13
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(50).ToString()+Strings.ChrW(54).ToString()+Strings.ChrW(65).ToString(),  // 14
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(54).ToString()+Strings.ChrW(68).ToString(),          // 15
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+"88"+Strings.ChrW(80).ToString(),             // 16
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(108).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(69).ToString(),          // 17
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38)+Strings.ChrW(108)+Strings.ChrW(53)+Strings.ChrW(53)+Strings.ChrW(70),  // 18
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(76).ToString(),           // 19
                                 Strings.ChrW(27).ToString()+Strings.ChrW(38).ToString()+Strings.ChrW(97).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(77).ToString(),           // 20
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(85).ToString(),                   // 21
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(80).ToString(),          // 22
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(49).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(72).ToString(),  // 23
                                 Strings.ChrW(27).ToString()+Strings.ChrW(40).ToString()+Strings.ChrW(115).ToString()+Strings.ChrW(48).ToString()+Strings.ChrW(66).ToString()           // 24
                                 // HPLJ_6L End
                                 }};
        private void WriteCharactersToALine(int Value)
        {
            if ((FPrintingInProgress) || (FBuildingInProgress))
                return;
            if (Value <= 132)
                FCharactersToALine = Value;
        }
        private void WriteLinesToAPage(int Value)
        {
            if (Value <= 100)
                FLinesToAPage = Value;
        }
        private void SetReportColumns(TReportColumns Value)
        {
            
        }
        private string GetAlignString(string AText, int ALength, int APadding, PutTextAlign AAlign)
        {
            string Result = "";
            if (APadding > 0)
                ALength = ALength - (APadding * 2);

            if (AAlign == PutTextAlign.Left)
            {
                if (AText.Length > ALength)
                    Result = AText.Substring(1, ALength);
                else if (AText.Length < ALength)
                {
                    for (int i = 1; i <= (ALength - AText.Length); i++)
                        Result = Result + " ";
                    Result = AText + Result;
                }
                else
                    Result = AText; ;
            }
            else if (AAlign == PutTextAlign.Right)
            {
                if (AText.Length > ALength)
                    Result = AText.Substring(AText.Length - ALength, ALength);
                else if (AText.Length < ALength)
                {
                    for (int i = 1; i <= ALength - AText.Length; i++)
                        Result = Result + " ";
                    Result = Result + AText;
                }
                else
                    Result = AText;
            }
            else if (AAlign == PutTextAlign.Center)
            {
                if (AText.Length > ALength)
                    Result = AText.Substring((AText.Length - ALength) / 2 + 1, ALength);
                else if (AText.Length < ALength)
                {
                    for (int i = 1; i <= ((ALength - AText.Length) / 2); i++)
                        Result = Result + " ";
                    Result = Result + AText;
                    for (int i = 1; i <= (ALength - Result.Length); i++)
                        Result = Result + " ";
                }
                else
                    Result = AText;
            }
            else
                Result = AText;

            if (APadding > 0)
                for (int i = 1; i <= APadding; i++)
                    Result = " " + Result + " ";
            return Result;
        }
        private int FindMainHeaderLines()
        {
            int Result = 0;
            for (int i = 0; i <= FMainPageHeaders.Count - 1; i++)
            {
                if (FMainPageHeaders[i].Expanded)
                    Result = Result + 2;
                else
                    Result = Result + 1;
            }
            return Result;
        }
        private int FindSubHeaderLines()
        {
            int Result = 0;
            for (int i = 0; i <= FSubPageHeaders.Count - 1; i++)
            {
                if (FSubPageHeaders[i].Expanded)
                    Result = Result + 2;
                else
                    Result = Result + 1;
            }
            return Result;
        }
        private int FindColumnHeaderLines()
        {
            bool IsExpanded = false;
            int Result = 0;
            for (int i = 0; i <= FReportColumns.Count - 1; i++)
            {
                if (FReportColumns[i].Header.Expanded)
                {
                    IsExpanded = true;
                    break;
                }
            }
            if (IsExpanded)
                Result = 4;
            else
                Result = 3;
            return Result;
        }
        private int FindFooterLines()
        {
            int Result = 0;
            for (int i = 0; i <= FPageFooters.Count - 1; i++)
            {
                if (FPageFooters[i].Expanded)
                    Result = Result + 2;
                else
                    Result = Result + 1;
            }
            return Result;
        }
        private int FindCustomLines(int APageNo)
        {
            int Result = 0;
            for (int i = 0; i <= FCustomisedSection.Count - 1; i++)
            {
                if (!(FCustomisedSection[i].Position == Position.AtEndofReport))
                {
                    if (APageNo == 1)
                        Result = Result + FCustomisedSection[i].Lines.Count;
                    else
                    {
                        if (!(FCustomisedSection[i].Position == Position.AtBeginningofReport))
                            Result = Result + FCustomisedSection[i].Lines.Count;
                    }
                }
            }
            return Result;
        }
        private void BuildReport()
        {
            int BorderLength = 0, j = 0;
            bool BlankRec = false; ;
            for (int i = 0; i <= FReportColumns.Count - 1; i++)
            {
                BorderLength = BorderLength + FReportColumns[i].LinesToAColumn;
            }
            FFinalList.Clear();
            FCurrentPage = 1;
            FCurrentLine = FindMainHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage);
            FLinesRemaining = FLinesToAPage - (FindMainHeaderLines() + FindColumnHeaderLines() + FindFooterLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage));
            string s = "";
            if (FDrawLineAtBeginingofPage)
            {
                s = s + WriteContinuesData(Strings.ChrW(45).ToString(), BorderLength);
                s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.ChrW(10) + Strings.ChrW(13);
                FFinalList.Add(s);
            }
            WriteCustomData(Position.AtBeginningofReport);
            WriteCustomData(Position.AtBeginningofPage);
            WritePageHeaderData();
            WriteCustomData(Position.AfterPageHeading);
            WriteColumnHeaderData();
            if ((FActiveDataSet) && (RptDataSet!=null))
            {
                BlankRec = false;
                while (j <= RptDataSet.Tables[0].Rows.Count - 1)
                {
                    BlankRec = false;
                    PageFormating(BorderLength, j, BlankRec);
                    j++;
                }

                if (BlankRec)
                {
                    s = "";
                    s = s + WriteContinuesData(Strings.Chr(32).ToString(), BorderLength);
                    s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                    FFinalList[FFinalList.Count - 1] = s;
                }
            }
            else
            {
                for (int i = 0; i <= slOutput.Count - 1; i++)
                {
                    if ((slOutput[i].ToString() == "##END##"))
                        FLinesRemaining = 0;
                    PageFormating(BorderLength, i, BlankRec);
                }
            }
            WriteCustomData(Position.AtEndofReport);
            s = "";
            if (FDrawLineAtEndofReport)
            {
                s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                FFinalList.Add(s);
            }
        }
        private void BuildReportForContinuesPrinting()
        {
            int i = 0, BorderLength = 0;
            string s = "";
            for (i = 0;i<= FReportColumns.Count - 1; i++)
                BorderLength = BorderLength + FReportColumns[i].LinesToAColumn;

            FFinalList.Clear();
            FCurrentLine = FindMainHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines();
            FCurrentPage = 1;
            s = "";
            if (FDrawLineAtBeginingofPage)
            {
                s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                FFinalList.Add(s);
            }
            WritePageHeaderData();
            WriteColumnHeaderData();

            for (i = 0; i <= slOutput.Count - 1; i++)
            {
                FFinalList.Add(slOutput[i]);
                FCurrentLine++;
            }
            s = "";
            if (FDrawLineBeforePageFooter)
            {
                s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                FFinalList.Add(s);
            }
            WriteFooterData();

            s = "";
            if (FDrawLineAtEndofReport)
            {
                s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                FFinalList.Add(s);
            }
        }
        private void WritePageHeaderData()
        {
            int ACharPerLine = 0, i;
            string FldNm = "", Caption = "", s = "";
            DataSet HdrDataSet = new DataSet();
            if (FCurrentPage == 1)
            {
                for (i = 0; i <= FMainPageHeaders.Count - 1; i++)
                {
                    if (FMainPageHeaders[i].Expanded)
                        ACharPerLine = FCharactersToALine / 2;
                    else if (FMainPageHeaders[i].Condensed)
                    {
                        if (FCharactersToALine <= 80)  //should be 80
                            ACharPerLine = 132;
                        if (FCharactersToALine > 80)  //should be 132
                            ACharPerLine = 225;
                    }
                    else
                        ACharPerLine = FCharactersToALine;

                    s = "";
                    s = s + FCondensedOff();
                    if (FMainPageHeaders[i].Expanded)
                        s = s + FExpOn();
                    else
                        s = s + FExpOff();
                    if (FMainPageHeaders[i].Bold)
                        s = s + FBoldOn();
                    else
                        s = s + FBoldOff();
                    if (FMainPageHeaders[i].Italic)
                        s = s + FItalicOn();
                    else
                        s = s + FItalicOff();
                    if (FMainPageHeaders[i].Condensed)
                        s = s + FCondensedOn();
                    else
                        s = s + FCondensedOff();

                    if ((FMainPageHeaders[i].Caption != ""))
                    {
                        if ((FMainPageHeaders[i].DataSet != null))
                        {
                            HdrDataSet = FMainPageHeaders[i].DataSet;
                            FldNm = FMainPageHeaders[i].DataField;
                            if (!(Information.IsDBNull(HdrDataSet)))
                                Caption = HdrDataSet.Tables[0].Rows[0][FldNm].ToString();
                        }
                    }
                    else
                        Caption = FMainPageHeaders[i].Caption;
                    if (i == FMainPageHeaders.Count - 1)
                    {
                        if (Caption.Trim() == "Page :")
                        {
                            Caption = Caption.Trim();
                            Caption = Caption + " " + FCurrentPage.ToString("00000");
                        }
                    }

                    switch (FMainPageHeaders[i].SysData)
                    {
                        case STSysDataType.Time:
                            Caption = Caption + DateTime.Now.ToShortTimeString();
                            break;
                        case STSysDataType.Date:
                            Caption = Caption + DateTime.Now.ToShortDateString();
                            break;
                        case STSysDataType.DateTime:
                            Caption = Caption + DateTime.Now.ToString();
                            break;
                        case STSysDataType.PageNumber:
                            Caption = Caption + FCurrentPage.ToString();
                            break;
                        case STSysDataType.NextPageNumber:
                            Caption = Caption + Convert.ToString(FCurrentPage + 1);
                            break;
                        default :Caption=FMainPageHeaders[i].Caption;
                            break;
                    }
                    s = s + GetAlignString(Caption, ACharPerLine, FMainPageHeaders[i].Padding, FMainPageHeaders[i].Alignment);
                    s = s + Strings.Chr(10) + Strings.Chr(13);
                    FFinalList.Add(s);
                }
            }
            else
            {
                if (FShowSubPageHeaders)
                {
                    for (i = 0; i <= FSubPageHeaders.Count - 1; i++)
                    {
                        if (FSubPageHeaders[i].Expanded)
                            ACharPerLine = FCharactersToALine / 2;
                        else if (FSubPageHeaders[i].Condensed)
                            ACharPerLine = (FCharactersToALine * 7) / 4;
                        else
                            ACharPerLine = FCharactersToALine;

                        s = "";
                        s = s + FCondensedOff();
                        if (FSubPageHeaders[i].Expanded)
                            s = s + FExpOn();
                        else
                            s = s + FExpOff();
                        if (FSubPageHeaders[i].Bold)
                            s = s + FBoldOn();
                        else
                            s = s + FBoldOff();
                        if (FSubPageHeaders[i].Italic)
                            s = s + FItalicOn();
                        else
                            s = s + FItalicOff();
                        if (FSubPageHeaders[i].Condensed)
                            s = s + FCondensedOn();
                        else
                            s = s + FCondensedOff();

                        if (!(FSubPageHeaders[i].Caption == ""))
                        {
                            HdrDataSet = FSubPageHeaders[i].DataSet;
                            FldNm = FSubPageHeaders[i].DataField;
                            if (!(Information.IsDBNull(HdrDataSet)))
                                Caption = HdrDataSet.Tables[0].Rows[0][FldNm].ToString();
                        }
                        else
                            Caption = FSubPageHeaders[i].Caption;
                        switch (FSubPageHeaders[i].SysData)
                        {
                            case STSysDataType.Time:
                                Caption = Caption + DateTime.Now.ToShortTimeString();
                                break;
                            case STSysDataType.Date:
                                Caption = Caption + DateTime.Now.ToShortDateString();
                                break;
                            case STSysDataType.DateTime:
                                Caption = Caption + DateTime.Now.ToString();
                                break;
                            case STSysDataType.PageNumber:
                                Caption = Caption + FCurrentPage.ToString();
                                break;
                            case STSysDataType.NextPageNumber:
                                Caption = Caption + Convert.ToString(FCurrentPage + 1);
                                break;
                            default: Caption = FSubPageHeaders[i].Caption;
                                break;
                        }
                        s = s + GetAlignString(Caption, ACharPerLine, FSubPageHeaders[i].Padding, FSubPageHeaders[i].Alignment);
                        s = s + Strings.Chr(10) + Strings.Chr(13);
                        FFinalList.Add(s);
                    }
                }
                else
                {
                    for (i = 0; i <= FMainPageHeaders.Count - 1; i++)
                    {
                        if (FMainPageHeaders[i].Expanded)
                            ACharPerLine = FCharactersToALine / 2;
                        else if (FMainPageHeaders[i].Condensed)
                            ACharPerLine = (FCharactersToALine * 7) / 4;
                        else
                            ACharPerLine = FCharactersToALine;

                        s = "";
                        s = s + FCondensedOff();
                        if (FMainPageHeaders[i].Expanded)
                            s = s + FExpOn();
                        else
                            s = s + FExpOff();
                        if (FMainPageHeaders[i].Bold)
                            s = s + FBoldOn();
                        else
                            s = s + FBoldOff();
                        if (FMainPageHeaders[i].Italic)
                            s = s + FItalicOn();
                        else
                            s = s + FItalicOff();
                        if (FMainPageHeaders[i].Condensed)
                            s = s + FCondensedOn();
                        else
                            s = s + FCondensedOff();

                        if ((FMainPageHeaders[i].Caption == ""))
                        {
                            if (FMainPageHeaders[i].DataSet != null)
                            {
                                HdrDataSet = FMainPageHeaders[i].DataSet;
                                FldNm = FMainPageHeaders[i].DataField;
                                if (!(Information.IsDBNull(HdrDataSet)))
                                    Caption = HdrDataSet.Tables[0].Rows[0][FldNm].ToString();
                            }
                        }
                        else
                            Caption = FMainPageHeaders[i].Caption;
                        if (i == FMainPageHeaders.Count - 1)
                        {
                            if ((Caption.Trim() == "Page :"))
                            {
                                Caption = Caption.Trim();
                                Caption = Caption + " " + FCurrentPage.ToString("00000");
                            }
                        }
                        switch (FMainPageHeaders[i].SysData)
                        {
                            case STSysDataType.Time:
                                Caption = Caption + DateTime.Now.ToShortTimeString();
                                break;
                            case STSysDataType.Date:
                                Caption = Caption + DateTime.Now.ToShortDateString();
                                break;
                            case STSysDataType.DateTime:
                                Caption = Caption + DateTime.Now.ToString();
                                break;
                            case STSysDataType.PageNumber:
                                Caption = Caption + FCurrentPage.ToString();
                                break;
                            case STSysDataType.NextPageNumber:
                                Caption = Caption + Convert.ToString(FCurrentPage + 1);
                                break;
                            default: Caption = FMainPageHeaders[i].Caption;
                                break;
                        }
                        s = s + GetAlignString(Caption, ACharPerLine, FMainPageHeaders[i].Padding, FMainPageHeaders[i].Alignment);
                        s = s + Strings.ChrW(10) + Strings.ChrW(13);
                        FFinalList.Add(s);
                    }
                }
            }
        }
        private void WriteColumnHeaderData()
        {
            int i, j, Max = 0;
            string TopBorder = "", BottomBorder = "", HeaderCaption = "", s = "";
            ArrayList HeaderCaptionList = new ArrayList();
            for (i = 0; i <= FReportColumns.Count - 1; i++)
            {
                if (FReportColumns[i].Header.Count > Max)
                    Max = FReportColumns[i].Header.Count;
            }

            for (i = 0; i <= FReportColumns.Count - 1; i++)
            {
                s = "";
                s = s + FCondensedOff();
                if (FReportColumns[i].Header.Expanded)
                    s = s + FExpOn();
                else
                    s = s + FExpOff();
                if (FReportColumns[i].Header.Condensed)
                    s = s + FCondensedOn();
                else
                    s = s + FCondensedOff();
                if (FReportColumns[i].Header.Bold)
                    s = s + FBoldOn();
                else
                    s = s + FBoldOff();
                if (FReportColumns[i].Header.Italic)
                    s = s + FItalicOn();
                else
                    s = s + FItalicOff();

                TopBorder = TopBorder + s;
                BottomBorder = BottomBorder + s;

                if (FReportColumns[i].Header.TopBorder)
                    TopBorder = TopBorder + WriteContinuesData(Strings.ChrW(45).ToString(), FReportColumns[i].LinesToAColumn);
                else
                    TopBorder = TopBorder + WriteContinuesData(Strings.ChrW(32).ToString(), FReportColumns[i].LinesToAColumn);

                if (FReportColumns[i].Header.BottomBorder)
                    BottomBorder = BottomBorder + WriteContinuesData(Strings.ChrW(45).ToString(), FReportColumns[i].LinesToAColumn);
                else
                    BottomBorder = BottomBorder + WriteContinuesData(Strings.ChrW(32).ToString(), FReportColumns[i].LinesToAColumn);

                s = "";
                s = s + FCondensedOff();
                if (FReportColumns[i].Header.Expanded)
                    s = s + FExpOn();
                else
                    s = s + FExpOff();
                if (FReportColumns[i].Header.Condensed)
                    s = s + FCondensedOn();
                else
                    s = s + FCondensedOff();
                if (FReportColumns[i].Header.Bold)
                    s = s + FBoldOn();
                else
                    s = s + FBoldOff();
                if (FReportColumns[i].Header.Italic)
                    s = s + FItalicOn();
                else
                    s = s + FItalicOff();
                if (FReportColumns[i].Header.Underline)
                    s = s + FUnderlineOn();
                else
                    s = s + FUnderlineOff();
                HeaderCaptionList.Add(s);
            }

            TopBorder = TopBorder + Strings.ChrW(10).ToString() + Strings.ChrW(13).ToString();
            BottomBorder = BottomBorder + Strings.ChrW(45).ToString() + Strings.ChrW(13).ToString();
            FFinalList.Add(TopBorder);
            for (i = 0; i <= Max - 1; i++)
            {
                HeaderCaption = "";
                for (j = 0; j <= FReportColumns.Count - 1; j++)
                {
                    s = HeaderCaptionList[j].ToString();
                    if (FReportColumns[j].Header.Count > i)
                    {
                        if ((FReportColumns[j].Header.Caption[i].ToString() == ""))
                            s = s + GetAlignString(FReportColumns[j].DataField, FReportColumns[j].LinesToAColumn - 1, FReportColumns[j].Padding, FReportColumns[j].Header.Alignment);
                        else
                            s = s + GetAlignString(FReportColumns[j].Header.Caption[i].ToString(), FReportColumns[j].LinesToAColumn - 1, FReportColumns[j].Padding, FReportColumns[j].Header.Alignment);
                    }

                    if (FReportColumns[j].Header.Border)
                        s = s + Strings.ChrW(124).ToString();
                    else
                        s = s + Strings.ChrW(32).ToString();
                    HeaderCaption = HeaderCaption + s;
                }
                HeaderCaption = HeaderCaption + Strings.ChrW(10).ToString() + Strings.ChrW(13).ToString();
                FFinalList.Add(HeaderCaption);
            }
            FFinalList.Add(BottomBorder);
        }
        private void WriteFooterData()
        {
            int i;
            string s, FldNm;
            DataSet FtrDataSet = new DataSet();
            int ACharPerLine = 0;
            string Caption = "";
            for (i = 0; i <= FPageFooters.Count - 1; i++)
            {
                if (FPageFooters[i].Expanded)
                    ACharPerLine = FCharactersToALine / 2;
                else if (FPageFooters[i].Condensed)
                {
                    if (FCharactersToALine <= 80)  //should be 80
                        ACharPerLine = 132;
                    if (FCharactersToALine > 80)  //should be 132
                        ACharPerLine = 225;
                }
                else
                    ACharPerLine = FCharactersToALine;

                s = "";
                s = s + FCondensedOff();
                if (FPageFooters[i].Expanded)
                    s = s + FExpOn();
                else
                    s = s + FExpOff();
                if (FPageFooters[i].Bold)
                    s = s + FBoldOn();
                else
                    s = s + FBoldOff();
                if (FPageFooters[i].Italic)
                    s = s + FItalicOn();
                else
                    s = s + FItalicOff();
                if (FPageFooters[i].Condensed)
                    s = s + FCondensedOn();
                else
                    s = s + FCondensedOff();

                if (FPageFooters[i].Caption == "")
                {
                    if (FPageFooters[i].DataSet != null)
                    {
                        FtrDataSet = FPageFooters[i].DataSet;
                        FldNm = FPageFooters[i].DataField;
                        if (!Information.IsDBNull(FtrDataSet))
                            Caption = FtrDataSet.Tables[0].Rows[0][FldNm].ToString();
                    }
                }
                else
                    Caption = FPageFooters[i].Caption;
                switch (FPageFooters[i].SysData)
                {
                    case STSysDataType.Time:
                        Caption = Caption + DateTime.Now.ToShortTimeString();
                        break;
                    case STSysDataType.Date:
                        Caption = Caption + DateTime.Now.ToShortDateString();
                        break;
                    case STSysDataType.DateTime:
                        Caption = Caption + DateTime.Now.ToString();
                        break;
                    case STSysDataType.PageNumber:
                        Caption = Caption + FCurrentPage.ToString(); ;
                        break;
                    case STSysDataType.NextPageNumber:
                        Caption = Caption + Convert.ToString(FCurrentPage + 1);
                        break;
                    default: Caption = FPageFooters[i].Caption;
                        break;
                }

                s = s + GetAlignString(Caption, ACharPerLine, FPageFooters[i].Padding, FPageFooters[i].Alignment);
                s = s + Strings.Chr(10) + Strings.Chr(13);
                FFinalList.Add(s);
            }
        }
        private string WriteContinuesData(string SpChar, int Length)
        {
            string Result = "";
            if (Length == 0)
                return Result;
            while (Length == 0)
            {
                Result = Result + SpChar;
                Length--;
            }
            return Result;
        }
        private int CalculateBorderLines()
        {
            int Result = 0;
            if (FDrawLineAtBeginingofPage)
                Result = Result + 1;
            if (FDrawLineAtEndofPage)
                Result = Result + 1;
            if (FDrawLineBeforePageFooter)
                Result = Result + 1;
            return Result;
        }
        private int GetPrinterOrdVal(PrntDriverType PrinterDriver)
        {
            if (PrinterDriver == PrntDriverType.Esc_P)
                return 0;
            else if (PrinterDriver == PrntDriverType.HPDJ_5L)
                return 1;
            else if (PrinterDriver == PrntDriverType.HPDJ_710)
                return 2;
            else if (PrinterDriver == PrntDriverType.HPDJ500_600)
                return 3;
            else  return 4;
        }
        private string RowFormating(string RptString, int i, string FldVal)
        {
            string ColString = "";
            ColString = ColString + FCondensedOff();
            if (FReportColumns[i].Bold)
                ColString = ColString + FBoldOn();
            else
                ColString = ColString + FBoldOff();
            if (FReportColumns[i].Underline)
                ColString = ColString + FUnderlineOn();
            else
                ColString = ColString + FUnderlineOff();
            if (FReportColumns[i].Expanded)
                ColString = ColString + FExpOn();
            else
                ColString = ColString + FExpOff();
            if (FReportColumns[i].Italic)
                ColString = ColString + FItalicOn();
            else
                ColString = ColString + FItalicOff();
            if (FReportColumns[i].Condensed)
                ColString = ColString + FCondensedOn();
            else
                ColString = ColString + FCondensedOff();

            ColString = ColString + GetAlignString(FldVal, FReportColumns[i].LinesToAColumn - 1, FReportColumns[i].Padding, FReportColumns[i].Alignment);

            if (FReportColumns[i].Borderget)
                ColString = ColString + Strings.Chr(124);
            else
                ColString = ColString + Strings.Chr(32);
            RptString = RptString + ColString;

            return RptString;
        }
        private void PageFormating(int BorderLength, int j, bool BlankRec)
        {
            string s, RptString = "", FldNm;
            int i;
            DataSet SubRptDataSet = new DataSet();
            if (FActiveDataSet)
            {
                BlankRec = true;
                for (i = 0; i <= FReportColumns.Count - 1; i++)
                {
                    SubRptDataSet = FReportColumns[i].TDataSet;
                    FldNm = FReportColumns[i].DataField;
                    if (SubRptDataSet.Tables[0].Columns.Contains(FldNm))
                        s = SubRptDataSet.Tables[0].Rows[j][FldNm].ToString();
                    else
                        s = "";
                    if (!((s.Trim()) == "")) BlankRec = false;
                    RptString = RowFormating(RptString, i, s);
                }
                RptString = RptString + Strings.Chr(10) + Strings.Chr(13);
            }

            if (FLinesRemaining == 0)
            {
                if (FCurrentPage == 1)
                {
                    FCurrentLine = FindMainHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage);
                    FLinesRemaining = FLinesToAPage - (FindMainHeaderLines() + FindColumnHeaderLines() + FindFooterLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage));
                }
                else
                {
                    if (FShowSubPageHeaders)
                    {
                        FCurrentLine = FindSubHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage);
                        FLinesRemaining = FLinesToAPage - (FindSubHeaderLines() + FindColumnHeaderLines() + FindFooterLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage));
                    }
                    else
                    {
                        FCurrentLine = FindMainHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage);
                        FLinesRemaining = FLinesToAPage - (FindMainHeaderLines() + FindColumnHeaderLines() + FindFooterLines() + CalculateBorderLines() + FindCustomLines(FCurrentPage));
                    }
                }

                WriteCustomData(Position.BeforePageFooter);
                s = "";
                if (FDrawLineBeforePageFooter)
                {
                    s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                    s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                    FFinalList.Add(s);
                }
                WriteFooterData();
                WriteCustomData(Position.AtEndofPage);
                s = "";
                if (FDrawLineAtEndofPage)
                {
                    s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                    s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                    FFinalList.Add(s);
                }
                FFinalList.Add(Strings.Chr(12));
                FCurrentPage++;
                s = "";
                if (FDrawLineAtBeginingofPage)
                {
                    s = s + WriteContinuesData(Strings.Chr(45).ToString(), BorderLength);
                    s = FBoldOff() + FExpOff() + FUnderlineOff() + FItalicOff() + FCondensedOff() + FCondensedOn() + s + Strings.Chr(10) + Strings.Chr(13);
                    FFinalList.Add(s);
                }
                WriteCustomData(Position.AtBeginningofPage);
                WritePageHeaderData();
                WriteCustomData(Position.AfterPageHeading);
                WriteColumnHeaderData();
                if (FActiveDataSet)
                    FFinalList.Add(RptString);
                else
                    FFinalList.Add(slOutput[j]);
            }
            else
            {
                FCurrentLine++;
                FLinesRemaining--;

                if (FActiveDataSet)
                    FFinalList.Add(RptString);
                else
                    FFinalList.Add(slOutput[j]);
            }
        }
        private void WriteCustomData(Position APosition)
        {
            int i, j, k;
            string LineStr, s, FldNm;
            DataSet FtrDataSet = new DataSet();
            string Caption = "";
            TCustomisedCell MyCell;
            for (i = 0; i <= FCustomisedSection.Count - 1; i++)
            {
                if (FCustomisedSection[i].Position == APosition)
                {
                    for (j = 0; j <= FCustomisedSection[i].Lines.Count - 1; j++)
                    {
                        LineStr = "";
                        for (k = 0; k <= FCustomisedSection[i].Lines[j].Cells.Count - 1; k++)
                        {
                            MyCell = FCustomisedSection[i].Lines[j].Cells[k];
                            s = "";
                            s = s + FCondensedOff();
                            if (MyCell.Expanded)
                                s = s + FExpOn();
                            else
                                s = s + FExpOff();
                            if (MyCell.Bold)
                                s = s + FBoldOn();
                            else
                                s = s + FBoldOff();
                            if (MyCell.Italic)
                                s = s + FItalicOn();
                            else
                                s = s + FItalicOff();
                            if (MyCell.Condensed)
                                s = s + FCondensedOn();
                            else
                                s = s + FCondensedOff();

                            if (!(MyCell.Caption == ""))
                            {
                                if ((MyCell.DataSet != null))
                                {
                                    FtrDataSet = MyCell.DataSet;
                                    FldNm = MyCell.DataField;
                                    if (!Information.IsDBNull(FtrDataSet.Tables))
                                        Caption = FtrDataSet.Tables[0].Rows[0][FldNm].ToString();
                                }
                            }
                            else
                                Caption = MyCell.Caption;
                            switch (MyCell.SysData)
                            {
                                case STSysDataType.Time:
                                    Caption = Caption + DateTime.Now.ToShortTimeString();
                                    break;
                                case STSysDataType.Date:
                                    Caption = Caption + DateTime.Now.ToShortDateString();
                                    break;
                                case STSysDataType.DateTime:
                                    Caption = Caption + DateTime.Now.ToString();
                                    break;
                                case STSysDataType.PageNumber:
                                    Caption = Caption + FCurrentPage.ToString();
                                    break;
                                case STSysDataType.NextPageNumber:
                                    Caption = Caption + Convert.ToString(FCurrentPage + 1);
                                    break;
                                default: Caption = MyCell.Caption;
                                    break;
                            }

                            s = s + GetAlignString(Caption, MyCell.Width, MyCell.Padding, MyCell.Alignment);
                            LineStr = LineStr + s;
                        }
                        LineStr = LineStr + Strings.ChrW(10) + Strings.ChrW(13);
                        FFinalList.Add(LineStr);
                    }
                }
            }
        }
        //public
        public string FBoldOn()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), BOLD_ON).ToString();
        }
        public string FBoldOff()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), BOLD_OFF).ToString();
        }
        public string FExpOn()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), EXPANDED_ON).ToString();
        }
        public string FExpOff()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), EXPANDED_OFF).ToString();
        }
        public string FCondensedOn()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), CONDENSED_ON).ToString();
        }
        public string FCondensedOff()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), CONDENSED_OFF).ToString();
        }
        public string FItalicOn()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), ITALICS_ON).ToString();
        }
        public string FItalicOff()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), ITALICS_OFF).ToString();
        }
        public string FUnderlineOn()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), UNDERLINE_ON).ToString();
        }
        public string FUnderlineOff()
        {
            return PrntCodeAry.GetValue(GetPrinterOrdVal(fPrinterDriverType), UNDERLINE_OFF).ToString();
        }
        public void SaveToFile(string FilePath)
        {
            FFinalList.Clear();
            FileStream fs = new FileStream(FilePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < FFinalList.Count - 1; i++)
                sw.WriteLine(FFinalList[i]);
            sw.Close();
        }
        public void LoadFromFile(string FilePath)
        {
            FileStream fs;
            if (!File.Exists(FilePath))
            {
                fs = new FileStream(FilePath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                FFinalList.Clear();
                while ((sr.Peek() != -1))
                {
                    FFinalList.Add(sr.ReadLine());
                }
                sr.Close();
            }
            else throw new Exception("File not Found.");
        }
        public void Preview()
        {

        }
        public void Print()
        {
            string filename = "\"" + Environment.SystemDirectory.Substring(0, 3) + "print.txt" + "\"";
            string command = "CMD /C TYPE " + filename + " > PRN";
            FileStream fs = new FileStream(Environment.SystemDirectory.Substring(0, 3) + "print.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            if (FContinuesReport)
                BuildReportForContinuesPrinting();
            else
                BuildReport();
            FBuildingInProgress = false;
            FPrintingInProgress = true;
            for (int i = 0; i < FFinalList.Count - 1; i++)
                sw.WriteLine(FFinalList[i]);
            FPrintingInProgress = false;
            if (FEjectAfterPrint)
                sw.Write(Strings.Chr(12));
            sw.Close();
            //Interaction.Shell("net use lpt1: /DELETE", AppWinStyle.Hide, true, -1);
            //Interaction.Shell("net use lpt1: " + cmbPinter.Text, AppWinStyle.Hide, true, -1);
            Interaction.Shell(command, AppWinStyle.Hide, false, -1);
            File.Delete(Environment.SystemDirectory.Substring(0, 3) + "print.txt");
        }
        public void InitReport()
        {
            int intPrntType;
            string aStr;
            if (FPrintingInProgress)
                return;
            FBuildingInProgress = false;
            slOutput.Clear();
            FCurrentLine = FindMainHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines();
            FLinesRemaining = FLinesToAPage - (FindMainHeaderLines() + FindColumnHeaderLines() + FindFooterLines() + CalculateBorderLines());
            FCurrentPage = 1;
            aStr = "";
            intPrntType = GetPrinterOrdVal(fPrinterDriverType);
            switch (intPrntType)
            {
                case 1:                // pdtHPDJ500_600
                    aStr = aStr + PrntCodeAry[intPrntType, P_RESET];
                    aStr = aStr + PrntCodeAry[intPrntType, P_BIDIRECTIONAL];
                    if (fPrinterOrientation == PrinterOrientation.Portrait)
                        aStr = aStr + PrntCodeAry[intPrntType, P_PORTRAIT];
                    else
                        aStr = aStr + PrntCodeAry[intPrntType, P_LANDSCAPE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_PAGESIZE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_LINESPERINCH];
                        aStr = aStr + PrntCodeAry[intPrntType, P_PAGELENGTH];
                        aStr = aStr + PrntCodeAry[intPrntType, P_TOPMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_TEXTLENGTHINLINE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_LEFTMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_RIGHTMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_CHARACTERSET];
                        aStr = aStr + PrntCodeAry[intPrntType, P_SPACEBETWEENLINE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_STANDARDPRINTING];
                        aStr = aStr + PrntCodeAry[intPrntType, P_NORMALSTYLE];
                    break;
                case 3:                // pdtHPDJ_710
                    aStr = aStr + PrntCodeAry[intPrntType, P_RESET];
                    aStr = aStr + PrntCodeAry[intPrntType, P_BIDIRECTIONAL];
                    if (fPrinterOrientation == PrinterOrientation.Portrait)
                        aStr = aStr + PrntCodeAry[intPrntType, P_PORTRAIT];
                    else
                        aStr = aStr + PrntCodeAry[intPrntType, P_LANDSCAPE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_PAGESIZE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_LINESPERINCH];
                        aStr = aStr + PrntCodeAry[intPrntType, P_PAGELENGTH];
                        aStr = aStr + PrntCodeAry[intPrntType, P_TOPMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_TEXTLENGTHINLINE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_LEFTMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_RIGHTMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_CHARACTERSET];
                        aStr = aStr + PrntCodeAry[intPrntType, P_SPACEBETWEENLINE];
                        aStr = aStr + PrntCodeAry[intPrntType, P_STANDARDPRINTING];
                        aStr = aStr + PrntCodeAry[intPrntType, P_NORMALSTYLE];
                    break;
                case 4:                // pdtHPLJ_6L
                    aStr = aStr + PrntCodeAry[intPrntType, P_RESET];
                    if (fPrinterOrientation == PrinterOrientation.Portrait)
                        aStr = aStr + PrntCodeAry[intPrntType, P_PORTRAIT];
                    else
                        aStr = aStr + PrntCodeAry[intPrntType, P_LANDSCAPE];
                        aStr = aStr + Strings.Chr(27) + Strings.Chr(38) + Strings.Chr(107) + Strings.Chr(56) + Strings.Chr(72); //HMI no. of col setting per line
                        aStr = aStr + PrntCodeAry[intPrntType, P_LEFTMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_RIGHTMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_LINESPERINCH];
                        aStr = aStr + PrntCodeAry[intPrntType, P_TOPMARGIN];
                        aStr = aStr + PrntCodeAry[intPrntType, P_PAGESIZE];
                        aStr = aStr + Strings.Chr(27) + Strings.Chr(38) + Strings.Chr(107) + Strings.Chr(50) + Strings.Chr(71);
                        aStr = aStr + PrntCodeAry[intPrntType, P_SPACEBETWEENLINE]; // fixed space on primary font
                        aStr = aStr + Strings.Chr(27) + Strings.Chr(40) + Strings.Chr(115) + Strings.Chr(48) + Strings.Chr(83);  //font style upright solid
                        aStr = aStr + PrntCodeAry[intPrntType, P_STANDARDPRINTING]; // font size to accomodate - 132 chars/line
                        aStr = aStr + PrntCodeAry[intPrntType, P_NORMALSTYLE]; // stroke weight normal
                    break;
            }
            FFinalList.Add(aStr);
        }
        public int CurrentLine
        {
            get
            {
                return FCurrentLine;
            }
        }
        public int CurrentPage
        {
            get
            {
                return FCurrentPage;
            }
        }
        public int LinesRemaining
        {
            get
            {
                return FLinesRemaining;
            }
        }
        public bool PrintingInProgress
        {
            get
            {
                return FPrintingInProgress;
            }
        }
        public bool BuildingInProgress
        {
            get
            {
                return FBuildingInProgress;
            }
        }
        //published
        [Category("Data"), Description("The DataSet is Active or not."), DefaultValue(false)]
        public bool ActiveDataSet
        {
            get
            {
                return FActiveDataSet;
            }
            set
            {
                FActiveDataSet = value;
            }
        }
        [Category("Data"), Description("Initialize the Dataset Property."), DefaultValue("")]
        public DataSet DataSet
        {
            get
            {
                return RptDataSet;
            }
            set
            {
                RptDataSet = value;
            }
        }
        [Category("Misc"), Description("Enter the Integer for Character per Line"), DefaultValue(80)]
        public int CharactersToALine
        {
            get
            {
                return FCharactersToALine;
            }
            set
            {
                FCharactersToALine = value;
            }
        }
        [Category("Misc"), Description("Enter the Integer for Lines per Page"), DefaultValue(60)]
        public int LinesToAPage
        {
            get
            {
                return FLinesToAPage;
            }
            set
            {
                FLinesToAPage = value;
            }
        }
        [Category("Misc"), Description("Set Printer Path"), DefaultValue("")]
        public string PrinterPath
        {
            get
            {
                return FPrinterPath;
            }
            set
            {
                FPrinterPath = value;
            }
        }
        [Category("Misc"), Description("Page will be Eject or Not"), DefaultValue(false)]
        public bool EjectAfterPrint
        {
            get
            {
                return FEjectAfterPrint;
            }
            set
            {
                FEjectAfterPrint = value;
            }
        }
        [Category("Edp"), Description("Report Column Collection"), DefaultValue(null)]
        public TReportColumns ReportColumns
        {
            get
            {
                return FReportColumns;
            }
            set
            {
                FReportColumns = value;
            }
        }
        [Category("Edp"), Description("Main PageHeaders Collection"), DefaultValue(null)]
        public TMainPageHeaders MainPageHeaders
        {
            get
            {
                return FMainPageHeaders;
            }
            set
            {
                FMainPageHeaders = value;
            }
        }
        [Category("Edp"), Description("Sub PageHeaders Collection"), DefaultValue(null)]
        public TSubPageHeaders SubPageHeaders
        {
            get
            {
                return FSubPageHeaders;
            }
            set
            {
                FSubPageHeaders = value;
            }
        }
        [Category("Edp"), Description("PageFooters Collection"), DefaultValue(null)]
        public TPageFooters PageFooters
        {
            get
            {
                return FPageFooters;
            }
            set
            {
                FPageFooters = value;
            }
        }
        [Category("Edp"), Description("CustomisedSection Collection"), DefaultValue(null)]
        public TCustomisedSections CustomisedSection
        {
            get
            {
                return FCustomisedSection;
            }
            set
            {
                FCustomisedSection = value;
            }
        }
        [Category("Edp"), Description("Subpage Headers Will Be shown or Not."), DefaultValue(false)]
        public bool ShowSubPageHeaders
        {
            get
            {
                return FShowSubPageHeaders;
            }
            set
            {
                FShowSubPageHeaders = value;
            }
        }
        [Category("Edp"), Description("DrawLine At Begining of Page or Not."), DefaultValue(false)]
        public bool DrawLineAtBeginingofPage
        {
            get
            {
                return FDrawLineAtBeginingofPage;
            }
            set
            {
                FDrawLineAtBeginingofPage = value;
            }
        }
        [Category("Edp"), Description("DrawLine At End of Page or Not."), DefaultValue(false)]
        public bool DrawLineAtEndofPage
        {
            get
            {
                return FDrawLineAtEndofPage;
            }
            set
            {
                FDrawLineAtEndofPage = value;
            }
        }
        [Category("Edp"), Description("DrawLine before Page Footer or Not."), DefaultValue(false)]
        public bool DrawLineBeforePageFooter
        {
            get
            {
                return FDrawLineBeforePageFooter;
            }
            set
            {
                FDrawLineBeforePageFooter = value;
            }
        }
        [Category("Edp"), Description("DrawLine At End of Report or Not."), DefaultValue(false)]
        public bool DrawLineAtEndofReport
        {
            get
            {
                return FDrawLineAtEndofReport;
            }
            set
            {
                FDrawLineAtEndofReport = value;
            }
        }
        [Category("Edp"), Description("Report will be continuous or Not."), DefaultValue(false)]
        public bool ContinuesReport
        {
            get
            {
                return FContinuesReport;
            }
            set
            {
                FContinuesReport = value;
            }
        }
        [Category("Edp"), Description("Select Printer Driver Type."), DefaultValue(SimpleTextReport.PrntDriverType.Esc_P)]
        public PrntDriverType PrintDriverType
        {
            get
            {
                return fPrinterDriverType;
            }
            set
            {
                fPrinterDriverType = value;
            }
        }
        [Category("Edp"), Description("Select Printer Orientation Type."), DefaultValue(SimpleTextReport.PrinterOrientation.Portrait)]
        public PrinterOrientation PPrinterOrientation
        {
            get
            {
                return fPrinterOrientation;
            }
            set
            {
                fPrinterOrientation = value;
            }
        }
        public SimpleTextReport()
        {
            InitializeComponent();
            slOutput = new ArrayList();
            FFinalList = new ArrayList();
            FCharactersToALine = 80;
            FLinesToAPage = 60;
            FPrinterPath = "";
            FPrintingInProgress = false;
            FReportColumns = new TReportColumns(FReportColumns);
            FMainPageHeaders = new TMainPageHeaders(FMainPageHeaders);
            FSubPageHeaders = new TSubPageHeaders(FSubPageHeaders);
            FPageFooters = new TPageFooters(FPageFooters);
            FCustomisedSection = new TCustomisedSections(FCustomisedSection);
            InitReport();
            FCurrentLine = FindMainHeaderLines() + FindColumnHeaderLines() + CalculateBorderLines();
            FLinesRemaining = FLinesToAPage - (FindMainHeaderLines() + FindColumnHeaderLines() + FindFooterLines() + CalculateBorderLines());
            FCurrentPage = 1;
            this.Load += new EventHandler(SimpleTextReport_Load);
        }

        void SimpleTextReport_Load(object sender, EventArgs e)
        {
            PrinterSettings ps = new PrinterSettings();
            int index = -1;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count - 1; i++)
            {
                ps.PrinterName = PrinterSettings.InstalledPrinters[i];
                if (ps.IsDefaultPrinter)
                    index = i;
                cmbPinter.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }
            cmbPinter.SelectedIndex = index;
        }
        [Serializable]
        public class TReportColumn : CollectionBase
        {
            public TReportColumn this[int index]
            {
                get
                {
                    return ((TReportColumn)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
            private DataSet FDataSet;
            private string FDataField;
            private Boolean FBorder;
            private int FLinesToAColumn;
            private Boolean FExpanded;
            private Boolean FUnderline;
            private Boolean FBold;
            private Boolean FItalic;
            private Boolean FCondensed;
            private PutTextAlign FAlignment;
            private TColumnHeader FHeader;
            private int FCurrentPage;
            private int FCurrentLine;
            private int FPadding;
            protected TColumnHeader CreateHeader()
            {
               return new TColumnHeader();
            }
            public TReportColumn()
            {
                FAlignment = PutTextAlign.Left;
                FHeader = CreateHeader();
                FPadding = 0;
                FExpanded = false;
            }
            ~TReportColumn()
            {
                
            }
            public Int32 CurrentLine
            {
                get
                {
                    return FCurrentLine;
                }
                set
                {
                    FCurrentLine = value;
                }
            }
            public Int32 CurrentPage
            {
                get
                {
                    return FCurrentPage;
                }
                set
                {
                    FCurrentPage = value;
                }
            }
//published property
            [Category("Data"), Description("The DataSet, DataSet for the Report Column."),DefaultValue("")]
            public DataSet TDataSet
            {
                get
                {
                    return FDataSet;
                }
                set
                {
                    FDataSet = value;
                }
            }
            public Boolean Borderget
            {
                get
                {
                    return FBorder;
                }
                set
                {
                    FBorder = value;
                }
            }
            public string DataField
            {
                get
                {
                    return FDataField;
                }
                set
                {
                    FDataField = value;
                }
            }
            public Boolean Bold
            {
                get
                {
                    return FBold;
                }
                set
                {
                    FBold = value;
                }
            }
            public Boolean Italic
            {
                get
                {
                    return FItalic;
                }
                set
                {
                    FItalic = value;
                }
            }
            public Boolean Expanded
            {
                get
                {
                    return FExpanded;
                }
                set
                {
                    FExpanded = value;
                }
            }
            public Boolean Condensed
            {
                get
                {
                    return FCondensed;
                }
                set
                {
                    FCondensed = value;
                }
            }
            public Boolean Underline
            {
                get
                {
                    return FUnderline;
                }
                set
                {
                    FUnderline = value;
                }
            }
            [Category("Misc"), Description("Enter the Integer for Character per Line")]
            public int LinesToAColumn
            {
                get
                {
                    return FLinesToAColumn;
                }
                set
                {
                    FLinesToAColumn = value;
                }
            }
            [Category("Misc"), Description("Enter the Allignment"), DefaultValue(PutTextAlign.Left)]
            public PutTextAlign Alignment
            {
                get
                {
                    return FAlignment;
                }
                set
                {
                    FAlignment = value;
                }
            }
            public TColumnHeader Header
            {
                get
                {
                    return FHeader;
                }
                set
                {
                    FHeader = value;
                }
            }
            public int Padding
            {
                get
                {
                    return FPadding;
                }
                set
                {
                    FPadding = value;
                }
            }
        }
        [Serializable]
        public class TColumnHeader : CollectionBase
        {
            private Boolean FItalic;
            private Boolean FExpanded;
            private Boolean FUnderline;
            private Boolean FBorder;
            private Boolean FBottomBorder;
            private Boolean FCondensed;
            private Boolean FTopBorder;
            private Boolean FBold;
            private string FCaption;
            private PutTextAlign FAlignment;
            private TReportColumn FReportColumn;
            //public
            public TColumnHeader()
            {
                FReportColumn = ReportColumn;
                FCaption = "";
            }//constructor
            ~TColumnHeader()
            {
                FCaption = null;
            }//destructor
            public TReportColumn ReportColumn
            {
                get
                {
                    return FReportColumn;
                }
            }
            //published
            public Boolean Border
            {
                get
                {
                    return FBorder;
                }
                set
                {
                    FBorder = value;
                }
            }
            public Boolean Bold
            {
                get
                {
                    return FBold;
                }
                set
                {
                    FBold = value;
                }
            }
            public Boolean Italic
            {
                get
                {
                    return FItalic;
                }
                set
                {
                    FItalic = value;
                }
            }
            public Boolean Expanded
            {
                get
                {
                    return FExpanded;
                }
                set
                {
                    FExpanded = value;
                }
            }
            public Boolean Condensed
            {
                get
                {
                    return FCondensed;
                }
                set
                {
                    FCondensed = value;
                }
            }
            public Boolean Underline
            {
                get
                {
                    return FUnderline;
                }
                set
                {
                    FUnderline = value;
                }
            }
            [Category("Misc"), Description("Enter the Allignment of the Column."), DefaultValue(PutTextAlign.Left)]
            public PutTextAlign Alignment
            {
                get
                {
                    return FAlignment;
                }
                set
                {
                    FAlignment = value;
                }
            }
            public string Caption
            {
                get
                {
                    return FCaption;
                }
                set
                {
                    FCaption = value;
                }
            }
            public Boolean TopBorder
            {
                get
                {
                    return FTopBorder;
                }
                set
                {
                    FTopBorder = value;
                }
            }
            public Boolean BottomBorder
            {
                get
                {
                    return FBottomBorder;
                }
                set
                {
                    FBottomBorder = value;
                }
            }
        }
        [Serializable]
        public class TReportColumns : CollectionBase
        {
            private Object FOwner;
            //private TReportColumn GetItem(int Index)
            //{
            //    return cb.
            //}
            //         procedure SetItem(Index: Integer; Value: TReportColumn);
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TReportColumns(Object Owner)
            {
                FOwner = Owner;
            }
            public TReportColumn Add()
            {
                TReportColumn rc=new TReportColumn();
                List.Add(rc);
                return (rc);
            }
            public TReportColumn this[int index]
            {
                get
                {
                    return ((TReportColumn)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }
        [Serializable]
        public class TPageFooter : CollectionBase
        {
            private DataSet FDataSet;
            private string FDataField;
            private Boolean FBold;
            private Boolean FItalic;
            private Boolean FExpanded;
            private string FCaption;
            private PutTextAlign FAlignment;
            private STSysDataType FSysData;
            private Int32 FPadding;
            private Boolean FCondensed;
            public TPageFooter()
            {
                FAlignment = PutTextAlign.Right;
                FSysData = STSysDataType.None;
                FPadding = 0;
            }
            ~TPageFooter()
            {

            }
            //  published
            public DataSet DataSet
            {
                get
                {
                    return FDataSet;
                }
                set
                {
                    FDataSet = value;
                }
            }
            public string DataField
            {
                get
                {
                    return FDataField;
                }
                set
                {
                    FDataField = value;
                }
            }
            public Boolean Bold
            {
                get
                {
                    return FBold;
                }
                set
                {
                    FBold = value;
                }
            }
            public Boolean Italic
            {
                get
                {
                    return FItalic;
                }
                set
                {
                    FItalic = value;
                }
            }
            public Boolean Expanded
            {
                get
                {
                    return FExpanded;
                }
                set
                {
                    FExpanded = value;
                }
            }
            public Boolean Condensed
            {
                get
                {
                    return FCondensed;
                }
                set
                {
                    FCondensed = value;
                }
            }
            [Category("Misc"), Description("Enter the Allignment"), DefaultValue(PutTextAlign.Left)]
            public PutTextAlign Alignment
            {
                get
                {
                    return FAlignment;
                }
                set
                {
                    FAlignment = value;
                }
            }
            public string Caption
            {
                get
                {
                    return FCaption;
                }
                set
                {
                    FCaption = value;
                }
            }
            public STSysDataType SysData
            {
                get
                {
                    return FSysData;
                }
                set
                {
                    FSysData = value;
                }
            }
            public Int32 Padding
            {
                get
                {
                    return FPadding;
                }
                set
                {
                    FPadding = value;
                }
            }
        }
        [Serializable]
        public class TPageFooters : CollectionBase
        {
            private Object FOwner;
            //function GetItem(Index: Integer): TPageFooter;
            //procedure SetItem(Index: Integer; const Value: TPageFooter);
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TPageFooters(Object Owner)
            {
                FOwner = Owner;
            }
            public TPageFooter Add()
            {
                TPageFooter pf = new TPageFooter();
                List.Add(pf);
                return pf;
            }
            public TPageFooter this[int index]
            {
                get
                {
                    return ((TPageFooter)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }
        [Serializable]
        public class TSubPageHeader : CollectionBase
        {
            private DataSet FDataSet;
            private string FDataField;
            private Boolean FBold;
            private Boolean FItalic;
            private Boolean FExpanded;
            private string FCaption;
            private PutTextAlign FAlignment;
            private STSysDataType FSysData;
            private Int32 FPadding;
            private Boolean FCondensed;
            public TSubPageHeader()
            {
                FAlignment = PutTextAlign.Right;
                FSysData = STSysDataType.None;
                FPadding = 0;
            }
            ~TSubPageHeader()
            {

            }
            //  published
            public DataSet DataSet
            {
                get
                {
                    return FDataSet;
                }
                set
                {
                    FDataSet = value;
                }
            }
            public string DataField
            {
                get
                {
                    return FDataField;
                }
                set
                {
                    FDataField = value;
                }
            }
            public Boolean Bold
            {
                get
                {
                    return FBold;
                }
                set
                {
                    FBold = value;
                }
            }
            public Boolean Italic
            {
                get
                {
                    return FItalic;
                }
                set
                {
                    FItalic = value;
                }
            }
            public Boolean Expanded
            {
                get
                {
                    return FExpanded;
                }
                set
                {
                    FExpanded = value;
                }
            }
            public Boolean Condensed
            {
                get
                {
                    return FCondensed;
                }
                set
                {
                    FCondensed = value;
                }
            }
            public PutTextAlign Alignment
            {
                get
                {
                    return FAlignment;
                }
                set
                {
                    FAlignment = value;
                }
            }
            public string Caption
            {
                get
                {
                    return FCaption;
                }
                set
                {
                    FCaption = value;
                }
            }
            public STSysDataType SysData
            {
                get
                {
                    return FSysData;
                }
                set
                {
                    FSysData = value;
                }
            }
            public Int32 Padding
            {
                get
                {
                    return FPadding;
                }
                set
                {
                    FPadding = value;
                }
            }
        }
        [Serializable]
        public class TSubPageHeaders : CollectionBase
        {
            private Object FOwner;
            //function GetItem(Index: Integer): TPageFooter;
            //procedure SetItem(Index: Integer; const Value: TPageFooter);
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TSubPageHeaders(Object Owner)
            {
                FOwner = Owner;
            }
            public TSubPageHeader Add()
            {
                TSubPageHeader sp = new TSubPageHeader();
                List.Add(sp);
                return sp;
            }
            public TSubPageHeader this[int index]
            {
                get
                {
                    return ((TSubPageHeader)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }
        [Serializable]
        public class TMainPageHeader : CollectionBase
        {
            private DataSet FDataSet;
            private string FDataField;
            private Boolean FBold;
            private Boolean FItalic;
            private Boolean FExpanded;
            private string FCaption;
            private PutTextAlign FAlignment;
            private STSysDataType FSysData;
            private Int32 FPadding;
            private Boolean FCondensed;
            public TMainPageHeader()
            {
                FAlignment = PutTextAlign.Center;
                FSysData = STSysDataType.None;
                FPadding = 0;
            }
            ~TMainPageHeader()
            {
                
            }
            //  published
            public DataSet DataSet
            {
                get
                {
                    return FDataSet;
                }
                set
                {
                    FDataSet = value;
                }
            }
            public string DataField
            {
                get
                {
                    return FDataField;
                }
                set
                {
                    FDataField = value;
                }
            }
            public Boolean Bold
            {
                get
                {
                    return FBold;
                }
                set
                {
                    FBold = value;
                }
            }
            public Boolean Italic
            {
                get
                {
                    return FItalic;
                }
                set
                {
                    FItalic = value;
                }
            }
            public Boolean Expanded
            {
                get
                {
                    return FExpanded;
                }
                set
                {
                    FExpanded = value;
                }
            }
            public Boolean Condensed
            {
                get
                {
                    return FCondensed;
                }
                set
                {
                    FCondensed = value;
                }
            }
            [Category("Misc"), Description("Enter the Allignment"), DefaultValue(PutTextAlign.Center)]
            public PutTextAlign Alignment
            {
                get
                {
                    return FAlignment;
                }
                set
                {
                    FAlignment = value;
                }
            }
            public string Caption
            {
                get
                {
                    return FCaption;
                }
                set
                {
                    FCaption = value;
                }
            }
            public STSysDataType SysData
            {
                get
                {
                    return FSysData;
                }
                set
                {
                    FSysData = value;
                }
            }
            public Int32 Padding
            {
                get
                {
                    return FPadding;
                }
                set
                {
                    FPadding = value;
                }
            }
        }
        [Serializable]
        public class TMainPageHeaders : CollectionBase
        {
             private Object FOwner;
            //function GetItem(Index: Integer): TPageFooter;
            //procedure SetItem(Index: Integer; const Value: TPageFooter);
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TMainPageHeaders(Object Owner)
            {
                FOwner = Owner;
            }
            public TMainPageHeader Add()
            {
                TMainPageHeader mp = new TMainPageHeader();
                List.Add(mp);
                return mp;
            }
            public TMainPageHeader this[int index]
            {
                get
                {
                    return ((TMainPageHeader)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }
        [Serializable]
        public class TCustomisedCell : CollectionBase
        {
            private Int32 FWidth=80;
            private DataSet FDataSet;
            private string FDataField;
            private Boolean FBold;
            private Boolean FItalic;
            private Boolean FExpanded;
            private string FCaption;
            private PutTextAlign FAlignment;
            private STSysDataType FSysData;
            private Int32 FPadding;
            private Boolean FCondensed;
            public TCustomisedCell()
            {
                FAlignment = PutTextAlign.Left;
                FSysData = STSysDataType.None;
                FPadding = 0;
            }
            ~TCustomisedCell()
            {

            }
            //  published
            public DataSet DataSet
            {
                get
                {
                    return FDataSet;
                }
                set
                {
                    FDataSet = value;
                }
            }
            public string DataField
            {
                get
                {
                    return FDataField;
                }
                set
                {
                    FDataField = value;
                }
            }
            public Boolean Bold
            {
                get
                {
                    return FBold;
                }
                set
                {
                    FBold = value;
                }
            }
            public Boolean Italic
            {
                get
                {
                    return FItalic;
                }
                set
                {
                    FItalic = value;
                }
            }
            public Boolean Expanded
            {
                get
                {
                    return FExpanded;
                }
                set
                {
                    FExpanded = value;
                }
            }
            public Boolean Condensed
            {
                get
                {
                    return FCondensed;
                }
                set
                {
                    FCondensed = value;
                }
            }
            [Category("Misc"), Description("Enter the Allignment"), DefaultValue(PutTextAlign.Left)]
            public PutTextAlign Alignment
            {
                get
                {
                    return FAlignment;
                }
                set
                {
                    FAlignment = value;
                }
            }
            public string Caption
            {
                get
                {
                    return FCaption;
                }
                set
                {
                    FCaption = value;
                }
            }
            public STSysDataType SysData
            {
                get
                {
                    return FSysData;
                }
                set
                {
                    FSysData = value;
                }
            }
            public Int32 Padding
            {
                get
                {
                    return FPadding;
                }
                set
                {
                    FPadding = value;
                }
            }
            [Category("Misc"), Description("Width of the Line"), DefaultValue(80)]
            public Int32 Width
            {
                get
                {
                    return FWidth;
                }
                set
                {
                    FWidth = value;
                }
            }
        }
        [Serializable]
        public class TCustomisedCells : CollectionBase
        {
             private Object FOwner;
            //function GetItem(Index: Integer): TPageFooter;
            //procedure SetItem(Index: Integer; const Value: TPageFooter);
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TCustomisedCells(Object Owner)
            {
                FOwner = Owner;
            }
            public TCustomisedCell Add()
            {
                TCustomisedCell cc = new TCustomisedCell();
                List.Add(cc);
                return cc;
            }
            public TCustomisedCell this[int index]
            {
                get
                {
                    return ((TCustomisedCell)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }
        [Serializable]
        public class TLine : CollectionBase
        {
            private TCustomisedCells FCells;
            public TLine()
            {
                FCells = new TCustomisedCells(FCells);
            }
            ~TLine()
            { }
            public TCustomisedCells Cells
            {
                get
                {
                    return FCells;
                }
                set
                {
                    FCells = value;
                }
            }
        }
        [Serializable]
        public class TLines : CollectionBase
        {
            private Object FOwner;
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TLines(Object Owner)
            {
                FOwner = Owner;
            }
            public TLine Add()
            {
                TLine cc = new TLine();
                List.Add(cc);
                return cc;
            }
            public TLine this[int index]
            {
                get
                {
                    return ((TLine)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }
        [Serializable]
        public class TCustomisedSection : CollectionBase
        {
            private TLines FLines;
            private Position FPosition;
            public TCustomisedSection()
            {
                FLines = new TLines(FLines);
            }
            public TLines Lines
            {
                get
                {
                    return FLines;
                }
                set
                {
                    FLines = value;
                }
            }
            public Position Position
            {
                get
                {
                    return FPosition;
                }
                set
                {
                    FPosition=value;
                }
            }
            //  end;
        }
        [Serializable]
        public class TCustomisedSections : CollectionBase
        {
            private Object FOwner;
            protected Object GetOwner()
            {
                return FOwner;
            }
            public TCustomisedSections(Object Owner)
            {
                FOwner = Owner;
            }
            public TCustomisedSection Add()
            {
                TCustomisedSection cc = new TCustomisedSection();
                List.Add(cc);
                return cc;
            }
            public TCustomisedSection this[int index]
            {
                get
                {
                    return ((TCustomisedSection)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}