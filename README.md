# 概要
Goで作成したAPIサーバーから、JSONを受け取るUnityのプログラム

## 開発環境
- Go 1.21.0
- Unity 2022.3.6f1
- UniTask 2.3.3

## GoJsonAPI.cs
- GETメソッド
- UnityWebRequest.Result
- アウトレット接続
- ゲッター、セッター(get,set)
- ~~Invoke~~
- UniTask
- await/async
- try-catch
- JsonUtility

## PostJSON.cs
- POSTメソッド

## TextManager.cs
- TextUIに取得したJSONのデータを表示する

## 参考URL
- GET：https://docs.unity3d.com/ja/current/Manual/UnityWebRequest-RetrievingTextBinaryData.html
- DownloadHandler：https://docs.unity3d.com/ja/current/ScriptReference/Networking.DownloadHandler.html
- Result：https://docs.unity3d.com/ja/current/ScriptReference/Networking.UnityWebRequest.Result.html
- UniTask：https://github.com/Cysharp/UniTask
- Unity Content-Length：https://qiita.com/broken55/items/207a231996552358aee3
- ResponseWriter：https://pkg.go.dev/net/http#ResponseWriter
