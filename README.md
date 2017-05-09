# Unity3D_ObjectController

デバッグなどを目的として、オブジェクトを自動で移動したり回転したりするためのスクリプト集です。

## 実装された動き

<table>
<td colspan="3">Walker</td>
<tr>
<th>CheckPointWalker</th>
<th>PingPongWalkerInSphere</th>
<th>RandomWalkerInRectangle</th>
</tr>
<tr>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_checkpointwalker.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_pingpongwalkerinsphere.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_randomwalkerinrectangle.gif" width="160px"></td>
</tr>
<tr>
<td>指定した座標を順に移動します。</td>
<td>球状の中をランダムに跳ね返り続けます。</td>
<td>矩形の中をランダムに移動し続けます。</td>
</tr>

<td colspan="3">Rotator</td>
<tr>
<th>AxisRotator</th>
<th>AxisAroundRotator</th>
<th>RandomRotator</th>
</tr>
<tr>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_axisrotator.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_axisaroundrotator.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_randomrotator.gif" width="320px"></td>
</tr>
<tr>
<td>任意の軸を中心に回転します。</td>
<td>任意の軸を中心に周囲を回転します。</td>
<td>ランダムに回転し続けます。</td>
</tr>

<td colspan="3">Color</td>
<tr>
<th>ColorSetter</th>
<th>ColorShifter</th>
<th>ColorShifterAuto</th>
</tr>
<tr>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_colorsetter.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_colorshifter.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_colorshifterauto.gif" width="160px"></td>
</tr>
<tr>
<td>色を設定します。</td>
<td>任意のタイミングで色を変化します。</td>
<td>一定時間おきに色を変化します。</td>
</tr>

<td colspan="3">Others</td>
<tr>
<th>KeyboardController</th>
<th>CosMover</th>
<th></th>
</tr>
<tr>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_keyboardcontroller.gif" width="160px"></td>
<td><img src="https://github.com/XJINE/Unity3D_ObjectController/blob/master/Screenshot/screenshot_cosmover.gif" width="160px"></td>
<td></td>
</tr>
<tr>
<td>キーボードでオブジェクトを動かします。</td>
<td>任意の方向に Cos の値を使って動きます。</td>
<td></td>
</tr>
</table>