![cover](https://github.com/hongjinkim/TIL/blob/main/cover.png)
# TIL
## 2024.04.15 내일배움캠프 첫날
    오늘은 스파르타내일배움캠프의 첫날입니다.
    매일 배운 내용과 진행한 일들을 오늘부터 기록할 예정입니다.
    캠프 합류 전 공부해온 내용을 바탕으로 아주 간단한 미니프로젝트를 진행하게 되었습니다.
    첫 프로젝트 주제는 우리 팀, 우리만의 이야기를 담을 수 있는 ”팀원 소개 카드게임”으로, 사전에 학습한 게임개발종합반 4주차 내용을 참고하여, 우리 팀원 매칭 카드게임을 만들게 되었습니다.
    팀원들과 각자의 역할을 분담하여 오늘 저는

    * 결과에 매칭 시도 횟수 표시
    * 결과에 점수 표시 → 남은 시간, 매칭 시도한 횟수 등을 점수로 환산
    * 카드 오브젝트 개수 늘리기

    위의 기능을 구현 하였습니다.
#### 미니프로젝트 1일차 https://velog.io/@ghdwls4654/2024.04.15

## 2024.04.16
    어제에 이어서 미니프로젝트를 진행하였습니다. 서로 작성한 코드를 리뷰하는 시간을 가졌고, 추가적으로 기능들을 구현하였습니다.

    * 현재 스테이지(또는 난도)에 따라 카드 배열 증가시켜보기
    * 스테이지 선택 가능한 시작 화면 만들기
    * 플레이 중 해당 스테이지의 최단 기록 띄워주기
    * 조건에 맞게 시작 불가능 스테이지와 해금한 스테이지를 구분

#### 미니프로젝트 2일차 https://velog.io/@ghdwls4654/2024.04.16

## 2024.04.17
    git 사용 특강이 있었습니다. 이전에 진행해본 프로젝트들은 거의 3인 이하의 소수나 때로는 혼자 개발을 진행하여 충돌이 일어날 일이 많지 않았지만, 이번에 5인이라는 인원이 작은 프로젝트를 진행하면서 충돌이 자주 일어나게 됬습니다. 그래서 이번 특강을 계기로 git을 사용해야 하는지 더 탐구해보았습니다.

    프로젝트 제작 마무리 단계를 진행하였습니다. 최종 병합한 결과물을 바탕으로 테스트를 진행하여 버그와 개선사항을 취합, 수정하였습니다.

#### 미니프로젝트 3일차 https://velog.io/@ghdwls4654/2024.04.17

## 2024.04.18
    미니프로젝트의 발표를 준비하면서 마무리 지었습니다. 남은 시간을 이용하여 앞으로 있을 취업 면접 대비를 위한 컴퓨터 사이언스 공부를 시작하였습니다.
#### https://www.inflearn.com/course/%ED%98%BC%EC%9E%90-%EA%B3%B5%EB%B6%80%ED%95%98%EB%8A%94-%EC%BB%B4%ED%93%A8%ED%84%B0%EA%B5%AC%EC%A1%B0-%EC%9A%B4%EC%98%81%EC%B2%B4%EC%A0%9C/dashboard
* 컴퓨터 사이언스
    * [데이터](https://github.com/hongjinkim/TIL/blob/main/%EC%BB%B4%ED%93%A8%ED%84%B0%EA%B5%AC%EC%A1%B0%20%2B%20%EC%9A%B4%EC%98%81%EC%B2%B4%EC%A0%9C/%EB%8D%B0%EC%9D%B4%ED%84%B0.md)
    * [명령어](https://github.com/hongjinkim/TIL/blob/main/%EC%BB%B4%ED%93%A8%ED%84%B0%EA%B5%AC%EC%A1%B0%20%2B%20%EC%9A%B4%EC%98%81%EC%B2%B4%EC%A0%9C/%EB%AA%85%EB%A0%B9%EC%96%B4.md)
    * [CPU의 작동 원리](https://github.com/hongjinkim/TIL/blob/main/%EC%BB%B4%ED%93%A8%ED%84%B0%EA%B5%AC%EC%A1%B0%20%2B%20%EC%9A%B4%EC%98%81%EC%B2%B4%EC%A0%9C/CPU%EC%9D%98%20%EC%9E%91%EB%8F%99%20%EC%9B%90%EB%A6%AC.md)

## 2024.04.19
    미니프로젝트의 발표를 진행하였습니다. 같은 주제를 여러팀들이 각자 어떤식으로 진행하였고 코드는 어떤식으로 구현하였는지를 보면서 비교하는 시간을 가졌습니다.
    이후 다음과 같은 피드백을 받았습니다.

    - 레벨링 시스템, 애니메이션, 카운트다운, 시도횟수 등 추가 기능/UI 구현 good
    - 다양한 비주얼/사운드 이펙트 구현 good- 연출/기획적인 부분을 잘 구현해 낸 점이 좋습니다.
    -  시작 전 카운트다운, 맵 세팅, 해금 기능의 조건 등- 로직 내 디테일한 부분에 어필할 부분이 있는 프로젝트입니다.
    - 프로젝트에 알맞는 보조 도구를 찾아보세요. (와이어프레임, 데이터 플로우 차트, UML 등)- 구현에 사용했던 핵심 내용을 설명에 추가해주시면 좋을 것 같습니다. (레벨링에 따른 카드 재배치 etc)
    - A를 '어떻게' 구현했다. 구성으로 생각해보면 도움이 될 것 같습니다!- 문제 해결(트러블 슈팅)에 대한 내용이 구체적으로 들어가면 좋겠습니다. (구현부분) (문제 - 해결 - 도출) 구성으로 정리해보세요!

    마지막으로 이번에 프로젝트를 진행하며 있었던 일들을 회고하면서 KPT를 진행하였습니다.

    [Keep]
    - Git만 사용하기 말고도 팀원들과 소통하며 Merge 해나가기
    - 정기적인 코드 리뷰 시행
    - 와이어 프레임 제작(기획의 중요성)
    - 우리 팀 약속 지키기
    - 적극적인 소통

    [Problem]
    - Git Flow 지식 부족으로 인한 오류 발생
    - 씬, 기능 등의 역할 분담 조정 미
    - 세밀한 기획의 부재
    - 시간 및 일정 관리
    - 스크립트 분류

    [Try]
    - Git Convention 정하기
    - FlowChart 만들어 순서 정리해보기
    - UML 작성해보기
    - 코드 작성 규칙 만들기
    - 와이어 프레임을 좀 더 구체적으로 작성하기

    이번 경험을 바탕으로 다음에는 더 좋은 결과를 만들 수 있을 것 같습니다.
## 2024.04.22
    내일배움캠프의 2주차는 기초 프로그래밍 교육 주차 입니다. Unity 게임 개발을 진행하기 전 기초적인 c# 공부를 통해 기초를 다지는 기간입니다.

    C# 문법 종합반 1주차 강의를 수강하고, 배운내용을 바탕으로 과제 풀이를 하였습니다.

### 1-1 사용자로부터 입력 받기

이름과 나이를 입력 받고 출력하는 코드를 작성하세요.

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/87dea54c-4143-4c35-9f90-2be02b020229/Untitled.png)

    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("이름을 입력하세요: ");
            string userName = Console.ReadLine();

            Console.Write("나이를 입력하세요: ");
            string userAge = Console.ReadLine();

            Console.WriteLine("안녕하세요, " + userName + "! 당신은 " + userAge + " 세 이군요.");
        }
    }

### 1-2 간단한 사칙연산 계산기 만들기

두 수를 입력 받고 사칙연산의 결과를 출력하세요.

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/f3d35730-46a4-4ce9-8484-a31562ff8178/Untitled.png)

    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("첫번째 수를 입력하세요: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("두번째 수를 입력하세요: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("더하기: " + (num1 + num2));
            Console.WriteLine("빼기: " + (num1 - num2));
            Console.WriteLine("곱하기: " + (num1 * num2));
            Console.WriteLine("나누기: " + ((float)num1 / num2));
        }
    }

