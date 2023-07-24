!!!!!!!!!!!!ATTENTION!!!!!!!!!!!!!!!!!!!!!!
1. By default api starts on "https://localhost:44397/", if you have another address you need change the proxy.config.json
(change "44397" to your port)
   {
    "/api/*": {
        "target": "https://localhost:44397",
        "secure": false
    }
}
2. By default frontend starts on "http://localhost:4200/", if you have another address you need change program.cs line 45
(change "4200" to yout port)
app.UseCors(builder=> builder.WithOrigins("http://localhost:4200", "http://localhost:4200/api/").AllowAnyHeader().AllowAnyMethod());
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

1. To start api just run TestAssignment project, to check out api just add "/swagger" or "/swagger/index.hmtl" to your api url
   (by default: https://localhost:44397/swagger/index.html)
2. To start frontend part go to folder "test-assignment-frontedn" and in command line run "ng serve -o --proxy-config proxy.config.json --host 0.0.0.0"
