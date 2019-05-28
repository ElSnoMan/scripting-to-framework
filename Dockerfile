FROM microsoft/dotnet:2.2-sdk-alpine
# WORKDIR /tests
ADD . .
RUN dotnet build
# RUN ./scripts/unit-test.sh
CMD "dotnet test --filter testcategory=unit"

# vim:sw=2:et
