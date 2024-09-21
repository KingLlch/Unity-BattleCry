using System.Collections.Generic;
using UnityEngine;

public class MissionBase
{
    public int CampaignNumber;
    public int MissionNumber;
    public string Name;
    public string Description;
    public Sprite Sprite;

    public int Gold;

    public bool Completed;
}

public class MissionArmy
{
    public Army Army;
}

public class Mission
{
    public MissionBase MissionBase;
    public MissionArmy MissionArmy;

    public Mission(int campaignNumber, int missionNumber, string name, string spritePath, Army army, string description = "", int gold = 1000)
    {
        MissionBase = new MissionBase()
        {
            CampaignNumber = campaignNumber,
            MissionNumber = missionNumber,
            Name = name,
            Description = description,
            Sprite = Resources.Load<Sprite>(spritePath),
            Gold = gold
        };

        MissionArmy = new MissionArmy()
        {
            Army = army
        };
    }
}

public static class MissionList
{
    public static bool IsMissionsAdded = false;

    public static List<Mission> AllMission = new List<Mission>();
}


public class MissionManager : MonoBehaviour
{
    private void Awake()
    {

    }

    private void Start()
    {
        if (!MissionList.IsMissionsAdded)
        {
            AddMission();
            MissionList.IsMissionsAdded = true;
        }
    }