### 1-3 **온도 변환기 만들기**

사용자로부터 섭씨온도를 입력받아, 화씨온도로 변환하는 프로그램을 만들어봅시다. 

공식은 **`화씨 = (섭씨 * 9/5) + 32`** 입니다.

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/81cc0630-c382-4cbc-a1a9-73b2b0c5ae9d/Untitled.png)

    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("섭씨 온도를 입력하세요: ");
            float celsius = float.Parse(Console.ReadLine());

            float fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine("변환된 화씨 온도: " + fahrenheit);
        }
    }

### 1-4 BMI 계산기 만들기

사용자로부터 키(m)와 체중(kg)를 입력받아, BMI 지수를 계산하는 프로그램을 만들어봅시다. 공식은 **`BMI = 체중(kg) / 키(m)^2`** 입니다.

    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("체중(kg)를 입력하세요: ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("키(m)를 입력하세요: ");
            float height = float.Parse(Console.ReadLine());

            float bmi = weight / (height * height);
            Console.WriteLine("당신의 BMI: " + bmi);
        }
    }

개인과제의 class 구조를 작성하였습니다.
<details>
<summary>오늘 커밋한 코드</summary>
<div markdown="1">

[프로그래밍 기초 개인과제 스파르타 던전 만들기](https://github.com/hongjinkim/TIL/commit/4c136932620d24cab35e7df97a063c393b3b4029)

</div>
</details>

*개인 과제
* [스파르타 던전](https://github.com/hongjinkim/TIL/tree/4c136932620d24cab35e7df97a063c393b3b4029/%EA%B0%9C%EC%9D%B8%EA%B3%BC%EC%A0%9C/SpartaDungeon_By_%EA%B9%80%ED%99%8D%EC%A7%84)



