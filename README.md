API URL = http://localhost:5003/swagger/index.html

PgAdmin UI URL = http://localhost:8002/browser/

Step 1 - > 
username = oguz@atli.com 
password = oatli

Step 2 - >

 "DefaultConnection": "User ID=postgres;Password=1;Server=postgres;Port=5432;Database=TrendyolDB;Integrated Security=true;Pooling=true;"

Server - > Create -> Server

General Section 
Give a name in name column.

Connection Section
Host name/addres = postgres
Username = postgres
Password = 1

and Click Save button.

Step 3 - >

Find TrendyolDB in Database section. 

Execute create table script.


CREATE TABLE public."DeepLinks"
(
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "DeepLinkRequest" text COLLATE pg_catalog."default",
    "WebUrlRequest" text COLLATE pg_catalog."default",
    "WebUrlResponse" text COLLATE pg_catalog."default",
    "DeepLinkResponse" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_DeepLinks" PRIMARY KEY ("Id")
)

Check Data

SELECT * FROM "DeepLinks";

NOTE = If you are buil projects with docker-compose, you can not create data in the database.
But you are build project with IIS it's working correctly. I think the problem is the network. 
But I couldn't fix it. I don't have enough time. 
By the way, I didn't have much time to think about this project, I wrote code in a short time. 
I'm sorry for that. (Could be written better).
