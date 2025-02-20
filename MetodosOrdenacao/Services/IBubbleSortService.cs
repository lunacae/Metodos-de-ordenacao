using MetodosOrdenacao.Models;

namespace MetodosOrdenacao.Services
{
    public interface IBubbleSortService
    {
        string Sort(SortBody body);
    }
}