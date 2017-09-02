# Exceptions Example

Projeto com tr�s APIs:

1. Utiliza Exceptions (`Mpc.ExceptionsExample.WithExceptions.Api`)
2. N�o utilizado Exceptions (`Mpc.ExceptionsExample.NoExceptions.Api`)
3. Em DotNetCore 1.1 (`Mpc.ExceptionsExample.NoExceptions.Core11.Api`)

Cada api tem apenas o endpoint:

- POST api/values

O endpoint recebe um array de `int` e devolve a soma de todos os elementos.

Exemplo:

```
POST /api/values HTTP/1.1
Host: localhost:8103
Content-Type: application/json

[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,16,18,19,20]
```

A grande diferen�a entre as API � que no caso de a lista ser vazia.

Na API `WithExceptions` � devolvido um BadRequest atrav�s do lan�amento de um `Exception` no 
servi�o respons�vel por fazer o c�lculo.

Exemplo da API `WithExceptions`:

```c#
public IActionResult Post([FromBody] IEnumerable<int> values)
{
    try
    {
        var serviceResult = _valuesService.ProcessValues(values);
        return Ok(serviceResult);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(ex.Message);
    }
}
```

Enquanto que na API `NoExceptions` � feita a verifica��o se o array tem ou n�o elemendos.

Exemplo da API `NoExceptions`:

```c#
public IActionResult Post([FromBody] IEnumerable<int> values)
{
    var serviceResult = _valuesService.ProcessValues(values);
    if (!serviceResult.Success)
    {
        return BadRequest(serviceResult.Messages);
    }

    return Ok(serviceResult.Result);
}
```

## Resultados

### NoExceptions vs Exceptions

O objetivo � fazer pedidos �s API com a lista vazia, ou seja, a resposta tem de ser `BadRequest`.

Utilizando a ferramente [vegeta](https://github.com/tsenart/vegeta), fizemos pedidos durante 30seg com rate=100.

![img](compare-results-exceptions.png)

Atrav�s dos resultados obtidos, podemos dizer que a API que lan�a `Exceptions` demora em m�dia mais tempo a responder.


### .Net Core 2.0 vs .Net Core 1.1

O objetivo � comparar duas APIs que fazem exatamente o mesmo mas est�o em vers�es .Net Core diferentes.

O pedido consiste em enviar uma array de inteiros ([ficheiro input](vegeta/input.json)) e a resposta � a soma dessa lista.

![img](compare-results-versions-dotnetcore.png)

Atrav�s dos resultado sobtidos, podemos dizer que surpreendemente a API em .Net Core 1.1 tem 
um tempo de resposta m�dio (2.893328ms) inferior � API em .Net Core 2.0 (4.225719ms).

## Folders

- `Postman`: ficheiros para importar no Postman de forma a simular os pedidos
- `vegeta`: permitir simular v�rios request em simult�neo. Utilizar os ficheiros `.bat`.
