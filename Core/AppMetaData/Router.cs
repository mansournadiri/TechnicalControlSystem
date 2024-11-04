using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppMetaData
{
    public static class Router

    {
        public const string singleRoute = "/{id}";
        public const string root = "api";
        public const string version = "v1";
        public const string rule = root + "/" + version + "/";

        public static class RepositoryRouting
        {
            public const string Prefix = rule + "Repository";
            public static class Actions
            {
                public const string Create = Prefix + "/Create";
                public const string GetById = Prefix + singleRoute;
                public const string GetAll = Prefix + "/All";
                public const string Update = Prefix + singleRoute;
                public const string Delete = Prefix + singleRoute;
            }
        }
        public static class RepositoryFolderRouting
        {
            public const string Prefix = rule + "RepositoryFolder";

            public static class Actions
            {
                public const string CreateFolder = Prefix + "/CreateFolder";
                public const string GetFolderContents = Prefix + "/GetFolderContents";
                public const string GetFolderById = Prefix + "/GetFolderById";
                public const string GetFoldersByParentId = Prefix + "/GetFoldersByParentId";
                public const string EditName = Prefix + "/EditName";
            }
        }
        public static class AuthRouting
        {
            public const string Prefix = rule + "Auth";
            public static class Actions
            {
                public const string Login = Prefix + "/Login";
                public const string Register = Prefix + "/Register";
                public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
                public const string ResetPassword = Prefix + "/ResetPassword";
            }
        }
        public static class EmailsRoute
        {
            public const string Prefix = rule + "Emails";
            public static class Actions
            {
                public const string SendEmail = Prefix + "/SendEmail";
            }
        }
    }
}
