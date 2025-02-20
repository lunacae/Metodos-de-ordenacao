using MetodosOrdenacao.Models;
using MetodosOrdenacao.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace MetodosOrdenacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenacaoController : ControllerBase
    {
        private readonly ILogger<OrdenacaoController> _logger;
        private readonly IBubbleSortService bubbleSortService;
        private readonly IInsertionSortService insertionSortService;
        private readonly ISelectionSortService selectionSortService;
        private readonly IQuickSortService quickSortService;

        public OrdenacaoController(ILogger<OrdenacaoController> logger, IBubbleSortService bubbleSort, IInsertionSortService insertionSort, ISelectionSortService selectionService, IQuickSortService quickSortService)
        {
            _logger = logger;
            this.bubbleSortService = bubbleSort;
            this.insertionSortService = insertionSort;
            this.selectionSortService = selectionService;
            this.quickSortService = quickSortService;
        }


        [HttpPost("BubbleSort")]
        public IActionResult BubbleSort([FromBody] SortBody body)
        {
            var stopwatch = new Stopwatch();
            var response = new SortResponse();
            stopwatch.Start();
            response.textSorted = bubbleSortService.Sort(body);
            stopwatch.Stop();
            response.duration = stopwatch.ElapsedMilliseconds;
            return Ok(response);
        }

        [HttpPost("InsertionSort")]
        public IActionResult InsertionSort([FromBody] SortBody body)
        {
            var stopwatch = new Stopwatch();
            var response = new SortResponse();
            stopwatch.Start();
            response.textSorted = insertionSortService.Sort(body.textToSort);
            stopwatch.Stop();
            response.duration = stopwatch.ElapsedMilliseconds;
            return Ok(response);

        }

        [HttpPost("SelectionSort")]
        public IActionResult SelectionSort([FromBody] SortBody body)
        {
            var stopwatch = new Stopwatch();
            var response = new SortResponse();
            stopwatch.Start();
            response.textSorted = selectionSortService.Sort(body.textToSort);
            stopwatch.Stop();
            response.duration = stopwatch.ElapsedMilliseconds;
            return Ok(response);
        }

        [HttpPost("QuickSort")]
        public IActionResult QuickSort([FromBody] SortBody body)
        {
            var stopwatch = new Stopwatch();
            var response = new SortResponse();
            stopwatch.Start();
            response.textSorted = quickSortService.Sort(body.textToSort);
            stopwatch.Stop();
            response.duration = stopwatch.ElapsedMilliseconds;
            return Ok(response);
        }

    }
}
