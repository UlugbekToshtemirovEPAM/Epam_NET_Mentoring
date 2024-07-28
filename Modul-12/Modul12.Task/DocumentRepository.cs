using Newtonsoft.Json;

namespace Modul12.Task
{
    public class DocumentRepository
    {
        private const string FileExtension = ".json";

        public IDocument GetDocumentInstance(string documentType)
        {
            switch (documentType)
            {
                case "book":
                    return new Book();
                default:
                    return null;
            }
        }

        public string LoadDocumentData(string fileName)
        {
            File.ReadAllText($@"{Path}\{fileName}{FileExtension}");
        }
    }
}
