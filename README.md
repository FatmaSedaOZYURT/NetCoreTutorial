# NetCoreTutorial


<p>Temel bilgiler için <a href="https://github.com/FatmaSedaOZYURT/NetCoreStartup">tıklayınız</a>.</p>

Bogus ile CRUD işlemlerinin yapıldığı proje için <a href="https://github.com/FatmaSedaOZYURT/NetCoreTutorial/tree/master/UserManagementAPI">tıklayın.</a>


<h1>🚀 Swagger Entegrasyonu</h1>
<h3>1. Startup.cs sınıfında eklemeler yapılmalıdır.</h3>
<p>Öncelikle ConfigureServices metoduna swagger dokümanını eklememiz gerekmekte. Bunun için; <code>services.AddSwaggerDocument();</code> kodunu ekleriz.</p>
<h3>2. Sonrasında Configure metoduna şu kod parçalarının eklenmesi gerekmekte:</h3>
<code>
            //Eskiden useswagger dı ama useOpenApi kulllanılmalı.
            //app.UseSwagger();
            app.UseOpenApi();
            app.UseSwaggerUi3(); 
</code>

<h3>3. Metod açıklamalarının swaggerda görünmesi için;</h3>
<p>Projenin properties bölümü açılır ve Buil sekmesinden XML documentation file alanı seçilir.</p>

<p>Böylece, swagger entegrasyonunu tamamlamış oluruz.<p>

<h3>4. Swagger ı özelleştirmek (versiyon, yazan kişinin iletişim bilgileri vs.) için;</h3>
<p>ConfigureServices metodundaki  <code>services.AddSwaggerDocument();</code> kod güncellenir. </p>
<code>
            services.AddSwaggerDocument(config => {

                config.PostProcess = (doc => {
                    doc.Info.Title = "All Hotels Api";
                    doc.Info.Version = "1.0.13";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Fatma Seda Özyurt",
                        Url = "https://github.com/FatmaSedaOZYURT"
                    };
                });
            });
</code>

<h1>Async X Sync</h1>
⭐ Async kod yazmak işlemin daha hızlı çalışacağını değil daha optimize çalışacağını belirtir. Yani thread'in, yaptığı işlem devam ederken bu işin bitmesini beklemez başka işlere bakar ve bu işlem bittiğinde boşta olan herhangi bir thread işlemin sonlanmasına yardımcı olabilir. Burada, kaynak kullanımını azaltmış oluyoruz. İşlemin hızlı sonuçlanmasını değil!
<h3>1. CPU Tabanlı(use sync)</h3>
<p>Complex Calculates</p>
<p>Processing data in RAM</p>
<h3>2. I/O Based (use async)</h3>
<p>HTTP Requests</p>
<p>Database Operations</p>


Kaynak: <a href='https://github.com/kenanyildirim'>Kenan Yıldırım'ın</a> derslerinden edindiğim bilgidir.
