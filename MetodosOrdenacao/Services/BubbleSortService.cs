using MetodosOrdenacao.Models;
using System.Diagnostics;
using System.Text;

namespace MetodosOrdenacao.Services
{
    public class BubbleSortService : IBubbleSortService
    {
        private readonly ILogger<BubbleSortService> _logger;

        public BubbleSortService(ILogger<BubbleSortService> logger)
        {
            _logger = logger;
        }

        public string Sort(SortBody body)
        {
            StringBuilder sb = new StringBuilder(body.textToSort);
            return BubbleSort(sb, sb.Length-1);
        }

        private string BubbleSort(StringBuilder text, int size)
        {
            if (size < 1) return text.ToString();

            for (int i = 0; i < size; i++)
            {
                if ((int)text[i] > (int)text[i + 1])
                    text = Swap(text, i, i + 1);
            }

            return BubbleSort(text, size - 1);
        }

        private StringBuilder Swap(StringBuilder sb, int indexA, int indexB)
        {
            char temp = sb[indexA];
            sb[indexA] = sb[indexB];
            sb[indexB] = temp;
            return sb;
        }
    }
}
