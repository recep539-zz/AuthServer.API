Projede ilk olarak Token bazlı kimlik doğrulama işlemi yaptık. Bu işlemi ASP.Net Core API kullanarak gerçekleştirdik. Versiyon olarak Core 7 yi kullandık.
Oluşturduğumuz AuthAPI projesinin içerisinde Token, Refresh Token, Client üretme işlemlerini yaptık. Ayrıca User ve Role atama işlemlerini yine bu API da tasarladık ve Authorize işlemi uyguladık.
2. oluşturduğumuz Survey API da Anket uygulamamızda kullanacağımız Entity lerimizi tasarladık ve gerekli işlemleri yaparak daha sonra Migrasion ile veri tabanında bu entityleri oluşturduk. API ın kontrolünü Postman yardımıyla kontrol edip projemizin backend kısmını tamamlamış oldum. Bu API da bazı controller bölümlerine Role ve Policy ile güvenlik işlemlerine tabi tuttuk.
Projemde Katmanlı Mimari kurallarına uygulayarak tasarlamaya çalıştım.
Token bazlı kimlik doğrulama sistemini daha önce uygulamadığım için dışarıdan bir kaynaktan yararlanarak yaptım.
Projenin devamında API mızı React ta kullanarak frontend tasarımını gerçekleştirmeyi hedefliyorum.
