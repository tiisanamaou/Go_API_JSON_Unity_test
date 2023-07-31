# 概要
Goで作成したAPIサーバーから、JSONを受け取るUnityのプログラム

## 開発環境
- Go 1.20.6
- Unity 2021.3.4f1

## GoJsonAPI.cs
- GETメソッド
- UnityWebRequest.Result
- アウトレット接続
- ゲッター、セッター(get,set)
- Invoke

## PostJSON.cs
- POSTメソッド

## TextManager.cs
- TextUIに取得したJSONのデータを表示する

## 参考URL
- GET：https://docs.unity3d.com/ja/current/Manual/UnityWebRequest-RetrievingTextBinaryData.html
- DownloadHandler：https://docs.unity3d.com/ja/current/ScriptReference/Networking.DownloadHandler.html
- Result：https://docs.unity3d.com/ja/current/ScriptReference/Networking.UnityWebRequest.Result.html
