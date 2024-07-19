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

                // Split the input to get the document type and number
                string[] inputParts = input.Split(',');

                // Get an instance of document class based on the document type
                IDocument document = _repository.GetDocumentInstance(inputParts[0]);
                if (document != null)
                {
                    // Load the document data
                    document.Load(inputParts[1]);

                    //Display output - For simplicity just using ToString(). You might need to override ToString() method in each document class.
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
