SephirothSceneSwitchingEffects
 - 真っ暗な画面を経由しないシーン遷移用のエフェクト集。 /Ver1.00.0
Copyright (c) 2024 GiftedStyle

===
導入

シーン内を移動するときに使用するエフェクトは、アプリの印象を左右する可能性があります。
SephirothSceneSwitchingEffects は、次の 4 つのエフェクトを提供します。
- 最後のタッチポイントから円が広がるようにシーンを移動します。
- 特定の点から円が広がるようにシーンを移動します。
- フェードを使用してシーンを移動します。
- グレースケール画像に基づいてシーンを移動します。

黒い画面を経由せずに直接遷移します。

グレースケール画像を作成するスキルがあれば
グレースケール画像に基づいてシーンを移動する機能を使用して
エフェクトを自分で作成できます。

SephirothSceneSwitchingEffects を使用するには、次のようなメソッドを実行するだけです。
「SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitchAtLastTouchPoint(string sceneName);」。

「グレースケール画像に基づくフェード」エフェクトを使用したい場合は
グレースケール画像を「Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage」に
保存してください。

シーンの前後を同時に読み込むタイミングはありません。
そのため、前後のシーンで多くのメモリが必要な場合でも、問題なくシーン間を移動できます。

例えば、円が広がるようにシーンを移動したい場合は、以下の手順で操作します。
step1: シーンを移動する直前に画面をTexture2Dに変換します。
step2: シーンをアンロードします。
step3: 次のシーンを読み込みます。
step4: 上記Texture2Dを画面いっぱいに表示し、円状に広がるように広げます。

境界線を暗くすることもできます。
枠線が濃いバージョンについてはアセットストアの参考動画をご確認ください。
境界線を暗くしたい場合は Shader で書いた作業を行ってください。 (コメントアウトを解除します)

このアセットをインポートすると
SephirothSceneSwitchingEffects フォルダが Assets 直下に配置されます。
この SephirothSceneSwitchingEffects フォルダは
他のフォルダに移動する事ができます。

ロードシーンなどで
フェードを 1 回だけ自動的に実行したい場合があります。
このような場合のフリーズを避けるために
フェード中にフェードを実行すると、フェードは 1 回だけ予約されます。
予約されたフェードはフェード完了後に実行されます。

Android、iOSで動作確認済み。

---
使用方法

このアセットは SephirothSceneSwitchingEffects.cs 内のメソッドを実行してご利用ください。

「最後のタッチポイントから円が広がるようにシーンを移動する」エフェクトを使用する場合は
UnityEngine.SceneManagement.SceneManager.LoadScene(string sceneName) の代わりに
SephirothTools.SephirothSceneSwitchingEffects.CircleWipeSceneSwitchAtLastTouchPoint(string sceneName) を
使用します。

SephirothTools.SephirothSceneSwitchingEffects
 .CircleWipeSceneSwitchAtLastTouchPoint(string sceneName、float speed = 1f);
の speed 部分を設定することで、円が広がる速度を変更できます。

「グレースケール画像に基づくフェード」エフェクトを使用したい場合はグレースケール画像を
「Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage」に保存してください。
上記フォルダーに保存されたファイルはStreamingAssetsに保存されます。
出力前に未使用の画像を削除することをお勧めします。

「Tools/SephirothSceneSwitchingEffects/ExecSephirothGrayScaleRotateFunction」
を実行することで
「Assets/SephirothSceneSwitchingEffects/GrayScale/GrayScaleImage」
に格納されている画像を90度回転します。

グレースケール画像は引き伸ばして使用します。
引き伸ばしても違和感のないグレースケール画像の使用をおすすめします。
縦画面で使用する場合は、縦に長いグレースケール画像を使用する事を推奨します。

このアセットを使用するには、UseScene フォルダー内のシーンを「Scenes In Build」に追加する必要があります。
アセットをインポートすると自動で対象になりますが、誤って取り除いてしまった場合は再度入れて下さい。

DemoScene を試してみたい場合は、DemoScene のシーンを「Scenes In Build」に入れてください。

Android、iOSで動作確認済み。