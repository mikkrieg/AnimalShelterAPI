# _Animal Shelter API backend_

#### _The backend of an API for an AnimalShelter_

#### By _**Michael Kriegel**_

##### This project is a practice project

## Technologies Used

* _C#_
* _.NET 5.0_
* _ASP.NET Core_
* _JSON_
* _JSONWebTokens_
* _Entity Framework_
* _MySQL_

## Description

_This project is the backend of an API for an animal shelter. It provides ability to Create, Read, Update and Delete animals from a shelters database. Users are able to search for specific animals with several different queries. Users are also able to make an account, with which they login. When an account is created and when a user is logged in the response that returns has their JSON web token attatched to authorize their calls. If a user tries to tamper with their token it will become invalid and they will require a new one. Currently these tokens do not expire for development purposes. For the final product an expiration will need to be implemented. The token is required to access the API, anonymous users are not able to access the API without registering and recieving a token_

## Setup/Installation Requirements

### Local Machine
* 


## How to use the API
### Queries
### Login/Registration

## Known Bugs

* _JSON web tokens do not expire_
* _No client_

## License

[MIT](https://opensource.org/licenses/MIT)

Copyright(c) 2021 Michael Kriegel

## Contact Information

Michael Kriegel: mikkrieg@gmail.com
