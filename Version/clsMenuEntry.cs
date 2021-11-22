using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edpcom;

namespace EDPVersion
{
   public class clsMenuEntry
    {
        EDPCommon edpcom = new EDPCommon();
        DataTable dtreg = new DataTable();
        DataTable dtcount = new DataTable();
        public void EnterIntomenu(SqlConnection con, DateTime Pbuilddate, DateTime Cbuilddate)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            if (Cbuilddate > Pbuilddate)
            {
                //if (edpcom.EnvironMent_Menu == "NewMenu")
                //    Entermenufirst1(con);
                //else
                    Entermenufirst(con);
            }
        }
        public void Entermenufirst(SqlConnection con)
        {
            int dAttend = 0, MenuLvSal = 0, dqry = 0, MEmp = 0, EmpM = 0, clrec = 0;

            try
            {
                clrec = Convert.ToInt32(edpcom.GetDatatable("select clrec from CompanyLimiter").Rows[0][0].ToString());
            }
            catch { clrec = 0; }
            try
            {
                dAttend = Convert.ToInt32(edpcom.GetDatatable("select dAttend from CompanyLimiter").Rows[0][0].ToString());

            }
            catch { dAttend = 0; }

            try
            {
                MEmp = Convert.ToInt32(edpcom.GetDatatable("select MEmp from CompanyLimiter").Rows[0][0].ToString());

            }
            catch { MEmp = 0; }

            try
            {
                EmpM = Convert.ToInt32(edpcom.GetresultS("select DormentDur from CompanyLimiter"));
                if (EmpM > 0)
                {
                    EmpM = 1;
                }
            }
            catch { EmpM = 0; }

            try
            {
                MenuLvSal = Convert.ToInt32(edpcom.GetDatatable("select MenuLvSal from CompanyLimiter").Rows[0][0].ToString());

            }
            catch { MenuLvSal = 0; }

            try
            {
                dqry = Convert.ToInt32(edpcom.GetDatatable("select SalExc2 from CompanyLimiter").Rows[0][0].ToString());

            }
            catch { dqry = 0; }
            try
            {
                string sql = " delete from menutable";
                int icount = Convert.ToInt16(edpcom.GetDatatable("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='CompanyLimiter' AND COLUMN_NAME ='reg_central'").Rows[0][0].ToString());
                try
                {
                    if (icount > 0)
                    {
                        dtreg = edpcom.GetDatatable("select reg_central,reg_tamilnadu,reg_general,inv from CompanyLimiter");
                    }
                    else
                    {
                        dtreg = edpcom.GetDatatable("select 0 as reg_central,0 as reg_tamilnadu,0 as reg_general,0 as inv");
                    }
                }
                catch { }
                if (dtreg.Rows.Count == 0)
                {
                    dtreg = edpcom.GetDatatable("select 0 as reg_central,0 as reg_tamilnadu from CompanyLimiter");
                }
                // ------------------------------------ New Code Block --------------------------------------------------
                //added by Bibhas
                // ******* Admin *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'10000000000', N'0', N'Admin', N'Admin', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'10070100000', N'10000000000', N'User Login', N'User Login', 1, N' ', N'Ctrl+Q', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'10070200000', N'10000000000', N'Create Session', N'Create Session', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'10070300000', N'10000000000', N'Account Transfer', N'Account Transfer', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'10070400000', N'10000000000', N'Document Number', N'Document Number', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'10070500000', N'10000000000', N'Account Link Config', N'Account Link Config', 0, NULL, NULL, 0)";
                // ******* Master *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20000000000', N'0', N'Master', N'Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010000000', N'20000000000', N'General Master', N'General Master', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010010000', N'20010000000', N'Country Master', N'Country Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010020000', N'20010000000', N'State Master', N'State Master', 1, NULL, NULL, 0)";
                
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010030000', N'20010000000', N'Company Master', N'Company Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010040000', N'20010000000', N'Client Master', N'Client master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010050000', N'20010000000', N'Location Site Master', N'Location Site Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010060000', N'20010000000', N'PF Code Generate', N'PF Code Generate', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010070000', N'20010000000', N'ESI Code Generate', N'ESI COde Generate', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010080000', N'20010000000', N'PTAX Code Generate', N'PTAX Code Generate', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010090000', N'20010000000', N'PTax Slab', N'PTax Slab', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100000', N'20010000000', N'Holiday List', N'Holiday', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100001', N'20010000000', N'Working Hours', N'Hour', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100002', N'20010000000', N'Month Of Days', N'MonthOfDays', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100003', N'20010000000', N'Kit Master && Opening Entry', N'KitMaster', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100011', N'20010000000', N'Fine Master', N'FineMaster', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100004', N'20010000000', N'SAC Master', N'SAC Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100005', N'20010000000', N'Status Master', N'Status Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010020001', N'20010000000', N'Zone Master', N'Zone Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100006', N'20010000000', N'Shift Master', N'Shift Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100007', N'20010000000', N'Enclosure Master', N'Enclosure Master', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100008', N'20010000000', N'Verify Status Master', N'VSMaster', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100009', N'20010000000', N'Police Station Master', N'Enclosure Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010100010', N'20010000000', N'Vendor Master', N'Vendor Master', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020000000', N'20000000000', N'Employee Master', N'Employee Master', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020010000', N'20020000000', N'Job Type Master', N'Job Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020020000', N'20020000000', N'Designation Master', N'Designation Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020030000', N'20020000000', N'Qualification Master', N'Qualification Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020040000', N'20020000000', N'Relation Master', N'Relation Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020050000', N'20020000000', N'Retirement Master', N'Retirement Master', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020060000', N'20020000000', N'Employee Joining', N'Employee Joining', 1, NULL, N'Ctrl+E', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020070000', N'20020000000', N'EmployeeStatusLog', N'EmployeeStatusLog', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020080000', N'20020000000', N'Employee Movement / Deployment Order', N'EmployeeDMLog', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020090000', N'20020000000', N'LvEntry', N'LvEntry', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020100000', N'20020000000', N'Emp Verification', N'EmpVerification', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020110000', N'20020000000', N'Emp Query', N'EmpQry',"+dqry+", NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020120000', N'20020000000', N'Emp Mirror', N'EmpMirror'," + MEmp + ", NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20020130000', N'20020000000', N'Emp Monitoring', N'Monitoring'," + EmpM + ", NULL, NULL, 0)";
                


                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010200000', N'20000000000', N'Salary Master', N'Salary Master', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20030010000', N'20010200000', N'Salary Heads', N'Salary Heads', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20030020000', N'20010200000', N'Salary Structure', N'Salary Structure', 1, NULL, NULL, 0)";


                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20010300000', N'20000000000', N'Link Master', N'Link Master', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20040010000', N'20010300000', N'Link Location Wise Salary Structure', N'Link Location Wise Salary Structure', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20040020000', N'20010300000', N'Company Client Code', N'Company wise Location (Company Client Code)', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20040030000', N'20010300000', N'Locationwise LeaveMaster', N'Locationwise LeaveMaster', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20050000000', N'20000000000', N'Leave Encashment', N'Leave Encashment', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20070000000', N'20000000000', N'Arrears', N'Arrears', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20080000000', N'20000000000', N'Arrear Payslip', N'Arrear Payslip', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20090000000', N'20000000000', N'PF Loan', N'PF Loan', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'20110000000', N'20000000000', N'Temp', N'Temp', 0, NULL, NULL, 0)";

