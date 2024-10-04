namespace Dung_baitapBuoi8.Phan1
{
    public class ZBaiTap
    {
        public static int GetSumValue(List<int> lsNumber)
        {
            int sum = 0;
            foreach (var item in lsNumber) sum += item;
            return sum;
        }
        public static List<int> TwoSum(List<int> lsNumber, int target)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < lsNumber.Count() - 1; i++)
            {
                for (int j = i + 1; j < lsNumber.Count(); j++)
                {
                    if (lsNumber[i] + lsNumber[j] == target)
                    {
                        result.Add(i);
                        result.Add(j);
                        return result;
                    }
                }
            }
            return result;
        }

        public static List<int> RemoveDuplicates(List<int> lsNumber)
        {
            List<int> res = new List<int>();
            foreach (var num in lsNumber)
            {
                if (FindItem(res, num) == false)
                {
                    res.Add(num);
                }
            }
            return res;
        }

        public static bool FindItem(List<int> lsNumber, int target)
        {
            bool res = false;
            foreach (var num in lsNumber)
            {
                if (num == target)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public static List<int> GetTopFrequentElement(List<int> lsNumber, int k)
        {
            Dictionary<int, int> elementWithFrequent = new Dictionary<int, int>();

            foreach (var num in lsNumber)
            {
                if (elementWithFrequent.ContainsKey(num))
                {
                    elementWithFrequent[num] += 1;
                }
                else
                {
                    elementWithFrequent.Add(num, 1);
                }
            }

            List<int> res = elementWithFrequent.Select(i => new KeyValuePair<int, int>(i.Key, i.Value))
            .OrderByDescending(i => i.Value).Take(k).Select(i => i.Key).ToList();
            return res;
        }

        public static int GetBestProfit(List<int> lsPrice)
        {
            int bestPrice = 0;
            for (int i = 0; i < lsPrice.Count() - 1; i++)
            {
                for (int j = i + 1; j < lsPrice.Count(); j++)
                {
                    bestPrice = Math.Max(bestPrice, lsPrice[j] - lsPrice[i]);
                }
            }
            return bestPrice;
        }



    }

}

