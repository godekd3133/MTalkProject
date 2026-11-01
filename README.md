# MTalkProject

C# TCP 소켓으로 만들기 시작한 채팅 프로그램입니다. Windows Forms 서버와 클라이언트로 나뉘어 있고, 서버의 접속 수락까지 작성한 단계에서 멈췄습니다.

## 소개

- 저장소 설명은 "MTalk TCP Chat Program Project"입니다. 커밋은 2021-12-01 하루에 3건입니다("Client, Server 프로젝트 생성", "1:1 서버 오픈", "서버쪽 작업 완료 클라 작업중").
- 의도한 구조는 서버가 접속자를 받아 `ChatGroup`에 넣고, 접속자마다 수신 작업과 송신 작업을 따로 돌리며, 사용자별 송신 큐에 쌓인 메시지를 내보내는 형태입니다.

## 핵심 구현

### 서버 (`MTalk_Sever`)

`ChatGroup.StartChatSever`가 `TcpListener`(모든 인터페이스, 포트 7000)를 열고 무한 루프로 접속을 비동기 수락합니다.

```csharp
TcpListener listener = new TcpListener(IPAddress.Any, 7000);
listener.Start();
while (true)
{
    TcpClient tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
    var newUser = new ChatUser() { Client = tc, Name = "user" };
    Join(newUser);
    Task.Factory.StartNew(UserRecvProcess, newUser);   // 수신 전용
    Task.Factory.StartNew(UserSendProcess, newUser);   // 송신 전용
}
```

- `UserRecvProcess`: 1024바이트 버퍼로 `ReadAsync`를 반복하고 ASCII로 해석합니다(수신 후 처리는 주석 상태).
- `UserSendProcess`: 사용자의 송신 큐(`LinkedList<string>`)에 항목이 있으면 `WriteAsync`로 내보내고 큐에서 제거합니다.
- `SendMessage(users, message)`: 모든 사용자 또는 한 사용자의 송신 큐에 메시지를 쌓는 방송 함수입니다.
- `ChatUser`는 이름, `TcpClient`, 송신 큐를 담는 단순 데이터 클래스입니다.
- `MainForm`은 "서버 열기" 버튼을 누르면 `ChatGroup`을 만들어 서버를 시작하고 상태 라벨을 "서버 상태 : ON"으로 바꿉니다.

### 클라이언트 (`MTalk_Client`)

`MainForm`은 빈 폼이고, `ChatLogManager`는 싱글톤 틀과 `TextBox` 필드 선언 중간에서 끝난 미완성 파일입니다.

## 프로젝트 구조

| 경로 | 내용 |
| --- | --- |
| `MTalk_Sever/` | 서버 프로젝트: `ChatGroup`, `ChatUser`, `MainForm` |
| `MTalk_Client/` | 클라이언트 프로젝트: `MainForm`, `ChatLogManager`(미완성) |
| `MTalk/` | 별도 `MTalk_Server` 프로젝트(빈 폼). `MTalk.sln`에는 포함되지 않음 |
| `MTalk.sln` | `MTalk_Client`, `MTalk_Sever` 솔루션 |

## 기술 스택

- C#, .NET Framework 4.6.1, Windows Forms
- `System.Net.Sockets`(`TcpListener`, `TcpClient`, `NetworkStream`), `async/await`
- Visual Studio 솔루션

## 실행 방법

1. Visual Studio와 .NET Framework 4.6.1 개발 도구가 필요합니다.
2. `MTalk.sln`을 열어 서버(`MTalk_Sever`)를 시작 프로젝트로 두고 실행한 뒤 "서버 열기"를 누르면 포트 7000으로 접속을 받습니다.
3. 클라이언트 프로젝트는 `ChatLogManager.cs`에 문법이 끝나지 않은 줄이 있어 현재 코드로는 빌드되지 않습니다.

## 현재 상태

미완성 상태에서 중단된 학습용 프로젝트입니다(마지막 커밋 2021-12-01). 코드에서 확인한 한계는 다음과 같습니다.

- 서버 쪽에서도 `ChatGroup`의 사용자 목록(`users`)과 `ChatUser.sendMessageTask`가 초기화되지 않아, 첫 접속의 `Join` 단계에서 예외가 납니다.
- 수신한 메시지를 다른 사용자의 송신 큐로 보내는 부분이 구현되어 있지 않습니다. 송신 쪽도 문자열을 인코딩한 결과를 버퍼에 담지 않고 빈 버퍼를 써서, 내용이 전달되지 않는 상태입니다.
- 수신/송신 루프가 종료 조건 없이 돌아 연결을 닫는 코드에 도달하지 못합니다.
- `.vs/`(SQLite 캐시 포함)와 `bin/`, `obj/` 산출물이 함께 올라가 있어 정리가 필요합니다.
- 이 문서는 당시 환경(.NET Framework 4.6.1) 기준으로 코드를 읽고 정리한 것이며, 현재 환경에서 다시 빌드해 확인하지는 않았습니다.
