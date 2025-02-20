using System.Text;

namespace MetodosOrdenacao.Services
{
    public class SelectionSortService : ISelectionSortService
    {
        private readonly ILogger<SelectionSortService> _logger;

        public SelectionSortService(ILogger<SelectionSortService> logger)
        {
            _logger = logger;
        }

        public string Sort(string text)
        {
            StringBuilder stringBuilder = new StringBuilder(text);

            int i, j, min;
            char x;
            for (i = 0; i <= stringBuilder.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j <= stringBuilder.Length - 1; j++)
                {
                    if ((int)stringBuilder[j] < (int)stringBuilder[min])
                        min = j;
                }
                x = stringBuilder[min];
                stringBuilder[min] = stringBuilder[i];
                stringBuilder[i] = x;
            }

            return stringBuilder.ToString();
        }
    }
}