                // ******* Employee *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'30000000000', N'0', N'Employee', N'EMPLOYEE', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'30010000000', N'30000000000', N'Daily Attendance', N'Daily Attendance'," + dAttend + ", NULL, N'Alt+D', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'30010000001', N'30000000000', N'Monthly Attendance', N'Monthly Attendance', 1, NULL, N'Alt+M', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'30020000000', N'30000000000', N'Employee Allotment', N'Employee Allotment', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'30210000000', N'30000000000', N'Additional Earnings/Deduction', N'Additional Earnings/Deduction', 0, NULL, NULL, 0)";
                // ******* Salary *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40000000000', N'0', N'Salary', N'Salary', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40010000000', N'40000000000', N'Salary Formula Defination', N'Salary Formula Defination', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40010000001', N'40000000000', N'Salary Lumpsum Defination', N'Salary Lumpsum Defination', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40020000000', N'40000000000', N'Assign Heads To Sal Structure', N'Assign Heads To Sal Structure', 1, NULL, N'Ctrl+H', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40030000000', N'40000000000', N'Salary Allotment', N'Salary Allotment', 1, NULL, N'Alt+S', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40020000001', N'40000000000', N'Advance / Loan / Kit / Fine', N'Advance Taken', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40020000002', N'40000000000', N'Employee Wise Salary [Earnings / Deductions]', N'OthDed', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40030000001', N'40000000000', N'Salary Paid Unpaid', N'Salary Paid Unpaid', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40030000002', N'40000000000', N'Leave Adjustment', N'Leave Adjustment', 1, NULL, NULL, 0)";
                /*--------------- Inventory --------------------------*/
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000000', N'0', N'Inventory', N'Inventory', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000002',N'40040000000',  N'Purchase', N'Purchase', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000003', N'40040000000', N'Purchase Return', N'Purchase Return', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000004', N'40040000000', N'Issue', N'Issue', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000005', N'40040000000', N'Issue Return', N'Issue Return', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000006', N'40040000000', N'Damage', N'Damage', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000007', N'40040000000', N'Closing Stock', N'Closing Stock', (case when (" + dtreg.Rows[0]["inv"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                
               //=====================================================================================================================================================================================================================================================================


