using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Model.Constant
{
    public static class ERROR_RESPONSE
    {
        public const string LOGIN_ERROR_RESPONSE = "Username or password incorrect";
        public const string DELETE_PARKINGLOT_ERROR_RESPONSE = "There are cars in this parkinglot";
        public const string DELETE_CAR_ERROR_RESPONSE = "There are tickets using this car";
        public const string DELETE_TRIP_BOOKING_OFFICE_ERROR_RESPONSE = "There are booking office using this trip";
        public const string DELETE_TRIP_TICKET_ERROR_RESPONSE = "There are tickets in this trip";


    }
}
