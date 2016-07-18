using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class MasterService : IMasterService
    {
        private readonly IAlgoService _algoService;

        private readonly IDataService _dataService;
        
        public MasterService(IAlgoService algo, IDataService data)
        {
            _algoService = algo;
            _dataService = data;
        }

        public int GetDoubleSum()
        {
            if (IsNullOrEmpty(_dataService.GetAllData()))
            {
                throw new InvalidOperationException("We have no data to process");
            }

            var data = _dataService.GetAllData();

            return _algoService.DoubleSum(data);;
        }

        //TODO: Make more methods

        public double GetAverage()
        {
            if (IsNullOrEmpty(_dataService.GetAllData()))
            {
                throw new InvalidOperationException("We have no data to process");
            }

            var data = _dataService.GetAllData();

            return _algoService.GetAverage(data);
        }

        public double GetMaxSquare()
        {
            if (IsNullOrEmpty(_dataService.GetAllData()))
            {
                throw new InvalidOperationException("We have no data to process");
            }

            var data = _dataService.GetMax();
            return _algoService.Sqr(data);
        }


        /////////////////////////////////////
        public double GetMinSquare()
        {
            if (IsNullOrEmpty(_dataService.GetAllData()))
            {
                throw new InvalidOperationException("We have no data to process");
            }
            var data = _algoService.MinValue(_dataService.GetAllData());
            return _algoService.Sqr(data);
        }

        public double SqrGetElementAt(int a)
        {
            if (IsNullOrEmpty(_dataService.GetAllData()))
            {
                throw new InvalidOperationException("We have no data to process");
            }

            var elem = _dataService.GetElementAt(a);

            return _algoService.Sqr(elem);
        }


        public static bool IsNullOrEmpty(IEnumerable<int> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }
    }
}