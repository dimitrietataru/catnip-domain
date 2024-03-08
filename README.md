## Clean Architecture Template - Never-ending Improvement Process

[![build](https://github.com/dimitrietataru/catnip-domain/actions/workflows/build.yml/badge.svg)](https://github.com/dimitrietataru/catnip-domain/actions/workflows/build.yml)
[![release](https://github.com/dimitrietataru/catnip-domain/actions/workflows/release.yml/badge.svg)](https://github.com/dimitrietataru/catnip-domain/actions/workflows/release.yml)
[![NuGet](https://img.shields.io/nuget/v/CatNip.Domain)](https://www.nuget.org/packages/CatNip.Domain)

# Domain Abstractions

## IModel

Introducing the **IModel** type.

``` csharp
interface IModel
{
}
```

At *Service* and *Repository* layer, the following actions can be performed:
  * Queries
    * GetAll()
    * Count()
  * Commands
    * Create(TModel)
    * Update(TModel)
    * Delete(TModel)

<details>
  <summary>IModel abstractions</summary>

### Definition
``` csharp
interface IModel
{
}

abstract class Model : IEquatable<Model>, IModel
{
    public override bool Equals(object? obj) { .. }
    public override int GetHashCode() { .. }

    public abstract bool Equals(Model? other);
    protected abstract int DetermineHashCode();
}
```

### Service
``` csharp
interface IQueryService<TModel>
    where TModel : IModel
{
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellation);
    Task<int> CountAsync(CancellationToken cancellation);
}

interface ICommandService<TModel>
    where TModel : IModel
{
    Task CreateAsync(TModel model, CancellationToken cancellation);
    Task UpdateAsync(TModel model, CancellationToken cancellation);
    Task DeleteAsync(TModel model, CancellationToken cancellation);
}

interface ICrudService<TModel> : IQueryService<TModel>, ICommandService<TModel>
    where TModel : IModel
{
}
```

### Repository
``` csharp
interface IQueryRepository<TModel>
    where TModel : IModel
{
    Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellation);
    Task<int> CountAsync(CancellationToken cancellation);
}

interface ICommandRepository<TModel>
    where TModel : IModel
{
    Task CreateAsync(TModel model, CancellationToken cancellation);
    Task UpdateAsync(TModel model, CancellationToken cancellation);
    Task DeleteAsync(TModel model, CancellationToken cancellation);
}

interface ICrudRepository<TModel> : IQueryRepository<TModel>, ICommandRepository<TModel>
    where TModel : IModel
{
}
```

</details>

## IModel\<TId\>

Introducing the **IModel\<TId\>** type

``` csharp
interface IModel<TId> : IModel
    where TId : IEquatable<TId>
{
    TId Id { get; }
}
```

At *Service* and *Repository* layer, the previous actions are extended and the following extra actions can be performed:
  * Queries
    * GetById(TId)
    * Exists(TId)
  * Commands
    * Create(TModel)
    * Update(TId, TModel)
    * Delete(TId)

<details>
  <summary>IModel< TId > abstractions</summary>

### Definition
``` csharp
interface IModel<TId> : IModel
    where TId : IEquatable<TId>
{
    TId Id { get; }
}

abstract class Model<TId> : Model, IModel<TId>
    where TId : IEquatable<TId>
{
    public virtual TId Id { get; set; }

    public override bool Equals(Model? other) { .. }
    protected override int DetermineHashCode() { .. }
}
```

### Service
``` csharp
interface IQueryService<TModel, TId> : IQueryService<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation);
}

interface ICommandService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation);
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation);
    Task DeleteAsync(TId id, CancellationToken cancellation);
}

interface ICrudService<TModel, TId> : IQueryService<TModel, TId>, ICommandService<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
}
```

### Repository
``` csharp
interface IQueryRepository<TModel, TId> : IQueryRepository<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation);
}

interface ICommandRepository<TModel, TId> : ICommandRepository<TModel>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation);
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation);
    Task DeleteAsync(TId id, CancellationToken cancellation);
}

interface ICrudRepository<TModel, TId> : IQueryRepository<TModel, TId>, ICommandRepository<TModel, TId>
    where TModel : IModel<TId>
    where TId : IEquatable<TId>
{
}
```

</details>

### Related projects
* [catnip-application](https://github.com/dimitrietataru/catnip-application)
* [catnip-infrastructure](https://github.com/dimitrietataru/catnip-infrastructure)
* [catnip-presentation](https://github.com/dimitrietataru/catnip-presentation)
* [csharp-coding-standards](https://github.com/dimitrietataru/csharp-coding-standards)

### License
CatNip.Domain is Copyright © 2023 [Dimitrie Tataru](https://github.com/dimitrietataru) and other contributors under the [MIT license](https://github.com/dimitrietataru/catnip-domain/blob/ace/LICENSE).
