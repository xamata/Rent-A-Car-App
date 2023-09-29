using RentACarAppLibrary.DataAccess;
using RentACarAppLibrary.Models;

namespace RentACarAppLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "Default";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<CarTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<CarTypeModel, dynamic>("dbo.spCarTypes_GetAvailableTypes",
                                                new { startDate, endDate },
                                                connectionStringName,
                                                true);
        }

        public void RentCar(string firstName,
                             string lastName,
                             DateTime startDate,
                             DateTime endDate,
                             int carTypeId)
        {

            GuestModel guest = _db.LoadData<GuestModel, dynamic>("dbo.spGuests_Insert",
                new { firstName, lastName },
                connectionStringName,
                true).First();

            // Getting the total cost
            CarTypeModel carType = _db.LoadData<CarTypeModel, dynamic>("select * from dbo.CarTypes where Id = @Id",
                new { Id = carTypeId },
                connectionStringName,
                false).First();

            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

            List<CarModel> availibleCars = _db.LoadData<CarModel, dynamic>("dbo.spCars_GetAvailableCars",
                new { startDate, endDate, carTypeId },
                            connectionStringName,
                            true);

            _db.SaveData("dbo.spRentals_Insert",
                new
                {
                    carId = availibleCars.First().Id,
                    guestId = guest.Id,
                    startDate,
                    endDate,
                    totalCost = (timeStaying.Days * carType.Price)
                },
                connectionStringName,
                true);
        }

        public List<RentalFullModel> SearchRentals(string lastName)
        {
            return _db.LoadData<RentalFullModel, dynamic>("dbo.spRentals_Search",
                new { lastName, startDate = DateTime.Now.Date },
                connectionStringName,
                true);
        }

        public void CheckInGuest(int rentalId)
        {
            _db.SaveData("dbo.spRentals_CheckIn",
                new { Id = rentalId },
                connectionStringName,
                true);
        }
    }
}
