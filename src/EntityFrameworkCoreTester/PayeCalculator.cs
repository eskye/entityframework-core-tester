namespace EntityFrameworkCoreTester
{
    public static class PayeCalculator
    {
        public static decimal SimpleTax(decimal salary)
        {
            decimal psal, tax = 0;  // tsal = current salary portion to be taxed
            var onePercent = salary / 100;

            if (salary < 300000)
                return 0;

            var consolidatedRelief = (onePercent > 200000 ? onePercent : 200000) + ((20 * salary)/ 100);

            var rsal = salary - consolidatedRelief;  //remaining taxable income

            int cnt = 0;
            int ptax = 0; // current portion of tax
            while (rsal > 0)
            {
                switch (cnt)
                {
                    case 1:
                        ptax = 300000;
                        psal = rsal > ptax ? ptax : rsal;
                        tax += psal * 7 / 100; // first 300000 is taxed at 7%
                        break;
                    case 2:
                        ptax = 300000;
                        psal = rsal > ptax ? ptax : rsal;
                        tax += psal * 11 / 100; // next 300000 is taxed at 11%
                        break;
                    case 3:
                        ptax = 500000;
                        psal = rsal > ptax ? ptax : rsal;
                        tax += psal * 15 / 100; // next 500000 is taxed at 15%
                        break;
                    case 4:
                        ptax = 500000;
                        psal = rsal > ptax ? ptax : rsal;
                        tax += psal * 19 / 100; // next 500000 is taxed at 19%
                        break;
                    case 5:
                        ptax = 1600000;
                        psal = rsal > ptax ? ptax : rsal;
                        tax += psal * 21 / 100; // next 1600000 is taxed at 21%
                        break;
                }

                if (cnt >= 6)
                {
                    tax += rsal * 24 / 100; // tax remaining salary at 24%
                    break;
                }

                rsal = rsal - ptax;
                cnt++;
            }

            var minTax = onePercent;  //minimum tax is one percent of gross salary

            return tax > minTax ? tax : minTax;
        }

        public static decimal SimpleTaxMonthly(decimal monthlySalary)
        {
            var annualTax = SimpleTax(monthlySalary * 12);

            return annualTax / 12;
        }
    }
}
