namespace Modul12.Task
{
    public interface IDocument
    {
        string DocumentNumber { get; set; }
        void Load(string documentNumber);
        void SearchDocument(string documentNumber);
    }
}
