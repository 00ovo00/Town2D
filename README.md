# 1. 프로젝트 소개

캐릭터 선택 및 이동의 기본적인 기능을 갖춘 2D 프로그램
![2DTown_demo](https://github.com/user-attachments/assets/c07b6367-3419-417c-884a-5e5bf9faf1f2)

--- 

# 2. Workflow

1. **캐릭터 선택**: 플레이어는 UI를 통해 `CharacterButton.cs`와 `JoinButton.cs`를 사용하여 캐릭터를 선택하고 이름 입력. 선택된 캐릭터와 이름을 `PlayerPrefs` 에 저장
2. **입력 처리**: `PlayerInputController.cs`가 플레이어의 입력 감지, 이를 이동 및 조준 이벤트로 변환.
3. **캐릭터 이동 및 조준**: `CreatureController`에서 발생한 이벤트가 이동 및 조준 스크립트로 전달되어 캐릭터의 동작 처리.
4. **카메라 이동**: `CameraController.cs` 로 카메라가 플레이어를 중심으로 이동하도록 관리.
5. **플레이어 설정**: `PlayerSettingManager.cs`는 저장된 플레이어 데이터(이름)를 로드하여 UI에 반영.

![image](https://github.com/user-attachments/assets/1eab2959-2d1a-40f5-a52a-da2110089309)

---

# 3. 파일 명세

## Managers

### **GameManager.cs**

- 플레이어 생성 및 씬 간의 상태 관리를 처리, 싱글톤 객체
    
    `InstantiatePlayer` : 게임 시작 시 저장된 설정에 따라 플레이어 캐릭터(펭귄 또는 마법사)를 동적으로 생성
    

### **PlayerSettingManager.cs**

- 플레이어의 설정(현재는 이름)을 관리
- **필드**:
    - `Text playerName`: UI에 플레이어의 이름을 표시하는 텍스트 컴포넌트 참조
- **`Start()`**: (GameManager의 Awake에서 플레이어 생성된 이후에 동작)
    - 게임 시작 시 `PlayerPrefs`에서 저장된 이름이 있는지 확인(`PlayerPrefs.HasKey("Name")`), 있다면 이를 불러와 `playerName` 텍스트 컴포넌트에 반영

## Controllers

### **CameraController.cs**

- 카메라가 플레이어를 따라다니며 화면 중앙에 플레이어를 배치하도록 업데이트
- **`Start()`**:
    - 게임 시작 시 `GameObject.FindGameObjectWithTag("Player")`를 사용하여 플레이어 객체 가져옴
- **`Update()`**:
    - 매 프레임마다 카메라와 플레이어 간의 방향 벡터를 계산하여 카메라의 위치 갱신
    - `cameraSpeed`를 이용하여 카메라가 플레이어를 따라가는 속도 조절

### **CreatureController.cs**

`CreatureController` 이동 및 시야(조준) 이벤트 처리 Broadcaster 역할. `CreatureMovement` 및 `CreatureAimRotation`과 같은 다른 컴포넌트들이 이 이벤트를 구독하여 동작

- **이벤트**:
    - `OnMoveEvent`: 이동 동작 이벤트
    - `OnLookEvent`: 시야 방향 이벤트
- **`CallMoveEvent(Vector2 direction)`**:
    - 이동 방향을 받아 `OnMoveEvent`를 호출하여 이동 관련 이벤트를 트리거
- **`CallLookEvent(Vector2 direction)`**:
    - 조준 방향을 받아 `OnLookEvent`를 호출하여 구독한 다른 컴포넌트가 캐릭터 회전 처리

### **PlayerInputController.cs**

- Unity의 InputSystem을 사용하여 플레이어의 입력 처리, `CreatureController`를 상속받아 이동 및 조준 관련 이벤트를 처리.
- **`OnMove(InputValue value)`**:
    - 플레이어가 입력한 이동 명령(WASD) 처리
    - **이동 이벤트 호출**: 입력 값을 정규화하고 `CallMoveEvent`를 호출하여 이동 이벤트를 발생시킴
- **`OnLook(InputValue value)`**:
    - 마우스를 통한 조준 입력(마우스 위치) 처리
    - **화면에서 월드 좌표로 변환**: 마우스 좌표를 화면 좌표에서 월드 좌표로 변환
    - **조준 이벤트 호출**:  캐릭터와 마우스 간의 방향 벡터를 계산하여 정규화하고 ****`CallLookEvent`를 호출하여 캐릭터의 시야 방향을 조정

## Behaviors

### **CreatureMovement.cs**

- 캐릭터의 실제 이동을 처리. 이동 입력 이벤트를 구독하고 `Rigidbody2D` 통해 이동
- `FixedUpdate`: 물리 관련 업데이트 처리, 프레임 속도와 상관없이 일관된 동작 보장
- `Move` **&** `ApplyMovement`: `Move` 는 입력된 이동 방향 설정, 실제 이동은 `ApplyMovement`에서 처리

### **CreatureAimRotation.cs**

- 플레이어의 마우스 입력에 따라 캐릭터가 향하는 방향 조정.
- `RotateSprite`: 방향 벡터를 기반으로 각도를 계산하여 캐릭터 스프라이트를 회전
- `OnAim`: 입력 이벤트에 의해 트리거, 캐릭터의 월드 공간 내의 방향 조정.

## Buttons

### **CharacterChoiceButton.cs & CharacterButton.cs**

- 캐릭터 선택 메뉴와 플레이어의 캐릭터 선택 처리
- **`CharacterChoiceButton`**: 캐릭터 선택 UI 활성화
- **`CharacterButton`**: 선택된 캐릭터의 스프라이트를 변경하여 캐릭터 설정, 설정 후 메뉴 비활성화

### **JoinButton.cs**

- 플레이어가 이름과 캐릭터 타입 정보를 저장하고 씬 이동 관리
- **필드**:
    - `InputField inputName`: UI에서 플레이어가 입력한 이름 저장
    - `Image characterImage`: 선택된 캐릭터의 이미지를 담고 있으며 이를 통해 플레이어의 캐릭터 타입 결정
- **`Join()`**:
    - 플레이어가 "Join" 버튼을 클릭하면 호출
    - **플레이어 타입과 이름 저장**:
        - 캐릭터 타입과 플레이어의 이름을 각각 `PlayerPrefs.SetInt` 및 `PlayerPrefs.SetString`으로 저장
    - **씬 전환**:  `SceneManager.LoadScene("MainScene")` 으로 메인 씬 이동
- **`FindCharaterType()`**:
    - 스프라이트 파일 이름의 첫 번째 문자를 사용하여 캐릭터 타입 결정

---
