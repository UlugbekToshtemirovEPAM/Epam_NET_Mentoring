namespace Modul7.Tasks.DoNotChange
{
    public interface IHybridFlowProcessor<T>
    {
        void Push(T item);

        T Pop();

        void Enqueue(T item);

        T Dequeue();
    }
}
