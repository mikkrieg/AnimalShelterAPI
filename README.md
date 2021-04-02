# _Animal Shelter API backend_

#### _The backend of an API for an AnimalShelter_

#### By _**Michael Kriegel**_

##### This project is a practice project

## Technologies Used

* _C#_
* _.NET 5.0_
* _ASP.NET Core_
* _JSON_
* _JSON WebTokens_
* _Entity Framework_
* _MySQL_

## Description

_This project is the backend of an API for an animal shelter. It provides ability to Create, Read, Update and Delete animals from a shelters database. Users are able to search for specific animals with several different queries. Users are also able to make an account, with which they login. When an account is created and when a user is logged in the response that returns has their JSON web token attatched to authorize their calls. If a user tries to tamper with their token it will become invalid and they will require a new one. Currently these tokens do not expire for development purposes. For the final product an expiration will need to be implemented. The token is required to access the API, anonymous users are not able to access the API without registering and recieving a token_

## Setup/Installation Requirements

### Local Machine
* Clone this repository to your machine and navigate to its location
* Navigate to the AnimalShelter project directory
* Enter the command `dotnet restore` into the terminal to add required packages
* Enter the command `dotnet build` into the terminal to create `obj` and `bin` directories
* Within the AnimalShelter directory create an `appsettings.json` file
  * Inside `appsettings.json` establish a connection to your database
    * It will look similar to this: `{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=(database_name_here);uid=(user_name_here));pwd=(your_password_here);` Leave out all parenthesis, they are for example purposes only
  * Inside this file you may add a `Logging` property to enhance any warning or error messages if you so choose
    * Ex: ` "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System":"Information",
      "Microsoft": "Information"
    }`
  * Next add a `JwtConfig` property, this will require a `Secret` which will contain a 32 character string to identify JSON Web Tokens
    * It will look similar to this: `"JwtConfig": {
    "Secret": "(32_character_string_here)"}` Leave out all parenthesis, they are for example purposes only
    * [OnlineRandomTools](https://onlinerandomtools.com/generate-random-string) is a great site for generating random strings 
  * Next add an `AllowedHosts` property and provide with the `*` value
    * Ex: `"AllowedHosts": "*"`
*  After finishing the `appsettings.json`run the command `dotnet ef database update` in the terminal to update your database based on the migrations in this repository
* To start a server enter the command `dotnet run` in the terminal 
* Once the server is running, open postman or a similar program to start making API calls (Instructions on how to use API are down below)

## How to use the API
### Login/Registration
### Queries
The API accepts several different GET queries once a user is registered and logged in:
* `?name=insert_pet_name_here` : returns animal(s) with specific name
  * Example Call: `http://localhost:5000/api/animals/?name="toby"`
* `?gender=insert_gender_here` : returns animals of a specific gender
  * Example Call: `http://localhost:5000/api/animals/?gender="female"`
* `?species=insert_species_here` : returns animals of a specific species
  * Example Call: `http://localhost:5000/api/animals/?species="dog"`
* `?personality=insert_personality_here` : returns all animals with a certain personality
  * Example Call: `http://localhost:5000/api/animals/?personality="sweet"`    

Users are also able to make generic GET calls
* A call without a query will return all animals
  * Example Call: `http://localhost:5000/api/animals`
* A call with an id number will return a specific animal attatched to that id
  * Example Call: `http://localhost:5000/api/animals/1`

### Create, Update and Delete entries  
Users are able to make a POST call that can create animals 
  * To do so make sure the call you are making is a POST call
  * Next make the body of the call raw and in JSON format (Make sure your Web Token is included in the header)
    * Example body: `{
   "AnimalId": 1,
   "Name": "toby",
   "Species":"dog",
   "Age" : 5
   "Gender": "female"
   "Personality" : "timid"  
}`
 * Sed the request to create an entry in the database

Users are able to make PUT calls that can edit already existing entries
  * To do so make sure the call you are making is a PUT call
  * Make the body of the call raw and in JSON format (Make sure your Web Token is included in the header)
  * Edit the body of the entry your are targeting
  * Send the request to update an entry in the database

User are able to make DELETE calls to remove already existing entries
  * To do so make sure the call you are making is a DELETE call
  * In the URL of the call enter the id of the animal you would like to delete
    * Example Call: `http://localhost:5000/api/animals/1` will delete the animal with an Id of 1
  * Send the request to delete an entry in the database

## Known Bugs

* _JSON web tokens do not expire_
* _No UI, calls can only be made through PostMan or a similar application_

## License

[MIT](https://opensource.org/licenses/MIT)

Copyright(c) 2021 Michael Kriegel

## Contact Information

Michael Kriegel: mikkrieg@gmail.com
