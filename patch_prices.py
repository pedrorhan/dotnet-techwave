import os

files_to_patch = [
    "Views/Cart/Index.cshtml",
    "Views/Order/OrderList.cshtml"
]

for filepath in files_to_patch:
    with open(filepath, "r") as f:
        content = f.read()
    
    # Cart/Index.cshtml
    content = content.replace('@item.Urun.fiyat ₺', '@item.Urun.fiyat.ToString("N2") ₺')
    content = content.replace('@Model.AraToplam() ₺', '@Model.AraToplam().ToString("N2") ₺')
    content = content.replace('@(Model.AraToplam() * 0.2) ₺', '@(Model.AraToplam() * 0.2).ToString("N2") ₺')
    content = content.replace('@(Model.Toplam()) ₺', '@Model.Toplam().ToString("N2") ₺')
    
    # Order/OrderList.cshtml
    content = content.replace('@item.Fiyat ₺', '@item.Fiyat.ToString("N2") ₺')
    content = content.replace('@(item.Fiyat * item.Miktar) ₺', '@(item.Fiyat * item.Miktar).ToString("N2") ₺')
    content = content.replace('@order.AraToplam() ₺', '@order.AraToplam().ToString("N2") ₺')
    content = content.replace('@order.Toplam() ₺', '@order.Toplam().ToString("N2") ₺')
    
    with open(filepath, "w") as f:
        f.write(content)
    print(f"Patched prices in {filepath}")
