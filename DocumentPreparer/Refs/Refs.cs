using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentPreparer.Processers;

namespace DocumentPreparer.Refs
{
    public static class BlockHeadersRefs
    {
        public const string GeneralInfo = "GeneralInfo";
        public const string ChangesHistory = "ChangesHistory";
        public const string ExtractFromEGRUL = "ExtractFromEGRUL";
        public const string Affiliation = "Affiliation";
        public const string EstablishedEnterprises = "EstablishedEnterprises";
    }

    public static class PropertyRetrieversRefs
    {
        public static class GeneralInfo
        {
            public static string ShortName = "ShortName";
            public static string FullName = "FullName";
            public static string InitialRegistrationDate = "InitialRegistrationDate";
            public static string RegistrationNumber = "RegistrationNumber";
            public static string INN = "INN";
        }

        public static class Management
        {
            public static string Individual = "Individual";
            public static string IndividualAffiliations = "IndividualAffiliations";
            public static string Entity = "Entity";
        }

        public static class ExtractEGRUL
        {
            public static string AuthorizedCapital = "EGRULAuthorizedCapital";
        }

        public static class Founders
        {
            public static string LECommon = "LECommon";
            public static string NPCommon = "NPCommon";
        }
    }
}
