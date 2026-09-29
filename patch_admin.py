with open("Views/Shared/Partials/Admin/_AdminCard.cshtml", "r") as f:
    content = f.read()
content = content.replace("40.000 ₺", "40.000,00 ₺")
with open("Views/Shared/Partials/Admin/_AdminCard.cshtml", "w") as f:
    f.write(content)

with open("Views/Shared/Partials/Admin/_NewOrder.cshtml", "r") as f:
    content = f.read()
content = content.replace("2000 ₺", "2.000,00 ₺")
content = content.replace("10/20/2026", "20.10.2026")
with open("Views/Shared/Partials/Admin/_NewOrder.cshtml", "w") as f:
    f.write(content)

print("Admin dashboard static data formatted.")
