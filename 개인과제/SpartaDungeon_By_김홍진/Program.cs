using System.Runtime.InteropServices;

namespace SpartaDungeon_By_김홍진
{
    public struct Option
    {
        public int Index;
        public string Text;
    }
    public class Player
    {
        public int Level { get; set; }
        public string Name { get; }
        public string Class { get;  }
        public int Strength { get; set;  }
        public int Defence { get; set;  }
        public int Health { get; set; }
        public int Gold { get; set; }
        public Item EquippedWeapon { get; set; }
        public Item EquippedArmor { get; set; }
        public List<Item> Inventory { get; set;  }
        public Player(string name)
        {
            Level = 1;
            Name = name;
            Class = "전사";
            Strength = 10;
            Defence = 5;
            Health = 100;
            Gold = 1500;
            Inventory = new List<Item>();
        }
    }

    // 아이템 인터페이스 정의
    //public class Item
    //{
    //    string Name { get; set; }
    //    string Bio { get; set; }
    //    string Status { get; set; }
    //    int Value { get; set;  }
    //}

    // 장비 클래스
    public enum ItemType
    {
        Weapon,
        Armor
    }
    public class Item
    {
        public string Name;
        public string Bio;
        public int Value = 0;
        public ItemType Type;
        public bool isEquipped;
        public Item(string name, string bio, int value, ItemType type)
        {
            Name = name;
            Bio = bio;
            Value = value;
            Type = type;
            isEquipped = false;
        }
    }

    public class Screen
    {
        private Player player;
        private string Title;
        private string Bio;
        private List<Option> Options;
        private string Content;
        public Screen(Player player, string title, string bio,string content, List<Option> options)
        {
            this.player = player;
            this.Title = title;
            this.Bio = bio;
            this.Content = content;
            this.Options = options;
        }

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
            Player player = new Player("홍진");

            // 초기 인벤토리 추가
            player.Inventory = new List<Item>
            {
                new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 5, ItemType.Armor),
                new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, ItemType.Armor),
                new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, ItemType.Weapon)
            };
            // 스파르타의 창과 낡은 검을 장착 상태로 시작
            EquipItem(player,1);
            EquipItem(player, 2);

            // StartScreen으로 시작
            StartScreen(player);

        }
        public static void StartScreen(Player player)
        {
            List<Option> options = new List<Option>
            {
                new Option { Index = 1, Text = "상태 보기"},
                new Option { Index = 2, Text = "인벤토리"},
                new Option { Index = 3, Text = "상점"}
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
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }         
        }
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
                                        $"공격력 : {player.Strength} (+{weaponValue})\n" +
                                        $"방어력 : {player.Defence} (+{armorValue})\n" +
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
                content += $" - {EquipSign}{item.Name} \t\t | {type} +{item.Value} | {item.Bio}\n";
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
        public static void EquipScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 1, Text = "상태 보기"},
                                new Option { Index = 2, Text = "인벤토리"},
                                new Option { Index = 3, Text = "상점"}
                            };
            Screen screen = new Screen(player, "", "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.", "", options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        StatusScreen(player);
                        isCorrectInput = true;
                        break;
                    case 2:
                        isCorrectInput = true;
                        break;
                    case 3:
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        public static void StoreScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 1, Text = "상태 보기"},
                                new Option { Index = 2, Text = "인벤토리"},
                                new Option { Index = 3, Text = "상점"}
                            };
            Screen screen = new Screen(player, "", "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.", "", options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        StatusScreen(player);
                        isCorrectInput = true;
                        break;
                    case 2:
                        isCorrectInput = true;
                        break;
                    case 3:
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
        public static void BuyScreen(Player player)
        {
            List<Option> options = new List<Option>
                            {
                                new Option { Index = 1, Text = "상태 보기"},
                                new Option { Index = 2, Text = "인벤토리"},
                                new Option { Index = 3, Text = "상점"}
                            };
            Screen screen = new Screen(player, "", "스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.", "", options);

            screen.Start();

            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                int input = screen.GetInput();
                switch (input)
                {
                    case 1:
                        StatusScreen(player);
                        isCorrectInput = true;
                        break;
                    case 2:
                        isCorrectInput = true;
                        break;
                    case 3:
                        isCorrectInput = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        // player.Inventory 내에서 idx번째 아이템을 장착하거나 해제
        public static void EquipItem(Player player, int idx)
        {
            if (idx < 0 || idx >= player.Inventory.Count())
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
            ItemType type = player.Inventory[idx].Type;
            if (player.Inventory[idx].isEquipped) // 장착중이라면 해제
            {
                player.Inventory[idx].isEquipped = false;
                if(type == ItemType.Weapon)
                {
                    player.EquippedWeapon = null;
                }
                else if(type == ItemType.Armor)
                {
                    player.EquippedArmor = null;
                }
            }
            else                        // 해제중이라면 장착
            {
                player.Inventory[idx].isEquipped = true;
                if (type == ItemType.Weapon)
                {
                    player.EquippedWeapon = player.Inventory[idx];
                }
                else if (type == ItemType.Armor)
                {
                    player.EquippedArmor = player.Inventory[idx];
                }
            }
        }
    }
}