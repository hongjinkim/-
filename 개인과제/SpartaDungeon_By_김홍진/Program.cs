using System.Runtime.InteropServices;


namespace SpartaDungeon_By_김홍진
{
    //선택지 구조체. 번호와 내용을 저장
    public struct Option
    {
        public int Index;
        public string Text;
    }
    // 캐릭터 클래스
    public class Player
    {
        public int Level { get; set; }
        public string Name { get; }
        public string Class { get; }
        public int Strength_Default { get; }
        public int Strength { get; set; }
        public int Defence_Default { get; }
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public Item EquippedWeapon { get; set; }
        public Item EquippedArmor { get; set; }
        public List<Item> Inventory { get; set; }
        public Player(string name)
        {
            Level = 1;
            Name = name;
            Class = "전사";
            Strength_Default = 10;
            Strength = Strength_Default;
            Defence_Default = 5;
            Defence = Defence_Default;
            Health = 100;
            Gold = 1500;
            Inventory = new List<Item>();
        }
    }

    //장비 타입을 Weapon, Armor 두가지로 사용
    public enum ItemType
    {
        Weapon,
        Armor
    }
    // 장비 클래스
    public class Item
    {
        public string Name;
        public string Bio;
        public int Value = 0;
        public ItemType Type;
        public bool isEquipped;
        public int Price;
        public bool isAlreadyBuyed;
        public Item(string name, string bio, int value, ItemType type, int price)
        {
            Name = name;
            Bio = bio;
            Value = value;
            Type = type;
            isEquipped = false;
            Price = price;
            isAlreadyBuyed = false;
        }
    }

    // 게임 화면 출력 클래스
    public class Screen
    {
        private Player player;                           //플레이어 데이터
        private string Title;                               //현재 화면 제목
        private string Bio;                                //현재 화면 설명
        private List<Option> Options;             //선택지
        private string Content;                         //내용
        public Screen(Player player, string title, string bio,string content, List<Option> options)
        {
            this.player = player;
            this.Title = title;
            this.Bio = bio;
            this.Content = content;
            this.Options = options;
        }

