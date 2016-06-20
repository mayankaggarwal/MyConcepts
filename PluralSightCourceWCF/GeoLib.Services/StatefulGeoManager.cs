using GeoLib.Contracts;
using GeoLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Services
{
    public class StatefulGeoManager : IStatefulGeoService
    {
        private string zip;

        public StatefulGeoManager()
        {
            zip = string.Empty;
        }

        public void PushZip(string zip)
        {
            if (!String.IsNullOrWhiteSpace(zip))
                this.zip = zip;
        }

        public ZipCodeData GetZipInfo()
        {
            ZipCodeData zipCodeData = null;
            if (!String.IsNullOrWhiteSpace(this.zip))
            {
                IZipCodeRepository zipCodeRepository = new ZipCodeRepository();

                ZipCode zipCode = zipCodeRepository.GetByZip(this.zip);
                if (zipCode != null)
                {
                    zipCodeData.City = zipCode.City;
                    zipCodeData.ZipCode = zipCode.Zip;
                    zipCodeData.State = zipCode.State.Abbreviation;
                }
            }

            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(int range)
        {
            List<ZipCodeData> lstZipCodeData = null;
            if (!String.IsNullOrWhiteSpace(this.zip))
            {
                IZipCodeRepository zipCodeRepository = new ZipCodeRepository();
                IEnumerable<ZipCode> zipCodeList = zipCodeRepository.GetZipsForRange(new ZipCode
                {
                    Zip = this.zip
                }, range);

                if (zipCodeList != null)
                {
                    lstZipCodeData = new List<ZipCodeData>();
                    foreach (ZipCode zipCode in zipCodeList)
                    {
                        lstZipCodeData.Add(new ZipCodeData
                        {
                            ZipCode = zipCode.Zip,
                            City = zipCode.City,
                            State = zipCode.State.Abbreviation
                        });
                    }
                }
            }
            return lstZipCodeData;
        }

    }
}
