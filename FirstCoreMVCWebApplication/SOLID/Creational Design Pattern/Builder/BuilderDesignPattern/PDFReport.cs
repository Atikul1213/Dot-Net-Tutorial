namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Builder.BuilderDesignPattern
{
    public class PDFReport : ReportBuilder
    {
        public override void SetReportContent()
        {
            reportObject.ReportContent = "PDF content section";
        }
        public override void SetReportFooter()
        {
            reportObject.ReportFooter = "PDF Footer";
        }
        public override void SetReportHeader()
        {
            reportObject.ReportHeader = "PDF header";
        }
        public override void SetReportType()
        {
            reportObject.ReportType = "PDF";
        }
    }
}