    private void AddMission()
    {
        MissionList.AllMission.Add(new Mission(0, 0, "Шайка гоблинов", "Sprites/Missions/Mission1", AllEnemyArmy.EnemyArmy[0], "Небольшой отряд гоблинов грабил поселения неподалёку. Командир, это ваш шанс проявить себя. Уничтожьте этих мерзавцев!"));
        MissionList.AllMission.Add(new Mission(0, 1, "Отряд гоблинов", "Sprites/Missions/Mission1", new Army(), "Отряд гоблинов взял в плен группу лучников. Нужно спасти наших и отправить на тот свет этих зелёных мерзавцев!"));
        MissionList.AllMission.Add(new Mission(0, 2, "Лучники гоблинов", "Sprites/Missions/Mission2", new Army(), "Часть армии гоблинов отделилась от основной группы для того чтобы ограбить наши поля. В их составе есть лучники. Нужно показать им что не стоит нападать на наших крестьян!"));
        MissionList.AllMission.Add(new Mission(0, 3, "Армия гоблинов", "Sprites/Missions/Mission2", new Army(), "Командир, мы собрали достаточно воинов чтобы сокрушить армию гоблинов вторгнувшуяся к нам. Давайте сокрушим этих мерзавцев!"));
        MissionList.AllMission.Add(new Mission(0, 4, "Король гоблинов", "Sprites/Missions/Mission3", new Army(), "Командир, король гоблинов собрал все остатки своих войск и осадил наш город, мы должны спасти жителей. Покончим с ним раз и навсегда!"));
        MissionList.AllMission.Add(new Mission(0, 5, "Неожиданный союз", "Sprites/Missions/Mission4", new Army(), "После поражения король гоблинов поклялся в верности вожаку орков в замен на его помощь в войне, теперь у них есть отряды орков на поле боя. Это им не поможет одержать победу над нами!"));
        MissionList.AllMission.Add(new Mission(0, 6, "Орочье подкрепление", "Sprites/Missions/Mission4", new Army(), "Значительный отряд орков подошел к нашему лагерю, похоже орки хотят провести время как им больше всего нравится - в битве. Но победа будет за тем кто защищает простой народ, командир!"));
        MissionList.AllMission.Add(new Mission(0, 7, "Войско орков", "Sprites/Missions/Mission5", new Army(), "А вот и основные силы пехоты орков, это будет непросто, но мы справимся!"));
        MissionList.AllMission.Add(new Mission(0, 8, "Тролли", "Sprites/Missions/Mission6", new Army(), ""));
        MissionList.AllMission.Add(new Mission(0, 9, "Огр", "Sprites/Missions/Mission6", new Army(), ""));
        MissionList.AllMission.Add(new Mission(0, 10, "Красные орки", "Sprites/Missions/Mission7", new Army(), ""));
        MissionList.AllMission.Add(new Mission(0, 11, "Вождь ОРДЫ", "Sprites/Missions/Mission17", new Army(), ""));

        MissionList.AllMission.Add(new Mission(1, 0, "Группа скавенов", "Sprites/Missions/Mission1", new Army(), "Небольшая группа скавенов-рабов атаковала наши западные границы. Командир покажем этим крысам, как нападать в спину!"));
        MissionList.AllMission.Add(new Mission(1, 1, "Войско скавенов", "Sprites/Missions/Mission2", new Army(), "Целая армия скавенов-рабов собралась у стен города. Нужно уничтожить их пока они не начали рыть подкоп для его взятия!"));
        MissionList.AllMission.Add(new Mission(1, 2, "Пращеметатели", "Sprites/Missions/Mission3", new Army(), "Скавены решили использовать дальнобойное оружие. Эти пращеметатели не сравнятся ни с нашими воинами ни с нашими лучниками!"));
        MissionList.AllMission.Add(new Mission(1, 3, "Кланокрысы", "Sprites/Missions/Mission4", new Army(), "Костяк армии скавенов - кланокрысы, и их тут целое войско! Нужно разгромить основные войска скавенов!"));
        MissionList.AllMission.Add(new Mission(1, 4, "Штормокрысы", "Sprites/Missions/Mission5", new Army(), "Скавены решили пустить в бой элиту сових войск - штормокрыс. Это им не поможет!"));
        MissionList.AllMission.Add(new Mission(1, 5, "Черные скавены", "Sprites/Missions/Mission6", new Army(), ""));
        MissionList.AllMission.Add(new Mission(1, 6, "Войско черных скавенов", "Sprites/Missions/Mission7", new Army(), ""));
        MissionList.AllMission.Add(new Mission(1, 7, "Вождь клана", "Sprites/Missions/Mission7", new Army(), ""));
        MissionList.AllMission.Add(new Mission(1, 8, "Белые скавены", "Sprites/Missions/Mission7", new Army(), ""));
        MissionList.AllMission.Add(new Mission(1, 9, "Элита белых скавенов", "Sprites/Missions/Mission7", new Army(), ""));
        MissionList.AllMission.Add(new Mission(1, 10, "Император скавенов", "Sprites/Missions/Mission7", new Army(), ""));

        MissionList.AllMission.Add(new Mission(2, 0, "Живые деревья", "Sprites/Missions/Mission1", new Army(), ""));
        MissionList.AllMission.Add(new Mission(2, 1, "Войско Дриад", "Sprites/Missions/Mission2", new Army(), ""));
        MissionList.AllMission.Add(new Mission(2, 2, "Стражи леса", "Sprites/Missions/Mission3", new Army(), ""));
        MissionList.AllMission.Add(new Mission(2, 3, "Древолюды", "Sprites/Missions/Mission4", new Army(), ""));
        MissionList.AllMission.Add(new Mission(2, 4, "Каменные дубы", "Sprites/Missions/Mission5", new Army(), ""));
        MissionList.AllMission.Add(new Mission(2, 5, "Железные деревья", "Sprites/Missions/Mission6", new Army(), ""));
        MissionList.AllMission.Add(new Mission(2, 6, "Древнейший дуб", "Sprites/Missions/Mission7", new Army(), ""));

        MissionList.AllMission.Add(new Mission(3, 0, "Восставшие из мертвых", "Sprites/Missions/Mission1", new Army(), ""));
        MissionList.AllMission.Add(new Mission(3, 1, "Некромант", "Sprites/Missions/Mission2", new Army(), ""));
        MissionList.AllMission.Add(new Mission(3, 2, "Орки скелеты", "Sprites/Missions/Mission3", new Army(), ""));
        MissionList.AllMission.Add(new Mission(3, 3, "Орда нежити", "Sprites/Missions/Mission4", new Army(), ""));
        MissionList.AllMission.Add(new Mission(3, 4, "Вампиры", "Sprites/Missions/Mission5", new Army(), ""));
        MissionList.AllMission.Add(new Mission(3, 5, "Древние вампиры", "Sprites/Missions/Mission6", new Army(), ""));
        MissionList.AllMission.Add(new Mission(3, 6, "АльфаВампир", "Sprites/Missions/Mission7", new Army(), ""));

        MissionList.AllMission.Add(new Mission(4, 0, "Живой металл", "Sprites/Missions/Mission1", new Army(), ""));
        MissionList.AllMission.Add(new Mission(4, 1, "Первое поколение", "Sprites/Missions/Mission2", new Army(), ""));
        MissionList.AllMission.Add(new Mission(4, 2, "Второе поколение", "Sprites/Missions/Mission3", new Army(), ""));
        MissionList.AllMission.Add(new Mission(4, 3, "Третье поколение", "Sprites/Missions/Mission4", new Army(), ""));
        MissionList.AllMission.Add(new Mission(4, 4, "Четвертое поколение", "Sprites/Missions/Mission5", new Army(), ""));
        MissionList.AllMission.Add(new Mission(4, 5, "Пятое поколение", "Sprites/Missions/Mission6", new Army(), ""));
        MissionList.AllMission.Add(new Mission(4, 6, "Шестое поколение", "Sprites/Missions/Mission7", new Army(), ""));
    }
}
