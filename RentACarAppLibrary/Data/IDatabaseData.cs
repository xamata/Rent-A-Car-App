using RentACarAppLibrary.Models;

namespace RentACarAppLibrary.Data
{
    public interface IDatabaseData
    {
        void CheckInGuest(int rentalId);
        List<CarTypeModel> GetAvailableCarTypes(DateTime startDate, DateTime endDate);
        void RentCar(string firstName, string lastName, DateTime startDate, DateTime endDate, int carTypeId);
        List<RentalFullModel> SearchRentals(string lastName);
        public CarTypeModel GetCarTypeById(int id);
    }
}