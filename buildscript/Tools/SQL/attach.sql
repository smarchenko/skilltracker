EXECUTE ('CREATE DATABASE $(prefix)_$(name)
ON (FILENAME = "$(filepath)\Sitecore.$(name).MDF") 
LOG ON (FILENAME = "$(filepath)\Sitecore.$(name).LDF") FOR ATTACH;')