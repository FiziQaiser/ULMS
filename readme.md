## Setup

install packages
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.17" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.17">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
</PackageReference>
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="7.0.11" />
```

create folder Shared/Models

run the following command in Shared
```env
dotnet ef dbcontext scaffold "Host=aws-0-us-west-1.pooler.supabase.com;Port=5432; Database=postgres; Username=postgres.cvikrfiqwuwfbnfqxvpv; Password=IOrLlIapntLwoLbD" Npgsql.EntityFrameworkCore.PostgreSQL --table account -o Models/
```

create folder Server/Data

move 'Shared/Models/PostgresContext.cs' to 'Server/Data/PostgresContext.cs'

replace 'namespace Shared' to 'namepsace Server' in Server/Data/PostgresContext.cs

import 'using Shared.Models' in Server/Data/PostgresContext.cs

add connection string in appsetting.json
```json
{
    "ConnectionStrings": {
        "connectionstring": "Host=aws-0-us-west-1.pooler.supabase.com;Port=5432; Database=postgres; Username=postgres.cvikrfiqwuwfbnfqxvpv; Password=IOrLlIapntLwoLbD"
    }
}
```

add Services in Server/Program.cs (make sure to import required libraries)
```cs
var conn = builder.Configuration.GetConnectionString("connectionstring");

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgresContext>(opt => opt.UseNpgsql(conn));
```

## Update (whenever database schema is changed)

run the following command in Shared
```env
dotnet ef dbcontext scaffold "Host=aws-0-us-west-1.pooler.supabase.com;Port=5432; Database=postgres; Username=postgres.cvikrfiqwuwfbnfqxvpv; Password=IOrLlIapntLwoLbD" Npgsql.EntityFrameworkCore.PostgreSQL --table account -o Models/
```

or

```
dotnet ef dbcontext scaffold "Host=aws-0-us-west-1.pooler.supabase.com;Port=5432; Database=postgres; Username=postgres.cvikrfiqwuwfbnfqxvpv; Password=IOrLlIapntLwoLbD" Npgsql.EntityFrameworkCore.PostgreSQL --table tablename1 --table tablename2 -o Models/ --force
```

move 'Shared/Models/PostgresContext.cs' to 'Server/Data/PostgresContext.cs'

replace 'namespace Shared' to 'namepsace Server' in Server/Data/PostgresContext.cs

import 'using Shared.Models' in Server/Data/PostgresContext.cs

create controller to make APIs