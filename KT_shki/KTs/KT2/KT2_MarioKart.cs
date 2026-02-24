using System;
using System.Collections.Generic;
using System.Linq;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        private List<Driver> _driversLibrary = new List<Driver>
        {
            new Driver("Mario", 0.5f),
            new Driver("Peach", 0.7f),
            new Driver("Bouzer", 1f),
        };

        private List<Transport> _transportsLibrary = new List<Transport>
        {
            //new SportsCar()
        };

        private Dictionary<Driver, DriverTrack> _driversInRace = new Dictionary<Driver, DriverTrack>(); // driver + track
        private int _driversCountInRace = 0;

        private float _raceTrackSize = 200f;
        private float _raceSectionSize = 10f;

        private string _raceStartChar = "!";
        private string _raceSectionChar = "-";
        private string _raceCarChar = ">";
        private string _raceFinishChar = "||";
        private string _raceBonusChar = "$";

        private bool _raceRunning = false;
        private Driver _raceWinner;

        public void Execute()
        {
            Helper.MakeAnIndentation("КТ2: Абстракция");

            InitGame();

            while (true)
            {
                Console.WriteLine("Выберите действие:\n >> 1 - Начать забег \n >> 2 - Настройки \n >> 0 - Завершить");

                string action = "";
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Helper.MakeAnIndentation(" STARTING RACE ");

                        string raceAction = "";
                        Helper.ActionReseter(ref raceAction);

                        _driversInRace.Add(_driversLibrary[])

                        switch (raceAction)
                        {
                            case " ":
                                if (!_raceRunning && _raceWinner != null) { _raceRunning = false; Console.WriteLine($"{_raceWinner} is won"); return; }

                                Console.Beep();
                                Tick();
                                break;
                            case "1":
                                break;
                            default:
                                break;
                        }

                        break;
                    case "2":

                        break;
                    case "0":
                        Console.WriteLine("\n bye KT2 \n");
                        return;
                    default:
                        Console.WriteLine("\n invalid \n");
                        break;
                }


            }
        }
        
        private void Tick() 
        {
            List<Driver> drivers = _driversInRace.Keys.ToList();
            List<DriverTrack> tracks = _driversInRace.Values.ToList();

            for (int i = 0; i < _driversCountInRace; i++)
            {
                Driver driver = drivers[i];
                DriverTrack track = tracks[i];
                Console.WriteLine();
                if (track.PassedDistance == 0)
                {
                    Console.Write(driver.Name[0] + _raceStartChar);
                }
            }
        }

        private void InitGame()
        {
            _raceRunning = true;

        }

        private void SpawnBonus(int currentPosIndex, int maxIndex) {

        }

        private void AddDriverToDic(Driver driver)
        {
            _driversInRace.Add(driver, new DriverTrack(driver, _raceTrackSize, _raceSectionSize));
            _driversCountInRace++;
        }

        public enum TransportType
        {
            Car,
            Plane,
            Boat
        }

        public interface IExtremeTransport
        {
            bool CanDoStunts(); // да / нет
            void PerformStunt(); // метод трюка
            float RiskFactor(); // промежуток от 0.0 - 1.0
        }

        public class DriverTrack
        {
            public Driver Driver => _driver;
            public float PassedDistance => _passedDistance;
            public bool IsOnBonus => _isOnBonus;

            public float TotalDistance => _totalDistance; // необязательно
            public Dictionary<int, float> BonusPos => _bonusPos;


            private Driver _driver;
            private float _passedDistance = 0f;
            private bool _isOnBonus = false;

            private float _totalDistance;
            private float _sectionDistance;

            private Dictionary<int, float> _bonusPos = new Dictionary<int, float>(); // id + pos

            public void MoveDriver(float distance)
            {
                _passedDistance += distance;
            }

            public DriverTrack(Driver driver, float totalDistance,  float sectionDistance)
            {
                _driver = driver;
                _passedDistance = totalDistance;
                _sectionDistance = sectionDistance;
            }
        }
    }
}