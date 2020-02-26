# Henchman.DAL

Bu repository Micro ORM mantığıyla geliştirilmiş ve çoklu DB teknolojilerine hitap etmektedir. DB teknolojilerine göre Jenerik Repositoryler geliştirilip  bu repositorleri ister kendi projenizde Specification pattern kullanarak genişletebilir istersenizde  repositorylerde bulunan metodları entity bazlı kullanabilirsiniz.

## Installation

Use the package manager [Nuget](https://www.nuget.org/packages/Henchman.DAL/) to install Henchman.DAL.

```bash
Install-Package Henchman.DAL
```

## Usage

Kullanım örenği içerisinde bulunan [DataAccessLayer.Test](https://github.com/ahmetgencozlu/Henchman.DAL/tree/master/DataAccessLayer.Test) projesinde anlatılmıştır.

Entity yapısında aşağıdaki gibi attributleri kullanmalısınız. 
- [TableInfo("TableName")] bu attribute entitynin dbdeki karşılığını temsil eder.
- [PropertiesInfo("Id", true)] bu attribute entitynin dbdeki primary keyini temsil eder.
```csharp
    [TableInfo("TBLUser")]
    public class User
    {
        [PropertiesInfo("Id", true)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
```
Repositoryleri genişletmek için IBaseRepository den implement alın.
```charp
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<string> GetUserNameReverseAsync(Guid id);
    }
```
SQliteRepository<TEntity> yerine SQLRepository<TEntity> kullanılabilir. versiyon güncellendikçe yeni db teknolojileri içinde repositoryler gelecektir.
```charp
    public class UserRepository : SQliteRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task<string> GetUserNameReverseAsync(Guid id)
        {
            var result = await this.GetAsync(id);
            result.FirstName = string.Join("",result.FirstName.ToCharArray().Reverse());
            return result.FirstName;
     }
```
Genişetilmiş repository kullanımı
```csharp
_userRepository = new UserRepository(config["ConnectionString"]);
await _userRepository.GetAllAsync();
```
## Contributing
- Hızlı ORM Yapısı ([Dapper](https://dapper-tutorial.net/dapper))
- Genişletilebilir Repository yapısı ([Specification Pattern
](https://en.wikipedia.org/wiki/Specification_pattern))
- .Net Core Teknolojisi
- Kısmi yönetilebilir Entity yapısı
- Çoklu DB teknolojisi uyumluluğu
  - SQlite
  - MSSQL

