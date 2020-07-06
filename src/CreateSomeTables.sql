CREATE TABLE [dbo].[Weather] (
    ReportTime datetime NULL, 
    humidity float NULL, 
    temperature float NULL
)
WITH (CLUSTERED COLUMNSTORE INDEX, DISTRIBUTION = ROUND_ROBIN);

CREATE TABLE [dbo].[WeatherView] (
    ReportTime datetime NULL, 
    userMessage VARCHAR(8000) NULL, 
    userHandle VARCHAR(8000) NULL
)
WITH (CLUSTERED COLUMNSTORE INDEX, DISTRIBUTION = ROUND_ROBIN);

select *
from [dbo].[Weather]

select *
from [dbo].[WeatherView]