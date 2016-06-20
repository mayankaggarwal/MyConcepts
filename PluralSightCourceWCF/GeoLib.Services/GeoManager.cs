using GeoLib.Contracts;
using GeoLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Services
{
    [ServiceBehavior(UseSynchronizationContext =false,InstanceContextMode = InstanceContextMode.PerSession)]
    public class GeoManager : IGeoService
    {
        #region class Initializers
        public GeoManager()
        {

        }

        IStateRepository _stateRepository;
        IZipCodeRepository _zipRepository;
        int _counter = 0;
        public GeoManager(IStateRepository stateRepository)
        {
            this._stateRepository = stateRepository;
        }

        public GeoManager(IZipCodeRepository zipRepository)
        {
            this._zipRepository = zipRepository;
        }

        public GeoManager(IStateRepository stateRepository, IZipCodeRepository zipRepository)
        {
            this._zipRepository = zipRepository;
            this._stateRepository = stateRepository;
        }

        #endregion

        public ZipCodeData GetZipInfo(string zip)
        {
            ZipCodeData zipCodeData = null;

            IZipCodeRepository zipCodeRepository = _zipRepository ?? new ZipCodeRepository();
            ZipCode zipCode = zipCodeRepository.GetByZip(zip);
            if (zipCode != null)
            {
                zipCodeData = new ZipCodeData
                {
                    City = zipCode.City,
                    State = zipCode.State.Abbreviation,
                    ZipCode = zipCode.Zip,
                };
            }
            _counter++;
            Console.WriteLine("Counter = {0}", _counter);
            return zipCodeData;
        }

        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            List<string> statesList = new List<String>();

            IStateRepository statepository = _stateRepository ?? new StateRepository();
            IEnumerable<State> states = statepository.Get(primaryOnly);
            if (states != null)
            {
                foreach (State state in states)
                {
                    statesList.Add(state.Abbreviation);
                }
            }

            return statesList;

        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            List<ZipCodeData> zipCodeDataList = new List<ZipCodeData>();

            IZipCodeRepository zipRepository = _zipRepository ?? new ZipCodeRepository();

            IEnumerable<ZipCode> zipCodeList = zipRepository.GetByState(state);
            if (zipCodeList != null)
            {
                foreach (ZipCode zipCode in zipCodeList)
                {
                    zipCodeDataList.Add(new ZipCodeData
                    {
                        City = zipCode.City,
                        ZipCode = zipCode.Zip,
                        State = zipCode.State.Abbreviation
                    });
                }
            }

            return zipCodeDataList;
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            List<ZipCodeData> zipCodeDataList = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipRepository ?? new ZipCodeRepository();

            IEnumerable<ZipCode> zipCodeList = zipCodeRepository.GetZipsForRange(new ZipCode
            {
                Zip = zip
            }, range);

            if (zipCodeList != null)
            {
                foreach (ZipCode zipCode in zipCodeList)
                {
                    zipCodeDataList.Add(new ZipCodeData
                    {
                        City = zipCode.City,
                        ZipCode = zipCode.Zip,
                        State = zipCode.State.Abbreviation
                    });
                }
            }

            return zipCodeDataList;
        }

        public void PushZip(string zip)
        {
            throw new NotImplementedException();
        }

        public ZipCodeData GetZipInfo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZipCodeData> GetZips(int range)
        {
            throw new NotImplementedException();
        }
    }
}
