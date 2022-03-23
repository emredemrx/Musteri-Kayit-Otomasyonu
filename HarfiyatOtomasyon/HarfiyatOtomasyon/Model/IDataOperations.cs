using System;
namespace HarfiyatOtomasyon.Model
{
    interface IDataOperations
    {
        void Add(int vehicleid,string customerFirstName,string customerLastName,string number, string customerAddress, int drivingTime, DateTime dateOfStart, DateTime endDate, decimal payments,string explanation,int status);
        void Delete(int deleteValue);
        void Update(int update, int vehicleID, string firstName, string lastName, string number, string address, int drivingTime, DateTime dateOfStart, DateTime endDate, decimal payments, string explanation, int v);
    }
}
