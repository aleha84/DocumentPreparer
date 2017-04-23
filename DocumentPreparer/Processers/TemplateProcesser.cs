using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentPreparer.Models;
using Novacode;
using DocumentPreparer.Extensions;
using DocumentPreparer.Attributes;
using System.Reflection;

namespace DocumentPreparer.Processers
{
    public class TemplateProcesser : ITemplateProcesser
    {
        private DocX docx; 

        public DocX Process(string templatePath, DocumentModel documentModel)
        {
            if (string.IsNullOrEmpty(templatePath))
                throw new ArgumentNullException("templatePath");

            if (!System.IO.File.Exists(templatePath))
                throw new ArgumentException(string.Format("Файл '{0}' не существует", templatePath));

            if (documentModel == null)
                throw new ArgumentNullException("documentModel");

            if(documentModel.GeneralInfoBlock == null)
                throw new ArgumentNullException("documentModel.GeneralInfoBlock");

           docx = DocX.Load(templatePath);
       
            //tests
            //documentModel.FoundersLE = new FounderLE[] { new FounderLE(), new FounderLE(), new FounderLE(), new FounderLE(), new FounderLE() };
            ProcessProperties(documentModel, string.Empty);

            return docx;
        }

        private void ProcessProperties(object obj, string parentName)
        {
            foreach(var prop in obj.GetType().GetProperties())
            {
                var propertyValue = prop.GetValue(obj, null);
                if (prop.PropertyType.IsArray)
                {
                    var array = (object[])propertyValue;
                    var propFullName = GetPropertyNameWithParentName(parentName, prop.Name);
                    var paragraph = docx.Paragraphs.FirstOrDefault(p => p.FindAll(propFullName).Count > 0);
                    var targetTable = paragraph.FollowingTable;

                    var additionType = GetArrayItemAdditionType(prop);

                    if(additionType == ArrayItemAdditionType.AddAsTable)
                    {
                        if (array.Length > 0)
                        {
                            for (var arrIndex = 1; arrIndex < array.Length + 1; arrIndex++) //+1 special hack, to add extra 1 table, and delete it, to preserve needed amount
                            {
                                paragraph.InsertTableAfterSelf(targetTable);
                                targetTable = paragraph.FollowingTable;
                                targetTable.Paragraphs.ForEach(tableParagraph =>
                                {
                                    tableParagraph.FindAll(string.Format("%{0}[{1}]", propFullName, arrIndex - 1))
                                    .ForEach(index => tableParagraph.ReplaceText(string.Format("%{0}[{1}]", propFullName, arrIndex - 1), string.Format("%{0}[{1}]", propFullName, arrIndex)));
                                });
                            }

                        }

                        targetTable.Remove();

                        paragraph.Remove(false);

                        for (var arrIndex = 0; arrIndex < array.Length; arrIndex++)
                        {
                            var arrTypeProperties = array[arrIndex].GetType().GetProperties();
                            foreach (var arrItemProp in arrTypeProperties)
                            {
                                var arryaItemPropValue = arrItemProp.GetValue(array[arrIndex], null);
                                var template = GetPropertyNameWithParentName(string.Format("{0}[{1}]", propFullName, arrIndex), arrItemProp.Name);
                                docx.ReplaceText(template, arryaItemPropValue == null ? string.Empty : arryaItemPropValue.ToString());
                            }
                        }
                    }
                    else if(additionType == ArrayItemAdditionType.AddAsRow)
                    {
                        var row = targetTable.InsertRow();
                        //ADD DATA
                        targetTable.Rows.Add(row);
                    }

                }
                else if (prop.PropertyType.IsClass
                    && !prop.PropertyType.FullName.StartsWith("System"))
                {
                    ProcessProperties(propertyValue,
                        (parentName.IsNullOrEmpty() ? string.Empty : parentName+".") +  prop.Name);
                }
                else
                {
                    var template = GetPropertyNameWithParentName(parentName, prop.Name);
                    docx.ReplaceText(template, propertyValue == null ? string.Empty : propertyValue.ToString());
                }
            }
        }

        private string GetPropertyNameWithParentName(string parentName, string propName)
        {
            if(parentName.IsNullOrEmpty())
                return propName;

            return string.Format("%{0}.{1}%", parentName, propName);
        }

        private ArrayItemAdditionType GetArrayItemAdditionType(PropertyInfo prop)
        {
            var result = ArrayItemAdditionType.AddAsTable;

            return result;
        }
    }
}
