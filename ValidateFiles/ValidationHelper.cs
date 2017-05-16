using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ValidateFiles
{
    public static class ValidationHelper
    {
        public static bool IsEmailValid(string email)
        {

            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public static bool DoesAddressValidatOK(string address)
        {
            bool isAddressOK = false;
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");

            string status = (string)
                (from el in xdoc.Descendants("status")
                 select el).First();

            string formattedAddress = (string)
                (from el in xdoc.Descendants("formatted_address")
                 select el).First();

            foreach (XElement e in xdoc.Descendants("status"))
            {
                Console.WriteLine("Descendants : " + e.Value);
                if ((e.Value == "OK") && (formattedAddress.ToLower() == address.ToLower()))
                {
                    isAddressOK = true;
                }
                else
                {
                    isAddressOK = false;
                }
            }

            return isAddressOK;


        }

        public enum CprValidity { Valid, MaybeValid, Invalid }

        public static CprValidity IsCprValid(string cpr)
        {

            if (cpr == null)
                throw new ArgumentNullException();

            //"-" is required
            if(cpr.Contains("-") == false)
                return CprValidity.Invalid;

            //Days larger than 31
            if(int.Parse(cpr.Substring(0,2)) > 31)
            {
                return CprValidity.Invalid;
            }

            //Months larger than 12
            if (int.Parse(cpr.Substring(2, 2)) > 12)
            {
                return CprValidity.Invalid;
            }


            cpr = cpr.Replace("-", "");

            if (cpr.Length != 10)
                return CprValidity.Invalid;

            int sum = 0;
            int[] check = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2, 1 };
            try
            {
                for (int i = 0; i < check.Length; i++)
                    sum += int.Parse(cpr.Substring(i, 1)) * check[i];
            }
            catch (FormatException)
            {
                return CprValidity.Invalid;
            }

            if (sum % 11 == 0)
                return CprValidity.Valid;
            else
                return CprValidity.MaybeValid;
        }

        public static bool DoesRegnrValidatOK(string regnr)
        {
            if ((regnr.Length == 4) && (regnr.Substring(0, 4) != "4571"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool DoesKontonrValidatOK(string kontonr)
        {
            if (kontonr.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string MakeStringPascalCase(string stringToChange)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(stringToChange);

        }

        public static string RemoveDashAndDotFromString(string stringToChange)
        {
            string result = stringToChange.Replace("-", "");
            result = result.Replace(".", "");
            result = result.Replace("00:00:00", "");
            return result;

        }

        //public static string MakeStringUTF8Encoded(string stringToEncode)
        //{
        //    byte[] data = Encoding.GetEncoding(1252).GetBytes(stringToEncode);
        //    return Encoding.UTF8.GetString(data);
        //}

        //public static string GetØÆFromWeirdCharacters(string stringReplaceCharactersIn)
        //{
        //    string result;
        //    result = stringReplaceCharactersIn.Replace("ã¥", "å");
        //    result = stringReplaceCharactersIn.Replace("ã¦", "æ");
        //    return result;
        //}

        public static bool DoesPhoneNumberValidatOK(string phoneNumber, bool blankPhoneNumberAllowed)
        {
            if (blankPhoneNumberAllowed == false)
            {
                if ((phoneNumber == null) || (phoneNumber.Length == 0))
                {
                    return false;
                }
            }
            else
            {
                if ((phoneNumber == null) || (phoneNumber.Length == 0))
                {
                    return true;
                }
            }


            if (phoneNumber.Contains("+45"))
            {
                if (phoneNumber.Length == 11)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (phoneNumber.Length == 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            }
        }
    }

