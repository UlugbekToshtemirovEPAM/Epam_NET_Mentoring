namespace Modul12.Task
{
    public class Book : IDocument
    {
        public string DocumentNumber { get; set; }
        // other properties needed

        public void Load(string documentNumber)
        {
            // Load book data from file system
        }

        public void SearchDocument(string documentNumber)
        {
            // Perform search functionality
        }
    }
}
