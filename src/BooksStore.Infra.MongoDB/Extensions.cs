using BooksStore.SharedKernel;
using BooksStore.SharedKernel.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;


namespace BooksStore.Infra.MongoDB;

public static class Extensions
{
  public static IServiceCollection AddMongo(this IServiceCollection services, string mongoConnectionString, string serviceName)
  {
    BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
    BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

    services.AddSingleton(serviceProvider =>
    {
      var mongoClient = new MongoClient(mongoConnectionString);
      return mongoClient.GetDatabase(serviceName);
    });

    return services;
  }

  public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : BaseEntity, IAggregateRoot
  {
    services.AddSingleton<IRepository<T>>(serviceProvider =>
    {
      var database = serviceProvider.GetService<IMongoDatabase>();
      return new MongoRepository<T>(database, collectionName);
    });

    return services;
  }
}
