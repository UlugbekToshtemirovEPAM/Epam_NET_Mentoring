namespace Modul12.Task
{
    public class App
    {
        private ICache _cache;
        private DocumentRepository _repository;

        public App(ICache cache, DocumentRepository repository)
        {
            _cache = cache;
            _repository = repository;
        }

      /*  public void SearchDocument(string documentType, string documentNumber)
        {
            IDocument document;
            if (!_cache.Has(documentNumber))
            {
                document = _repository.LoadDocument(documentType, documentNumber);
                _cache.Store(documentNumber, document);
            }
            else
            {
                document = _cache.Retrieve(documentNumber);
            }
        }*/
    }
}
