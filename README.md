# 20220820aldilaTipOdFreqMrDiepMrKhai
Phần mềm đọc thông tin TipOd rồi truyền xuống PLC

Pass MD5:@Aldila@123

App winform chạy ngầm, đọc thông tin cài đặt từ file CSV rồi lưu thông tin cài đặt vào SQL.
Thông tin cài đặt gồm 3 phần: 
- file TipOdFreq: thông tin chính, chứa số part (itemNum). Dưới máy sẽ scan barcode số này, rồi gửi lên app, query lấy ra info của nó.
- FormularG: chứa thông tin cấu hỉnh công thức G
- FormulaPo: chứa công thức cấu hình công thức PO

Log data: theo 2 kiểu
- Production: chỉ log 5 cây
- Pilot: log toàn bộ
