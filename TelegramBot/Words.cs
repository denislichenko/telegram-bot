using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    static class Words
    {
        public static string[] hello = new string[] { "Привет!", "Здравствуйте!", "Ку!", "Ку-ку!", "Рад тебя видеть!"};
        public static string[] start = new string[] { "Скажите « Привет! »", "Поздоровайтесь! :)", "Юхуу!!" };
        public static string[] mood = new string[] { "Неплохо! А ты как?", "Хорошо!", "Отлично!", "Только что сьел кусок пиццы друга! :D"};
        public static string[] other = new string[] { "Ясно.", "Бывает", ":)", "Я не знаю такой команды!" };
        public static string[] olbanskyi = new string[] {
            "Абассака", "Аффтар жжот нипадецки", "Аццкий Сотона", "Бугага", "Вмемориз!", "Во френды!",
            "Данунах", "Жжош сцуко", "Жызнинна", "Зачот", "Зомбоящик", "ИМХО", "Инстетуд", "Йа", "Кагдила?",
            "Кагтаг?", "Камменты рулят!", "Классный юзерпик!", "Кросафчег", "Энторнет", "Я забыл подписацца, асёл",
            "Ы-ы-ы", "Чмоки, пративный", "Фтыкать", "Фтопку", "Фтему", "Фотожоп", "Ф сотне и ниибет", "Учи олбанский!",
            "Ужоснах", "Требую РУЯ!"
        };
        public static string[] cats = new string[]
        {
            "https://cdn.pixabay.com/photo/2016/09/07/23/10/cat-1652880_960_720.jpg" ,
            "https://cdn.pixabay.com/photo/2015/11/15/20/21/cat-1044750_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/02/25/18/15/nature-3181350_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/01/04/18/58/cats-3061372_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/03/07/23/02/wood-3207385_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/03/05/02/04/cat-3199796_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/03/04/21/30/animal-3199289_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/03/04/21/30/animal-3199289_960_720.jpg",
            "https://cdn.pixabay.com/photo/2015/11/16/22/14/cat-1046544_960_720.jpg",
            "https://cdn.pixabay.com/photo/2016/06/14/00/14/cat-1455468_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/02/21/18/24/cat-3171125_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/06/24/12/05/cat-2437608_960_720.jpg"
        };

        public static string[] minimalism = new string[]
        {
            "https://cdn.pixabay.com/photo/2018/04/04/23/19/dawn-3291444_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/04/04/23/53/bridge-3291513_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/01/14/23/12/nature-3082832_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/02/02/22/28/nature-3126513_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/01/31/12/16/architecture-3121009_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/01/31/16/27/sea-3121435_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/01/11/19/02/architecture-3076685_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/01/18/21/49/singapore-1990959_960_720.jpg",
            "https://cdn.pixabay.com/photo/2016/11/13/12/52/kuala-lumpur-1820944_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/11/05/12/35/trees-2920264_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/06/27/05/33/shanghai-2446326_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/05/03/15/18/sunset-3371575_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/03/29/15/18/tianjin-2185510_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/05/01/03/55/sunset-3364658_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/04/27/19/10/sunset-3355583_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/05/03/18/31/sunset-3372022_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/04/30/10/23/sunset-3362337_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/07/19/01/41/clouds-2517653_960_720.jpg",
            "https://cdn.pixabay.com/photo/2015/09/05/04/27/milky-way-923738_960_720.jpg",
            "https://cdn.pixabay.com/photo/2015/08/20/02/04/delicate-arch-896885_960_720.jpg",
            "https://cdn.pixabay.com/photo/2013/09/14/11/28/moon-182145_960_720.jpg",
            "https://cdn.pixabay.com/photo/2013/03/02/02/41/sleeping-89197_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/04/29/01/17/hanoi-3358841_960_720.jpg",
            "https://cdn.pixabay.com/photo/2016/09/23/17/05/ulm-1690078_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/10/30/23/34/lamp-2903830_960_720.jpg",
            "https://cdn.pixabay.com/photo/2015/12/05/19/49/cologne-1078671_960_720.jpg",
            "https://cdn.pixabay.com/photo/2016/10/12/23/20/mining-excavator-1736289_960_720.jpg",
            "https://cdn.pixabay.com/photo/2014/11/09/17/14/night-sky-523892_960_720.jpg",
            "https://cdn.pixabay.com/photo/2015/11/14/22/43/flash-1043778_960_720.jpg",
            "https://cdn.pixabay.com/photo/2018/04/02/18/01/moon-3284601_960_720.jpg"
        };
    }
}