                ///* X */
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40040000001', N'40000000000', N'Employee wise Society', N'Employee Society', 1, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'40050000000', N'40000000000', N'Ex-Gratia Calculation', N'Ex-Gratia Calculation', 0, NULL, NULL, 0)";
                // ******* Transation *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'50000000000', N'0', N'Transaction', N'Transaction', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'50010000000', N'50000000000', N'Client Contract Order', N'Client Contract Order', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'50020000000', N'50000000000', N'Bill', N'Bill', 1, NULL, N'Ctrl+B', 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'50030000000', N'50000000000', N'Opening Balance', N'Opening Balance', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'50050000000', N'50000000000', N'Payment Addressing', N'Payment Addressing', 1, NULL, NULL, 0)";
                // ******* Report *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60000000000', N'0', N'Report', N'REPORT', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010000000', N'60000000000', N'Document Report', N'Document Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010000', N'60010000000', N'Salary Report', N'Salary Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010001', N'60010010000', N'Salary Allotment Report', N'Salary Allotment Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010002', N'60010010000', N'Pay Slip', N'Pay Slip', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010003', N'60010010000', N'PF/ESI Report', N'PF/ESI Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010015', N'60010010000', N'Salary Report Monthly', N'Salary Report Monthly', 1, NULL, NULL, 0)"; // month wise Salary report
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010016', N'60010010000', N'PF/ESI Report Monthly', N'PF/ESI Report Monthly', 1, NULL, NULL, 0)"; // month wise Pf Esi report
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010004', N'60010010000', N'PTAX Report', N'PTAX Report', 1, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010005', N'60010010000', N'Aquittance', N'Aquittance', 0, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010006', N'60010010000', N'P.F.Rep 1', N'P.F.Rep 1', 0, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010007', N'60010010000', N'P.F.Rep 2', N'P.F.Rep 2', 0, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010008', N'60010010000', N'P.F.Rep 3', N'P.F.Rep 3', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010009', N'60010010000', N'Composite Pay Slip', N'Composite Pay Slip',0, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010020000', N'60010000000', N'Payment Advice', N'Payment Advice', 1, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60020000000', N'60010000000', N'Leave Encashment', N'Leave Encashment', 0, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60030000000', N'60010000000', N'Leave Statement', N'Leave Statement', 0, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60040000000', N'60010000000', N'Bill of Ex-Gratia', N'Bill of Ex-Gratia', 0, NULL, NULL, 0)";
                /* X */sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60050000000', N'60010000000', N'Increment', N'Increment', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60030000001', N'60010000000', N'Leave Wage Report', N'LvWageReport', " + MenuLvSal + ", NULL, NULL, 0)";
                
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60060000000', N'60010000000', N'Arrear', N'Arrear', 0, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60060010000', N'60060000000', N'Pay Slip', N'Pay Slip', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60060020000', N'60060000000', N'Bill', N'Bill', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60060030000', N'60060000000', N'Aquittance', N'Aquittance', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60070000000', N'60010000000', N'Multi Bill Print', N'Bill Print', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080000000', N'60000000000', N'Grid Report', N'Grid Report', 1, NULL, NULL, 0)";
                

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080010000', N'60080000000', N'Section Master', N'Section Master', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080020000', N'60080000000', N'Pending Bill Report', N'Pending Bill Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080030000', N'60080000000', N'GST Statement Report', N'GST Statement Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080040000', N'60080000000', N'Workflow', N'Workflow', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080050000', N'60080000000', N'Zone Report', N'zonereport', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60080060000', N'60080000000', N'Salary Bill Report', N'salbillreport', 1, NULL, NULL, 0)";


                /*---------------- Inventory -------------------------------------------*/
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60090000000', N'60000000000', N'Inventory Report', N'Inventory Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60090000001', N'60090000000', N'Kit Issue && Return', N'Kit Issue Return', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60090000002', N'60090000000', N'CLOSING STOCK VALUATION', N'CLOSING STOCK VALUATION', 1, NULL, NULL, 0)";
                //sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60090000000', N'60000000000', N'Inventory Report', N'Inventory Report', 1, NULL, NULL, 0)";
                /*--------------- General Register --------------------------*/
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000000', N'60000000000', N'Register Report', N'Register Report', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'80000000001',N'8000000000',  N'General Register', N'General Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000010', N'80000000001', N'Wage Register', N'Wage Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000001', N'80000000001', N'OT Register', N'OT Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000002', N'80000000001', N'Fine Register', N'Fine Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000003', N'80000000001', N'Deduction Register', N'Deduction Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000004', N'80000000001', N'Advance Register', N'Advance Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000005', N'80000000001', N'Attendance Register', N'Attendance Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000006', N'80000000001', N'Workmen Register', N'Workmen Register',(case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000007', N'80000000001', N'Bonus Register', N'Bonus Register',(case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000008', N'80000000001', N'ICard Register', N'ICard Register', (case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000009', N'80000000001', N'Damage Register', N'Damage Register',(case when (" + dtreg.Rows[0]["reg_general"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
               
                /*--------------- Central Register --------------------------*///reg_central,reg_tamilnadu from CompanyLimiter

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'80000000002', N'8000000000', N'Central Register', N'Central Register', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000011', N'80000000002', N'Form A Employment', N'Form A Employment',(case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000012', N'80000000002', N'Form B Wages', N'Form B Wages', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000013', N'80000000002', N'Form C RECOVERY', N'Form C RECOVERY', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";//--
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000014', N'80000000002', N'Form D ATTENDANCE', N'Form D ATTENDANCE', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 0 else 0 end), NULL, NULL, 0)";//--
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000015', N'80000000002', N'FORM E LEAVE WAGES', N'FORM E LEAVE WAGES', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 0 else 0 end), NULL, NULL, 0)";//--
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000016', N'80000000002', N'Form XIX - WAGE SLIP', N'Form XIX - WAGE SLIP', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 0 else 0 end), NULL, NULL, 0)";//--
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000017', N'80000000002', N'FORM XII - Employee Card', N'FORM XII - Employee Card', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000018', N'80000000002', N'FORM D - Attendance Register', N'FORM D - Attendance Register', (case when (" + dtreg.Rows[0]["reg_central"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";

                /*--------------- State Register --------------------------*/
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'80000000003', N'8000000000', N'State Register', N'State Register', (case when (" + dtreg.Rows[0]["reg_tamilnadu"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'8000000021', N'80000000003', N'State - Tamilnadu', N'State - Tamilnadu', (case when (" + dtreg.Rows[0]["reg_tamilnadu"].ToString() + "=1) then 1 else 0 end), NULL, NULL, 0)";
                /* ======================================================== */
                
                //sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60090000000', N'60010000000', N'Profit and Loss', N'Profit and Loss', 0, NULL, NULL, 0)";

                //created by biplab 
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60100000000', N'60010000000', N'Employee PF & ESI', N'PF & ESI Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60110000000', N'60010000000', N'BioData && ICard', N'BioData', 1, NULL, NULL, 0)";

                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60120000000', N'60010000000', N'Salary Structure Rpt', N'Salary Structure Rpt', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60130000000', N'60010000000', N'Attendance Rpt', N'Attendance Rpt', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60130000001', N'60010000000', N'Bill && Attendance Difference', N'Bill Attendance Difference', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60140000000', N'60010000000', N'Holiday Rpt', N'Holiday Rpt', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60150000000', N'60010000000', N'Emp Posting Rpt', N'Emp Posting Rpt', 0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60160000000', N'60010000000', N'Employee Wise Joining Report', N'Employee Wise Joining Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60160000001', N'60010000000', N'Employee List Report', N'Employee List Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60170000000', N'60010000000', N'Bill Report', N'Bill Report', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60170000001', N'60010000000', N'Bill Outstanding Site wise', N'Bill Outstanding Site Wise', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60180000000', N'60010000000', N'Bank Payment Letter', N'Bank Payment Letter', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60190000000', N'60010000000', N'Kyc Exception', N'Kyc Exception', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60200000000', N'60010000000', N'Employee Advance', N'Employee Advance', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60210000000', N'60010000000', N'User Work Log', N'UserWorkLog',0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60220000000', N'60010000000', N'Receipt Register', N'Receipt Register',1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60230000000', N'60010000000', N'Bill Outstanding Bill wise', N'Bill Outstanding Bill Wise',1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60240000000', N'60010000000', N'Ledger Salary', N'Ledger Salary',1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60250000000', N'60010000000', N'Cheque Print', N'Cheque Print',0, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60260000000', N'60010000000', N'Ledger', N'Ledger',1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60270000000', N'60010000000', N'Other Deductions (Issue / Recovery)', N'Other Deduction',1, NULL, NULL, 0)";
                // ******* Configuration *******
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70000000000', N'0', N'Configuration', N'CONFIGURATION', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70010000000', N'70000000000', N'Salary Sheet Print Setup', N'Salary Sheet Print Setup', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70011000000', N'70000000000', N'Import Employee from Excel', N'Import Employee from Excel', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70012000000', N'70000000000', N'DashBoard', N'DashBoard', 1, NULL, NULL, 0)";



                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'90000000000', N'0', N'About Bravo', N'AboutBravo', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'90000000001', N'90000000000', N'Contact Details', N'Contact Details', 1, NULL, NULL, 0)";
                //-----------------XXXXX---------------------------------------XXXXX------------------------------------------------------------------------------------------------------------------XXXXX-----------------------------------------------------------------------------------
                //Anurag
                sql = sql + "  INSERT INTO MenuTable(MENUCODE, PARENTCODE, MENUDESC, DETAILDESC, ENABLE_MENU, FORMCODE, SHORTCUT_KEY, TOOLBARBTN) VALUES (80000000000,0,'Cheque','CHEQUE',1,'','',0), (80010000000,80000000000,'Cheque Details','Cheque Details',1,'','',0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010010', N'60010010000', N'PF ESI Eligibility', N'PF_ESI_Eligibility', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010011', N'60010010000', N'Bill Register', N'Bill_Register', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010012', N'60010010000', N'Order Register', N'Order_Register', 1, NULL, NULL, 0)";
                //sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010013', N'60010010000', N'Register of Wages', N'Register Of Wages', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'60010010014', N'60010010000', N'Wages Report', N'Wages Report', 0, NULL, NULL, 0)";
                //frmEmpSalWage_Rpt
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70013000000', N'70000000000', N'Company Statistics', N'Company Statistics', 1, NULL, NULL, 0)";
                // 05/05/2018 - autobackup path set - bibhas
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70014000000', N'70000000000', N'Set Auto Backup Path', N'Set Auto Backup Path', 1, NULL, NULL, 0)";
                sql = sql + " INSERT [MenuTable] ([MENUCODE], [PARENTCODE], [MENUDESC], [DETAILDESC], [ENABLE_MENU], [FORMCODE], [SHORTCUT_KEY], [TOOLBARBTN]) VALUES (N'70015000000', N'70000000000', N'Clear Records', N'Clear Records', " + clrec + ", NULL, NULL, 0)";
                
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                else {
                    con.Close();
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }


        private void Entermenufirst1(SqlConnection con)
        {
            try
            {
                string sql = " delete from menutable_New";
                sql = sql + " Insert into menutable_New values('10000000000','0','Company','Compnay Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10010000000','10000000000','Install Company','Install Details',1,' ',' ',1)";
                sql = sql + " Insert into menutable_New values('10020000000','10000000000','Select Company','Select Details',1,' ',' ',1)";
                sql = sql + " Insert into menutable_New values('10030000000','10000000000','Edit Company','Edit Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10040000000','10000000000','Delete Company','Delete Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10050000000','10000000000','Branch Entry','Branch Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10060000000','10000000000','Currency Details','Currency Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('10070000000','10000000000','User Login Details','User Login Details',1,' ',' ',0)";



                sql = sql + " Insert into menutable_New values('20000000000','0','Entry','Entry',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20010000000','20000000000','Accounts','Accounts',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010100000','20010000000','Ledger A/C','Ledger A/C',1,' ','F2',0)";
                sql = sql + " Insert into menutable_New values('20010200000','20010000000','Sub Groups','SubGroups',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010300000','20010000000','Voucher','Voucher',1,' ','F4',0)";               
                sql = sql + " Insert into menutable_New values('20010400000','20010000000','Document/Entry','Document/Entry',1,' ',' ',0)";
               
                sql = sql + " Insert into menutable_New values('20010301000','20010400000','BRS Entry','BRSEntry',1,' ',' ',0)";               
                sql = sql + " Insert into menutable_New values('20010302000','20010300000','Allocation','Allocation',1,' ','Ctrl+L',0)";

                sql = sql + " Insert into menutable_New values('20010500000','20010000000','VAT Grouping','VATGrouping',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010701000','20010500000','VAT Group Master','VATGroupMaster',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20010702000','20010500000','VAT Item Group Relation','VATItemGroupRelation',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('20020000000','20000000000','Trading','Trading',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020100000','20020000000','Sales','Sales',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020101000','20020100000','Sales Invoice','SalesInvoice',1,' ','F5',0)";
                sql = sql + " Insert into menutable_New values('20020202000','20020100000','Sales Return','SalesReturn',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('20020303000','20020100000','Sales Order','SalesOrder',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('20020404000','20020100000','Sales Challan/DNote','SalesChallon/DNote',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20020200000','20020000000','Purchase','Purchase',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020201000','20020200000','Purchase Invoice','PurchaseInvoice',1,' ','F8',0)";
                sql = sql + " Insert into menutable_New values('20020202000','20020200000','Purchase Return','PurchaseReturn',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020203000','20020200000','Purchase Indent','PurchaseIndent',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20020204000','20020200000','Purchase Order','Purchase',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('20020205000','20020200000','Purchase GRN','PurchaseGRN',1,' ','',0)";

                sql = sql + " Insert into menutable_New values('20030000000','20000000000','Inventory','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030100000','20030000000','Item / Product','Item/Product',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030101000','20030100000','Add New Product','AddNewProduct',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030102000','20030100000','Edit Product','EditProduct',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030103000','20030100000','Product Master','ProductMaster',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030104000','20030100000','Sale Rate Update','SaleRateUpdate',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20030200000','20030000000','Unit','Unit',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030201000','20030200000','Create Unit','CreateUnit',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030202000','20030200000','Edit Unit','EditUnit',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030203000','20030200000','Unit Series','UnitSeries',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030204000','20030200000','Unit Relation','UnitRelation',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20030300000','20030000000','Stock In/Out','StockIn/Out',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030301000','20030300000','Stock In','StockIn',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030302000','20030300000','Stock Out','StockOut',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20030400000','20030000000','Manufacturing','Manufacturing',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030401000','20030400000','Manufacturing Vouchers','ManufacturingVouchers',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030402000','20030400000','Production Formula','ProductionFormula',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20030403000','20030400000','Production Log','ProductionLog',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('20040000000','20000000000','Vectors','Vectors',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20040100000','20040000000','Vectors Configaration','VectorsConfigaration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('20040200000','20040000000','Vectors Master','VectorsMaster',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('30000000000','0','Query','Query',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010000000','30000000000','General','General',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010100000','30010000000','Transactions','Transactions',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010200000','30010000000','Outstanding','Outstanding',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30010300000','30010000000','Party Details','PartyDetails',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30020000000','30000000000','Accounts(Q)','Accounts',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('30020100000','30020000000','Accounts Books','AccountsBooks',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('30020101000','30020100000','Ledger','Journal(Q)',1,' ','',0)";
                sql = sql + " Insert into menutable_New values('30020102000','30020100000','Cash Book','CashBook',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020103000','30020100000','Bank Book','BankBook',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020104000','30020100000','Journal','Journal',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30020200000','30020000000','Final Accounts','FinalAccounts',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020201000','30020200000','Trail Balance Ctrl+T','TrailBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020202000','30020200000','Balance Sheet Ctrl+T','BalanceSheet',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30020203000','30020200000','P&L Account','P&LAccount',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30030000000','30000000000','Inventory(Q)','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030100000','30030000000','Items/Products','Items/Products',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030101000','30030100000','Details','Details',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030102000','30030100000','Locatoin','Locatoin',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30030103000','30030100000','Valuation & Rate','Valuation&Rate',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30030200000','30030000000','Stock Statemrnt','StockStatemrnt',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('30040000000','30000000000','Vector','Vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30040100000','30040000000','Vector Details','VectorDetails',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('30040200000','30040000000','Product Closing Analysis','ProductClosingAnalysis',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('40000000000','0','Reports','Reports',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010000000','40000000000','Account(R)','Account',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010100000','40010000000','Documents','Documents',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010101000','40010100000','Sales ','Sales',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010102000','40010100000','Purchase ','Purchase',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010103000','40010100000','Voucher ','Voucher',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010104000','40010100000','Receipt/Payment ','Receipt/Payment',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010105000','40010100000','Debit Note ','DebitNote ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010106000','40010100000','Credit Note ','CreditNote ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010107000','40010100000','Tax Invoice ','TaxInvoice ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010108000','40010100000','BRS Report ','BRSReport ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010109000','40010100000','Group Summary ','GroupSummary',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010110000','40010100000','Cheque Printing ','ChequePrinting',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('40010200000','40010000000','MIS Report ','MISReport ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010201000','40010200000','Ageging','Ageging',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010202000','40010200000','Analysis','Analysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010203000','40010200000','Forms','Forms',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010204000','40010200000','Budgets ','Budgets',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010205000','40010200000','Cash Flow','CashFlow',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010206000','40010200000','Tax Register','TaxRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010207000','40010200000','Vat Computation','Vat Computation',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010208000','40010200000','Vat Analysis','VatAnalysis',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010209000','40010200000','State_Wise VAT ','State_Wise_VAT',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010210000','40010200000','Outstanding Letter Bills','Outstanding_Letter_Bills',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40010300000','40010000000','Checklist','Checklist ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010301000','40010300000','Ledger','Ledger',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010302000','40010300000','Party Checklist','Party_Checklist',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40010303000','40010300000','Audit Check','AuditCheck',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40020000000','40000000000','Inventory(R)','Inventory',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020100000','40020000000','Documents','Documents ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020101000','40020100000','Trading Reports','TradingReports',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020102000','40020100000','Manufacturing Report','ManufacturingReport',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40020200000','40020000000','Stock Reports','StockReports ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020201000','40020200000','Stock Status','StockStatus ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020202000','40020200000','D-Note','D-Note',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020203000','40020200000','Unbilled D-Note','UnbilledD-Note',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40020300000','40020000000','MIS Reports','MISReports ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40020301000','40020300000','Product Wise Analysis','ProductWiseAnalysis ',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40030000000','40000000000','Vector(R)','Vector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030100000','40030000000','Register','Register ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030101000','40030100000','Vector Register','VectorRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030102000','40030100000','Ledger Vector Register ','LedgerVectorRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030103000','40030100000','Vector Sales Register','VectorSalesRegister',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030104000','40030100000','Vector Purchase ','VectorPurchase ',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40030200000','40030000000','Relation','Relation ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030201000','40030200000','Inter Vector Relation','InterVectorRelation',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030202000','40030200000','Vector Ledger Relation','VectorLedgerRelation',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030203000','40030200000','Vector Type_Ledger Relation','VectorType_LedgerRelation',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('40030300000','40030000000','MIS','MIS ',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030301000','40030300000','Vector Trail','Vector Trail',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030302000','40030300000','Unallocated Vector','UnallocatedVector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030303000','40030300000','Trail Blance With Vector','TrailBlanceWithVector',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('40030304000','40030300000','P/L With Vector','P/L With Vector',1,' ',' ',0)";



                sql = sql + " Insert into menutable_New values('50000000000','0','Utility','Utility',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50010000000','50000000000','Transaction Trail','Transaction Trail',1,' ','F10',0)";
                sql = sql + " Insert into menutable_New values('50020000000','50000000000','Delet Document','DeletDocument',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50030000000','50000000000','Copy Master','CopyMaster',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('50040000000','50000000000','Import Balance','ImportBalance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50040100000','50040000000','Account Import','AccountImport',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50040200000','50040000000','Stock Import','StockImport',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('50050000000','50000000000','Maintanance','Maintanance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50050100000','50050000000','Main Group Maintanance','MainGroupMaintanance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50050200000','50050000000','Sub Group Maintanance','SubGroupMaintanance',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50050300000','50050000000','Ledger Maintanance','LedgerMaintanance',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('50060000000','50000000000','Rebuild','Rebuild',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50070000000','50000000000','Advance Rebuild','AdvanceRebuild',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50080000000','50000000000','Diagnostics','Diagnostics',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50090000000','50000000000','Renumber','Renumber',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50100000000','50000000000','Set Cheque Position','SetChequePosition',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('50110000000','50000000000','User Log','UserLog',1,' ',' ',0)";


                sql = sql + " Insert into menutable_New values('60000000000','0','Tools','Tools',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60010000000','60000000000','Import Data','ImportData',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60010100000','60010000000','Item Import','ItemImport',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60010200000','60010000000','Ledger Import','LedgerImport',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60020000000','60000000000','Dat Back Up','DatBackUp',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60020100000','60020000000','Normal Back Up','NormalBackUp',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60020200000','60020000000','Financial Year Back Up','FinancialYearBack Up',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60030000000','60000000000','Data Restoration','Data Restoration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60030100000','60030000000','Normal Restoration','NormalRestoration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60030200000','60030000000','Financial Year Restoration','FinancialYearRestoration',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60040000000','60000000000','Data Statistics','Data Statistics',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60050000000','60000000000','Settings and configuration','Settingsandconfiguration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60050100000','60050000000','Documents Numbering and A/C Posting Setup','DocumentsNumberingandA/CPostingSetup',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60050200000','60050000000','Configuration','Configuration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60050300000','60050000000','Setting Hotkeys','SettingHotkeys',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60060000000','60000000000','Migration','Migration',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60060100000','60060000000','From Dos Accord','FromDosAccord',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60060200000','60060000000','From Win Accord','FromWinAccord',1,' ',' ',0)";

                sql = sql + " Insert into menutable_New values('60070000000','60000000000','Re_User Login','Re_UserLogin',1,' ',' ',0)";
                sql = sql + " Insert into menutable_New values('60080000000','60000000000','User Details','UserDetails',1,' ',' ',0)";
               
            }
            catch { }
        }
    }
}
