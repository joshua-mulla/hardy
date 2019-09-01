namespace Hardy.WebApi.Polly
{
    public class ResponsePredicate
    {
        public static bool IsInternalServerError(int statusCode) => 
            GetMostSignificantDigit(statusCode) == 5;

        public static bool IsBadRequest(int statusCode) =>
            GetMostSignificantDigit(statusCode) == 4;
        
        public static int GetMostSignificantDigit(int digit)
        {
            while(digit >= 10)
            {
                digit /= 10;
            }

            return digit;
        }
    }
}
