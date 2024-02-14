

##Låtar

GET
http://localhost:5030/api/songs

GET enstaka låt
http://localhost:5030/api/songs/{id}

POST
http://localhost:5030/api/songs

Exempel på JSON vid POST för låt.
{
  "artist": "test",
  "title": "Test",
  "length": 145,
  "categoryId": 1
}



DELETE enstaka låt
http://localhost:5030/api/songs/{id}


Kategorier

GET
http://localhost:5030/api/categories

GET enstaka kategori
http://localhost:5030/api/categories/{id}

POST
http://localhost:5030/api/categories

exempel på POST för kategori:
{
    "name" : "Rock"
}

DELETE
http://localhost:5030/api/categories/{id}