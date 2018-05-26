using SomethingToCode.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SomethingToCode.Web.Helpers
{
    public class CommonHelper : GlobalCommonHelper
    {
        public static string AvtarPath = "~/UserUploads/Avtar";
        public static string CategoryImages = "~/UserUploads/Category";

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


        /// <summary>
        /// Verifies that a uploading file is in valid Image format
        /// </summary>
        /// <author>
        /// Mayur Lohite
        /// </author>
        /// <param name="postedFile">File which is selected for upload</param>
        /// <param name="imageMinBytes">Minimum file size in byte</param>
        /// <param name="imageMaxBytes">Maximum file size in byte</param>
        /// <returns>true if the file is a valid image format and false if it's not</returns>
        public static bool IsValidImageFormat(HttpPostedFileBase postedFile, int imageMinBytes, long imageMaxBytes)
        {

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image MIME types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/gif" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }



            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.InputStream.CanRead)
                {
                    return false;
                }

                if (postedFile.ContentLength < imageMinBytes)
                {
                    return false;
                }

                if (postedFile.ContentLength > imageMaxBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                postedFile.InputStream.Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static string UploadPicture(HttpPostedFileBase image, string imageType)
        {
            string oriPhotoName;
            string dbPhotoName;
            string directoryPath;
            string dbPhotoPath;
            // Checking for Internet Explorer  

            if (image == null)
            {
                return null;
            }

            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
            {
                string[] testfiles = image.FileName.Split(new char[] { '\\' });
                oriPhotoName = testfiles[testfiles.Length - 1];
            }
            else
                oriPhotoName = image.FileName;

            string firstTwoChars = string.Empty;
            string secondTwoChars = string.Empty;
            dbPhotoName = CommonHelper.GenerateFileNameGuid(oriPhotoName, out firstTwoChars, out secondTwoChars);
            dbPhotoPath = HttpContext.Current.Server.MapPath(imageType + "/" + dbPhotoName);
            directoryPath = HttpContext.Current.Server.MapPath(imageType + "/" + firstTwoChars + "/" + secondTwoChars);
            Directory.CreateDirectory(directoryPath);
            image.SaveAs(dbPhotoPath);

            return dbPhotoName;
        }

    }
}