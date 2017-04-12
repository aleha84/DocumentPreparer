﻿using DocumentPreparer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Data
{
    public class OtelCity : ITestData
    {
        public Dictionary<string, string> Blocks { get; set; }
        public string DataName { get; set; }
        public GeneralInfoBlock GeneralInfo { get; set; }
        public FounderNP[] FoundersNP { get; set; }
        public FounderLE[] FoundersLE { get; set; }
        public decimal AuthirizedCapital { get; set; }

        public static OtelCity Instance
        {
            get
            {
                return new OtelCity
                {
                    DataName = "OtelCity",
                    AuthirizedCapital = 15000m,
                    GeneralInfo = new GeneralInfoBlock
                    {
                        ShortName = @"ООО ""ОТЕЛЬ СИТИ""",
                        FullName = @"ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ОТЕЛЬ СИТИ""",
                        INN = "7722345448",
                        InitialRegistrationDate = "09.11.2015"
                    },
                    FoundersLE = new FounderLE[]
                    {
                        new FounderLE()
                    },
                    FoundersNP = new FounderNP[]
                    {
                        new FounderNP
                        {
                            FullName = "ПАНИКАРОВСКАЯ СВЕТЛАНА ЛЕОНИДОВНА",
                            INN = "611801993362",
                            Share = "100"
                        }
                    },
                    Blocks = new Dictionary<string, string> {
                        { "GeneralInfo", @"
Всего компаний: 6. Подробнее смотрите на стр. 
 
НАИМЕНОВАНИЕ СТАТУС
Полное наименование
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ ""ОТЕЛЬ СИТИ""
Сокращенное наименование
ООО ""ОТЕЛЬ СИТИ""
Действующая
компания
СВЕДЕНИЯ О ЮР. ЛИЦАХ-ПРЕЕМНИКАХ ПРИ РЕОРГАНИЗАЦИИ
УСТАВНЫЙ КАПИТАЛ ДАТА РЕГИСТРАЦИИ
15 000,00 руб. 09.11.2015
РЕКВИЗИТЫ АДРЕСА И КОНТАКТЫ
ИНН: 7722345448
КПП: 772201001
ОГРН: 5157746028259
ОКПО: 16428510
ОКОПФ: 12300
ОКФС: 16
Юридический адрес
109316,ГОРОД МОСКВА,,,,ПРОЕЗД
ОСТАПОВСКИЙ,ДОМ 3,СТРОЕНИЕ
23,ОФИС 302
УПРАВЛЕНИЕ АФФИЛИРОВАННОСТЬ
ПАНИКАРОВСКАЯ СВЕТЛАНА
ЛЕОНИДОВНА
ГЕНЕРАЛЬНЫЙ ДИРЕКТОР
дата вступления: 10.01.2017
ИНН: 611801993362
1. ООО ""АПАРТ ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746987267, ИНН: 7715979690
2. (Учредитель; Имеет право действовать без доверенности)
ОГРН: 1177746006998, ИНН: 7714967220
3. ООО ""Де Люкс"" (Имеет право действовать без доверенности,
Учредитель)
ОГРН: 1117746588519, ИНН: 7715876960
4. ООО ""ДЕ ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746166590, ИНН: 7722801316
5. ООО ""ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1147746520558, ИНН: 7715431390
22
УЧРЕДИТЕЛИ ДОЛЯ АФФИЛИРОВАННОСТЬ
ПАНИКАРОВСКАЯ
СВЕТЛАНА ЛЕОНИДОВНА
ИНН: 611801993362
100%
1. ООО ""АПАРТ ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746987267, ИНН: 7715979690
2. (Учредитель; Имеет право действовать без доверенности)
ОГРН: 1177746006998, ИНН: 7714967220
3. ООО ""Де Люкс"" (Имеет право действовать без доверенности,
Учредитель)
ОГРН: 1117746588519, ИНН: 7715876960
4. ООО ""ДЕ ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746166590, ИНН: 7722801316
5. ООО ""ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1147746520558, ИНН: 7715431390
2Всего компаний: 6. Подробнее смотрите на стр. 
 
 
Всего дополнительных видов экономической деятельности: 56. Подробнее смотрите на стр. 
 
 
 
Имеются балансы 2015 Подробнее смотрите на стр. 
 
 
 
 
 Подробнее смотрите на стр. 
 
22
ВИДЫ ЭКОНОМИЧЕСКОЙ ДЕЯТЕЛЬНОСТИ
Основной вид деятельности
55.10 Деятельность гостиниц и прочих
мест для временного проживания
Дополнительные виды деятельности
46.15 Деятельность агентов по оптовой торговле мебелью,
бытовыми товарами, скобяными, ножевыми и прочими
металлическими изделиями
47.11 Торговля розничная преимущественно пищевыми продуктами,
включая напитки, и табачными изделиями в
неспециализированных магазинах
47.19 Торговля розничная прочая в неспециализированных
магазинах
47.21 Торговля розничная фруктами и овощами в
специализированных магазинах
47.22 Торговля розничная мясом и мясными продуктами в
специализированных магазинах
6
ЛИЦЕНЗИИ
отсутствуют
ФИНАНСОВЫЕ ПОКАЗАТЕЛИ
чистая прибыль в рублях
359 000,00
за 2015 год
Выручка: 3 949 000,00
Дебиторская задолженность: 1 800 000,00
Кредиторская задолженность: 4 012 000,00
Прибыль от продаж: 427 000,00
19
ГОСУДАРСТВЕННЫЕ КОНТРАКТЫ
отсутствуют
КОМПАНИИ, ЗАРЕГИСТРИРОВАННЫЕ ПО ТОМУ ЖЕ АДРЕСУ
отсутствуют
СВЕДЕНИЯ ПОДАННЫЕ ДЛЯ РЕГИСТРАЦИИ
2
1. 27.12.2016,, форма: Р14001, дата готовности документов: 11.01.2017
Вносимые в сведения реестра (форма  Р14001), в том числе в части: участников
юридического лица  физических лиц ( Решение о государственной
регистрации)
2. 27.12.2016,, форма: Р14001, дата готовности документов: 11.01.2017
Вносимые в сведения реестра (форма  Р14001), в том числе в части: лица,
имеющего право без доверенности действовать от имени юридического лица (
Решение о государственной регистрации)
18
УПОМИНАНИЯ В СПИСКАХ НЕДОБРОСОВЕСТНЫХ ПОСТАВЩИКОВ
3 
 
 
 Подробнее смотрите на стр. 
 
отсутствуют
УПОМИНАНИЯ В СПИСКАХ ДИСКВАЛИФИЦИРОВАННЫХ ЛИЦ
отсутствуют
АРБИТРАЖНЫЕ ДЕЛА
4
В качестве истца: 2 (общая сумма: 318 000,00 руб.)
В качестве ответчика: 0 (общая сумма: 0,00 руб.)
В качестве иного лица: 2 (общая сумма: 3 019 586,62 руб.)
21
ПРОЦЕДУРА БАНКРОТСТВА
отсутствуют
4" },
                        { "ChangesHistory", "" },
                        { "Affiliation", @"
УПРАВЛЕНИЕ АФФИЛИРОВАННОСТЬ
ПАНИКАРОВСКАЯ СВЕТЛАНА
ЛЕОНИДОВНА
ГЕНЕРАЛЬНЫЙ ДИРЕКТОР
дата вступления: 10.01.2017
1. ООО ""АПАРТ ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746987267, ИНН: 7715979690
2. (Учредитель; Имеет право действовать без доверенности)
ОГРН: 1177746006998, ИНН: 7714967220
3. ООО ""Де Люкс"" (Имеет право действовать без доверенности, Учредитель)
ОГРН: 1117746588519, ИНН: 7715876960
4. ООО ""ДЕ ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746166590, ИНН: 7722801316
5. ООО ""ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1147746520558, ИНН: 7715431390
6. ООО ""Фобос"" (Учредитель)
ОГРН: 1087746799018, ИНН: 7716610049
УЧРЕДИТЕЛИ АФФИЛИРОВАННОСТЬ
ПАНИКАРОВСКАЯ СВЕТЛАНА
ЛЕОНИДОВНА
ИНН: 611801993362
1. ООО ""АПАРТ ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746987267, ИНН: 7715979690
2. (Учредитель; Имеет право действовать без доверенности)
ОГРН: 1177746006998, ИНН: 7714967220
3. ООО ""Де Люкс"" (Имеет право действовать без доверенности, Учредитель)
ОГРН: 1117746588519, ИНН: 7715876960
4. ООО ""ДЕ ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1137746166590, ИНН: 7722801316
5. ООО ""ЛЮКС ОТЕЛЬ"" (Учредитель)
ОГРН: 1147746520558, ИНН: 7715431390
6. ООО ""Фобос"" (Учредитель)
ОГРН: 1087746799018, ИНН: 7716610049
22" },
                    { "ExtractFromEGRUL", @"
АДРЕС (МЕСТО НАХОЖДЕНИЯ) ЮЛ
1 ОГРН 5157746028259
2 Полное наименование
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
3 Наименование органа(лица)
Межрайонная инспекция Федеральной налоговой службы 
46 по г.Москве
4 Адрес (место нахождения) юр.лица
109316,ГОРОД МОСКВА,,,, ПРОЕЗД ОСТАПОВСКИЙ,ДОМ
3,СТРОЕНИЕ 23,ОФИС 302
5 Код города
6 Телефон
7 Факс
8 Дата внесения записи в ЕГРЮЛ 09.11.2015
9 ГРН 5157746028259
СВЕДЕНИЯ ОБ УСТАВНОМ КАПИТАЛЕ
10 Размер(в рублях) 15000
11 Вид капитала УСТАВНЫЙКАПИТАЛ
12 Дата внесения записи в ЕГРЮЛ 09.11.2015
13 ГРН 5157746028259
СВЕДЕНИЯ ОБ ОБРАЗОВАНИИ ЮРИДИЧЕСКОГО ЛИЦА
14 Cпособ образования Создание юридического лица
15 Дата регистрации 09.11.2015
16 ОГРН 5157746028259
17 Регномер до 01.07.2002
18 Код регоргана 7746
19 Наименование регоргана
Межрайонная инспекция Федеральной налоговой службы 
46 по г.Москве
СВЕДЕНИЯ ОБ УЧРЕДИТЕЛЯХ - ФИЗИЧЕСКИХ ЛИЦАХ
20 Фамилия ПАНИКАРОВСКАЯ
21 Имя СВЕТЛАНА
22 Отчество ЛЕОНИДОВНА
23 ИНН 611801993362
24 Размер вклада (в рублях) 15000
25 ОГРН учрежденного ЮЛ 5157746028259
26 Полное наименование учрежденного ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
27 Сведения о состоянии юр.лица Действующее
28 Дата внесения записи в ЕГРЮЛ 10.01.2017
29 ГРН 2177746195460
30 Вид обременения
31 Срок обременения
32
Номинальная стоимость доли или части доли,
находящейся в залоге или ином обременении(в рублях и
долей рубля в виде простой дроби)
5 
 
33
Номинальная стоимость доли или части доли,
находящейся в залоге или ином обременении(в рублях)
34
Размер доли или части доли, находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества(в виде простой дроби)
35
Размер доли или части доли, находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества(в процентах)
36
Размер доли или части доли, находящейся в залоге или
ином обременении по отношению к уставному капиталу
общества
СВЕДЕНИЯ О ФИЗИЧЕСКИХ ЛИЦАХ, ИМЕЮЩИХ ПРАВО ДЕЙСТВОВАТЬ БЕЗ ДОВЕРЕННОСТИ
37 Должность ГЕНЕРАЛЬНЫЙ ДИРЕКТОР
38 Фамилия ПАНИКАРОВСКАЯ
39 Имя СВЕТЛАНА
40 Отчество ЛЕОНИДОВНА
41 ИНН 611801993362
42 ОГРН 5157746028259
43 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
44 Статус Действующее
45 Дата внесения записи в ЕГРЮЛ 10.01.2017
46 ГРН 2177746184746
47 Телефон 8(916)9237391
СВЕДЕНИЯ О ВИДАХ ЭКОНОМИЧЕСКОЙ ДЕЯТЕЛЬНОСТИ
48 Порядковый номер 1
49 Код по ОКВЭД 55.10
50 Тип Основной вид деятельности
51 Наименование вида деятельности
Деятельность гостиниц и прочих мест для временного
проживания
52 Дата внесения записи в ЕГРЮЛ 09.11.2015
53 ГРН 5157746028259
 54 Порядковый номер 2
55 Код по ОКВЭД 46.15
56 Тип Дополнительный вид деятельности
57 Наименование вида деятельности
Деятельность агентов по оптовой торговле мебелью,
бытовыми товарами, скобяными, ножевыми и прочими
металлическими изделиями
58 Дата внесения записи в ЕГРЮЛ 09.11.2015
59 ГРН 5157746028259
 60 Порядковый номер 3
61 Код по ОКВЭД 47.11
62 Тип Дополнительный вид деятельности
63 Наименование вида деятельности
Торговля розничная преимущественно пищевыми
продуктами, включая напитки, и табачными изделиями в
неспециализированных магазинах
64 Дата внесения записи в ЕГРЮЛ 09.11.2015
65 ГРН 5157746028259
666 Порядковый номер 4
67 Код по ОКВЭД 47.19
68 Тип Дополнительный вид деятельности
69 Наименование вида деятельности
Торговля розничная прочая в неспециализированных
магазинах
70 Дата внесения записи в ЕГРЮЛ 09.11.2015
71 ГРН 5157746028259
 72 Порядковый номер 5
73 Код по ОКВЭД 47.21
74 Тип Дополнительный вид деятельности
75 Наименование вида деятельности
Торговля розничная фруктами и овощами в
специализированных магазинах
76 Дата внесения записи в ЕГРЮЛ 09.11.2015
77 ГРН 5157746028259
 78 Порядковый номер 6
79 Код по ОКВЭД 47.22
80 Тип Дополнительный вид деятельности
81 Наименование вида деятельности
Торговля розничная мясом и мясными продуктами в
специализированных магазинах
82 Дата внесения записи в ЕГРЮЛ 09.11.2015
83 ГРН 5157746028259
 84 Порядковый номер 7
85 Код по ОКВЭД 47.23
86 Тип Дополнительный вид деятельности
87 Наименование вида деятельности
Торговля розничная рыбой, ракообразными и моллюсками
в специализированных магазинах
88 Дата внесения записи в ЕГРЮЛ 09.11.2015
89 ГРН 5157746028259
 90 Порядковый номер 8
91 Код по ОКВЭД 47.24
92 Тип Дополнительный вид деятельности
93 Наименование вида деятельности
Торговля розничная хлебом и хлебобулочными изделиями
и кондитерскими изделиями в специализированных
магазинах
94 Дата внесения записи в ЕГРЮЛ 09.11.2015
95 ГРН 5157746028259
 96 Порядковый номер 9
97 Код по ОКВЭД 47.25
98 Тип Дополнительный вид деятельности
99 Наименование вида деятельности
Торговля розничная напитками в специализированных
магазинах
100 Дата внесения записи в ЕГРЮЛ 09.11.2015
101 ГРН 5157746028259
 102 Порядковый номер 10
103 Код по ОКВЭД 47.26
7104 Тип Дополнительный вид деятельности
105 Наименование вида деятельности
Торговля розничная табачными изделиями в
специализированных магазинах
106 Дата внесения записи в ЕГРЮЛ 09.11.2015
107 ГРН 5157746028259
 108 Порядковый номер 11
109 Код по ОКВЭД 47.29
110 Тип Дополнительный вид деятельности
111 Наименование вида деятельности
Торговля розничная прочими пищевыми продуктами в
специализированных магазинах
112 Дата внесения записи в ЕГРЮЛ 09.11.2015
113 ГРН 5157746028259
 114 Порядковый номер 12
115 Код по ОКВЭД 47.43
116 Тип Дополнительный вид деятельности
117 Наименование вида деятельности
Торговля розничная аудио- и видеотехникой в
специализированных магазинах
118 Дата внесения записи в ЕГРЮЛ 09.11.2015
119 ГРН 5157746028259
 120 Порядковый номер 13
121 Код по ОКВЭД 47.51
122 Тип Дополнительный вид деятельности
123 Наименование вида деятельности
Торговля розничная текстильными изделиями в
специализированных магазинах
124 Дата внесения записи в ЕГРЮЛ 09.11.2015
125 ГРН 5157746028259
 126 Порядковый номер 14
127 Код по ОКВЭД 47.52
128 Тип Дополнительный вид деятельности
129 Наименование вида деятельности
Торговля розничная скобяными изделиями,
лакокрасочными материалами и стеклом в
специализированных магазинах
130 Дата внесения записи в ЕГРЮЛ 09.11.2015
131 ГРН 5157746028259
 132 Порядковый номер 15
133 Код по ОКВЭД 47.54
134 Тип Дополнительный вид деятельности
135 Наименование вида деятельности
Торговля розничная бытовыми электротоварами в
специализированных магазинах
136 Дата внесения записи в ЕГРЮЛ 09.11.2015
137 ГРН 5157746028259
 138 Порядковый номер 16
139 Код по ОКВЭД 47.59
140 Тип Дополнительный вид деятельности
141 Наименование вида деятельности
Торговля розничная мебелью, осветительными приборами
и прочими бытовыми изделиями в специализированных
магазинах
8142 Дата внесения записи в ЕГРЮЛ 09.11.2015
143 ГРН 5157746028259
 144 Порядковый номер 17
145 Код по ОКВЭД 47.61
146 Тип Дополнительный вид деятельности
147 Наименование вида деятельности
Торговля розничная книгами в специализированных
магазинах
148 Дата внесения записи в ЕГРЮЛ 09.11.2015
149 ГРН 5157746028259
 150 Порядковый номер 18
151 Код по ОКВЭД 47.7
152 Тип Дополнительный вид деятельности
153 Наименование вида деятельности
Торговля розничная прочими товарами в
специализированных магазинах
154 Дата внесения записи в ЕГРЮЛ 09.11.2015
155 ГРН 5157746028259
 156 Порядковый номер 19
157 Код по ОКВЭД 47.71
158 Тип Дополнительный вид деятельности
159 Наименование вида деятельности
Торговля розничная одеждой в специализированных
магазинах
160 Дата внесения записи в ЕГРЮЛ 09.11.2015
161 ГРН 5157746028259
 162 Порядковый номер 20
163 Код по ОКВЭД 47.72
164 Тип Дополнительный вид деятельности
165 Наименование вида деятельности
Торговля розничная обувью и изделиями из кожи в
специализированных магазинах
166 Дата внесения записи в ЕГРЮЛ 09.11.2015
167 ГРН 5157746028259
 168 Порядковый номер 21
169 Код по ОКВЭД 47.73
170 Тип Дополнительный вид деятельности
171 Наименование вида деятельности
Торговля розничная лекарственными средствами в
специализированных магазинах(аптеках)
172 Дата внесения записи в ЕГРЮЛ 09.11.2015
173 ГРН 5157746028259
 174 Порядковый номер 22
175 Код по ОКВЭД 47.75
176 Тип Дополнительный вид деятельности
177 Наименование вида деятельности
Торговля розничная косметическими и товарами личной
гигиены в специализированных магазинах
178 Дата внесения записи в ЕГРЮЛ 09.11.2015
179 ГРН 5157746028259
 180 Порядковый номер 23
9181 Код по ОКВЭД 47.8
182 Тип Дополнительный вид деятельности
183 Наименование вида деятельности
Торговля розничная в нестационарных торговых объектах
и на рынках
184 Дата внесения записи в ЕГРЮЛ 09.11.2015
185 ГРН 5157746028259
 186 Порядковый номер 24
187 Код по ОКВЭД 47.99
188 Тип Дополнительный вид деятельности
189 Наименование вида деятельности
Торговля розничная прочая вне магазинов, палаток,
рынков
190 Дата внесения записи в ЕГРЮЛ 09.11.2015
191 ГРН 5157746028259
 192 Порядковый номер 25
193 Код по ОКВЭД 49.32
194 Тип Дополнительный вид деятельности
195 Наименование вида деятельности Деятельность такси
196 Дата внесения записи в ЕГРЮЛ 09.11.2015
197 ГРН 5157746028259
 198 Порядковый номер 26
199 Код по ОКВЭД 52.29
200 Тип Дополнительный вид деятельности
201 Наименование вида деятельности
Деятельность вспомогательная прочая, связанная с
перевозками
202 Дата внесения записи в ЕГРЮЛ 09.11.2015
203 ГРН 5157746028259
 204 Порядковый номер 27
205 Код по ОКВЭД 55.30
206 Тип Дополнительный вид деятельности
207 Наименование вида деятельности
Деятельность по предоставлению мест для временного
проживания в кемпингах, жилых автофургонах и
туристических автоприцепах
208 Дата внесения записи в ЕГРЮЛ 09.11.2015
209 ГРН 5157746028259
 210 Порядковый номер 28
211 Код по ОКВЭД 55.90
212 Тип Дополнительный вид деятельности
213 Наименование вида деятельности
Деятельность по предоставлению прочих мест для
временного проживания
214 Дата внесения записи в ЕГРЮЛ 09.11.2015
215 ГРН 5157746028259
 216 Порядковый номер 29
217 Код по ОКВЭД 56.10
218 Тип Дополнительный вид деятельности
219 Наименование вида деятельности
Деятельность ресторанов и услуги по доставке
продуктов питания
10220 Дата внесения записи в ЕГРЮЛ 09.11.2015
221 ГРН 5157746028259
 222 Порядковый номер 30
223 Код по ОКВЭД 56.10.1
224 Тип Дополнительный вид деятельности
225 Наименование вида деятельности
Деятельность ресторанов и кафе с полным ресторанным
обслуживанием, кафетериев, ресторанов быстрого
питания и самообслуживания
226 Дата внесения записи в ЕГРЮЛ 09.11.2015
227 ГРН 5157746028259
 228 Порядковый номер 31
229 Код по ОКВЭД 56.10.3
230 Тип Дополнительный вид деятельности
231 Наименование вида деятельности
Деятельность ресторанов и баров по обеспечению
питанием в железнодорожных вагонахресторанах и на
судах
232 Дата внесения записи в ЕГРЮЛ 09.11.2015
233 ГРН 5157746028259
 234 Порядковый номер 32
235 Код по ОКВЭД 56.30
236 Тип Дополнительный вид деятельности
237 Наименование вида деятельности Подача напитков
238 Дата внесения записи в ЕГРЮЛ 09.11.2015
239 ГРН 5157746028259
 240 Порядковый номер 33
241 Код по ОКВЭД 68.10
242 Тип Дополнительный вид деятельности
243 Наименование вида деятельности
Покупка и продажа собственного недвижимого
имущества
244 Дата внесения записи в ЕГРЮЛ 09.11.2015
245 ГРН 5157746028259
 246 Порядковый номер 34
247 Код по ОКВЭД 68.10.1
248 Тип Дополнительный вид деятельности
249 Наименование вида деятельности
Подготовка к продаже собственного недвижимого
имущества
250 Дата внесения записи в ЕГРЮЛ 09.11.2015
251 ГРН 5157746028259
 252 Порядковый номер 35
253 Код по ОКВЭД 68.20
254 Тип Дополнительный вид деятельности
255 Наименование вида деятельности
Аренда и управление собственным или арендованным
недвижимым имуществом
256 Дата внесения записи в ЕГРЮЛ 09.11.2015
257 ГРН 5157746028259
11258 Порядковый номер 36
259 Код по ОКВЭД 68.31
260 Тип Дополнительный вид деятельности
261 Наименование вида деятельности
Деятельность агентств недвижимости за вознаграждение
или на договорной основе
262 Дата внесения записи в ЕГРЮЛ 09.11.2015
263 ГРН 5157746028259
 264 Порядковый номер 37
265 Код по ОКВЭД 68.32
266 Тип Дополнительный вид деятельности
267 Наименование вида деятельности
Управление недвижимым имуществом за вознаграждение
или на договорной основе
268 Дата внесения записи в ЕГРЮЛ 09.11.2015
269 ГРН 5157746028259
 270 Порядковый номер 38
271 Код по ОКВЭД 73.11
272 Тип Дополнительный вид деятельности
273 Наименование вида деятельности Деятельность рекламных агентств
274 Дата внесения записи в ЕГРЮЛ 09.11.2015
275 ГРН 5157746028259
 276 Порядковый номер 39
277 Код по ОКВЭД 77.11
278 Тип Дополнительный вид деятельности
279 Наименование вида деятельности
Аренда и лизинг легковых автомобилей и легких
автотранспортных средств
280 Дата внесения записи в ЕГРЮЛ 09.11.2015
281 ГРН 5157746028259
 282 Порядковый номер 40
283 Код по ОКВЭД 77.29
284 Тип Дополнительный вид деятельности
285 Наименование вида деятельности
Прокат и аренда прочих предметов личного пользования
и хозяйственно-бытового назначения
286 Дата внесения записи в ЕГРЮЛ 09.11.2015
287 ГРН 5157746028259
 288 Порядковый номер 41
289 Код по ОКВЭД 77.34
290 Тип Дополнительный вид деятельности
291 Наименование вида деятельности
Аренда и лизинг водных транспортных средств и
оборудования
292 Дата внесения записи в ЕГРЮЛ 09.11.2015
293 ГРН 5157746028259
 294 Порядковый номер 42
295 Код по ОКВЭД 77.35
296 Тип Дополнительный вид деятельности
297 Наименование вида деятельности
Аренда и лизинг воздушных судов и авиационного
оборудования
12298 Дата внесения записи в ЕГРЮЛ 09.11.2015
299 ГРН 5157746028259
 300 Порядковый номер 43
301 Код по ОКВЭД 77.39.11
302 Тип Дополнительный вид деятельности
303 Наименование вида деятельности
Аренда и лизинг прочего автомобильного транспорта и
оборудования
304 Дата внесения записи в ЕГРЮЛ 09.11.2015
305 ГРН 5157746028259
 306 Порядковый номер 44
307 Код по ОКВЭД 77.39.24
308 Тип Дополнительный вид деятельности
309 Наименование вида деятельности
Аренда и лизинг профессиональной радио- и
телевизионной аппаратуры и аппаратуры связи
310 Дата внесения записи в ЕГРЮЛ 09.11.2015
311 ГРН 5157746028259
 312 Порядковый номер 45
313 Код по ОКВЭД 78.10
314 Тип Дополнительный вид деятельности
315 Наименование вида деятельности Деятельность агентств по подбору персонала
316 Дата внесения записи в ЕГРЮЛ 09.11.2015
317 ГРН 5157746028259
 318 Порядковый номер 46
319 Код по ОКВЭД 79.11
320 Тип Дополнительный вид деятельности
321 Наименование вида деятельности Деятельность туристических агентств
322 Дата внесения записи в ЕГРЮЛ 09.11.2015
323 ГРН 5157746028259
 324 Порядковый номер 47
325 Код по ОКВЭД 79.90.1
326 Тип Дополнительный вид деятельности
327 Наименование вида деятельности
Деятельность по предоставлению туристических
информационных услуг
328 Дата внесения записи в ЕГРЮЛ 09.11.2015
329 ГРН 5157746028259
 330 Порядковый номер 48
331 Код по ОКВЭД 79.90.2
332 Тип Дополнительный вид деятельности
333 Наименование вида деятельности
Деятельность по предоставлению экскурсионных
туристических услуг
334 Дата внесения записи в ЕГРЮЛ 09.11.2015
335 ГРН 5157746028259
 336 Порядковый номер 49
337 Код по ОКВЭД 79.90.3
13338 Тип Дополнительный вид деятельности
339 Наименование вида деятельности
Деятельность по предоставлению туристических услуг,
связанных с бронированием
340 Дата внесения записи в ЕГРЮЛ 09.11.2015
341 ГРН 5157746028259
 342 Порядковый номер 50
343 Код по ОКВЭД 81.22
344 Тип Дополнительный вид деятельности
345 Наименование вида деятельности
Деятельность по чистке и уборке жилых зданий и
нежилых помещений прочая
346 Дата внесения записи в ЕГРЮЛ 09.11.2015
347 ГРН 5157746028259
 348 Порядковый номер 51
349 Код по ОКВЭД 82.99
350 Тип Дополнительный вид деятельности
351 Наименование вида деятельности
Деятельность по предоставлению прочих
вспомогательных услуг для бизнеса, не включенная в
другие группировки
352 Дата внесения записи в ЕГРЮЛ 09.11.2015
353 ГРН 5157746028259
 354 Порядковый номер 52
355 Код по ОКВЭД 90.0
356 Тип Дополнительный вид деятельности
357 Наименование вида деятельности
Деятельность творческая, деятельность в области
искусства и организации развлечений
358 Дата внесения записи в ЕГРЮЛ 09.11.2015
359 ГРН 5157746028259
 360 Порядковый номер 53
361 Код по ОКВЭД 90.04
362 Тип Дополнительный вид деятельности
363 Наименование вида деятельности Деятельность учреждений культуры и искусства
364 Дата внесения записи в ЕГРЮЛ 09.11.2015
365 ГРН 5157746028259
 366 Порядковый номер 54
367 Код по ОКВЭД 93.29
368 Тип Дополнительный вид деятельности
369 Наименование вида деятельности Деятельность зрелищно-развлекательная прочая
370 Дата внесения записи в ЕГРЮЛ 09.11.2015
371 ГРН 5157746028259
 372 Порядковый номер 55
373 Код по ОКВЭД 93.29.9
374 Тип Дополнительный вид деятельности
375 Наименование вида деятельности
Деятельность зрелищно-развлекательная прочая, не
включенная в другие группировки
376 Дата внесения записи в ЕГРЮЛ 09.11.2015
377 ГРН 5157746028259
14 
 
 
 378 Порядковый номер 56
379 Код по ОКВЭД 96.02
380 Тип Дополнительный вид деятельности
381 Наименование вида деятельности
Предоставление услуг парикмахерскими и салонами
красоты
382 Дата внесения записи в ЕГРЮЛ 09.11.2015
383 ГРН 5157746028259
 384 Порядковый номер 57
385 Код по ОКВЭД 97.00
386 Тип Дополнительный вид деятельности
387 Наименование вида деятельности
Деятельность домашних хозяйств с наемными
работниками
388 Дата внесения записи в ЕГРЮЛ 09.11.2015
389 ГРН 5157746028259
СВЕДЕНИЯ О ПОСТАНОВКЕ НА УЧЕТ В НАЛОГОВОМ ОРГАНЕ
390 ИНН 7722345448
391 КПП 772201001
392 Дата постановки на учет в налоговом органе 09.11.2015
393 Дата снятия с учета
394 Код налогового органа 7722
395 Наименование налогового органа
Инспекция Федеральной налоговой службы  22 по
г.Москве
396 Дата внесения записи в ЕГРЮЛ 10.11.2015
397 ГРН 9157747614664
СВЕДЕНИЯ О РЕГИСТРАЦИИ В ПФ РОССИИ
398 ОГРН 5157746028259
399 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
400 Регномер ПФ 087512019415
401 Дата регистрации 11.11.2015
402 Дата снятия с учета
403 Наименование территориального органа ПФ
Государственное учреждение - Главное Управление
Пенсионного фонда РФ 3 по г. Москве и Московской
области муниципальный район Нижегородский г.Москвы
404 Дата внесения записи в ЕГРЮЛ 12.11.2015
405 ГРН 9157747716887
СВЕДЕНИЯ О РЕГИСТРАЦИИ В ФСС РОССИИ
406 ОГРН 5157746028259
407 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
408 Регномер ФСС 771307559677131
409 Дата первичной регистрации
410 Дата регистрации 11.11.2015
411 Дата снятия с учета
15 
412 Наименование исполнительного органа ФСС
Филиал 13 Государственного учреждения - Московского
регионального отделения Фонда социального
страхования Российской Федерации
413 Дата внесения записи в ЕГРЮЛ 12.11.2015
414 ГРН 9157747713554
СВЕДЕНИЯ О ЗАПИСЯХ В ЕГРЮЛ
415 Порядковый номер 1
416 ГРН 5157746028259
417 Дата внесения записи 09.11.2015
418 Событие, с которым связано внесение записи (Р11001) Создание ЮЛ
419 Наименование регоргана, в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы 
46 по г.Москве
420 Статус Действующая запись
421 ОГРН 5157746028259
422 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
 423 Порядковый номер 2
424 ГРН 9157747614664
425 Дата внесения записи 10.11.2015
426 Событие, с которым связано внесение записи Внесение сведений об учете в налоговом органе
427 Наименование регоргана, в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г. Москве
428 Статус Действующая запись
429 ОГРН 5157746028259
430 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
 431 Порядковый номер 3
432 ГРН 9157747713554
433 Дата внесения записи 12.11.2015
434 Событие, с которым связано внесение записи Внесение сведений о регистрации в ФСС РФ
435 Наименование регоргана, в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г. Москве
436 Статус Действующая запись
437 ОГРН 5157746028259
438 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
 439 Порядковый номер 4
440 ГРН 9157747716887
441 Дата внесения записи 12.11.2015
442 Событие, с которым связано внесение записи Внесение сведений о регистрации в ПФ РФ
443 Наименование регоргана, в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы
46 по г. Москве
444 Статус Действующая запись
445 ОГРН 5157746028259
446 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
 447 Порядковый номер 5
16 
448 ГРН 2177746184746
449 Дата внесения записи 10.01.2017
450 Событие, с которым связано внесение записи
(Р14001) Внесение изменений не связанных с
учредительными документами
451 Наименование регоргана, в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы 
46 по г.Москве
452 Статус Действующая запись
453 ОГРН 5157746028259
454 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
 455 Порядковый номер 6
456 ГРН 2177746195460
457 Дата внесения записи 10.01.2017
458 Событие, с которым связано внесение записи
(Р14001) Внесение изменений не связанных с
учредительными документами
459 Наименование регоргана, в котором внесена запись
Межрайонная инспекция Федеральной налоговой службы 
46 по г.Москве
460 Статус Действующая запись
461 ОГРН 5157746028259
462 Полное наименование ЮЛ
ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ
""ОТЕЛЬ СИТИ""
СВЕДЕНИЯ О ВЫДАННЫХ СВИДЕТЕЛЬСТВАХ
463 Номер свидетельства 017626286
464 Серия свидетельства 77
465 Дата выдачи 10.11.2015
466 Наименование регоргана, выдавшего свидетельство
Межрайонная инспекция Федеральной налоговой службы
46 по г. Москве
467 Статус Действующее
468 ГРН 5157746028259
17
" } }
                };
            }
        }
    }
}
