using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentPreparer.Models;
using DocumentPreparer.Common;
using DocumentPreparer.Processers;
using DocumentPreparer.Extensions;
using DocumentPreparer.Refs;

namespace DocumentPreparer.Retrievers
{
    public class PropertiesRetrievers : IPropertiesRetrievers
    {
        public Dictionary<string, PropertyRetriever> Get()
        {
            PropertyRetriever[] propertiesRetrievers = new PropertyRetriever[]
            {
                new PropertyRetriever { Name = PropertyRetrieversRefs.GeneralInfo.ShortName, RegExPattern = "сокращенное наименование\r?\n(?<value>.*)\r?\n" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.GeneralInfo.FullName, RegExPattern = @"полное наименование\r?\n(?<value>[\S\s]*?)\r?\nсокращенное наименование", Processer = CommonHelper.MultiLineProcesser },
                new PropertyRetriever { Name = PropertyRetrieversRefs.GeneralInfo.InitialRegistrationDate, RegExPattern = @"дата регистрации\r?\n.*\s(?<value>\d{1,2}\.\d{1,2}\.\d{4})\r?\n" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.GeneralInfo.RegistrationNumber, RegExPattern = @"реквизиты адреса и контакты[\S\s]*огрн: (?<value>\d*)\r?\n" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.GeneralInfo.INN, RegExPattern = @"реквизиты адреса и контакты[\S\s]*?инн: (?<value>\d*)\r?\n" },
                new PropertyRetriever {
                    Name = "MainAddress",
                    RegExPattern = @"юридический адрес(?<value>[\s\S]*?)(?>фактический адрес|управление аффилированность)",
                    Processer = CommonHelper.MultiLineProcesser
                },
                new PropertyRetriever { Name = "OtherAddresses",
                    RegExPattern = @"фактический адрес(?<value>[\s\S]*?)(?>телефон|управление аффилированность)",
                    Processer = CommonHelper.MultiLineProcesser
                },
                new PropertyRetriever
                {
                    Name = "Contacts", RegExPattern = @"телефон:(?<value>[\S\s]+)управление аффилированность",
                    Processer = (input) => {
                        return string.Join(", ", input.Split(new [] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Replace("телефон:", "", StringComparison.CurrentCultureIgnoreCase).Replace("сайт:", "", StringComparison.CurrentCultureIgnoreCase).Trim()));
                    }
                },
                new PropertyRetriever { Name = "AuthorizedCapital", RegExPattern = @"уставный капитал дата регистрации\r?\n(?<value>.*)\w\d{1,2}\.\d{1,2}\.\d{4}" },
                new PropertyRetriever { Name = "MainActivity", RegExPattern = @"основной вид деятельности\r?\n[\d\.]*\s(?<value>[\S\s]*)дополнительные виды деятельности", Processer = CommonHelper.MultiLineProcesser },
                new PropertyRetriever { Name = "State", RegExPattern = @"сокращенное наименование\n[\S\s]*""\r?\n(?<value>[\S\s]*)сведения о юр", Processer = CommonHelper.MultiLineProcesser },
                new PropertyRetriever { Name = "NameChanges", RegExPattern = @"наименование\r?\nДата Изменение(?<value>[\S\s]*?)управление", Processer = CommonHelper.MultiLineJoiner },
                new PropertyRetriever { Name = PropertyRetrieversRefs.Management.Individual, RegExPattern = @"имеющих[\s\n]право[\s\n]действовать[\s\n]без[\s\n]доверенности\n(?<value>[\S\s]+?)\d+\sогрн" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.Management.IndividualAffiliations, RegExPattern = @"УПРАВЛЕНИЕ АФФИЛИРОВАННОСТЬ[\S\s]+дата вступления.+\n(?<value>[\S\s]+?)(?>УЧРЕДИТЕЛИ АФФИЛИРОВАННОСТЬ|\Z)" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.Management.Entity, RegExPattern = @"сведения[\s\n]об[\s\n]управляющей[\s\n]компании\n(?<value>[\S\s]+?)\d+\sполное наименование юл" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.Founders.LECommon, RegExPattern = @"УЧРЕДИТЕЛИ ДОЛЯ АФФИЛИРОВАННОСТЬ(?<value>[\S\s]*)ВИДЫ ЭКОНОМИЧЕСКОЙ ДЕЯТЕЛЬНОСТИ" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.Founders.NPCommon, RegExPattern = @"УЧРЕДИТЕЛИ ДОЛЯ АФФИЛИРОВАННОСТЬ(?<value>[\S\s]+?)лицензии" },
                new PropertyRetriever { Name = PropertyRetrieversRefs.ExtractEGRUL.AuthorizedCapital, RegExPattern = @"СВЕДЕНИЯ[\s\n]ОБ[\s\n]УСТАВНОМ[\s\n]КАПИТАЛЕ[\S\s]+Размер[\s\n]?\(в рублях\)\s(?<value>\d+([,\.]d+)?)" }
            };

            var noValueRule = propertiesRetrievers.FirstOrDefault(pr => pr.RegExPattern.IndexOf("?<value>") == -1);
            if (noValueRule != null)
                throw new Exception(string.Format("В правиле {0} отсутствует именованная группа value", noValueRule.Name));

            return propertiesRetrievers.ToDictionary(x => x.Name, x => x);
        }
    }
}
