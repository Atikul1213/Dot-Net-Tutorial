namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Builder.BuilderDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            PDFReport pdfReport = new PDFReport();

            ReportDirector reportDirector = new ReportDirector();

            Report report = reportDirector.MakeReport(pdfReport);

            report.DisplayReport();
        }
    }
}
