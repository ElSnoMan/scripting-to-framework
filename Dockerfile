FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine
# WORKDIR /tests
ADD . .
RUN dotnet build
# RUN ./scripts/unit-test.sh
CMD "dotnet test --filter testcategory=unit"

# vim:sw=2:et
