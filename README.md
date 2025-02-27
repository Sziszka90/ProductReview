
# Product Review Service

This service allows users to view, write and delete reviews for products.
Pagination is supported for both entities.
Update is not yet supported.



## Tech Stack



**Backend:** .NET8
**Tests:** Postman



## Installation

Install my-project with npm

```bash
  cd my-project
  dotnet restore
  dotnet run
```
    
## Configuration

Configuration in appsettings.json:

```json
  "TableStorageSettings": {
    "ConnectionString": "your-connection-string"
  }

```

## Usage

Supported endpoints:

**GET** - /api/products?pageNumber=5&pageSize=3


**POST** - /api/products 

**Parameters** 

| Name | Required | Description |
|------|----------|----------|
| Name | required   | Unique name   |
| Category | required  | Category of the product   |

**DELETE** - /api/products/{category}/{productName} 

**GET** - /api/products/{productName}/reviews?pageNumber=5&pageSize=3


**POST** - /api/products/{productName}/reviews 

**Parameters** 

| Name | Required | Description |
|------|----------|----------|
| ReviewContent | required   | Review content   |


**DELETE** - /api/products/{productName}/reviews/{reviewId}





## Feedback

Kedves Tresorit Team!

Szeretném egyből a hiányosságokkal kezdeni, sajnos nekem is limitált volt az időm, de ha még lett volna, akkor a következőket építettem volna bele (a sorrend nem feltétlenük tükrözi a fontosságot):

- overall hiba kezelés, akár központi middleware segítségével, akár Result objectekkel.
- Loggolás
- InitAsync nem feltétlenül lenne a TableClientFactory-ban
- Docker image készítése
- Swagger
- A felhasználó nem fogja látni posztolás előtt a legaktuálisabb review-kat
- Tesztek írása ( unit, integration )
- Még sosem használtam noSQL DB-t, ezért a partitionKey használata nem feltétlenül a legjobb megoldás.
- README.md-t nem szoktam írni, így azon még dolgoznék.

A feladat készítése során próbáltam valamilyen formán kialakítani egy clean architecture-t, természetesen a clean code szabályait betartva.

Az endpointoknál próbáltam a REST principles-t betartani, hogy egységesek legyenek.

Feltételezve, hogy nagyon sok review és product van paginationt használtam.

A reviewknál a rowKey egy idő bélyeg. Sajnos nem sikerült megoldani, hogy a legfrissebb review-kat kapjam vissza. 
Elvileg RowKey alapján rendezi sorba, de sehogy sem sikerült. Memory-ban meglehetne oldani, de akkor a pagination lenne felesleges.

Feedback:

Maga a feladat érdekes volt. Jó volt kicsit többet megtudni a noSQL DB-kről és a Cosmos DB kezeléséről.

Legnagyobb kihívás az volt, hogy nem dolgoztam még noSQL DB-vel.

Elég sok időt töltöttem vele, az említett 6 óra inkább 12 óra felé közelített.

Microsoft hivatalos dokumentációját használtam és pörgött a ChatGPT :D 

Szerintem sok jó fejlesztő nem feltétlenül töltene ilyen feladattal időt, kivéve, ha tényleg a céghez szeretne bekerülni. Szerintem egy ismerkedős interjú jó lett volna előtte, ahol akár technikai dolgokról is lehet beszélni és ha megvan az elkötelezettség akkor megcsinálni a feladatot. 






