using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.WebApi.Middleware
{
    public static class DataSeedManager
    {
        public static IHost SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            if (context.Continents.Any())
            {
                return host;
            }


            var continents = new List<Continent>()
            {
                new Continent(Guid.NewGuid(), "Africa", 30370000, new(-8.783195, 34.508522))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "East Africa", 2467000, new(1.957709, 37.297203))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Uganda", 241037, new(1.373333, 32.290276),
                            new CapitalCity(Guid.NewGuid(), "Kampala", 189, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Kenya", 580367, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nairobi", 696, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Burundi", 27834, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Gitega", 22, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Tanzania", 945087, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Dodoma", 2576, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Rwanda", 26338, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kigali", 730, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Malawi", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Lilongwe", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Zimbabwe", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Harare", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Zambia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Lusaka", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Seychelles (Republic Of)", 459, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Victoria", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Madagascar", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Antananarivo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Eritria", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Asmara", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Ethiopia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Adis Ababa", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Somalia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Mogadishu", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Comoros", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Moroni", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Mozambique", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Maputo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Sudan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Khartoum", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Mauritius", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Port Louis", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "South Sudan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Juba", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Djibouti", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Djibouti", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Central Africa", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Equatorial Guinea", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Malabo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Gabon", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Libreville", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "S�o Tom� and Pr�ncipe", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "S�o Tom�", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Congo (Republic of)", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Brazzaville", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Cameroon", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Yaound�", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Chad", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "N'Djamena", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Central African Republic", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bangui", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Angola", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Luanda", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Congo (Democratic Republic of)", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kinshasa", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "West Africa", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Mauritania", 1030000, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nouakchott", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Cape Verde", 4033, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Praia", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Liberia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Monrovia", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Benin", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Poto-Novo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Ghana", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Accra", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Niger", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Niamey", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Togo", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Lom�", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Senegal", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Dakar", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Gambia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Banjul", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Mali", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bamako", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "C�te d'Ivoire (Ivory Coast)", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Yamoussoukro", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Guinea", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Conakra", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Sierra Leon", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Freetown", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Nigeria", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Abuja", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Guinea-Bissau", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bissau", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Burkina Faso", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Ouagadougou", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "North Africa", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Algeria", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Algiers", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Egypt", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Cairo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Libya", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tripoli", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Morocco", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Rabat", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Tunisia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tunis", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Western Sahara", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "El Aai�n", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Southern Africa", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "South Africa", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Pretoria", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Botswana", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Gaborone", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Namibia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Windhoek", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Lesotho", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Maseru", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Eswatini (Swaziland)", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Mbabane", 0, new(0, 0))))),
                new Continent(Guid.NewGuid(), "South America", 0, new(0, 0))
                    .AddOrUpdateRegion(new Region(Guid.Parse("76801F02-F191-4CBE-AA52-3D66C9D68D30"), "South America", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Suriname", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Paramaribo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Trinidad & Tobago", 5131, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Port of Spain", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "French Guyana", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Cayenne", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Venezuela", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Caracas", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Paraguay", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Asuncion", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bolivia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "La Paz", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Falklands Islands", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Stanley", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Uruguay", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Montevideo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Peru", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Lima", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Argentina", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Buenos Aires", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Chile", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Santiago", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Brazil", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Brasilia", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Colombia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bogota", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Ecuador", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Quito", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Guyana", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Georgetown", 0, new(0, 0))))),
                new Continent(Guid.NewGuid(), "North America", 0, new(0, 0))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "North America", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Antigua and Barbuda", 440, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "St. John's", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bahamas", 13878, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nassau", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Barbados", 439, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bridgetown", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Cuba", 109884, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Havana", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Dominica", 750, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Roseau", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Saint Vincent and the Grenadines", 389, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kingstown", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Saint Lucia", 617, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Castries", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Saint Kitts & Nevis", 261, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Basseterre", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Grenada", 348.5, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "St. George's", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Dominican Republic", 48671, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Santo Domingo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Haiti", 27750, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Port-au-Prince", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Mexico", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Mexico City", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "United States of America", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Washington, DC", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Canada", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Ottawa", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Central America", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Belize", 22966, new(0, 0),
                                new CapitalCity(Guid.NewGuid(), "Belmopan", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "El Salvador", 21041, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "San Salvador", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Honduras", 112492, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tegucigalpa", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Nicaragua", 130375, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Managua", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Panama", 75417, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Panama City", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Costa Rica", 51100, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "San Jos�", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Guatemala", 108889, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Guatemala City", 0, new(0, 0))))),
                new Continent(Guid.NewGuid(), "Oceania", 0, new(0, 0))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Australasia", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Australia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Caberra", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "New Zealand", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Wellington", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Pacific Islands", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Samoa", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Apia", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Solomon Islands", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Honiara", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Tuvalu", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Funafuti", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Federated Islands of Micronesia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Palikir", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Vanuatu", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Port Vila", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Palau", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Ngerulmud", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Nauru", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Yaren (Unofficial)", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Tonga", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nuku'alofa", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Fiji", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Suva", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Marshall Islands", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Majuro", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Kiribati", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "South Tawara", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Papua New Guinea", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Port Moresby", 0, new(0, 0))))),
                new Continent(Guid.NewGuid(), "Europe", 0, new(0, 0))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Eastern Europe", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Russia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Moscow", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Czech Republic", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Prague", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Poland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Warsaw", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Romania", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bucharest", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Slovakia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bratislava", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Ukraine", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kiev", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Hungary", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Budapest", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Belarus", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Minsk", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Georgia", 69700, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tbilisi", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bulgaria", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Sofia", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Moldova", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Chisinau", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Western Europe", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Switzerland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bern", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "France", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Paris", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Netherlands", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Amsterdam", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Germany", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Berlin", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Luxembourg", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Luxembourg", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Liechtenstein", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Vaduz", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Austria", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Vienna", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Belgium", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Brussels", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Southern Europe", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Montenegro", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Podgorica", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bosnia and Herzegovina", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Sarajevo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Serbia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Belgrade", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Albania", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tirana", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Malta", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Valletta", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Portugal", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Lisbon", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Vatican City (Holly See)", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Vatican City", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Andorra", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Andoraa la Vella", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "San Marino", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "San Marino", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Spain", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Madrid", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Slovenia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Ljubljana", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "North Macedonia (Republic Of)", 25713, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Skopje", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Greece", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Athens", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Croatia", 56594, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Zagreb", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Cyprus", 9251, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nicosia", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Italy", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Rome", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Northern Europe", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Lithuania", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Vilnius", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Norway", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Oslo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Iceland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Reykjavik", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "England", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "London", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Estonia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tallin", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Denmark", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Copenhagen", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Finland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Helsinki", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Sweden", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Stockholm", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Scotland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Edinburgh", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Northern Ireland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Belfast", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Latvia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Riga", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Republic of Ireland", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Dublin", 0, new(0, 0))))),
                new Continent(Guid.Parse("EDC63F66-3D33-4B3E-B44D-294CC49B1FCD"), "Asia", 0, new(0, 0))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "South East Asia", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Brunei", 5765, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bandar Seri Begawan", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Cambodia", 181035, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Phnom Penh", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "East Timor", 14874, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Dili", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Indonesia", 1904569, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Jakarta", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Laos", 236800, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Vientiane", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Malaysia", 329847, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kuala Lumpur", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Myanmar", 676578, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nay Pwi Taw", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Philipines", 300000, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Manila", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Thailand", 513210, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bangkok", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Vietnam", 331210, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Hanoi", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Singapore", 719.2, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Singapore City", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Southern Asia", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Afghanistan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kabul", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Maldives", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Mal�", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Pakistan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Islamabad", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "India", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "New Delhi", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Nepal", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kathmandu", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Sri Lanka", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Colombo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Iran", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tehran", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bangladesh", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Dhakar", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bhutan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Thimpu", 0, new(0, 0)))))           
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Eastern Asia", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Uzbekistan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tashkent", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Kazakhstan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Nur-Sultan", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Tajikistan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Dushambe", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Kyrgyzstan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Bishkek", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Turkmenistan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Asgabat", 0, new(0, 0)))))
                    .AddOrUpdateRegion(new Region(Guid.NewGuid(), "Western Asia", 0, new(0, 0))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Armenia", 29743, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Yerevan", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Azerbaijan", 86600, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Baku", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Bahrain", 29743, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Manama", 785.08, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Iraq", 438317, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Baghdad", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Israel", 20770, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Jerusalem", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Jordan", 89342, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Amman", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Kuwait", 17818, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Kuwait City", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Lebanon", 10452, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Beirut", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Oman", 309500, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Muscat", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Qatar", 11581, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Doha", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Saudi Arabia", 2149690, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Riyadh", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Syria", 185180, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Damascus", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Turkey", 783556, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Ankara", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "United Arab Emirates", 83600, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Abu Dhabi", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Yemen", 555000, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Sana'a", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "China", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Beijing", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Japan", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Tokyo", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "South Korea", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Seoul", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "North Korea", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Pyongyang", 0, new(0, 0))))
                        .AddOrUpdateCountry(new Country(Guid.NewGuid(), "Mongolia", 0, new(0, 0),
                            new CapitalCity(Guid.NewGuid(), "Ulaanbaatar", 0, new(0, 0)))))
            };
            context.Continents.AddRange(continents);

            try
            {
                context.SaveChanges();
            }
            catch
            {
                // ignored
            }

            return host;
        }
    }
}