        //순서에 맞게 출력
        public void Start()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Bio);
            Console.WriteLine(Content + "\n");
            foreach (Option option in Options)
            {
                Console.WriteLine($"{option.Index}. {option.Text}");
            }
        }
        //입력 받기
        public int GetInput()
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
                    Console.Write("잘못된 입력입니다.\n");   //숫자가 아닐경우 다시 입력받기
                }
            }
        }

    }

    // 메인 메서드
    class Program
    {
        static void Main(string[] args)
        {
            // 내 캐릭터 생성
            Player player = new Player("홍진");
            //상점에 판매할 상품을 List로 지정
            List<Item> Products = new List<Item>
            {
                new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, ItemType.Armor, 200),
                new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, ItemType.Armor, 500),
                new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, ItemType.Armor, 3500),
                new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, ItemType.Weapon, 600),
                new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다", 5, ItemType.Weapon, 1500),
                new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, ItemType.Weapon, 300)
            };

            // 초기 인벤토리 추가
            //player.Inventory = new List<Item>();
            //{
            //    new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 5, ItemType.Armor, 500),
            //    new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, ItemType.Armor, 800),
            //    new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, ItemType.Weapon, 200)
            //};
            //// 스파르타의 창과 낡은 검을 장착 상태로 시작
            //EquipItem(player, 1);
            //EquipItem(player, 2);

            // StartScreen으로 시작
            StartScreen(player);

        }
        // 각 화면을 표시하는 메써드
        // 시작화면
        public static void StartScreen(Player player)
        {
            List<Option> options = new List<Option>
            {
                new Option { Index = 1, Text = "상태 보기"},
                new Option { Index = 2, Text = "인벤토리"},
                new Option { Index = 3, Text = "상점"},
                new Option { Index = 4, Text = "던전입장"},
                new Option { Index = 5, Text = "휴식하기"}
            };
            Screen screen = new Screen(player, "", "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.", "", options);

            screen.Start();

            bool isCorrectInput = false;
            while(!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        StatusScreen(player);
                        isCorrectInput = true;
                        break;
                    case 2:
                        InventoryScreen(player);
                        isCorrectInput = true;
                        break;
                    case 3:
                        StoreScreen(player);
                        isCorrectInput = true;
                        break;
                    case 4:
                        DungeonScreen(player);
                        isCorrectInput = true;
                        break;
                    case 5:
                        RestScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }         
        }   
        // 상태 보기
        public static void StatusScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 0, Text = "나가기"},  
                            };

            int weaponValue;
            int armorValue;

            if(player.EquippedWeapon == null)
            {
                weaponValue = 0;
            }
            else
            {
                weaponValue = player.EquippedWeapon.Value;
            }
            if (player.EquippedArmor == null)
            {
                armorValue = 0;
            }
            else
            {
                armorValue = player.EquippedArmor.Value;
            }

            string content = $"Lv. {player.Level.ToString().PadLeft(2, '0')}\n" +
                                        $"{player.Name} ({player.Class})\n" +
                                        $"공격력 : {player.Strength_Default} (+{weaponValue})\n" +
                                        $"방어력 : {player.Defence_Default} (+{armorValue})\n" +
                                        $"체 력 : {player.Health}\n" +
                                        $"Gold : {player.Gold}\n";
            Screen screen = new Screen(player, "상태 보기", "캐릭터의 정보가 표시됩니다.", content, options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 0:
                        StartScreen(player);
                        break;  
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        // 장비 관리
        public static void InventoryScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 1, Text = "장착 관리"},
                                new Option { Index = 0, Text = "나가기"}
                            };
            string content = "[아이템 목록]\n";

            foreach(Item item in player.Inventory)
            {
                string EquipSign = "";
                string type = "";
                if(item.isEquipped)
                {
                    EquipSign = "[E]";
                }
                if(item.Type == ItemType.Weapon)
                {
                    type = "공격력";
                }
                else if (item.Type == ItemType.Armor)
                {
                    type = "방어력";
                }
                content += $" - {EquipSign}{item.Name} \t | {type} +{item.Value} | {item.Bio}\n";
            }

            Screen screen = new Screen(player, "인벤토리", "보유 중인 아이템을 관리할 수 있습니다.", content, options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        EquipScreen(player);
                        isCorrectInput = true;
                        break;  
                    case 0:
                        StartScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        // 장비 관리 - 장착
        public static void EquipScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 0, Text = "나가기"}
                            };
            string content = "[아이템 목록]\n";
            int idx = 1;
            foreach (Item item in player.Inventory)
            {
                string EquipSign = "";
                string type = "";
                if (item.isEquipped)
                {
                    EquipSign = "[E]";
                }
                if (item.Type == ItemType.Weapon)
                {
                    type = "공격력";
                }
                else if (item.Type == ItemType.Armor)
                {
                    type = "방어력";
                }
                content += $" - {idx} {EquipSign}{item.Name} \t\t | {type} +{item.Value} | {item.Bio}\n";
                idx++;
            }

            Screen screen = new Screen(player, "인벤토리 - 장착 관리", "보유 중인 아이템을 관리할 수 있습니다.", content, options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 0:
                        StartScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        isCorrectInput = EquipItem(player, input - 1);
                        EquipScreen(player);
                        break;
                }
            }
        }
        // 상점
        public static void StoreScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 1, Text = "아이템 구매"},
                                new Option { Index = 2, Text = "아이템 판매"},
                                new Option { Index = 0, Text = "나가기" }
                            };
            string content = "[아이템 목록]\n";
            foreach (Item item in Products)
            {
                string type = "";

                if (item.Type == ItemType.Weapon)
                {
                    type = "공격력";
                }
                else if (item.Type == ItemType.Armor)
                {
                    type = "방어력";
                }
                content += $" - {item.Name} \t | {type} +{item.Value} | {item.Bio} \t | ";
                if (item.isAlreadyBuyed)
                {
                    content += "구매완료\n";
                }
                else
                {
                    content += $"{item.Price} G\n";

                }
            }
                Screen screen = new Screen(player, "상점", $"필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n{player.Gold} G\n", content, options);
           
                screen.Start();

                bool isCorrectInput = false;
                while (!isCorrectInput)
                {
                    int input = screen.GetInput();
                    switch (input)
                    {
                        case 0:
                            StartScreen(player);
                            isCorrectInput = true;
                            break;
                        case 1:
                            BuyScreen(player);
                            isCorrectInput = true;
                            break;
                        case 2:
                            SellScreen(player);
                            isCorrectInput = true;
                            break;
                    default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                }
        }
        // 상점 - 구매
        public static void BuyScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 0, Text = "나가기" }
                            };
            string content = "[아이템 목록]\n";
            int idx = 1;
            foreach (Item item in Products)
            {
                string type = "";

                if (item.Type == ItemType.Weapon)
                {
                    type = "공격력";
                }
                else if (item.Type == ItemType.Armor)
                {
                    type = "방어력";
                }
                content += $" -{idx} {item.Name} \t | {type} +{item.Value} | {item.Bio} \t | ";
                if (item.isAlreadyBuyed)
                {
                    content += "구매완료\n";
                }
                else
                {
                    content += $"{item.Price} G\n";

                }
                idx++;
            }
            Screen screen = new Screen(player, "상점", $"필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n{player.Gold} G\n", content, options);
                

                screen.Start();

                bool isCorrectInput = false;
                while (!isCorrectInput)
                {
                    int input = screen.GetInput();
                    switch (input)
                    {
                        case 0:
                            StoreScreen(player);
                            isCorrectInput = true;
                            break;
                        default:
                            isCorrectInput = BuyItem(player, input - 1);
                            BuyScreen(player);
                            break;
                    }
                }

                bool BuyItem(Player player, int idx)
                {
                    if (idx < 0 || idx > Products.Count() - 1)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        return false;
                    }
                    if (Products[idx].isAlreadyBuyed)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                    }
                    else
                    {
                        if (player.Gold >= Products[idx].Price)
                        {
                            Products[idx].isAlreadyBuyed = true;
                            player.Gold -= Products[idx].Price;
                            player.Inventory.Add(Products[idx]);
                        }
                        else
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                        }
                    }
                    return true;
                }
        }
        // 상점 - 판매
        public static void SellScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 0, Text = "나가기" }
                            };
            string content = "[아이템 목록]\n";
            int idx = 1;
            foreach (Item item in player.Inventory)
            {
                string type = "";
                string EquipSign = "";
                if (item.isEquipped)
                {
                    EquipSign = "[E]";
                }
                if (item.Type == ItemType.Weapon)
                {
                    type = "공격력";
                }
                else if (item.Type == ItemType.Armor)
                {
                    type = "방어력";
                }
                content += $" -{idx} {EquipSign}{item.Name} \t | {type} +{item.Value} | {item.Bio} \t | {item.Price} G\n";
                idx++;
            }
            Screen screen = new Screen(player, "상점", $"필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n{player.Gold} G\n", content, options);


            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 0:
                        StoreScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        isCorrectInput = SellItem(player, input - 1);
                        SellScreen(player);
                        break;
                }
            }

            bool SellItem(Player player, int idx)
            {
                if (idx < 0 || idx > player.Inventory.Count() - 1)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return false;
                }
                if (player.Inventory[idx].isEquipped)
                {
                    EquipItem(player, idx);
                }
                player.Inventory[idx].isAlreadyBuyed = false;
                player.Gold += (int)(player.Inventory[idx].Price * 0.85f);
                player.Inventory.RemoveAt(idx);

                return true;
            }
        }
        // 던전 입장
        public static void DungeonScreen(Player player)
        {
            List<Tuple<string, int, int>> Dungeons = new List<Tuple<string, int, int>>
            {
                new Tuple<string, int, int>("쉬운 던전", 5, 1000),
                new Tuple<string, int, int>("일반 던전", 11, 1700),
                new Tuple<string, int, int>("어려운 던전", 17, 2500),
            };
            List<Option> options = new List<Option>
            {
                new Option { Index = 1, Text = $"{Dungeons[0].Item1}\t | 방어력 {Dungeons[0].Item2} 이상 권장"},
                new Option { Index = 2, Text = $"{Dungeons[1].Item1}\t | 방어력 {Dungeons[1].Item2} 이상 권장"},
                new Option { Index = 3, Text = $"{Dungeons[2].Item1}\t | 방어력 {Dungeons[2].Item2} 이상 권장"},
                new Option { Index = 0, Text = "나가기"}
            };

            Screen screen = new Screen(player, "던전입장", "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.", "", options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        DungeonClearScreen(player, Dungeons[0]);
                        isCorrectInput = true;
                        break;
                    case 2:
                        DungeonClearScreen(player, Dungeons[1]);
                        isCorrectInput = true;
                        break;
                    case 3:
                        DungeonClearScreen(player, Dungeons[2]);
                        isCorrectInput = true;
                        break;
                    case 0:
                        StartScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        // 던전 결과 (클리어, 실패)
        public static void DungeonClearScreen(Player player, Tuple<string, int, int> Dungeon)
        {
            List<Option> options = new List<Option>
            {
                new Option { Index = 0, Text = "나가기"}
            };
            Screen screen;
            string content = "";
            if (isCleared(Dungeon.Item2))
            {
                Random random = new Random();
                int bonus = random.Next(player.Strength, player.Strength * 2);
                int prize = Dungeon.Item3 + Dungeon.Item3 / 100 * bonus;
                int healthLost = random.Next(20+(Dungeon.Item2-player.Defence), 35+ (Dungeon.Item2 - player.Defence));
                content = "[탐험결과]\n" +
                                $"체력 {player.Health} -> {player.Health -= healthLost}\n" +
                                $"Gold {player.Gold} -> {player.Gold += prize}\n";
                screen = new Screen(player, "던전 클리어", $"축하합니다!!\n{Dungeon.Item1}을 클리어 하였습니다", content, options);
            }
            else
            {
                content = "[탐험결과]\n" +
                                $"체력 {player.Health} -> {player.Health /= 2}";
                screen = new Screen(player, "던전 실패", $"아쉽습니다...\n{Dungeon.Item1}클리어에 실패 하였습니다", content, options);
            }
            

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                { 
                    case 0:
                        StartScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
            bool isCleared(int difficulty)
            {
                if(player.Defence < difficulty)
                {
                    Random random = new Random();
                    int rnum = random.Next(100);
                    if(rnum < 40)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        // 휴식하기
        public static void RestScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 1, Text = "휴식하기" },
                                new Option { Index = 0, Text = "나가기" }
                            };
           
            Screen screen = new Screen(player, "휴식하기", $"500 G 를 내면 체력을 회복할 수 있습니다.\t ([보유 골드] : {player.Gold} G)\n","", options);


            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        isCorrectInput = Rest();
                        RestScreen(player);
                        break;
                    case 0:
                        StartScreen(player);
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;       
                }
            }
            bool Rest()
            {
                if(player.Gold < 500)
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                    return false;
                }
                else
                {
                    player.Gold -= 500;
                    player.Health = 100;
                    Console.WriteLine("휴식을 완료했습니다.");
                    return true;
                }
            }

           
        }
        // player.Inventory 내에서 idx번째 아이템을 장착하거나 해제
        public static bool EquipItem(Player player, int idx)
        {
            if (idx < 0 || idx >= player.Inventory.Count())
            {
                Console.WriteLine("잘못된 입력입니다.");
                return false;
            }
            ItemType type = player.Inventory[idx].Type;
            if (player.Inventory[idx].isEquipped) // 장착중이라면 해제
            {
                player.Inventory[idx].isEquipped = false;
                if (type == ItemType.Weapon)
                {
                    player.EquippedWeapon = null;
                }
                else if (type == ItemType.Armor)
                {
                    player.EquippedArmor = null;
                }
            }
            else                        // 해제중이라면 장착
            {
                if (type == ItemType.Weapon)
                {
                    player.EquippedWeapon = player.Inventory[idx];
                    foreach (Item item in player.Inventory)
                    {
                        if (item.isEquipped && item.Type == ItemType.Weapon)
                        {
                            item.isEquipped = false;
                        }
                    }
                }
                else if (type == ItemType.Armor)
                {
                    player.EquippedArmor = player.Inventory[idx];
                    foreach (Item item in player.Inventory)
                    {
                        if (item.isEquipped && item.Type == ItemType.Armor)
                        {
                            item.isEquipped = false;
                        }
                    }
                }
                player.Inventory[idx].isEquipped = true;
            }
            if (player.EquippedWeapon == null)
            {
                player.Strength = player.Strength_Default;
            }
            else
            {
                player.Strength = player.Strength_Default + player.EquippedWeapon.Value;
            }
            if (player.EquippedArmor == null)
            {
                player.Defence = player.Strength_Default;
            }
            else
            {
                player.Defence = player.Strength_Default + player.EquippedArmor.Value;
            }

            return true;
        }
    }
}