using SpecspicationPattern.Api.Models.Shared;

namespace SpecificationPattern.Data.Converters;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class CurrencyValueConverter() : ValueConverter<Currency, string>(currency => currency.Code,
    str => new Currency(str));