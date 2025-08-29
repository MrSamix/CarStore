select c.Id, b.Name as Brand, c.Model, co.Name as Color, ct.Name as Type, coun.Name as Country, r.Name as Region, f.Name as FuelType, c.Description, c.Price
from Cars as c  join Brands as b on c.BrandId = b.Id
				join Colors as co on c.ColorId = co.Id
				join CarTypes as ct on c.CarTypeId = ct.Id
				join Countries as coun on c.CountryId = coun.Id
				join Regions as r on c.RegionId = r.Id
				join FuelTypes as f on c.FuelTypeId = f.Id 