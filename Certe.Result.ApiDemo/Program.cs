using Certe.Result.ErrorDefinitions;
using Certe.Result.Extensions;
using Certe.Result.ResultImplementations;
using Certe.Result.ResultSets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var successGroup = app.MapGroup("/success-response").WithTags("success-response");
successGroup.MapGet("/command", () => Result.Success());
successGroup.MapGet("/query-simple", (int number) => Result<SimpleResultSet<int>>.Success(SimpleResultSet<int>.Create(number)));
successGroup.MapGet("/query-paged", (int pageSize, int pageNumber) => {
	if (pageNumber < 1)
		return Result<PagedResultSet<string>>.Failure([Errors.InvalidArgumentError("PageNumber must be grater than 0.")]);
	
	if (pageSize < 1)
		return Result<PagedResultSet<string>>.Failure([Errors.InvalidArgumentError("PageSize must be grater than 0.")]);

	List<string> fruits = ["apple", "banana", "orange", "grape", "watermelon", "pineapple", "strawberry", "blueberry", "mango", "pear", "peach", "cherry", "kiwi", "plum", "raspberry", "blackberry", "papaya", "lemon", "lime", "coconut", "pomegranate", "apricot", "fig", "guava", "tangerine", "nectarine", "passionfruit", "cranberry", "dragonfruit", "melon"];
	IEnumerable<string> filteredFruits = fruits.Skip((pageNumber - 1) * pageSize).Take(pageSize);

	return Result<PagedResultSet<string>>.Success(PagedResultSet<string>.Create(filteredFruits, pageNumber, pageSize, fruits.Count));
});



var errorGroup = app.MapGroup("/error-response").WithTags("error-response");
errorGroup.MapGet("/command", () => Result.Failure([Errors.InternalServerError("An unexpected error")]));
errorGroup.MapGet("/query-simple", () => Result<SimpleResultSet<int>>.Failure([Errors.InternalServerError("An unexpected error")]));
errorGroup.MapGet("/query-paged", () => Result<PagedResultSet<string>>.Failure([Error.Throw("Custom.Error", "A custom error")]));


app.Run();

