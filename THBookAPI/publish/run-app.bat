@echo off
title TH Books - Phan Mem Quan Ly Nha Sach
echo Dang khoi dong he thong Nha Sach TH Books...

:: 1. Chạy file exe của Backend ở chế độ ngầm
start "" "THBookAPI.exe"

:: 2. Đợi 3 giây để server kịp khởi động kết nối database
timeout /t 3 >nul

:: 3. Mở giao diện web trỏ đúng cổng 5171
start msedge --app="http://localhost:5171"

exit