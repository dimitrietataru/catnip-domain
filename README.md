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
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation);
    Task UpdateAsync(TModel model, CancellationToken cancellation);
    Task DeleteAsync(TModel model, CancellationToken cancellation);
}

interface IService<TModel> : IQueryService<TModel>, ICommandService<TModel>
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
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellation);
    Task UpdateAsync(TModel model, CancellationToken cancellation);
    Task DeleteAsync(TModel model, CancellationToken cancellation);
}

interface IRepository<TModel> : IQueryRepository<TModel>, ICommandRepository<TModel>
    where TModel : IModel
{
}
```

</details>

## ICrudModel

Introducing the **ICrudModel\<TId\>** type

``` csharp
interface ICrudModel<TId> : IModel
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
    * Update(TId, TModel)
    * Delete(TId)

<details>
  <summary>ICrudModel abstractions</summary>

### Definition
``` csharp
interface ICrudModel<TId> : IModel
    where TId : IEquatable<TId>
{
    TId Id { get; }
}

abstract class CrudModel<TId> : Model, ICrudModel<TId>
    where TId : IEquatable<TId>
{
    public virtual TId Id { get; set; }

    public override bool Equals(Model? other) { .. }
    protected override int DetermineHashCode() { .. }
}
```

### Service
``` csharp
interface IQueryCrudService<TModel, TId> : IQueryService<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation);
}

interface ICommandCrudService<TModel, TId> : ICommandService<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation);
    Task DeleteAsync(TId id, CancellationToken cancellation);
}

interface ICrudService<TModel, TId> : IService<TModel>, IQueryCrudService<TModel, TId>, ICommandCrudService<TModel, TId>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
}
```

### Repository
``` csharp
interface IQueryCrudRepository<TModel, TId> : IQueryRepository<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task<TModel> GetByIdAsync(TId id, CancellationToken cancellation);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellation);
}

interface ICommandCrudRepository<TModel, TId> : ICommandRepository<TModel>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
    Task UpdateAsync(TId id, TModel model, CancellationToken cancellation);
    Task DeleteAsync(TId id, CancellationToken cancellation);
}

interface ICrudRepository<TModel, TId> : IRepository<TModel>, IQueryCrudRepository<TModel, TId>, ICommandCrudRepository<TModel, TId>
    where TModel : ICrudModel<TId>
    where TId : IEquatable<TId>
{
}
```

</details>

## IAceModel

Introducing the **IAceModel\<TId\>** type

``` csharp
interface IAceModel<TId> : IAceModel<TId, TId>
    where TId : IEquatable<TId>
{
}

interface IAceModel<TId, TTraceId> : ICrudModel<TId>, IAddTraceable<TTraceId>, IEditTraceable<TTraceId>, IRemoveTraceable<TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
{
}
```

At *Service* and *Repository* layer, the previous actions are extended and the following extra actions can be performed:
  * Queries
    * Get(request)
    * Count(filter)
    * Exists(filter)
  * Commands
    * ImportCsv(request)
    * ImportExcel(request)

<details>
  <summary>IAceModel abstractions</summary>

### Definition
``` csharp
interface IAceModel<TId, TTraceId> : ICrudModel<TId>, IAddTraceable<TTraceId>, IEditTraceable<TTraceId>, IRemoveTraceable<TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
{
}

abstract class AceModel<TId, TTraceId> : CrudModel<TId>, IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
{
    public virtual DateTimeOffset? CreatedAt { get; set; }
    public virtual TTraceId? CreatedBy { get; set; }

    public virtual DateTimeOffset? UpdatedAt { get; set; }
    public virtual TTraceId? UpdatedBy { get; set; }

    public virtual bool IsDeleted { get; set; }
    public virtual DateTimeOffset? DeletedAt { get; set; }
    public virtual TTraceId? DeletedBy { get; set; }
}
```

### Service
``` csharp
interface IQueryAceService<TModel, TId, TTraceId, TModelRoot, TFiltering> : IQueryCrudService<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
{
    Task<QueryResponse<TModelRoot>> GetAsync(QueryRequest<TFiltering> request, CancellationToken cancellation);
    Task<int> CountAsync(TFiltering filter, CancellationToken cancellation);
    Task<bool> ExistsAsync(TFiltering filter, CancellationToken cancellation);
}

interface ICommandAceService<TModel, TId, TTraceId, TExchange> : ICommandCrudService<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TExchange : ICsvMappable, IExcelMappable
{
    Task<ImportResponse> ImportCsvAsync(ImportRequest request, CancellationToken cancellation);
    Task<ImportResponse> ImportExcelAsync(ImportRequest request, CancellationToken cancellation);
}

interface IAceService<TModel, TId, TTraceId, TModelRoot, TFiltering, TExchange>
    : ICrudService<TModel, TId>, IQueryAceService<TModel, TId, TTraceId, TModelRoot, TFiltering>, ICommandAceService<TModel, TId, TTraceId, TExchange>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
{
}
```

### Repository
``` csharp
interface IQueryAceRepository<TModel, TId, TTraceId, TModelRoot, TFiltering> : IQueryCrudRepository<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
{
    Task<QueryResponse<TModelRoot>> GetAsync(QueryRequest<TFiltering> request, CancellationToken cancellation);
    Task<int> CountAsync(TFiltering filter, CancellationToken cancellation);
    Task<bool> ExistsAsync(TFiltering filter, CancellationToken cancellation);
}

interface ICommandAceRepository<TModel, TId, TTraceId, TExchange> : ICommandCrudRepository<TModel, TId>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TExchange : ICsvMappable, IExcelMappable
{
    Task<ImportResponse> ImportAsync(ICollection<TExchange> records, CancellationToken cancellation);
}

interface IAceRepository<TModel, TId, TTraceId, TModelRoot, TFiltering, TExchange>
    : ICrudRepository<TModel, TId>, IQueryAceRepository<TModel, TId, TTraceId, TModelRoot, TFiltering>, ICommandAceRepository<TModel, TId, TTraceId, TExchange>
    where TModel : IAceModel<TId, TTraceId>
    where TId : IEquatable<TId>
    where TTraceId : IEquatable<TTraceId>
    where TModelRoot : ICrudModel<TId>
    where TFiltering : IFilteringRequest
    where TExchange : ICsvMappable, IExcelMappable
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
