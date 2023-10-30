# Giới thiệu#

Project Lý thuyết đồ thị KHTN - ĐTTX:

1. Tìm kiếm và in thông tin về đồ thị, chẳng hạn như số cạnh, số đỉnh khuyên, số đỉnh treo và nhiều thông tin khác.

2. Tìm kiếm và in các thành phần liên thông trong đồ thị.

3. Tìm kiếm và in cây khung nhỏ nhất bằng thuật toán Prim và Kruskal.

4. Tìm kiếm và in đường đi ngắn nhất bằng thuật toán Dijkstra và Bellman-Ford.

5. Tìm kiếm và in chu trình Euler hoặc đường đi Euler (nếu có).

## Hướng dẫn sử dụng

1. **Thay đổi đồ thị đầu vào**:

   - Mở tệp `Program.cs`.
   - Sửa biến `filePath` trong hàm `Main` để chỉ định đường dẫn đến tệp đồ thị đầu vào. Định dạng tập tin input được qui định như sau:
     ▪ Dòng đầu tiên chứa số nguyên n (n > 2) thể hiện số đỉnh của đồ thị.
     ▪ n dòng tiếp theo lần lượt chứa thông tin danh sách kề của đỉnh 0 đến đỉnh n-1.
     ▪ Danh sách kề của mỗi đỉnh i được biểu diễn bằng 2\*mi + 1 số nguyên. Số nguyên đầu tiên là số lượng đỉnh có cạnh nối xuất phát từ đỉnh i (tức là mi). Các cặp số nguyên tiếp theo là chỉ mục của đỉnh kề j (chỉ mục tính từ 0) và trọng số tương ứng của liên kết i-j.
     ▪ Các số nguyên kế cận đều cách nhau bằng một khoảng trắng.

2. **Chạy ứng dụng**:

   - Biên dịch và chạy ứng dụng để thực hiện các tác vụ trên đồ thị. Kết quả sẽ được hiển thị trong cửa sổ dòng lệnh hoặc môi trường phát triển.

3. **Xem kết quả**:
   - Ứng dụng sẽ thực hiện các tác vụ trên đồ thị và in kết quả vào cửa sổ dòng lệnh.

## Lưu ý

- Đảm bảo đồ thị đầu vào được lưu trong các tệp đúng định dạng. Kiểm tra dữ liệu đầu vào để đảm bảo chúng đúng về cấu trúc và giá trị.

- Nếu muốn chỉnh sửa hoặc mở rộng ứng dụng, bạn có thể xem mã nguồn của nó trong các lớp `Bai1`, `Bai2`, `Bai3`, `Bai4`, và `Bai5`. Bạn cũng có thể tùy chỉnh hàm `Main` trong tệp `Program.cs`.

- Github: https://github.com/cangnduc/LTDT-HCMUS
