namespace Modul12.Task
{
    internal class Program
    {
        private static DocumentRepository _repository = new DocumentRepository();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter document type and number separated by comma");
                string input = Console.ReadLine();

                string[] inputParts = input.Split(',');

                IDocument document = _repository.GetDocumentInstance(inputParts[0]);
                if (document != null)
                {
                    document.Load(inputParts[1]);

                    Console.WriteLine(document.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid document type.");
                }
            }
        }
    }
}
