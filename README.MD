# DT191G - Moment 4 (API)
**Av:** Roberto Piran Amedi (roam2200@student.miun.se), 2024.

## Låtar

### GET Alla Låtar
Hämtar en lista över alla låtar.
GET http://localhost:5030/api/songs

### GET Enstaka Låt
Hämtar en specifik låt med angivet ID.
GET http://localhost:5030/api/songs/{id}

### POST Lägg till Låt
Lägger till en ny låt i databasen.
POST http://localhost:5030/api/songs
**Exempel på JSON för att lägga till en låt:**
```json
{
  "artist": "test",
  "title": "Test",
  "length": 145,
  "categoryId": 1
}
 ```

### DELETE Ta bort låt
Tar bort en specifik låt med angivet id. 
DELETE http://localhost:5030/api/songs/{id}

### PUT för att ändra låt
PUT http://localhost:5030/api/songs/{id}
**Exempel på JSON för att ändra en låt:**
```json
{
  "id": 6,
  "artist": "Pink Floyd",
  "title": "Comfortably Numb (Live Version)",
  "length": 500,
  "categoryId": 1
}

 ```

## Kategorier

### GET Alla Kategorier
Hämtar en lista över alla Kategorier.
GET http://localhost:5030/api/categories

### GET Enstaka Kategori
Hämtar en specifik kategori med angivet ID.
GET http://localhost:5030/api/categories/{id}

### POST Lägg till kategori
Lägger till en ny låt i databasen.
POST http://localhost:5030/api/categories
**Exempel på JSON för att lägga till en kategori:**
```json
{
  "name": "test",
}
 ```

### DELETE Ta bort låt
Tar bort en specifik kategori med angivet id. 
DELETE http://localhost:5030/api/categories/{id}

### PUT för att ändra Kategori
PUT http://localhost:5030/api/categories/{id}
**Exempel på JSON för att ändra en Kategori:**
```json
{
    "id": 4,
    "name" : "Testing"
}

 ```