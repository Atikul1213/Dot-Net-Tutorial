namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Builder.BuilderDesignPattern
{
    public class ReportDirector
    {
        public Report MakeReport(ReportBuilder reportBuilder)
        {
            reportBuilder.CreateNewReport();
            reportBuilder.SetReportType();
            reportBuilder.SetReportHeader();
            reportBuilder.SetReportContent();
            reportBuilder.SetReportFooter();

            return reportBuilder.GetReport();
        }
    }
}
