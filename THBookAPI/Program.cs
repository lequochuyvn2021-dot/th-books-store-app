var builder = WebApplication.CreateBuilder(args);

// Ép buộc ứng dụng luôn chạy cố định ở cổng 5171 khi đóng gói phần mềm
builder.WebHost.UseUrls("http://localhost:5171");

// ... các dòng code đăng ký dịch vụ (DbContext, Controllers) giữ nguyên ...

var app = builder.Build();

// Bật tính năng phục vụ file tĩnh (HTML, CSS, JS, Images từ thư mục wwwroot)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();