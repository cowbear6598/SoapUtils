## 安裝 (Install)

- 此工具包一定要配合 Zenject 使用，或是要額外拆成單獨的程式再進行拼裝
- PlayerSetting -> Package Manager
```
Name: package.openupm.com
URL: https://package.openupm.com
Scope(s): 
         com.svermeulen.extenject
         com.cysharp.unitask
         com.neuecc.unirx
```
- Add package form git url
```
https://github.com/cowbear6598/SoapUtils.git?path=Assets/SoapUtils
```

- 感謝 AnimeTask 提供 Tween 的功能，但我無法直接使用 Package 去連結，所以只能把它專案裡的功能複製到我這邊，以下是他專案網址：<https://github.com/kyubuns/AnimeTask>

## Database 功能

### 設定

```
在 Project 視窗點擊右鍵 -> Soap -> SoapSettings，即可在裡面調整 domain 與 timeout，
之後在要需要的地方注入 IDatabaseService 即可
```

### 使用
- GET

```
DoGet(int domainIndex, string api, params string[] data);
```

- POST

```
DoPost(int domainIndex, string api, object data)
DoPost(int domainIndex, string api, string token, object data)
```

- PUT

```
DoPut(int domainIndex, string api, object data)
DoPut(int domainIndex, string api, string token, object data)
```