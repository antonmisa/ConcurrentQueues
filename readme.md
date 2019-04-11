# Concurrent-Queues
Study about perfomance of queues with different kind of locks in multithreaded environment.
Done on local machine and server.

Benchmarks done by great tools BenchmarkDotNet, see version below.
To install it just use nuget and find BenchmarkDotNet. Enjoy!

BenchmarkDotNet=v0.11.5,  OS=Windows 7 SP1 (6.1.7601.0)
Intel Core i5-4570S CPU 2.90GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
Frequency=2825644 Hz, Resolution=353.9016 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3133.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3133.0


```
|                                                  Method |       Mean |     Error |   StdDev |     Median |
|-------------------------------------------------------- |-----------:|----------:|---------:|-----------:|
|           QueueWrapper enqueue/dequeue with 2 threads   |   491.9 ms |  9.767 ms | 19.05 ms |   492.3 ms |
|          LockFreeQueue enqueue/dequeue with 2 threads   |   583.9 ms | 16.427 ms | 47.13 ms |   570.0 ms |
| ConcurrentQueueWrapper enqueue/dequeue with 2 threads   |   364.0 ms |  7.267 ms | 16.55 ms |   367.1 ms |
|           QueueWrapper enqueue/dequeue with 4 threads   |   978.3 ms | 21.109 ms | 25.13 ms |   972.0 ms |
|          LockFreeQueue enqueue/dequeue with 4 threads   | 1,519.8 ms | 30.093 ms | 51.10 ms | 1,515.1 ms |
| ConcurrentQueueWrapper enqueue/dequeue with 4 threads   |   860.3 ms | 17.065 ms | 48.69 ms |   859.9 ms |

|                                                  Method |       Mean |     Error |    StdDev |     Median |
|-------------------------------------------------------- |-----------:|----------:|----------:|-----------:|
|                   QueueWrapper enqueue with 2 threads   |   486.6 ms |  6.754 ms |  6.318 ms |   488.0 ms |
|                  LockFreeQueue enqueue with 2 threads   |   643.4 ms | 12.398 ms | 15.226 ms |   645.2 ms |
|         ConcurrentQueueWrapper enqueue with 2 threads   |   424.8 ms | 19.811 ms | 20.344 ms |   418.0 ms |
|                   QueueWrapper enqueue with 4 threads   | 1,013.0 ms | 21.459 ms | 63.273 ms |   980.0 ms |
|                  LockFreeQueue enqueue with 4 threads   | 1,432.8 ms | 28.213 ms | 43.084 ms | 1,439.1 ms |
|         ConcurrentQueueWrapper enqueue with 4 threads   |   835.3 ms | 16.447 ms | 31.688 ms |   827.7 ms |

