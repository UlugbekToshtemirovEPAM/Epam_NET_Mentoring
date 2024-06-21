namespace Modul8.Task.StringSum
{
    public class StringSum
    {
        public string Sum(string num1, string num2)
        {
            num1 = string.IsNullOrEmpty(num1) || !IsNaturalNumber(num1)
                ? "0"
                : num1;

            num2 = string.IsNullOrEmpty(num2) || !IsNaturalNumber(num2)
                ? "0"
                : num2;

            var result = int.Parse(num1) + int.Parse(num2);

            return result.ToString();
        }

        private static bool IsNaturalNumber(string num)
        {
            foreach (var ch in num)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
