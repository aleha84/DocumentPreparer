﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentPreparer.Models;

namespace UnitTestProject1.Data
{
    public class Abisoft : ITestData
    {
        public Dictionary<string, string> Blocks { get; set; }
        public IDictionary<string, string> Blocks2 { get; set; }
        public string DataName { get; set; }
        public string PDfName { get; set; }
        public GeneralInfoBlock GeneralInfo { get; set; }
        public FounderNP[] FoundersNP { get; set; }
        public FounderLE[] FoundersLE { get; set; }
        public decimal AuthirizedCapital { get; set; }
        public DocumentModel DocumentModel { get; set; }

        public static Abisoft Instance
        {
            get
            {
                return new Abisoft
                {
                    DataName = "Abisoft",
                    GeneralInfo = new GeneralInfoBlock
                    {
                        ShortName = @"ООО ""АБИСОФТ""",
                        FullName = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""АБИСОФТ""",
                        INN = "7716212993",
                        InitialRegistrationDate = "08.01.2002"

                    },
                    AuthirizedCapital = 16000m,
                    FoundersLE = new FounderLE[]
                    {
                        new FounderLE()
                    },
                    FoundersNP = new FounderNP[]
                    {
                        new FounderNP
                        {
                            FullName = "ВОРОНИН СЕРГЕЙ ВИКТОРОВИЧ",
                            INN = "772729678426",
                            Share = "50",
//                            LeaderOf =
//@"ООО ""ЦКО"" (Учредитель; Имеет право действовать без доверенности) ОГРН: 1027725002887, ИНН: 7725203346",
//                            FounderOf = string.Join("\n", 
//@"ООО ""АНТАНА"" (Учредитель) ОГРН: 1057746412613, ИНН: 7701587291",
//@"ООО ""ЦКО"" (Учредитель; Имеет право действовать без доверенности) ОГРН: 1027725002887, ИНН: 7725203346",
//@"ООО ""ГАРАНТ СЕРВИС МОСКВА"" (Учредитель) ОГРН: 1047796459413, ИНН: 7701544805",
//@"ООО ""ГСМ"" (Учредитель) ОГРН: 5067746789864, ИНН: 7720563803")
                        },
                        new FounderNP
                        {
                            FullName = "ПЫЛЬЦОВ ВАДИМ ВЯЧЕСЛАВОВИЧ",
                            INN = "561441936069",
                            Share = "50",
                        }
                    },
                    Blocks = new Dictionary<string, string> {
                        { "Affiliation", @"
УЧРЕДИТЕЛИ АФФИЛИРОВАННОСТЬ
ВОРОНИН СЕРГЕЙ
ВИКТОРОВИЧ
ИНН: 772729678426
1. ООО ""АНТАНА"" (Учредитель)
ОГРН: 1057746412613, ИНН: 7701587291
2. ООО ""ЦКО"" (Учредитель; Имеет право действовать без доверенности)
ОГРН: 1027725002887, ИНН: 7725203346
3. ООО ""ГАРАНТ СЕРВИС МОСКВА"" (Учредитель)
ОГРН: 1047796459413, ИНН: 7701544805
4. ООО ""ГСМ"" (Учредитель)
ОГРН: 5067746789864, ИНН: 7720563803
ПЫЛЬЦОВ ВАДИМ
ВЯЧЕСЛАВОВИЧ
ИНН: 561441936069
39" },
                        { "ChangesHistory", @"
2002 2003 2004 2005 2006 2007 2008 2009 2010 2011 2012 2013 2014
08.12 24.12
25.04
17.04
27.07
17.11 04.06
Адрес Наименование Управление Учредители
АДРЕСА
Дата Изменение
25 апреля 2007 129344, Москва г, Верхоянская ул, 18, 2,
08 декабря 2002 141060, Московская обл, Королев г, Первомайский пгт, Мира ул, 16,
НАИМЕНОВАНИЕ
Дата Изменение
27 июля 2008 Общество с ограниченной ответственностью ""Абисофт""
08 декабря 2002 Общество с ограниченной ответственностью ""ИКЦ Гарант""
УПРАВЛЕНИЕ
Дата ФИО Должность
04 июня 2013 Пыльцов Вадим Вячеславович Генеральный директор
17 ноября 2009 Боев Илья Анатольевич Директор
Пыльцов Вадим Вячеславович Генеральный директор
17 апреля 2008 Пыльцов Вадим Вячеславович Генеральный директор
Боев Илья Анатольевич Директор
24 декабря 2006 Боев Илья Анатольевич Директор
Пыльцов Вадим Вячеславович Генеральный директор
08 декабря 2002 Пыльцов Вадим Вячеславович Генеральный директор
Боев Илья Анатольевич Директор
УЧРЕДИТЕЛИ
Дата Наименование компании или ФИО Размер вклада
27 июля 2008 воронин сергей викторович 8 000 руб.
пыльцов вадим вячеславович 8 000 руб.
4025 апреля 2007 пыльцов вадим вячеславович 16 000 руб.
08 декабря 2002 Боев Илья Анатольевич 8 000 руб.
Пыльцов Вадим Вячеславович 8 000 руб.
41" },
                        { "GeneralInfo", @"
Всего компаний: 4. Подробнее смотрите на стр. 
 
НАИМЕНОВАНИЕ СТАТУС
Полное наименование
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""АБИСОФТ""
Сокращенное наименование
ООО ""АБИСОФТ""
Действующая
компания
Недобросовес
тный
поставщик
СВЕДЕНИЯ О ЮР. ЛИЦАХ-ПРЕЕМНИКАХ ПРИ РЕОРГАНИЗАЦИИ
УСТАВНЫЙ КАПИТАЛ ДАТА РЕГИСТРАЦИИ
16 000,00 руб. 08.01.2002
РЕКВИЗИТЫ АДРЕСА И КОНТАКТЫ
ИНН: 7716212993
КПП: 771601001
ОГРН: 1027739710338
ОКПО: 58202062
ОКОПФ: 65
ОКФС: 16
Юридический адрес
129344,ГОРОД МОСКВА,,,,УЛИЦА
ВЕРХОЯНСКАЯ,18,2
Фактический адрес
129344, Российская Федерация, г.
Москва, Верхоянская ул., д.18, кор. 2,
ОКАТО: 45280556000
Телефон:
Телефон: 7-499-7887117
Факс: 7-499-7887117
E-mail: tender@abisoft.ru
Сайт: www.abisoft.ru
УПРАВЛЕНИЕ АФФИЛИРОВАННОСТЬ
ПЫЛЬЦОВ ВАДИМ ВЯЧЕСЛАВОВИЧ
Генеральный директор
дата вступления: 05.06.2013
ИНН: 561441936069
УЧРЕДИТЕЛИ ДОЛЯ АФФИЛИРОВАННОСТЬ
ВОРОНИН СЕРГЕЙ
ВИКТОРОВИЧ
ИНН: 772729678426
50%
1. ООО ""АНТАНА"" (Учредитель)
ОГРН: 1057746412613, ИНН: 7701587291
2. ООО ""ЦКО"" (Учредитель; Имеет право действовать без доверенности)
ОГРН: 1027725002887, ИНН: 7725203346
3. ООО ""ГАРАНТ СЕРВИС МОСКВА"" (Учредитель)
ОГРН: 1047796459413, ИНН: 7701544805
4. ООО ""ГСМ"" (Учредитель)
ОГРН: 5067746789864, ИНН: 7720563803
39
ПЫЛЬЦОВ ВАДИМ
ВЯЧЕСЛАВОВИЧ
ИНН: 561441936069
50%
ЛИЦЕНЗИИ
отсутствуют
2 
 
Имеются балансы 2006, 2007, 2011, 2012, 2013, 2014, 2015 Подробнее смотрите на стр. 
 
 
 Подробнее смотрите на стр. 
 
 
 Подробнее смотрите на стр. 
 
 
 
 Подробнее смотрите на стр. 
 
 
ФИНАНСОВЫЕ ПОКАЗАТЕЛИ
чистая прибыль в рублях
0,00
за 2015 год
Выручка: 0,00
Дебиторская задолженность: 3 549 000,00
Кредиторская задолженность: 6 726 000,00
Прибыль от продаж: 0,00
13
ГОСУДАРСТВЕННЫЕ КОНТРАКТЫ
84
общая сумма
26 025 822,66
руб.
Исполнение: 0
Исполнение завершено: 0
Исполнение прекращено: 0
Аннулированные реестровые записи: 0
Статус неизвестен: 84
17
КОМПАНИИ, ЗАРЕГИСТРИРОВАННЫЕ ПО ТОМУ ЖЕ АДРЕСУ
972
1. АВТОНОМНАЯ НЕКОММЕРЧЕСКАЯ ОРГАНИЗАЦИЯ ""ФИЗКУЛЬТУРНО-
СПОРТИВНЫЙ КЛУБ ИНВАЛИДОВ ""РИТМ""
2. ООО ""БЕТОНПРЕСС""
3. ООО ЧОП ""ВЕНТА""
4. ООО ""ГОРОД-АВТО""
5. ООО ""МИКСТУМ""
42
СВЕДЕНИЯ ПОДАННЫЕ ДЛЯ РЕГИСТРАЦИИ
отсутствуют
УПОМИНАНИЯ В СПИСКАХ НЕДОБРОСОВЕСТНЫХ ПОСТАВЩИКОВ
1
1. Р1500752, дата включения: 19.05.2015, дата исключения:
38
УПОМИНАНИЯ В СПИСКАХ ДИСКВАЛИФИЦИРОВАННЫХ ЛИЦ
отсутствуют
АРБИТРАЖНЫЕ ДЕЛА
В качестве истца: 1 (общая сумма: 0,00 руб.)
В качестве ответчика: 0 (общая сумма: 0,00 руб.)
3 
 Подробнее смотрите на стр. 
 
1
В качестве иного лица: 0 (общая сумма: 0,00 руб.)
37
ПРОЦЕДУРА БАНКРОТСТВА
отсутствуют
4" },
                    { "ExtractFromEGRUL",
        @"АДРЕС (МЕСТО НАХОЖДЕНИЯ) ЮЛ
1 ОГРН 1027739710338
2 Полное наименование
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
3 Наименование органа(лица)
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
4 Адрес(место нахождения) юр.лица 129344,
                    ГОРОД МОСКВА,,,,
                    УЛИЦА ВЕРХОЯНСКАЯ,
                    18,
                    2,
                    5 Код города
6 Телефон
7 Факс
8 Дата внесения записи в ЕГРЮЛ 05.12.2002
9 ГРН 1027739710338
СВЕДЕНИЯ ОБ УСТАВНОМ КАПИТАЛЕ
10 Размер(в рублях) 16000
11 Вид капитала УСТАВНЫЙКАПИТАЛ
12 Дата внесения записи в ЕГРЮЛ 05.12.2002
13 ГРН 1027739710338
СВЕДЕНИЯ ОБ ОБРАЗОВАНИИ ЮРИДИЧЕСКОГО ЛИЦА
14 Cпособ образования Создание юридического лица до 01.07.2002
15 Дата регистрации 08.01.2002
16 ОГРН 1027739710338
17 Регномер до 01.07.2002 727.627
18 Код регоргана
19 Наименование регоргана
Государственное учреждение Московская
регистрационная палата
СВЕДЕНИЯ ОБ УЧРЕДИТЕЛЯХ - ФИЗИЧЕСКИХ ЛИЦАХ
20 Порядковый номер 1
21 Фамилия ВОРОНИН
22 Имя СЕРГЕЙ
23 Отчество ВИКТОРОВИЧ
24 ИНН 772729678426
25 Размер вклада(в рублях) 8000
26 ОГРН учрежденного ЮЛ 1027739710338
27 Полное наименование учрежденного ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
28 Сведения о состоянии юр.лица Действующее
29 Дата внесения записи в ЕГРЮЛ 18.11.2009
30 ГРН 7097748050734
31 Вид обременения
32 Срок обременения
33
Номинальная стоимость доли или части доли,
                    находящейся в залоге или ином обременении(в рублях и
долей рубля в виде простой дроби)
5


34
Номинальная стоимость доли или части доли,
                    находящейся в залоге или ином обременении(в рублях)
35
Размер доли или части доли,
                    находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества(в виде простой дроби)
36
Размер доли или части доли,
                    находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества(в процентах)
37
Размер доли или части доли,
                    находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества
 38 Порядковый номер 2
39 Фамилия ПЫЛЬЦОВ
40 Имя ВАДИМ
41 Отчество ВЯЧЕСЛАВОВИЧ
42 ИНН 561441936069
43 Размер вклада(в рублях) 8000
44 ОГРН учрежденного ЮЛ 1027739710338
45 Полное наименование учрежденного ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
46 Сведения о состоянии юр.лица Действующее
47 Дата внесения записи в ЕГРЮЛ 18.11.2009
48 ГРН 7097748050734
49 Вид обременения
50 Срок обременения
51
Номинальная стоимость доли или части доли,
                    находящейся в залоге или ином обременении(в рублях и
долей рубля в виде простой дроби)
52
Номинальная стоимость доли или части доли,
                    находящейся в залоге или ином обременении(в рублях)
53
Размер доли или части доли,
                    находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества(в виде простой дроби)
54
Размер доли или части доли,
                    находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества(в процентах)
55
Размер доли или части доли,
                    находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества
СВЕДЕНИЯ О ФИЗИЧЕСКИХ ЛИЦАХ,
                    ИМЕЮЩИХ ПРАВО ДЕЙСТВОВАТЬ БЕЗ ДОВЕРЕННОСТИ
56 Должность Генеральный директор
57 Фамилия ПЫЛЬЦОВ
58 Имя ВАДИМ
59 Отчество ВЯЧЕСЛАВОВИЧ
60 ИНН 561441936069
61 ОГРН 1027739710338
62 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
63 Статус Действующее
64 Дата внесения записи в ЕГРЮЛ 05.06.2013
65 ГРН 9137746643894
66 Телефон
6



СВЕДЕНИЯ О ПОСТАНОВКЕ НА УЧЕТ В НАЛОГОВОМ ОРГАНЕ
67 ИНН 7716212993
68 КПП 771601001
69 Дата постановки на учет в налоговом органе 05.12.2002
70 Дата снятия с учета
71 Код налогового органа 7716
72 Наименование налогового органа
Инспекция Федеральной налоговой службы  16 по г.
Москве
73 Дата внесения записи в ЕГРЮЛ 28.07.2008
74 ГРН
СВЕДЕНИЯ О РЕГИСТРАЦИИ В ПФ РОССИИ
75 ОГРН 1027739710338
76 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
77 Регномер ПФ 087302050851
78 Дата регистрации 05.09.2008
79 Дата снятия с учета
80 Наименование территориального органа ПФ
Государственное учреждение - Главное Управление
Пенсионного фонда РФ 6 по г.Москве и Московской
области муниципальный район Бабушкинский г.Москвы
81 Дата внесения записи в ЕГРЮЛ 08.09.2008
82 ГРН 2087761349212
СВЕДЕНИЯ О РЕГИСТРАЦИИ В ФСС РОССИИ
83 ОГРН 1027739710338
84 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
85 Регномер ФСС 773000938177301
86 Дата первичной регистрации
87 Дата регистрации 28.01.2002
88 Дата снятия с учета
89 Наименование исполнительного органа ФСС
Филиал 30 Государственного учреждения - Московского
регионального отделения Фонда социального
страхования Российской Федерации
90 Дата внесения записи в ЕГРЮЛ 18.09.2016
91 ГРН 9167748975748
СВЕДЕНИЯ О ЗАПИСЯХ В ЕГРЮЛ
92 Порядковый номер 1
93 ГРН 1027739710338
94 Дата внесения записи 05.12.2002
95 Событие,
                    с которым связано внесение записи
(Р17001) Внесение в ЕГРЮЛ сведений о ЮЛ,
                    созданном до
01.07.2002
96 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Министерства Российской
Федерации по налогам и сборам 39 по г.Москве
97 Статус Действующая запись
98 ОГРН 1027739710338
799 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 100 Порядковый номер 2
101 ГРН 2067761629582
102 Дата внесения записи 25.12.2006
103 Событие,
                    с которым связано внесение записи(Р14001) Исправление ошибок,
                    допущенных заявителем
104 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
105 Статус Действующая запись
106 ОГРН 1027739710338
107 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 108 Порядковый номер 3
109 ГРН 2067761629593
110 Дата внесения записи 25.12.2006
111 Событие,
                    с которым связано внесение записи Внесение сведений об учете в налоговом органе
112 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
113 Статус Действующая запись
114 ОГРН 1027739710338
115 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 116 Порядковый номер 4
117 ГРН 2067761629604
118 Дата внесения записи 25.12.2006
119 Событие,
                    с которым связано внесение записи Внесение сведений об учете в налоговом органе
120 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
121 Статус Действующая запись
122 ОГРН 1027739710338
123 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 124 Порядковый номер 5
125 ГРН 2077746994741
126 Дата внесения записи 08.02.2007
127 Событие,
                    с которым связано внесение записи Внесение сведений о регистрации в ПФ РФ
128 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
129 Статус Действующая запись
130 ОГРН 1027739710338
131 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 132 Порядковый номер 6
133 ГРН 9077746849908
134 Дата внесения записи 26.04.2007
135 Событие,
                    с которым связано внесение записи
(Р14001) Внесение изменений не связанных с
учредительными документами
8136 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
137 Статус Действующая запись
138 ОГРН 1027739710338
139 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 140 Порядковый номер 7
141 ГРН 9077746849920
142 Дата внесения записи 26.04.2007
143 Событие,
                    с которым связано внесение записи(Р13001) Внесение изменений в учредительные документы
144 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
145 Статус Действующая запись
146 ОГРН 1027739710338
147 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 148 Порядковый номер 8
149 ГРН
150 Дата внесения записи 28.07.2008
151 Событие,
                    с которым связано внесение записи Внесение сведений об учете в налоговом органе
152 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
153 Статус Действующая запись
154 ОГРН 1027739710338
155 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 156 Порядковый номер 9
157 ГРН 2087758245716
158 Дата внесения записи 28.07.2008
159 Событие,
                    с которым связано внесение записи
(Р14001) Внесение изменений не связанных с
учредительными документами
160 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
161 Статус Действующая запись
162 ОГРН 1027739710338
163 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 164 Порядковый номер 10
165 ГРН 2087758245804
166 Дата внесения записи 28.07.2008
167 Событие,
                    с которым связано внесение записи(Р13001) Внесение изменений в учредительные документы
168 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
169 Статус Действующая запись
170 ОГРН 1027739710338
171 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 172 Порядковый номер 11
9
173 ГРН 2087761349212
174 Дата внесения записи 08.09.2008
175 Событие,
                    с которым связано внесение записи Внесение сведений о регистрации в ПФ РФ
176 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
177 Статус Действующая запись
178 ОГРН 1027739710338
179 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 180 Порядковый номер 12
181 ГРН 7097748050734
182 Дата внесения записи 18.11.2009
183 Событие,
                    с которым связано внесение записи
(Р13001) Приведение устава ООО в соответствие с 312 -
ФЗ
184 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
185 Статус Действующая запись
186 ОГРН 1027739710338
187 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 188 Порядковый номер 13
189 ГРН 9137746643894
190 Дата внесения записи 05.06.2013
191 Событие,
                    с которым связано внесение записи
(Р14001) Внесение изменений не связанных с
учредительными документами
192 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
193 Статус Действующая запись
194 ОГРН 1027739710338
195 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
 196 Порядковый номер 14
197 ГРН 9167748975748
198 Дата внесения записи 18.09.2016
199 Событие,
                    с которым связано внесение записи Внесение сведений о регистрации в ФСС РФ
200 Наименование регоргана,
                    в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
201 Статус Действующая запись
202 ОГРН 1027739710338
203 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""АБИСОФТ""
СВЕДЕНИЯ О ВЫДАННЫХ СВИДЕТЕЛЬСТВАХ
204 Порядковый номер 1
205 Номер свидетельства 007366921
206 Серия свидетельства 77
207 Дата выдачи 05.12.2002
208 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Министерства Российской
Федерации по налогам и сборам 39 по г.Москве
10209 Статус Действующее
210 ГРН 1027739710338
 211 Порядковый номер 2
212 Номер свидетельства 009754640
213 Серия свидетельства 77
214 Дата выдачи 25.12.2006
215 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
216 Статус Действующее
217 ГРН 2067761629582
 218 Порядковый номер 3
219 Номер свидетельства 010115645
220 Серия свидетельства 77
221 Дата выдачи 26.04.2007
222 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
223 Статус Действующее
224 ГРН 9077746849908
 225 Порядковый номер 4
226 Номер свидетельства 010115646
227 Серия свидетельства 77
228 Дата выдачи 26.04.2007
229 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
230 Статус Действующее
231 ГРН 9077746849920
 232 Порядковый номер 5
233 Номер свидетельства 011283875
234 Серия свидетельства 77
235 Дата выдачи 28.07.2008
236 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
237 Статус Действующее
238 ГРН 2087758245716
 239 Порядковый номер 6
240 Номер свидетельства 011283876
241 Серия свидетельства 77
242 Дата выдачи 28.07.2008
243 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
244 Статус Действующее
245 ГРН 2087758245804
 246 Порядковый номер 7
247 Номер свидетельства 012771094
248 Серия свидетельства 77
11249 Дата выдачи 18.11.2009
250 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
251 Статус Действующее
252 ГРН 7097748050734
 253 Порядковый номер 8
254 Номер свидетельства 016038399
255 Серия свидетельства 77
256 Дата выдачи 05.06.2013
257 Наименование регоргана,
                    выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г.Москве
258 Статус Действующее
259 ГРН 9137746643894
12"
} }
                };
            }
        }
    }
}
