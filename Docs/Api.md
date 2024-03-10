# Buber Dinner API

- [Bumer Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Respons](#register-respons)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Respons](#login-respons)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Jan",
  "lastName": "Kowalski",
  "email": "jan.kowalski@gmail.com",
  "password": "Jkow1345!"
}
```
