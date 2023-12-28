# Telefon Rehberi Uygulaması.

Proje 2 mikro servis 1 api gateway 1 clienttan oluşmaktadır.

Mikro servisler .net core ile clean architecture mimarisinde geliştirilmiştir.

Client angular ile geliştirilmiştir.

Raporlar sayfasında "Yeni Rapor Talep Et" butonuna basıldığında, istek kuyruğa atılmaktadır. Kuyruktan mesaj alındıktan sonra rapor boş olarak oluşturulup raporlar sayfasındaki kullanıcıya bildirim gönderilmektedir. Tekrar kuyruğa mesaj bırakılıp, ilgili mesaj yakalandığında raporun detayları , diğer mikro servisten http ile verileri alıp doldurulmakta ve statüsü tamamlandı olarak set edilmektedir. Akabinde gene raporlar sayfasında ki kullanıcıya bildirim gönderilmektedir.

Projenin ayağa kaldırılması için, root dizinde "docker-compose up -d" komutunun çalıştırılması yeterlidir.
