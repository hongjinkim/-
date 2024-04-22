
namespace SpartaDungeon_By_김홍진
{
    internal class GameManager
    {
        //구조체, 열거형
        public struct Option
        {
            public uint optionNum;
            public string optionText;
        }
        public enum ItemType
        {
            Weapon,
            Armor
        }
        // Screen Class
        public class Screen()
        {

            public string screenTitle;
            public string screenBio;
            public List<Option> screenOptions;
        }
       
        public static Screen startScreen;
        public static Screen statusScreen;
        public static Screen inventoryScreen;
        public static Screen inventory_equipScreen;
        public static Screen shopScreen;
        public static Screen shop_buyScreen;
        public static Screen shop_sellScreen;
        //public static Screen dungeonScreen;
        //public static Screen restScreen;
        //public static Screen dungeon_clearScreen;

        // Info
        public class Player
        {
            public uint playerLevel;
            public string playerName;
            public string playerClass;
            public uint playerSTR;
            public uint playerDEF;
            public uint playerHP;
            public uint playerGold;  
        }
        public static Player playerInfo;
        public class Item
        {
            bool isEquipped;
            string itemName;
            ItemType itemType;
            uint itemValue;
            string itemInfo;
            bool isOnSale;
            public Item InitItem(string name, ItemType type, uint value, string info)
            {
                Item item = new Item();
                item.isEquipped = false;
                item.itemName = name;
                item.itemType = type;
                item.itemValue = value;
                item.itemInfo = info;
                item.isOnSale = true;

                return item;
            }
        }

