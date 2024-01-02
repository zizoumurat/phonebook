# Telefon Rehberi Uygulaması.

Uygulamada PersonService ve ReportsService isimlerinde microservice'ler bulunmaktadır.


PersonService:
 - Clean architecture mimarisinde geliştirilmiştir.
 - Mongodb veritabanını kullanarak, kişilerin ve iletişim bilgilerinin kayıt, güncelleme ve silme işlemlerini gerçekleştiren apidir.
 - docker-compose up -d ile ayağa kaldırıldığında http://localhost:4001/swagger/index.html adresi üzerinden swagger'a erişilebilmektedir.

ReportsService:
 - Clean architecture mimarisinde geliştirilmiştir.
 - Postgresql veritabanını kullanarak, raporların ve rapor detaylarının kayıt, güncelleme ve silme işlemlerini gerçekleştiren apidir.
 - docker-compose up -d ile ayağa kaldırıldığında http://localhost:4003/swagger/index.html adresi üzerinden swagger'a erişilebilmektedir.


ApiGateWay:
- Apigateway/Ocelotapi projesi microservislere tek bir kaynaktan erişebilmek amacıyla geliştirilmiştir
- gelen istekleri ilgili mikroservice'e yönlendirmektedir.
- docker-compose up -d ile ayağa kaldırıldığında http://localhost:6001/swagger/index.html adresi üzerinden swagger'a erişilebilmektedir.

Client:
- docker-compose up -d ile ayağa kaldırıldığında http://localhost:4200 adresinden erişilebilmektedir.
- http://localhost:4200/users adresinde kişi eklenebilir, silinebilir.Ayrıca kişiler listesinden "Detaylar" butonuna basarak, kullanıcının detaylı bilgisine erişilebilinir ve iletişim bilgileri bölümünden "Yeni Ekle" butonu ile açılan modal aracılığıyla iletişim bilgisi eklenebilir. Sil butonu ile mevcut iletişim bilgisi silinebilir.
- http://localhost:4200/reports adresi ile raporlar sayfasına gidilir, kayıtlı raparlor görüntülenir. "Yeni Rapor Talep Et" butonuna basılarak yeni rapor talep edilir. 
-Raporlar listesinde,  "Detaylar" butonu aracılığı ile rapor detayları görüntülenir. Sil butonu ile ilgili rapor silinir.


Yeni Rapor Talep Et butonuna basıldığında;
- Apigateway aracılığıyla, ReportsApi'nin  /api/report end-pointine "Post" isteği atılır.
- İlgili end-point Infrasturcture katmanında bulunan ReportQueueService içerisindeki SendCreateReportRequest metodunu kullanarak RabbitMq kuyruğuna "create_report_queue" mesajını bırakmaktadır.
- Kuyruğa bırakılan  "create_report_queue" mesajı gene Infrasturcture katmanındaki CreateReportConsumer classın aracılığıyla consume edilmektedir.
-Consume işleminde, IsComplated=false ve ComplatedDate=null olan bir Report kaydı veritabanına bırakılır.
-Db'ye kayıt işleminden sonra SignalR ile "http://localhost:4200/reports" adresindeki kullanıcıya "Rapor Oluşturuldu.Veriler Hazırlanıyor" mesajı gönderilir  ve kullanıcının görüntülediği Raporlar listesi client tarafında yenilenir..
-Kuyruğa "process_report_queue" mesajı bırakılır. Mesajın içinde az önce oluşturulan ve veritabanına kayıt edilen raporun Id bilgisi eklenir.
- Kuyruğa bırakılan  "process_report_queue" mesajı gene Infrasturcture katmanındaki ProcessReportConsumer classın aracılığıyla consume edilmektedir.
-Consume işleminde, Http.Get metodu iler PersonService'e istek atılır ve o an kayıtlı kişi ve telefon sayıları location bazda alınarak, ilgili raporun detayı olarak kayıt edilir. Raporun IsComplated değeri true set edilir ve complatedDate tarihi sistem tarihi olarak set edilir.
-SignalR ile "http://localhost:4200/reports" adresindeki kullanıcıya "Rapor Tamamlandı" mesajı gönderilir ve kullanıcının görüntülediği Raporlar listesi client tarafında yenilenir.

Notlar:
- Rapor oluşturma talebindeki sürecin gözlemlenebilmesi adına Consume işlemlerinde, 2 saniyelik gecikme uygulanmıştır.
- kök dizinde "docker-compose up -d" çalıştırılması yeterlidir. Migration işlemi otomatik yapılacaktır.