using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private string _playersName = "U";
        private float _playersSkill = 0.5f;

        private Driver _player;
        private Transport _playersTransport;
        private DriverTrack _playersTrack;

        private List<Transport> _transportsLibrary = new List<Transport>
        {
            new SportsCar(null, "Ferari", 20f, TransportType.Car, "FEWFEWFEWFEWFEW"),
            new Airplane(null, "SoSAAAL", 15f, TransportType.Plane, "AJKOSGHDYASFDAGSJDBASD"),
            new Taxi(null, "Yandex", 10f, TransportType.Car, "brbrbrbrbr"),
        };


        private Dictionary<DriverTrack, Transport> _driversInRace = new Dictionary<DriverTrack, Transport>(); // track + driver
        private int _driversCountInRace = 0;

        private float _raceTotalTrackSize = 200f;
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

            ResetRace();

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

                        if (_driversCountInRace == 0)
                            InitLazyPlayer();

                        Tick();
                        
                        while (true)
                        {
                            Console.WriteLine("\nВыберите действие: " +
                                "\n >> space - чтобы продвинуться дальше" +
                                "\n >> 1 - чтобы заправиться" +
                                "\n >> 2 - чтобы подобрать бонус" + // если есть
                                "\n ... " +
                                "\n >> 0 - чтобы завершить гонку"); 

                            string raceAction = "";
                            Helper.ActionReseter(ref raceAction);

                            Console.Clear();

                            switch (raceAction)
                            {
                                case " ":
                                    // end race
                                    if (!_raceRunning && _raceWinner != null) { _raceRunning = false; Console.WriteLine($"{_raceWinner} is won"); return; }
                                    // если топлива недостаточно -> сказать и вернуть обратно
                                    Move(_playersTransport, ref _playersTrack);

                                    Console.Beep();
                                    Tick();
                                    break;
                                case "1": 
                                    Tick();
                                    break;
                                case "2":
                                    Tick();
                                    break;
                                case "0":
                                    Console.WriteLine("\n н и к т о н е в ы и г р а л \n");
                                    return;
                                default:
                                    Console.WriteLine("\n no action \n");
                                    break;
                            }
                        }
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
        
        private void Move(Transport transport, ref DriverTrack track)
        {
            // init transport 
            transport.MaxSpeed(transport.Pilot.DriverSkill); // безполезное вычисление Так как это void

            double badLuck = 0.25d * transport.Pilot.DriverSkill;
            double random = Helper.random.NextDouble();

            float speedPenalty = 2f;

            float distance;

            if (random <= badLuck) // прок?
                distance = Convert.ToInt64(transport.MaxTransportSpeed / speedPenalty);
            else
                distance = Convert.ToInt64(transport.MaxTransportSpeed * random);

            track.MoveDriver(distance);
        }

        private void Tick() 
        {
            List<DriverTrack> tracks = _driversInRace.Keys.ToList();
            List<Transport> transport = _driversInRace.Values.ToList();

            for (int i = 0; i < _driversCountInRace; i++)
            {
                // init driver + track
                Driver driver = transport[i].Pilot;
                DriverTrack track = tracks[i];

                // find sectionCount + playerPosInSection

                int sectionCount, driverSection;

                sectionCount = Convert.ToInt32(_raceTotalTrackSize / _raceSectionSize);
                if (track.PassedDistance <= 0)
                    driverSection = 0;
                else
                    driverSection = Convert.ToInt32(_raceTotalTrackSize / track.PassedDistance);

                #region Track
                // init trackDisplay
                string originalTrack = "";
                StringBuilder finalTrack = new StringBuilder(); // нейро подсказало

                // write all sections
                for (int j = 0; j < sectionCount; j++) 
                    originalTrack += _raceSectionChar;
                finalTrack.Append(originalTrack);

                if (driverSection == 0) // В начале
                {
                    finalTrack[0] = _raceStartChar[0];
                    finalTrack.Insert(driverSection, Convert.ToString(driver.Name[0]), 1);
                    finalTrack.Insert(driverSection + 1, _raceCarChar, 1);
                }

                if (track.IsOnBonus)
                {
                    Console.WriteLine("blah");
                }

                // finish
                finalTrack.Append(_raceFinishChar);

                //// init Player
                //finalTrack[playerSection] = driver.Name[0]; 
                //// init car
                //if (!track.IsOnBonus)
                //{
                //    finalTrack.Insert(playerSection + 1, _raceCarChar, 1);
                //} else
                //{
                    
                //}
                
                foreach (var item in track.BonusPos)
                    finalTrack[item] = _raceBonusChar[0];
                #endregion

                Console.WriteLine(finalTrack);

                if (track.PassedDistance > _raceTotalTrackSize)
                {
                    _raceWinner = driver;
                    _raceRunning = false;
                }
            }

            Console.WriteLine();
        }

        private void InitGame()
        {
            _raceRunning = true;
            Tick();
        }

        private void CreateBot(out Transport transport, out DriverTrack track)
        {
            Driver newBot = _driversLibrary[Helper.random.Next(0, _driversLibrary.Count)];
            transport = _transportsLibrary[Helper.random.Next(0, _transportsLibrary.Count)];
            transport.ChangeDriver(newBot);

            track = new DriverTrack(newBot, _raceTotalTrackSize, _raceSectionSize);
        }

        private void InitPlayer(Transport transport)
        {
            _player = new Driver(_playersName, _playersSkill);
            _playersTransport = transport;

            _playersTransport.ChangeDriver(_player);
            _playersTrack = new DriverTrack(_player, _raceTotalTrackSize, _raceSectionSize);
        }

        private void InitLazyPlayer()
        {
            InitPlayer(_transportsLibrary[Helper.random.Next(_transportsLibrary.Count)]);

            _driversInRace.Add(_playersTrack, _playersTransport);
            _driversCountInRace++;

            CreateBot(out Transport bot1, out DriverTrack track1);
            _driversInRace.Add(track1, bot1);
            _driversCountInRace++;

            CreateBot(out Transport bot2, out DriverTrack track2);
            _driversInRace.Add(track2, bot2);
            _driversCountInRace++;
        }

        private void TryToRollBonus(int currentPos, int maxPos, ref DriverTrack track)
        {
            int chance = Helper.random.Next(1, 101);

            if (chance <= 15)
            {
                SpawnBonus(currentPos, maxPos, ref track); // todo
            }
        }

        private void SpawnBonus(int currentPos, int maxPos, ref DriverTrack track) {

        }

        private void ResetRace()
        {
            _driversInRace.Clear();
            _driversCountInRace = _driversInRace.Count;
        }

        //private void AddDriverToDic(Driver driver)
        //{
        //    _driversInRace.Add(driver, new DriverTrack(driver, _raceTotalTrackSize, _raceSectionSize));
        //    _driversCountInRace++;
        //}

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
            #region Public
            public Driver Driver => _driver;
            public float PassedDistance => _passedDistance;
            public bool IsStunned => _isStunned;
            public bool IsOnBonus => _isOnBonus;
            public List<int> BonusPos => _bonusPos;
            #endregion


            private Driver _driver;
            private float _passedDistance = 0f;
            private bool _isStunned = false;

            private float _totalDistance;
            private float _sectionDistance;

            private bool _isOnBonus = false;
            private List<int> _bonusPos = new List<int>(); // id + posIndex

            public void AddBonusToList(int pos)
            {
                _bonusPos.Add(pos);
            }

            public void CheckIsOnBonus(int playerPos, int bonusPos)
            {
                if (playerPos == bonusPos) _isOnBonus = true;
            }

            public void MoveDriver(float distance)
            {
                _passedDistance += distance;
            }

            public DriverTrack(Driver driver, float totalDistance,  float sectionDistance)
            {
                _driver = driver;
                _totalDistance = totalDistance;
                _sectionDistance = sectionDistance;
            }
        }
    }
}