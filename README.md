# Simple API for showing the benefits of Testing

## Features
This projects offers endpoints for using various crypto functions online

### SHA256 endpoint
If you need to get the SHA256 hash of some random test you can just use this endpoint.

Post something like 
```json
{
	"clearText": "Hello World"
}
```

to `https://localhost:5001/crypto/sha256`

and you will receive a response like:

```json
{
  "hash": "a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e"
}
```

#### Weather endpoint

Get `https://localhost:5001/weather/madrid`
(note only `madrid` is supported by now)

And you will get something like:

```json
{
  "description": "Fresh",
  "celsius": 8,
  "farenheit": 32
}
```