# OpenSW12
오픈소스SW개론 002분반 12조의 최종과제물 "Cube Zombie"입니다.

# 프로젝트 설명
본 프로젝트는 Unity로 3D 게임을 만들기 위한 목적으로 시작되었습니다.   
플레이어는 자신을 쫓아오는 파란색 적을 피해 최대한 점수를 획득하며 오래 살아남는 것을 목표로 하게 됩니다.<br><br>
<span style="font-size:150%">조작법
* WASD : 이동
* 스페이스바 : 점프
* 마우스 이동 : 시점 조절

<br>

# Install
On Windows<br>
<pre><code>git clone https://github.com/P-INI/OpenSW12 .</code></pre>
본 리포지토리를 목표 디렉토리에서 그대로 clone한 후 유니티 에디터 상에서 Add하시면 됩니다.<br><br>
단순 코드 확인이 목적이시라면 /Assets/Scripts에 코드 전체가 저장되어 있습니다.<br><br>
게임 플레이가 목적이시라면 /TestBuild/OpenSWTermProj.exe를 실행하시면 플레이하실 수 있습니다.<br><br>
해당 프로젝트는 Unity 기반 프로젝트이기 때문에 Unity Editor가 없는 경우 스크립트만으로 원활하게 확인하실 수 없으며, 권장 버전은 2022.3.22f1입니다.

# 코드의 기능
자세한 기능은 보고서를 참고해주시고. 이곳에선 간단하게 설명하겠습니다.<br>
* PlayerMove.cs : 플레이어의 이동 제어
* Player_Info.cs : 플레이어의 현재 정보 저장
* PlayerCollision.cs : 플레이어가 타 오브젝트와 충돌 시 행동
* Managers.cs : 적의 생성
* MainMenu.cs : 타이틀 화면과 타이틀에서의 조작
* InGameScore.cs : 점수의 설정과 표시
* Item_Score.cs : 아이템 획득 시 점수 증가
* MonsterControll.cs : 적의 플레이어 추적, 이동
* CameraControl.cs : 마우스를 통한 카메라 위치 및 각도 제어
