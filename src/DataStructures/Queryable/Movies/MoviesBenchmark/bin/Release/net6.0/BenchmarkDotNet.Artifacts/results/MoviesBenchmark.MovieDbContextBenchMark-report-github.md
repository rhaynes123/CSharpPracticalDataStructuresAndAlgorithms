``` ini

BenchmarkDotNet=v0.13.2, OS=macOS Monterey 12.5.1 (21G83) [Darwin 21.6.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), Arm64 RyuJIT AdvSIMD  [AttachedDebugger]
  DefaultJob : .NET 6.0.8 (6.0.822.36306), Arm64 RyuJIT AdvSIMD


```
|                           Method |   id |     Mean |    Error |   StdDev | Allocated |
|--------------------------------- |----- |---------:|---------:|---------:|----------:|
|       **FirstOrDefaultOnIquerayble** |    **0** | **11.63 ms** | **0.103 ms** | **0.092 ms** |   **8.88 MB** |
|             FirstOrDefaultOnList |    0 | 12.29 ms | 0.125 ms | 0.117 ms |   9.65 MB |
|  FirstOrDefaultOnIqueraybleAsync |    0 | 11.65 ms | 0.049 ms | 0.043 ms |   8.88 MB |
|        FirstOrDefaultOnListAsync |    0 | 12.33 ms | 0.128 ms | 0.120 ms |   9.65 MB |
|      SingleOrDefaultOnIquerayble |    0 | 11.74 ms | 0.128 ms | 0.120 ms |   8.88 MB |
|            SingleOrDefaultOnList |    0 | 12.52 ms | 0.191 ms | 0.179 ms |   9.65 MB |
| SingleOrDefaultOnIqueraybleAsync |    0 | 11.69 ms | 0.083 ms | 0.074 ms |   8.88 MB |
|       SingleOrDefaultOnListAsync |    0 | 12.47 ms | 0.240 ms | 0.236 ms |   9.65 MB |
|       **FirstOrDefaultOnIquerayble** |    **1** | **11.69 ms** | **0.082 ms** | **0.076 ms** |   **8.88 MB** |
|             FirstOrDefaultOnList |    1 | 12.31 ms | 0.119 ms | 0.111 ms |   9.65 MB |
|  FirstOrDefaultOnIqueraybleAsync |    1 | 11.61 ms | 0.074 ms | 0.065 ms |   8.88 MB |
|        FirstOrDefaultOnListAsync |    1 | 12.39 ms | 0.124 ms | 0.116 ms |   9.65 MB |
|      SingleOrDefaultOnIquerayble |    1 | 11.83 ms | 0.134 ms | 0.119 ms |   8.88 MB |
|            SingleOrDefaultOnList |    1 | 12.28 ms | 0.128 ms | 0.120 ms |   9.65 MB |
| SingleOrDefaultOnIqueraybleAsync |    1 | 11.60 ms | 0.069 ms | 0.058 ms |   8.88 MB |
|       SingleOrDefaultOnListAsync |    1 | 12.27 ms | 0.111 ms | 0.103 ms |   9.65 MB |
|       **FirstOrDefaultOnIquerayble** |   **10** | **11.61 ms** | **0.076 ms** | **0.071 ms** |   **8.88 MB** |
|             FirstOrDefaultOnList |   10 | 12.23 ms | 0.115 ms | 0.108 ms |   9.65 MB |
|  FirstOrDefaultOnIqueraybleAsync |   10 | 11.65 ms | 0.084 ms | 0.078 ms |   8.88 MB |
|        FirstOrDefaultOnListAsync |   10 | 12.27 ms | 0.089 ms | 0.083 ms |   9.65 MB |
|      SingleOrDefaultOnIquerayble |   10 | 11.60 ms | 0.082 ms | 0.073 ms |   8.88 MB |
|            SingleOrDefaultOnList |   10 | 12.20 ms | 0.101 ms | 0.094 ms |   9.65 MB |
| SingleOrDefaultOnIqueraybleAsync |   10 | 11.71 ms | 0.080 ms | 0.075 ms |   8.88 MB |
|       SingleOrDefaultOnListAsync |   10 | 12.25 ms | 0.103 ms | 0.096 ms |   9.65 MB |
|       **FirstOrDefaultOnIquerayble** |  **100** | **11.73 ms** | **0.127 ms** | **0.119 ms** |   **8.88 MB** |
|             FirstOrDefaultOnList |  100 | 12.31 ms | 0.105 ms | 0.093 ms |   9.65 MB |
|  FirstOrDefaultOnIqueraybleAsync |  100 | 11.68 ms | 0.133 ms | 0.125 ms |   8.88 MB |
|        FirstOrDefaultOnListAsync |  100 | 12.35 ms | 0.096 ms | 0.090 ms |   9.65 MB |
|      SingleOrDefaultOnIquerayble |  100 | 11.58 ms | 0.123 ms | 0.115 ms |   8.88 MB |
|            SingleOrDefaultOnList |  100 | 12.24 ms | 0.088 ms | 0.078 ms |   9.65 MB |
| SingleOrDefaultOnIqueraybleAsync |  100 | 11.66 ms | 0.098 ms | 0.087 ms |   8.88 MB |
|       SingleOrDefaultOnListAsync |  100 | 12.33 ms | 0.084 ms | 0.079 ms |   9.65 MB |
|       **FirstOrDefaultOnIquerayble** |  **500** | **11.57 ms** | **0.083 ms** | **0.074 ms** |   **8.88 MB** |
|             FirstOrDefaultOnList |  500 | 12.30 ms | 0.089 ms | 0.083 ms |   9.65 MB |
|  FirstOrDefaultOnIqueraybleAsync |  500 | 11.63 ms | 0.037 ms | 0.031 ms |   8.88 MB |
|        FirstOrDefaultOnListAsync |  500 | 12.30 ms | 0.186 ms | 0.174 ms |   9.65 MB |
|      SingleOrDefaultOnIquerayble |  500 | 11.65 ms | 0.098 ms | 0.091 ms |   8.88 MB |
|            SingleOrDefaultOnList |  500 | 12.25 ms | 0.079 ms | 0.070 ms |   9.65 MB |
| SingleOrDefaultOnIqueraybleAsync |  500 | 11.69 ms | 0.091 ms | 0.085 ms |   8.88 MB |
|       SingleOrDefaultOnListAsync |  500 | 12.24 ms | 0.082 ms | 0.073 ms |   9.65 MB |
|       **FirstOrDefaultOnIquerayble** | **1999** | **11.65 ms** | **0.125 ms** | **0.111 ms** |   **8.88 MB** |
|             FirstOrDefaultOnList | 1999 | 12.23 ms | 0.095 ms | 0.089 ms |   9.65 MB |
|  FirstOrDefaultOnIqueraybleAsync | 1999 | 11.62 ms | 0.075 ms | 0.070 ms |   8.88 MB |
|        FirstOrDefaultOnListAsync | 1999 | 12.30 ms | 0.066 ms | 0.058 ms |   9.65 MB |
|      SingleOrDefaultOnIquerayble | 1999 | 11.71 ms | 0.079 ms | 0.070 ms |   8.88 MB |
|            SingleOrDefaultOnList | 1999 | 12.38 ms | 0.105 ms | 0.098 ms |   9.65 MB |
| SingleOrDefaultOnIqueraybleAsync | 1999 | 11.88 ms | 0.076 ms | 0.071 ms |   8.88 MB |
|       SingleOrDefaultOnListAsync | 1999 | 12.24 ms | 0.106 ms | 0.099 ms |   9.65 MB |
