using System.Text;

namespace MetodosOrdenacao.Services
{
    public class InsertionSortService : IInsertionSortService
    {
        private readonly ILogger<InsertionSortService> _logger;

        public InsertionSortService(ILogger<InsertionSortService> logger)
        {
            _logger = logger;
        }

        public string Sort(string text)
        {
            StringBuilder stringBuilder = new StringBuilder(text);
            int i, j;
            char x;
            for (i = 2; i <= stringBuilder.Length-1; i++)
            {
                x = stringBuilder[i];
                j = i - 1;
                stringBuilder[0] = x;
                while ((int)x < (int)stringBuilder[j])
                {
                    stringBuilder[j + 1] = stringBuilder[j];
                    j--;
                }
                stringBuilder[j + 1] = x;
            }
            return stringBuilder.ToString();
        }
    }
}