        //메인함수
        static void Main(string[] args)
        {
            Init();
            OnStartScreen();
        }
        //게임 시작 시 정보 초기화
        static void Init()
        {
            playerInfo = InitPlayer("홍진");
            startScreen = InitScreen("게임 시작 화면",
                                                    "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n",
                                                    new List<Option>
                                                            {
                                                                new Option { optionNum = 1, optionText = "상태 보기"},
                                                                new Option { optionNum = 2, optionText = "인벤토리"},
                                                                new Option { optionNum = 3, optionText = "상점"},
                                                                new Option { optionNum = 4, optionText = "던전입장"},
                                                                new Option { optionNum = 5, optionText = "휴식하기"}
                                                            }
                                                    );
            statusScreen = InitScreen("상태 보기",
                                                    "캐릭터의 정보가 표시됩니다.\n",
                                                    new List<Option>
                                                            {
                                                                new Option { optionNum = 0, optionText = "나가기"},
                                                            }
                                                    );
            inventoryScreen = InitScreen("인벤토리",
                                                    "보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n",
                                                    new List<Option>
                                                            {
                                                                new Option { optionNum = 1, optionText = "장착 관리"},
                                                                new Option { optionNum = 0, optionText = "나가기"}
                                                            }
                                                    );
            inventory_equipScreen = InitScreen("인벤토리 - 장착 관리",
                                                    "보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n",
                                                    new List<Option>
                                                            {
                                                                new Option { optionNum = 0, optionText = "나가기"}
                                                            }
                                                    );
            shopScreen = InitScreen("상점",
                                                    "필요한 아이템을 얻을 수 있는 상점입니다.\n\n[아이템 목록]\n",
                                                    new List<Option>
                                                            {
                                                                new Option { optionNum = 1, optionText = "아이템 구매"},
                                                                new Option { optionNum = 2, optionText = "아이템 판매"},
                                                                new Option { optionNum = 0, optionText = "나가기"}
                                                            }
                                                    );
            shop_buyScreen = InitScreen("상점 - 아이템 구매",
                                                   "필요한 아이템을 얻을 수 있는 상점입니다.\n\n[아이템 목록]\n",
                                                   new List<Option>
                                                           {
                                                                new Option { optionNum = 0, optionText = "나가기"}
                                                           }
                                                   );
            shop_sellScreen = InitScreen("상점 - 아이템 판매",
                                                    "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n",
                                                    new List<Option>
                                                            {
                                                                new Option { optionNum = 0, optionText = "나가기"}
                                                            }
                                                    );
            //dungeonScreen = InitScreen("던전입장",
            //                                        "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n",
            //                                        new List<Option>
            //                                                {
            //                                                    new Option { optionNum = 1, optionText = "쉬운 던전"},
            //                                                    new Option { optionNum = 2, optionText = "일반 던전"},
            //                                                    new Option { optionNum = 3, optionText = "어려운 던전"},
            //                                                    new Option { optionNum = 0, optionText = "나가기"}
            //                                                }
            //                                        );
            //dungeon_clearScreen = InitScreen("던전 클리어\n",
            //                                        "축하합니다!!\n쉬운 던전을 클리어 하였습니다.\n",
            //                                        new List<Option>
            //                                                {
            //                                                    new Option { optionNum = 1, optionText = "쉬운 던전"},
            //                                                    new Option { optionNum = 2, optionText = "일반 던전"},
            //                                                    new Option { optionNum = 3, optionText = "어려운 던전"},
            //                                                    new Option { optionNum = 0, optionText = "나가기"}
            //                                                }
            //                                        );
            //restScreen = InitScreen("휴식하기",
            //                                        "500 G 를 내면 체력을 회복할 수 있습니다.",
            //                                        new List<Option>
            //                                                {
            //                                                    new Option { optionNum = 1, optionText = "휴식하기"},
            //                                                    new Option { optionNum = 0, optionText = "나가기"}
            //                                                }
            //                                        );
        }
        //각 화면 정보 초기화
        public static Screen InitScreen(string title, string bio, List<Option> options)
        {
            Screen screen = new Screen();
            screen.screenTitle = title;
            screen.screenBio = bio;
            screen.screenOptions = options;
            return screen;
        }
        public static Player InitPlayer(string name)
        {
            Player player = new Player();
            player.playerLevel = 1;
            player.playerName = name;
            player.playerClass = "전사";
            player.playerSTR = 10;
            player.playerDEF = 5;
            player.playerHP = 100;
            player.playerGold = 1500;

            return player;
        }
        public static void OnStartScreen()
        {
            bool isValid = true;
            while (isValid)
            {
                switch (ScreenOutput(startScreen, null))
                {
                    case 1:
                        isValid = false;
                        OnStatusScreen();
                        break;
                    case 2:
                        isValid = false;
                        OnInventoryScreen();
                        break;
                    case 3:
                        isValid = false;
                        OnShopScreen();
                        break;
                    case 4:
                        isValid = false;
                        //OnDungeonScreen();
                        break;
                    case 5:
                        isValid = false;
                        //OnRestScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        static void OnStatusScreen()
        {
            bool isValid = true;
            string content;
            content = "Lv. " + playerInfo.playerLevel.ToString().PadLeft(2, '0') + "\n"
                          + playerInfo.playerName + "(" + playerInfo.playerClass + ")" + "\n"
                          + "공격력 : " + playerInfo.playerSTR + "\n"
                          + "방어력 : " + playerInfo.playerDEF + "\n"
                          + "체 력 : " + playerInfo.playerHP + "\n"
                          + "Gold : " + playerInfo.playerGold + "\n"
                          + "\n";
            while (isValid)
            {
                switch (ScreenOutput(statusScreen, content))
                {
                    case 0:
                        isValid = false;
                        OnStartScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        static void OnInventoryScreen()
         {
            bool isValid = true;
            while (isValid)
            {
                switch (ScreenOutput(inventoryScreen, null))
                {
                    case 1:
                        isValid = false;
                        OnInventoryEquipScreen();
                        break;
                    case 0:
                        isValid = false;
                        OnStartScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        static void OnInventoryEquipScreen()
        {
            bool isValid = true;
            while (isValid)
            {
                switch (ScreenOutput(inventory_equipScreen, null))
                {
                    case 0:
                        isValid = false;
                        OnInventoryScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        static void OnShopScreen()
        {
            bool isValid = true;
            while (isValid)
            {
                switch (ScreenOutput(shopScreen, null))
                {
                    case 1:
                        isValid = false;
                        OnShopBuyScreen();
                        break;
                    case 2:
                        isValid = false;
                        OnShopSellScreen();
                        break;
                    case 0:
                        isValid = false;
                        OnStartScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        static void OnShopBuyScreen()
         {
            bool isValid = true;
            while (isValid)
            {
                switch (ScreenOutput(shop_buyScreen, null))
                {
                    case 0:
                        isValid = false;
                        OnShopScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        static void OnShopSellScreen()
        {
            bool isValid = true;
            while (isValid)
            {
                switch (ScreenOutput(shop_sellScreen, null))
                {
                    case 0:
                        isValid = false;
                        OnShopScreen();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 숫자입니다.");
                        break;
                }
            }
        }
        //static void OnDungeonScreen()
        //    {

        //    }
        //static void OnRestScreen()
        //    {

        //    }
        //static void OnDungeonClearScreen()
        //    {

        //    }
        static int ScreenOutput(Screen screen, string content)
        {
            PrintTitleAndBio(screen);

            //추가 정보 표시
            if(content != null)
            {
                Console.Write(content + "\n");
            }

            PrintOptions(screen);
            return GetInput();
        }
        static int GetInput()
            {
                Console.Write("\n");
                int myInt;
                bool isValid;
                while (true)
                {
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    string input = Console.ReadLine();
                    isValid = int.TryParse(input, out myInt);   //입력값이 숫자인지 판단
                    if (isValid)
                    {
                        return myInt;                                        //숫자를 입력받으면 int로 반환
                    }
                    else
                    {
                        Console.Write("숫자를 입력해주세요.\n");   //숫자가 아닐경우 다시 입력받기
                    }
                }
            }
        
        static void PrintTitleAndBio(Screen screen)
        {
            Console.Write("///////////////////////////////////////////////////////////////////\n");
            Console.Write(screen.screenTitle + "\n");
            Console.Write(screen.screenBio + "\n");
        }
        static void PrintOptions(Screen screen)
        {
            foreach (Option option in screen.screenOptions)
            {
                Console.Write(option.optionNum + ". ");
                Console.Write(option.optionText + "\n");
            }
        }
    }
}
