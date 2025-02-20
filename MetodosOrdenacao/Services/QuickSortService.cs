using System.Numerics;
using System.Text;

namespace MetodosOrdenacao.Services
{
    public class QuickSortService : IQuickSortService
    {
        private readonly ILogger<QuickSortService> _logger;

        public QuickSortService(ILogger<QuickSortService> logger)
        {
            _logger = logger;
        }

        public string Sort(string text)
        {
            StringBuilder stringBuilder = new StringBuilder(text);
            quickSort(stringBuilder, 0, stringBuilder.Length-1);
            return stringBuilder.ToString();
        }

        private void quickSort(StringBuilder text, int low, int high)
        {
            if (low < high)
            {
                // pi is the partition return index of pivot
                int pi = partition(text, low, high);

                // Recursion calls for smaller elements
                // and greater or equals elements
                quickSort(text, low, pi - 1);
                quickSort(text, pi + 1, high);
            }
        }

        private int partition(StringBuilder text, int low, int high)
        {
            // Choose the pivot
            int pivot = text[high];

            // Index of smaller element and indicates 
            // the right position of pivot found so far
            int i = low - 1;

            // Traverse arr[low..high] and move all smaller
            // elements on left side. Elements from low to 
            // i are smaller after every iteration
            for (int j = low; j <= high - 1; j++)
            {
                if (text[j] < pivot)
                {
                    i++;
                    text = Swap(text, i, j);
                }
            }

            // Move pivot after smaller elements and
            // return its position
            text = Swap(text, i + 1, high);
            return i + 1;
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
