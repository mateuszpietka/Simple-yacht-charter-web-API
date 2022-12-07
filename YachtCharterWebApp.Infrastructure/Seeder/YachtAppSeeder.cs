using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using YachtCharterWebApp.Core.Entities;
using YachtCharterWebApp.Infrastructure.Context;

namespace YachtCharterWebApp.Infrastructure.Seeder
{
    public class YachtAppSeeder
    {
        private readonly YachtsAppDbContext _context;

        public YachtAppSeeder(YachtsAppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                var pendingMigrations = _context.Database.GetPendingMigrations();

                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _context.Database.Migrate();
                }

                if (!_context.Reservations.Any())
                {
                    _context.Reservations.AddRange(GetReservations());
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Reservation> GetReservations()
        {
            var yachtTypes1 = new YachtType() { TypeDescription = "Motorowy" };
            var yachtTypes2 = new YachtType() { TypeDescription = "Żaglowy" };
            var yacht1 = new Yacht
            {
                YachtType = yachtTypes1,
                Name = "Nautika Soley",
                YearProduction = 2010,
                MaxPeople = 6,
                RequiredPermission = false,
                HasEngine = true,
                EnginePower = 30,
                NumberOfCabins = 2,
                HomePort = "Mikołajki",
                Description = "Cieszący się wielką popularnością model Nautika 830 został unowocześniony przez stocznię Delphia Yachts w Olecku, dzięki czemu jacht Nautika Soley prezentuje się obecnie jeszcze lepiej. Główną zasługę tutaj ma pełna szyba w kokpicie, która daje sternikowi przejrzysty widok w każdych warunkach atmosferycznych. Model Soely wyróżnia się przede wszystkim półślizgowym kadłubem, zatem jest możliwość instalcji nawet 100 – 150 KM silnika, dzięki czemu łódź może osiągać prędkości ok 24 km/h. U nas pływają Państwo bardzo cichym silnikiem Suzuki 30 KM na wtryskach – kultura pracy należy do jednej z najlepszych wśród silników zaburtowych."
            };
            var yacht2 = new Yacht
            {
                YachtType = yachtTypes1,
                Name = "Futura 40 Grand Horizon",
                YearProduction = 2015,
                MaxPeople = 6,
                RequiredPermission = true,
                HasEngine = true,
                EnginePower = 150,
                NumberOfCabins = 3,
                HomePort = "Giżycko",
                Description = "Najwyższej klasy kunszt rzemiosła szkutniczego na wodach śródlądowych – to chyba naprawdę trafne określenie dla tego jachtu motorowego. Jacht Futura 40 powstała na bazie modelu Futura 36, który osiągnął wielki sukces popularności wśród armatorów, czarterujących łodzie motorowe."
            };
            var yacht3 = new Yacht
            {
                YachtType = yachtTypes2,
                Name = "Antila 27",
                YearProduction = 2019,
                MaxPeople = 8,
                RequiredPermission = true,
                HasEngine = true,
                EnginePower = 10,
                NumberOfCabins = 3,
                HomePort = "Mikołajki",
                Description = "Antila 27 to rekreacyjny jacht żaglowy zdolny zakwaterować ośmioosobową załogę. Już na pierwszy rzut oka widać znaczną różnicę między Antilą 27 a mniejszymi jednostkami tej stoczni. Jacht świetnie sprawdza się w Krainie Wielkich jezior Mazurskich. Dzięki zwrotności i lekkości prowadzenia manewrów Antila 27 od swojej premiery jest jedną z najczęściej wybieranych łódek tej klasy."
            };
            var yacht4 = new Yacht
            {
                YachtType = yachtTypes2,
                Name = "Maxus 33",
                YearProduction = 2013,
                MaxPeople = 10,
                RequiredPermission = true,
                HasEngine = true,
                EnginePower = 15,
                NumberOfCabins = 3,
                HomePort = "Giżycko",
                Description = "Jeden z największych i najbardziej komfortowych jachtów pływających po Mazurach przeznaczony dla max 10-osobowej załogi. Jest to nowoczesna jednostka, bogato wyposażona, z trzema dwuosobowymi zamykanymi kabinami oraz messą. Przyjemność odpoczynku zapewnia wmontowane ogrzewane/chłodzenie Webasto, a ogromny kokpit zadowoli nawet najbardziej wymagających żeglarzy."
            };

            return new List<Reservation>()
            {
                new Reservation()
                {
                    Yacht = yacht1,
                    StartDate = new DateTime(2023,7,10),
                    EndDate = new DateTime(2023,7,17),
                },
                new Reservation()
                {
                    Yacht = yacht1,
                    StartDate = new DateTime(2023,7,18),
                    EndDate = new DateTime(2023,7,22),
                },
                new Reservation()
                {
                    Yacht = yacht2,
                    StartDate = new DateTime(2023,8,1),
                    EndDate = new DateTime(2023,8,22),
                },
                new Reservation()
                {
                    Yacht = yacht2,
                    StartDate = new DateTime(2023,8,23),
                    EndDate = new DateTime(2023,9,15),
                },
                new Reservation()
                {
                    Yacht = yacht3,
                    StartDate = new DateTime(2023,6,24),
                    EndDate = new DateTime(2023,6,27),
                },
                new Reservation()
                {
                    Yacht = yacht3,
                    StartDate = new DateTime(2023,6,29),
                    EndDate = new DateTime(2023,10,17),
                },
                new Reservation()
                {
                    Yacht = yacht4,
                    StartDate = new DateTime(2023,4,4),
                    EndDate = new DateTime(2023,6,12),
                },
                new Reservation()
                {
                    Yacht = yacht4,
                    StartDate = new DateTime(2023,7,13),
                    EndDate = new DateTime(2023,7,17),
                },
            };
        }
    }
}