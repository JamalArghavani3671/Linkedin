using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HandlingMultipleTaskProject.Controllers;

[ApiController]
[Route("[controller]")]
public class HandlingMultipleTaskController : ControllerBase
{
    private readonly ILogger<HandlingMultipleTaskController> _logger;

    public HandlingMultipleTaskController(ILogger<HandlingMultipleTaskController> logger)
    {
        _logger = logger;
    }


    [HttpGet("UsingTaskWhenAll")]
    public async Task<IActionResult> UsingTaskWhenAll()
    {
        Console.WriteLine("******************************************");
        var sp = new Stopwatch(); sp.Start();

        List<Task<string>> tasks = new List<Task<string>>();
        tasks.Add(CallApi1());
        tasks.Add(CallApi2());
        tasks.Add(CallApi3());
        tasks.Add(CallApi4());

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (AggregateException ex)
        {
            var ex1 = ex;
        }
        catch (Exception ex)
        {
            var ex1 = ex;
        }
        sp.Stop();
        Console.WriteLine($"Elapsed Miliseconds : {sp.ElapsedMilliseconds} ms");
        return Ok("ok");
    }


    [HttpGet("UsingTaskWhenAny")]
    public async Task<IActionResult> UsingTaskWhenAny()
    {
        Console.WriteLine("******************************************");
        var sp = new Stopwatch(); sp.Start();

        List<Task<string>> tasks = new List<Task<string>>();
        var cts = new CancellationTokenSource();
        tasks.Add(CallApi1(cts.Token));
        tasks.Add(CallApi2(cts.Token));
        tasks.Add(CallApi3(cts.Token));
        tasks.Add(CallApi4(cts.Token));

        var taskResult = new List<string>();

        try
        {
            while (tasks.Any())
            {
                Task<string> completedTask = await Task.WhenAny(tasks);
                if (completedTask.IsFaulted)
                {
                    // Cancel the rest of the tasks
                    cts.Cancel();
                    break;
                }

                if (completedTask.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(completedTask.Result);
                    taskResult.Add(completedTask.Result);
                }
                tasks.Remove(completedTask);
            }
        }
        catch (OperationCanceledException)
        {
            // Handle the cancellation
        }
        finally
        {
            cts.Dispose();
        }

        sp.Stop();
        Console.WriteLine($"Elapsed Miliseconds : {sp.ElapsedMilliseconds} ms");

        return Ok("ok");
    }

    private async Task<string> CallApi1(CancellationToken token = default)
    {
        try
        {
            Console.WriteLine("CallApi1 : Started!");
            await Task.Delay(30000, token);
            Console.WriteLine("CallApi1 : finished!");
            return "CallApi1";
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("CallApi1 : OperationCanceledException");
            return "CallApi1 : OperationCanceledException";
        }
        catch (Exception ex)
        {
            Console.WriteLine("CallApi1 : Throw Exception!");
            throw;
        }
    }

    private async Task<string> CallApi2(CancellationToken token = default)
    {
        try
        {
            Console.WriteLine("CallApi2 : Started!");
            await Task.Delay(1000, token);
            Console.WriteLine("CallApi2 : finished!");
            return "CallApi2";
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("CallApi2 : OperationCanceledException");
            return "CallApi2 : OperationCanceledException";
        }
        catch (Exception ex)
        {
            Console.WriteLine("CallApi2 : Throw Exception!");
            throw;
        }
    }

    private async Task<string> CallApi3(CancellationToken token = default)
    {
        try
        {
            Console.WriteLine("CallApi3 : Started!");
            await Task.Delay(20000, token);
            Console.WriteLine("CallApi3 : finished!");
            return "CallApi3";
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("CallApi3 : OperationCanceledException");
            return "CallApi3 : OperationCanceledException";
        }
        catch (Exception ex)
        {
            Console.WriteLine("CallApi3 : Throw Exception!");
            throw;
        }
    }

    private async Task<string> CallApi4(CancellationToken token = default)
    {
        try
        {
            Console.WriteLine("CallApi4 : Started!");
            await Task.Delay(5000, token);
            throw new Exception("Exception Occured at CallApi4");
            Console.WriteLine("CallApi4 : finished!");
            return "CallApi4";
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("CallApi4 : OperationCanceledException");
            return "CallApi4 : OperationCanceledException";
        }
        catch (Exception ex)
        {
            Console.WriteLine("CallApi4 : Throw Exception!");
            throw;
        }
    }
}
