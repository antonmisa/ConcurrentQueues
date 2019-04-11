``` ini

BenchmarkDotNet=v0.11.5,  OS=Windows 7 SP1 (6.1.7601.0)
Intel Core i5-4570S CPU 2.90GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
Frequency=2825644 Hz, Resolution=353.9016 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3133.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3133.0


```
|                                         Method |        Mean |      Error |     StdDev |
|----------------------------------------------- |------------:|-----------:|-----------:|
|               &#39;LockStack push with 10 threads&#39; |   234.13 ms |  4.6690 ms |  6.8437 ms |
|            &#39;MonitorStack push with 10 threads&#39; |    31.91 ms |  0.1797 ms |  0.1593 ms |
|           &#39;LockFreeStack push with 10 threads&#39; |    31.96 ms |  0.4401 ms |  0.4117 ms |
|  &#39;ConcurrentStackWrapper push with 10 threads&#39; |    31.64 ms |  0.5471 ms |  0.5118 ms |
|              &#39;LockStack push with 100 threads&#39; | 2,165.45 ms | 29.0961 ms | 25.7929 ms |
|           &#39;MonitorStack push with 100 threads&#39; |   381.26 ms |  3.9956 ms |  3.5420 ms |
|          &#39;LockFreeStack push with 100 threads&#39; |   382.80 ms |  3.7581 ms |  3.5153 ms |
| &#39;ConcurrentStackWrapper push with 100 threads&#39; |   387.40 ms |  4.5857 ms |  3.8292 ms |

|                                            Method |        Mean |      Error |     StdDev |
|-------------------------------------------------- |------------:|-----------:|-----------:|
|               &#39;LockStack pushpop with 10 threads&#39; |   425.15 ms |  8.2552 ms | 10.4402 ms |
|            &#39;MonitorStack pushpop with 10 threads&#39; |    28.13 ms |  0.1221 ms |  0.1082 ms |
|           &#39;LockFreeStack pushpop with 10 threads&#39; |    28.61 ms |  0.5461 ms |  0.5608 ms |
|  &#39;ConcurrentStackWrapper pushpop with 10 threads&#39; |    28.51 ms |  0.3097 ms |  0.2746 ms |
|              &#39;LockStack pushpop with 100 threads&#39; | 4,102.46 ms | 67.7666 ms | 63.3889 ms |
|           &#39;MonitorStack pushpop with 100 threads&#39; |   267.58 ms |  2.1457 ms |  2.0071 ms |
|          &#39;LockFreeStack pushpop with 100 threads&#39; |   266.41 ms |  2.4523 ms |  2.1739 ms |
| &#39;ConcurrentStackWrapper pushpop with 100 threads&#39; |   264.22 ms |  3.2156 ms |  2.6852 ms |
