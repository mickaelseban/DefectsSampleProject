namespace FizzBuzzProject
{
    public class FizzBuzz
    {
        public string GetFizzBuzz(int number)
        {
            // Bug! Fix:
            //if (number == 0)
            //{
            //    return "0";
            //}

            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (number % 3 == 0)
            {
                return "Fizz";
            }

            if (number % 5 == 0)
            {
                return "Buzz";
            }

            // Bug! Fix: return number.ToString();
            return (number + 1).ToString();
        }
    }
}