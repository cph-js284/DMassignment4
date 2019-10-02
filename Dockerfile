FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as base
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:2.2
WORKDIR /app
ADD logfilFail.txt .
ADD logfilSucces.txt .
COPY --from=base /app/out .
ENTRYPOINT [ "dotnet", "DMassignment4.dll" ]