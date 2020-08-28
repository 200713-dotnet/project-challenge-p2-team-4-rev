FROM mcr.microsoft.com/dotnet/core/sdk as publish
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out Perpective.Client/Perpective.Client.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /dist
COPY --from=publish /app/out /dist

CMD ["dotnet", "Perpective.Client.dll"]