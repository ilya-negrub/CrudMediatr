# CrudMediatr

Стандартная реализация функций по манипуляции с данными **CRUD** с использованием шаблона **Посредник ([MediatoR](https://github.com/jbogard/MediatR))**

Регистрация: 
```csharp
services.RegisterCrudEntity<CarEntity>(cfg =>
    {
        cfg.RegisterCreateHandler<CreateCarRequest, CreateCarExpressions>();
        cfg.RegisterReadHandler<CarModel, ReadCarRequest<CarModel>, ReadCarExpressions>();
        cfg.RegisterUpdateHandler<UpdateCarRequest, UpdateCarExpressions>();
        cfg.RegisterDeleteHandler<DeleteCarRequest, DeleteCarExpressions>();
    });
```


Использование: 
```csharp
[HttpPost("Create")]
public Task Create(
    CreateCarRequest request,
    CancellationToken cancellationToken)
{
    return _mediator.Send(request, cancellationToken);
}

[HttpPost("Read")]
public Task<ReadResultModel<CarModel>> Read(
    ReadCarRequest<CarModel> request,
    CancellationToken cancellationToken)
{
    return _mediator.Send(request, cancellationToken);
}
```
