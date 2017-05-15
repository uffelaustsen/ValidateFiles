using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ValidateFiles
{
    public class AdvancedLeadRow 
    {
        public string Empty1 { get; set; }
        public bool Empty1HasValidationError { get; set; }

        public string Beløb { get; set; }
        public bool BeløbHasValidationError { get; set; }

        public string Navn { get; set; }
        public bool FirstNameHasValidationError
        {
            get
            {
                if (Navn.Length > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public string Efternavn { get; set; }
        public bool LastNameHasValidationError
        {
            get
            {
                if (Efternavn.Length > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public string Empty2 { get; set; }
        public bool Empty2HasValidationError { get; set; }

        public string Adresse { get; set; }
        public bool AdresseHasValidationError { get; set; }

        public string Postnr { get; set; }
        public bool PostnrHasValidationError { get; set; }

        public string Postdistrikt { get; set; }
        public bool PostdistriktHasValidationError { get; set; }

        public string Telefon { get; set; }
        public bool TelefonHasValidationError
        {
            get
            {
                if (ValidationHelper.DoesPhoneNumberValidatOK(Telefon, false) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public string Telefon2 { get; set; }
        public bool Telefon2HasValidationError
        {
            get
            {
                if (ValidationHelper.DoesPhoneNumberValidatOK(Telefon2, true) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public string Email { get; set; }
        public bool EmailHasValidationError
        {
            get
            {
                if (ValidationHelper.IsEmailValid(Email) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public string Empty3 { get; set; }
        public bool Empty3HasValidationError { get; set; }

        public string Regnr { get; set; }
        public bool RegnrHasValidationError
        {
            get
            {
                if (ValidationHelper.DoesRegnrValidatOK(Regnr) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        public string Kontonr { get; set; }
        public bool KontonrHasValidationError
        {
            get
            {
                if (ValidationHelper.DoesKontonrValidatOK(Kontonr) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        public string CPR { get; set; }
        public bool CPRHasValidationError
        {
            get
            {
                if (ValidationHelper.IsCprValid(CPR) == ValidationHelper.CprValidity.Invalid)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public string Empty4 { get; set; }
        public bool Empty4HasValidationError { get; set; }

        public string Empty5 { get; set; }
        public bool Empty5HasValidationError { get; set; }

        public string Empty6 { get; set; }
        public bool Empty6HasValidationError { get; set; }

        public string Empty7 { get; set; }
        public bool Empty7HasValidationError { get; set; }

        public string Empty8 { get; set; }
        public bool Empty8HasValidationError { get; set; }

        public string Empty9 { get; set; }
        public bool Empty9HasValidationError { get; set; }

        public string EntryCode { get; set; }
        public bool EntryCodeHasValidationError { get; set; }

        public string Empty10 { get; set; }
        public bool Empty10HasValidationError { get; set; }

        public string Empty11 { get; set; }
        public bool Empty11HasValidationError { get; set; }

        public string StartDato { get; set; }
        public bool StartDatoHasValidationError { get; set; }



        public void MakeRelevantPropertiesPascalCase()
        {
            Navn = ValidationHelper.MakeStringPascalCase(Navn);
            Efternavn = ValidationHelper.MakeStringPascalCase(Efternavn);
            Adresse = ValidationHelper.MakeStringPascalCase(Adresse);
            Postdistrikt = ValidationHelper.MakeStringPascalCase(Postdistrikt);
        }

        public void RemoveDashAndDotFromRelevantProperties()
        {
            StartDato = ValidationHelper.RemoveDashAndDotFromString(StartDato);
        }
            


    }

}
