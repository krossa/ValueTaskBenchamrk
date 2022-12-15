using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ValueTaskBenchamrk
{
    readonly Repository _repo = new Repository();

    [Benchmark]
    public async Task RunTaskAsync() => await _repo.GetDataWithTaskAsync("key");


    [Benchmark]
    public async Task RunValueTaskAsync() => await _repo.GetDataWithValueTaskAsync("key");
}