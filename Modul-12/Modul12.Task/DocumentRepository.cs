using Newtonsoft.Json;

namespace Modul12.Task
{
    public class DocumentRepository
    {
        private const string FileExtension = ".json";

        // Returns an instance of IDocument class based on the given document type
        public IDocument GetDocumentInstance(string documentType)
        {
            switch (documentType)
            {
                case "book":
                    return new Book();
                // Add more cases based on the document types.
                default:
                    return null;
            }
        }

        public string LoadDocumentData(string fileName)
        {
            // Implement reading from file functionality here
            File.ReadAllText($@"{Path}\{fileName}{FileExtension}");
        }
    }
}
