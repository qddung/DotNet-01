using Dung_baitapBuoi8.Phan1;

#region Bai 1: Tính tổng các số trong mảng

// var lst_number = new List<int>() { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };
// var totalInList = ZBaiTap.GetSumValue(lst_number);
// Console.WriteLine(totalInList);

#endregion

#region Bai 2: Tìm hai số trong tổng danh sách số nguyên sao cho tổng của chúng bằng một giá trị target cho trước
// var lst_number = new List<int>() { 2, 7, 11, 15 };
// int target = 9;
// var result = ZBaiTap.TwoSum(lst_number, target);
// if (result.Count() > 0)
// {
//     string res = string.Join(",", result);
//     Console.WriteLine($"2 Phần từ cần tìm là : {res}");
// }
// else
// {
//     Console.WriteLine("Không có giá trị nào thỏa mãn đề bài");
// }
#endregion


#region Bai 3: Loại bỏ các phần tử trùng lặp từ một mảng đã sắp xếp và trả về chiều dài của mảng mới.
// var lsNumber3 = new List<int>() { 1, 1, 2, 2, 2, 3, 4, 4, 5 };
// var listValue = ZBaiTap.RemoveDuplicates(lsNumber3);
// Console.WriteLine($"Các phần tử sau khi rút gọn là: {string.Join(", ", listValue)}");
#endregion


#region Bai 4: Cho 1 mảng số nguyên, tìm phần tử k xuất hiện nhiều nhất trong mảng và trả chúng về dưới dạng danh sách. Nếu có nhiều phần tử cùng tần số xuất hiện trả về bất kì trong số chúng.
// var lsNumber4 = new List<int>() { 1, 1, 1, 2, 2, 3, 3, 3  };
// int k = 2;
// var listMaxFrequent = ZBaiTap.GetTopFrequentElement(lsNumber4, k);
// Console.WriteLine($"Các phần tử cần tìm là: {string.Join(", ", listMaxFrequent)}");
#endregion


#region Bai 5: Cho 1 mảng prices, mỗi phần tử của nó đại diện cho giá của cổ phiếu trong một ngày. Bạn chỉ được mua cổ phiếu 1 lần và bán cổ phiếu 1 lần. Hãy tìm giá trị lớn nhất từ việc mua và bán cổ phiếu
// var lsNumber5 = new List<int>() { 7, 1, 5, 3, 6, 4 };
// var bestPrice = ZBaiTap.GetBestProfit(lsNumber5);
// Console.WriteLine($"Giá mua tốt nhất là: {bestPrice}");
#endregion