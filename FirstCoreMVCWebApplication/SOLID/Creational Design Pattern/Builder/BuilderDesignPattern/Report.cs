namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Builder.BuilderDesignPattern
{
    public class Report
    {
        public string ReportType { get; set; }
        public string ReportHeader { get; set; }
        public string ReportFooter { get; set; }
        public string ReportContent { get; set; }

        public void DisplayReport()
        {
            Console.WriteLine("Report type: " + ReportType);
            Console.WriteLine("Header: " + ReportHeader);
            Console.WriteLine("Content: " + ReportContent);
            Console.WriteLine("Footer: " + ReportFooter);
        }
    }
}
