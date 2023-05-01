Instalar Visual Studio 2022

Instalar migrations
dotnet tool install --global dotnet-ef

Alterar appsettings.json com os dados corretos da base de dados

Executar o comando 
dotnet ef database update

Abrir o projeto no visual studio e executar (caso o visual studio peça para instalar algum componente, permitir a instalação).



--Evolução das classes e base de dados (Não executar, apenas histórico)
dotnet ef migrations add AddProfilesAndUsers
dotnet ef migrations add AddProfilesAndUsers
dotnet ef migrations add AddColumnDateOfBithOnProfiles
dotnet ef migrations add AddTasksSubtasksStatus
dotnet ef migrations add AddDbsetTasksSubtasksStatus
dotnet ef migrations add AddStatusOnSubtask
dotnet ef migrations add AddExpirationDateOnTasksAndSubtasks
dotnet ef migrations add AddPremium
dotnet ef migrations add AddResponsableDependentsOnDbset
dotnet ef migrations add RenamePremiumToRecompense
dotnet ef migrations add AddRecompenses
dotnet ef database update
