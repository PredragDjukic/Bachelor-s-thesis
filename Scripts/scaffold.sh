echo 'EF SCAFFOLD'
cd ../Server/Diplomski.DAL
echo 'Change directory to DAL project'
echo 'Start scaffold...'
dotnet ef dbcontext scaffold "Server=.;Database=FitConDev;MultipleActiveResultSets=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f -c ConcurrencyDbContext --startup-project=../Diplomski.Presentation --no-build --no-onconfiguring --no-pluralize
echo 'Done'
