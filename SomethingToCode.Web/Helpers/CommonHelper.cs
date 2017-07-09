using SomethingToCode.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomethingToCode.Web.Helpers
{
    public class CommonHelper : GlobalCommonHelper
    {
        public static string AvtarPath = "~/UserUploads/Avtar";
        public static string GamePlatform = "~/UserUploads/GamePlatform";
        public static string ArticleImg = "~/UserUploads/Article/Images";

        public enum EnumErrorMessages
        {
            ERROR,
            SUCCESS,
            INFO,
            WARNING
        };

        public static string GenerateMessage(string message, Enum ErrorType)
        {
            string msg = string.Empty;

            switch (Convert.ToInt32(ErrorType))
            {
                case 0:
                    msg = @"<div class='alert alert-danger alert-dismissable'>
                            <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                            <h4><i class='icon fa fa-ban'></i> Alert!</h4>" +
                             message +
                           @"</div>";
                    break;

                case 1:
                    msg = @"<div class='alert alert-success alert-dismissable'>
                            <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                            <h4><i class='icon fa fa-check'></i> Alert!</h4>" +
                            message +
                          @"</div>";
                    break;

                case 2:
                    msg = @"<div class='alert alert-info alert-dismissable'>
                            <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                            <h4><i class='icon fa fa-info'></i> Alert!</h4>" +
                            message +
                          @"</div>";
                    break;

                case 3:
                    msg = @"<div class='alert alert-warning alert-dismissable'>
                            <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                            <h4><i class='icon fa fa-warning'></i> Alert!</h4>" +
                            message +
                          @"</div>";
                    break;

                default:
                    break;
            }


            return msg;
        }

        
    }
}