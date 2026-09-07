# portfolio
StartScene: 시작화면
시작하기 버튼 -> GameScene 전환
게임방법 버튼 -> 플레이 방법 설명 
  ㄴ 닫기버튼 실행 x

GameScene: 게임 플레이 화면
차트 클릭 -> 환자 정보 확인
모니터 클릭 -> 진단서 작성 및 제출
ㄴ 누끼x 닫기버튼&타이머 구현 필요
gemini api 연동 완료 / 30초 후 다음으로 버튼 활성화
캐릭터 랜덤 호출 x

WaitingScene: 게임 결과 화면 (라운드 당)
ai의 진단 이후 시나리오+점수(프롬프트 추가 필요)

ResultScene: 3라운드 이후 최종 결과 화면
waiting씬에서 전환 되어야 함
각 라운드의 점수 합계 출력
로비로 돌아가기 버튼 클릭-> StartScene으로 전환
