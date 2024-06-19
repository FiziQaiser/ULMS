# University Learning Management System (LMS)

I developed a comprehensive University Learning Management System (ULMS) using Blazor, leveraging its capabilities for creating interactive web applications with C# and .NET. The ULMS is designed to support various user roles, including Students, Instructors, and Admins, each with specific functionalities.

## Key Features and Use Cases

### Students
- **View Attendance**: Students can check their attendance records.
- **Download Books**: Access and download course materials and books.
- **View Classroom**: Get information about their classrooms and schedules.
- **View Marks**: Check their marks and academic performance.
- **Submission of Quiz/Assignment/Sessional**: Submit assignments and quizzes online.
- **View Semester Calendar**: Keep track of important academic dates and events.

### Instructors
- **Upload Books**: Instructors can upload books and reading materials for students.
- **Upload Marks**: Enter and update student marks.
- **Upload Past Papers**: Provide access to past exam papers.
- **Mark Attendance**: Record student attendance.
- **Make Announcements**: Post announcements and updates for students.
- **Create Submissions**: Create and manage assignments, quizzes, and sessionals.
- **Upload Course Materials**: Upload additional course-related materials and resources.

### Admins
- **Manage User Accounts**: Administer user accounts, including adding, removing, and updating user information.
- **Manage Courses**: Create, update, and manage courses offered by the university.
- **Login**: Secure access to the admin dashboard.
- **Create Events**: Organize and manage university events and activities.

## Technologies Used
- **Blazor**: For building the interactive user interface using C# and .NET.
- **ASP.NET Core**: Backend framework for handling server-side logic.
- **Entity Framework Core**: ORM for database interactions.
- **HttpClient**: For making HTTP requests to the backend API.
- **Dependency Injection**: Ensuring modularity and easy maintenance of the codebase.

This LMS provides a robust platform for managing university operations, enhancing the educational experience for students, and streamlining administrative tasks for instructors and admins. For more details checkout Report.pdf.


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
