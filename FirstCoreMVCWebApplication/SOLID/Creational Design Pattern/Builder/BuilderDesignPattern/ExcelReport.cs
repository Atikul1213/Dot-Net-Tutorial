namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Builder.BuilderDesignPattern
{
    public class ExcelReport : ReportBuilder
    {
        public override void SetReportContent()
        {
            reportObject.ReportContent = "Excel content section";
        }

        public override void SetReportFooter()
        {
            reportObject.ReportFooter = "Excel Footer";
        }

        public override void SetReportHeader()
        {
            reportObject.ReportHeader = "Excel Header";
        }

        public override void SetReportType()
        {
            reportObject.ReportType = "Excel";
        }
    }
}
