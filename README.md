**This is my master's thesis practicle part**
### Air pollution data prediction based on meteorological data 
---

## Project structure

Dissertation.Data => App Domain Model
Dissertation.Service.IntegrationService => windows service for obtaining data from regional meteorological center
Dissertation.Service.IntegrationApp => console app - draft for integration service
Dissertation.Notification => service for estimated information publishing
Dissertation.Web => ASP.NET app for visualization part of the project

---

## Info

1. The data was collected in local MySQL db
2. Used keras/tensorflow to make prediction model based on LSTM NN
3. The python script is called from .Net Web app
4. Calculated values are stored in db
5. ...

---
//TODO:
1. Visualization estimated data on a map
2. Review project structure
3. Add python part into project
4. ...


