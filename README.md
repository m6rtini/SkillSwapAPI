# SkillSwapAPI

RESTful API projekts, kas ļauj lietotājiem piedāvāt un pieprasīt prasmes (skills). Projekts izveidots ar **ASP.NET Core**, **Entity Framework**, **Swagger**, un **JWT autentifikāciju**. Projekts ir sagatavots komandas projektam mācību kursā.

---

##  Tehnoloģijas

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **SQL Server**
- **JWT autentifikācija**
- **Swagger / Swashbuckle**
- **FluentValidation**
- **Docker**
- **BCrypt.Net** (paroles šifrēšanai)

---

##  Datubāzes struktūra

Projekts satur **4 tabulas**:

1. **Users** – lietotāji ar email, paroli un lomu (User/Admin)
2. **Skills** – lietotāju prasmes ar nosaukumu, aprakstu, kategoriju
3. **Categories** – prasmju kategorijas
4. **SkillRequests** – lietotāju prasību ieraksti

![ER Diagram](swagger.png)

---

##  API Endpointi

### **Autorizācija**

- `POST /api/auth/register` – reģistrē jaunu lietotāju  
- `POST /api/auth/login` – pieslēdzas un saņem JWT tokenu  

### **Skills**

- `GET /api/skills` – atgriež visu prasmju sarakstu (auth required)  
- `POST /api/skills` – izveido jaunu prasmi (auth required)  
- `PUT /api/skills/{id}` – atjauno prasmi (auth required)  
- `DELETE /api/skills/{id}` – dzēš prasmi (Admin role required)  

### **Categories**

- `GET /api/categories` – atgriež kategorijas  
- `POST /api/categories` – izveido jaunu kategoriju (Admin only)  

### **SkillRequests**

- `GET /api/skillrequests` – atgriež prasību sarakstu  
- `POST /api/skillrequests` – pievieno jaunu prasību  

---

##  JWT Autentifikācija

1. Pieslēdzies ar `/api/auth/login`
2. Saņem tokenu:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
